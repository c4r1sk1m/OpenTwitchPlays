/*
	Copyright 2014 Francesco "Franc[e]sco" Noferi (francesco149@gmail.com)

	This file is part of OpenTwitchPlays.

	OpenTwitchPlays is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	OpenTwitchPlays is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with OpenTwitchPlays.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace OpenTwitchPlays
{
    // TODO: separate this file into a more modular design? 700+ lines are a bit too much imho

    /// <summary>
    /// Main window.
    /// TODO: add some logging
    /// </summary>
    public partial class Form1 : Form
    {
        // TODO: properly wrap serialization inside these data structures instead of 
        // having the serialization code in Form1

        /// <summary>
        /// Stores the current uptime and keypress count status. Serializable.
        /// </summary>
        [Serializable]
        protected class Status
        {
            // keypress count indexed by GameKey name
            public Dictionary<string, ulong> keypresses = new Dictionary<string, ulong>(); 
            public ulong totalkeypresses = 0; // total keypress count
            public TimeSpan elapsed = TimeSpan.Zero; // total uptime
        }

        /// <summary>
        /// Temporary data structure used to serialize the program's settings.
        /// TODO: make this a proper immutable struct (lol too lazy)
        /// </summary>
        [Serializable]
        protected class Settings
        {
            /// <summary>
            /// Temporary data structure used to serialize the program's key bindings.
            /// TODO: make this a proper immutable struct (lol too lazy)
            /// </summary>
            [Serializable]
            public class KeyBinding
            {
                public string command; // command text
                public int delay; // delay in millisecs
                public ushort vkey; // virtual key code (will be used to retrieve the actual GameKey)
            }

            public List<KeyBinding> binds = new List<KeyBinding>(); // list of all the keybindings
            public bool usepostmessage = false; // true if the application should use PostMessage for keystrokes
            public bool autosave = true; // true if autosave is enabled
            public int autosaveinterval = 60; // autosave interval in seconds
            public string autosavekey = "+{F2}"; // autosave hotkey as a SendKeys string.
            // Note: multiple autosave keys are not allowed in PostMessage mode.
        }

        Status st = new Status(); // current status (serializable)
        string chatfile = ""; // path of the source chat log
        GameWindow gamewindow = null; // handle to the game window
        ulong commandsdone = 0; // commands executed since the last update of the commands / s counter
        DateTime lastcommandrefresh = DateTime.Now; // last time the commands / s counter was updated
        DateTime lastautosave = DateTime.Now; // time at which the last autosave was performed
        DateTime lastuptimerefresh = DateTime.Now; // last time the timer was updated
        int autosaveinterval = 60; // in seconds

        FileStream fs = null; // filestream to the chat log
        StreamReader sr = null; // reader for the chat log file stream
        bool firsttime = true; // true if we're accessing the chat log for the first time (skips old logs)
        bool wasendofstream = false; // used to check when the EOS state changes

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Stops the bot, saves the current status and quits the program.
        /// </summary>
        protected void SaveAndQuit()
        {
            if (timerProcessMessages.Enabled)
                Stop();

            SaveStatus();
            Close();
        }

        /// <summary>
        /// Applies the autosave settings.
        /// </summary>
        /// <returns>false if the settings are invalid, otherwise true.</returns>
        protected bool ApplySettings()
        {
            // TODO: throw an exception that describes the error once more settings are added

            try
            {
                autosaveinterval = Convert.ToInt32(textAutosaveInterval.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Serializes the current settings to settings.bin
        /// </summary>
        protected void SaveSettings()
        {
            ApplySettings();

            Settings cfg = new Settings();
            cfg.autosave = menuAutosave.Checked;
            cfg.autosaveinterval = autosaveinterval;
            cfg.autosavekey = textSaveCombo.Text;
            cfg.usepostmessage = menuUsePostMessage.Checked;

            // key bindings
            for (int i = 0; i < listKeyBindings.Items.Count; i++)
            {
                var theitem = listKeyBindings.Items[i];
                Settings.KeyBinding bind = new Settings.KeyBinding();
                bind.command = theitem.Text;
                bind.vkey = ((GameKey)theitem.Tag).VirtualKey;
                bind.delay = Convert.ToInt32(theitem.SubItems[2].Text);
                cfg.binds.Add(bind);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("settings.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, cfg);
            stream.Close();

            statusBar1.Text = "Successfully saved settings.";
        }

        /// <summary>
        /// Restores the serialized settings from settings.bin
        /// </summary>
        protected void RestoreSettings()
        {
            Settings cfg = null;

            if (!File.Exists("settings.bin"))
                return;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("settings.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            cfg = (Settings)formatter.Deserialize(stream);
            stream.Close();

            menuAutosave.Checked = cfg.autosave;
            autosaveinterval = cfg.autosaveinterval; // internal autosave interval
            textAutosaveInterval.Text = autosaveinterval.ToString(); // GUI autosave interval
            textSaveCombo.Text = cfg.autosavekey;
            menuUsePostMessage.Checked = cfg.usepostmessage;

            // key bindings
            foreach (Settings.KeyBinding bind in cfg.binds)
                AddKeyBinding(bind.command, GameKey.ByVKey(bind.vkey), bind.delay);
        }

        /// <summary>
        /// Saves the current uptime and keycount status as status.bin
        /// </summary>
        protected void SaveStatus()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("status.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, st);
            stream.Close();
        }

        /// <summary>
        /// Restores the current uptime and keycount status from status.bin
        /// </summary>
        protected void RestoreStatus()
        {
            if (!File.Exists("status.bin"))
                return;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("status.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            st = (Status)formatter.Deserialize(stream);
            stream.Close();

            labelKeyPresses.Text = "Keypresses: " + st.totalkeypresses;
            UpdateUptime();
        }

        /// <summary>
        /// Starts the IRC bot.
        /// </summary>
        protected void Start()
        {
            if (timerProcessMessages.Enabled)
                return;

            if (gamewindow == null)
            {
                MessageBox.Show("No game window detected! Please make sure your game is detected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(chatfile))
            {
                MessageBox.Show("You first need to open a source chat log.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ApplySettings())
            {
                // TODO: add different error messages as exceptions when more settings are added
                MessageBox.Show("Invalid autosave delay.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fs = new FileStream(chatfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            sr = new StreamReader(fs);

            // if we're not sending minimized keystrokes, put the window on top
            if (!menuUsePostMessage.Checked)
                gamewindow.SetForeground();

            Thread.Sleep(500);

            PerformAutoSave(); // initialize autosave by autosaving
            lastuptimerefresh = DateTime.Now; // initialize last time the uptime was refreshed
            timerUptime.Enabled = true; // start the uptime refresher

            firsttime = true; // we're accessing the chat log for the first time
            menuStart.Enabled = false; // cannot start twice
            timerProcessMessages.Enabled = true; // start the irc bot timer
            menuStop.Enabled = true; // we can now stop the bot if we want
        }

        /// <summary>
        /// Stops the IRC bot.
        /// </summary>
        protected void Stop()
        {
            if (!timerProcessMessages.Enabled)
                return;

            menuStop.Enabled = false; // can't stop twice
            timerProcessMessages.Enabled = false; // stop the irc bot timer
            timerUptime.Enabled = false; // stop the uptime ticker
            statusBar1.Text = "Bot stopped.";
            menuStart.Enabled = true; // we can now start the bot if we want

            // close and dispose the file stream and the streamreader
            fs.Close();
            sr.Close();
            fs.Dispose();
            sr.Dispose();
            fs = null;
            sr = null;
        }

        /// <summary>
        /// Reset the uptime and keystroke status and write it to file.
        /// </summary>
        protected void Reset()
        {
            bool restart = timerProcessMessages.Enabled;

            if (restart)
                Stop();

            st.totalkeypresses = 0;
            st.keypresses = new Dictionary<string, ulong>();
            ResetKeys();
            st.elapsed = TimeSpan.Zero;
            SaveStatus();
            RestoreStatus();

            if (restart)
                Start();
        }

        /// <summary>
        /// Handles a chat line and executes any valid command found.
        /// </summary>
        /// <param name="line">A raw chat line in formatted as username\tmessage</param>
        protected void HandleChatLine(string line)
        {
            string msgbody = ""; // will contain the message body
            string user = ""; // will contain the username
            GameKey key = GameKey.Invalid; // will contain the requested keystroke if the message is a command
            int times = 1; // will contain how many times the key will be pressed if the msg is a command
            int delay = 0; // will contain the duration of the keystroke if the msg is a command

            string[] splitted = line.Split('\t'); // split username from the message body

            try
            {
                user = splitted[0];
                msgbody = splitted[1];
            }
            catch (Exception)
            {
                // invalid format
                return;
            }

            try
            {
                // throttled commands (start9 & similar)
                string re1 = "([a-z]{1,9})"; // command (1 to 9 letters)
                string re2 = "(\\d)"; // any single digit

                // we're separating the command from the number by using a simple regex
                Regex r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Match m = r.Match(msgbody);

                if (m.Success)
                {
                    msgbody = m.Groups[1].ToString();
                    String d1 = m.Groups[2].ToString();
                    times = Convert.ToInt32(d1);

                    if (times < 1) // ignore command0's
                        return;

                    if (times > 9) // will never happen
                        times = 1;
                }
                else // invalid format
                    times = 1;
            }
            catch (Exception)
            {
                // invalid format
                times = 1;
            }

            // check if the command actually exists by searching it sequentially in the listview
            // TODO: index commands in a dictionary for better performance? 
            //       (not really necessary for something this trivial)
            for (int i = 0; i < listKeyBindings.Items.Count; i++)
            {
                var item = listKeyBindings.Items[i];

                if (msgbody == item.Text)
                {
                    // command found! retrieve key and duration
                    key = (GameKey)item.Tag;
                    delay = Convert.ToInt32(item.SubItems[2].Text);
                    break;
                }
            }

            if (key == GameKey.Invalid) // command not found
                return;

            if (delay <= 0) // invalid delay, should never happen
                return;

            // should never happen if ResetKeys is properly called when it should
            if (!st.keypresses.ContainsKey(msgbody))
                st.keypresses.Add(msgbody, 0);

            // repeat the keystroke as many times as needed
            for (int i = 0; i < times; i++)
            {
                st.keypresses[msgbody]++;
                st.totalkeypresses++;

                if (menuUsePostMessage.Checked)
                    gamewindow.SendMinimizedKeystroke(key, delay);
                else
                    GameWindow.SendGlobalKeystroke(key, delay);
            }

            commandsdone++; // this is for the command/s counter

            // log the command
            listBoxCommands.Items.Add(user + " " + msgbody + (times > 1 ? times.ToString() : ""));

            // keep the command log under 100 lines to save RAM
            if (listBoxCommands.Items.Count > 100)
                listBoxCommands.Items.RemoveAt(0);

            // autscroll the command log to the bottom
            listBoxCommands.TopIndex = listBoxCommands.Items.Count - 1;

            // refresh keypresses counter in the GUI
            labelKeyPresses.Text = "Keypresses: " + st.totalkeypresses;
        }

        /// <summary>
        /// Refreshes the uptime label in the GUI
        /// </summary>
        protected void UpdateUptime()
        {
            labelUptime.Text = "Uptime: " + st.elapsed.ToString(@"dd\d\ hh\h\ mm\m\ ss\s");
        }

        /// <summary>
        /// Writes stats, uptime and command log to stats.txt, uptime.txt and commands.txt
        /// </summary>
        protected void OutputStatsToFile()
        {
            using (FileStream fs = new FileStream("stats.txt", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Keypresses (total " + st.totalkeypresses + "):");

                    foreach (var entry in st.keypresses)
                        sw.WriteLine(entry.Key + ": " + entry.Value);

                    sw.Close();
                }
            }

            using (FileStream fs = new FileStream("uptime.txt", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(st.elapsed.ToString(@"dd\d\ hh\h\ mm\m\ ss\s"));
                    sw.Close();
                }
            }

            using (FileStream fs = new FileStream("commands.txt", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    if (listBoxCommands.Items.Count > 0)
                    {
                        int stopindex = listBoxCommands.Items.Count - 1 - 14;

                        if (stopindex < 0)
                            stopindex = 0;

                        for (int i = stopindex; i < listBoxCommands.Items.Count; i++)
                            sw.WriteLine(listBoxCommands.Items[i]);
                    }

                    sw.Close();
                }
            }
        }

        /// <summary>
        /// Checks if it's time to autosave and autosaves.
        /// </summary>
        protected void CheckAutosave()
        {
            if (menuAutosave.Checked && DateTime.Now - lastautosave > TimeSpan.FromSeconds(autosaveinterval))
                PerformAutoSave();
        }

        /// <summary>
        /// Sends the autosave keystroke.
        /// </summary>
        protected void PerformAutoSave()
        {
            try
            {
                if (menuUsePostMessage.Checked)
                {
                    if (!gamewindow.SendMinimizedKeystroke(GameKey.ByKeyString(textSaveCombo.Text), 10))
                        throw new Exception();
                }
                else
                    SendKeys.Send(textSaveCombo.Text);

                Thread.Sleep(200);
                statusBar1.Text = "Successfully autosaved.";
            }
            catch (Exception)
            {
                statusBar1.Text = "Something's wrong with the autosave hotkey.";
            }

            lastautosave = DateTime.Now;
        }

        /// <summary>
        /// Initializes the keypresses dictionary with all the current keys.
        /// </summary>
        protected void ResetKeys()
        {
            for (int i = 0; i < listKeyBindings.Items.Count; i++)
            {
                string k = listKeyBindings.Items[i].Text;

                if (!st.keypresses.ContainsKey(k))
                    st.keypresses.Add(k, 0);
            }
        }

        /// <summary>
        /// Adds a key binding to the GUI's listview.
        /// </summary>
        /// <param name="command">Command text</param>
        /// <param name="thekey">Desired key</param>
        /// <param name="delay">How long the key will be held down</param>
        protected void AddKeyBinding(string command, GameKey thekey, int delay)
        {
            var item = listKeyBindings.Items.Add(command);
            item.SubItems.Add(thekey.Name);
            item.SubItems.Add(delay.ToString());
            item.Tag = thekey;
        }

        private void menuOpenSource_Click(object sender, EventArgs e)
        {
            // displays a file open dialog and allows the user to pick a chat logfile.
            // NOTE: the logfile must be in the format username\tmessage
            var res = openFileDialog1.ShowDialog();

            if (res != DialogResult.OK)
                return;

            chatfile = openFileDialog1.FileName;
            labelSourceFile.Text = "Source chat file: " + chatfile;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            SaveAndQuit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RestoreSettings();
            ResetKeys();
            menuStop.Enabled = false;
            RestoreStatus();

            foreach (GameKey key in GameKey.List) // keys combobox
                comboKeyBindings.Items.Add(key);

            comboKeyBindings.SelectedItem = GameKey.ByName("left"); // left is selected by default
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coded by Francesco \"Franc[e]sco\" Noferi [francesco149@gmail.com]", "About", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            Stop();
            SaveStatus();
        }

        private void menuReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAndQuit();
        }

        private void menuAutosave_Click(object sender, EventArgs e)
        {
            menuAutosave.Checked ^= true;
        }

        private void timerProcessMessages_Tick(object sender, EventArgs e)
        {
            CheckAutosave();

            // read a new line
            if (!sr.EndOfStream)
            {
                if (wasendofstream)
                {
                    statusBar1.Text = "Processing new messages...";
                    wasendofstream = sr.EndOfStream;
                }

                string theline;

                if (firsttime)
                {
                    while (!sr.EndOfStream) // skip old logs
                        theline = sr.ReadLine();
                }
                else
                {
                    theline = sr.ReadLine();
                    HandleChatLine(theline);
                    OutputStatsToFile();
                }
            }

            // wait for new lines
            else if (sr.EndOfStream)
            {
                if (!wasendofstream)
                {
                    statusBar1.Text = "Waiting for new messages...";
                    wasendofstream = sr.EndOfStream;
                }

                OutputStatsToFile();

                firsttime = false;
            }

            // refresh the command/s counter
            if (DateTime.Now - lastcommandrefresh >= TimeSpan.FromSeconds(1.0))
            {
                labelCommandsPerSec.Text = "Commands/s: " + commandsdone;
                commandsdone = 0;
                lastcommandrefresh = DateTime.Now;
                SaveStatus();
            }
        }

        private void timerUptime_Tick(object sender, EventArgs e)
        {
            // refreshes the uptime accurately on every tick

            DateTime now = DateTime.Now;
            st.elapsed += now - lastuptimerefresh;
            lastuptimerefresh = now;
            UpdateUptime();
        }

        private void menuAttach_Click(object sender, EventArgs e)
        {
            // displays the PickWindow form as a modal window and retrieves the picked window

            PickWindow pw = new PickWindow();
            pw.ShowDialog(this);

            if (pw.PickedWindow != IntPtr.Zero)
                gamewindow = new GameWindow(pw.PickedWindow);
            else
                gamewindow = null;

            labelGameWindow.Text = "Game window: " + (gamewindow != null ? gamewindow.ToString("X8") : "0");
        }

        private void menuUsePostMessage_Click(object sender, EventArgs e)
        {
            menuUsePostMessage.Checked ^= true;
        }

        private void buttonClearKeyBindings_Click(object sender, EventArgs e)
        {
            listKeyBindings.Items.Clear();
        }

        private void buttonAddKeyBinding_Click(object sender, EventArgs e)
        {
            try
            {
                int delay = 0;
                GameKey thekey = (GameKey)comboKeyBindings.SelectedItem;

                if (thekey == null || thekey == GameKey.Invalid)
                    throw new InvalidOperationException("invalid key");

                try
                {
                    delay = Convert.ToInt32(textDelay.Text);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("invalid delay value");
                }

                if (delay <= 0)
                    throw new InvalidOperationException("cannot use a negative delay");

                if (String.IsNullOrEmpty(textCommand.Text))
                    throw new InvalidOperationException("the command must be at least one character long");

                AddKeyBinding(textCommand.Text, thekey, delay);
            }
            catch (InvalidOperationException shit)
            {
                MessageBox.Show("Could not add key binding: " + shit.Message, "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRemoveKeyBinding_Click(object sender, EventArgs e)
        {
            if (listKeyBindings.SelectedItems.Count <= 0) // no keybinds selected
                return;

            while (listKeyBindings.SelectedItems.Count > 0) // remove all selected keybindings
                listKeyBindings.Items.Remove(listKeyBindings.SelectedItems[0]);
        }

        private void menuSaveConfig_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
