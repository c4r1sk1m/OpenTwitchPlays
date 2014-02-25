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
using System.Diagnostics;
using System.Windows.Forms;

namespace OpenTwitchPlays
{
    public partial class PickWindow : Form
    {
        /// <summary>
        /// Gets the handle to the selected window. Will be stored when the form is closed.
        /// </summary>
        public IntPtr PickedWindow { get { return wnd; } }

        protected IntPtr wnd = IntPtr.Zero;

        public PickWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Makes the last column of the listview stretch as the window stretches.
        /// </summary>
        protected void RefreshColumnsSize()
        {
            int newwidth = listWindows.Width;

            for (int i = 0; i < listWindows.Columns.Count - 1; i++)
                newwidth -= listWindows.Columns[i].Width;

            newwidth -= 22;

            if (newwidth < 100) // min width = 100px
                newwidth = 100;

            listWindows.Columns[listWindows.Columns.Count - 1].Width = newwidth;
        }

        /// <summary>
        /// Adds a window to the listview from its parent process. 
        /// Does nothing if the process has no main window.
        /// </summary>
        /// <param name="theprocess">The parent process of the desired window.</param>
        protected void AddProcess(Process theprocess)
        {
            if (theprocess.MainWindowHandle == IntPtr.Zero)
                return;

            // TODO: use enumwindow, as some games might have a hidden non-main window

            var item = listWindows.Items.Add(theprocess.Id.ToString("X8"));
            item.SubItems.Add(theprocess.MainWindowHandle.ToInt32().ToString("X8"));
            item.SubItems.Add(theprocess.MainWindowTitle);
            item.Tag = theprocess.MainWindowHandle;
        }

        /// <summary>
        /// Refreshes the window list.
        /// </summary>
        protected void RefreshList()
        {
            listWindows.Items.Clear();

            Process[] p = Process.GetProcesses();

            for (int i = 0; i < p.Length; i++)
                AddProcess(p[i]);
        }

        private void PickWindow_Resize(object sender, EventArgs e)
        {
            RefreshColumnsSize();
        }

        private void PickWindow_Load(object sender, EventArgs e)
        {
            RefreshColumnsSize();
            RefreshList();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            wnd = IntPtr.Zero;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listWindows.SelectedItems.Count <= 0)
            {
                MessageBox.Show("No game window selected! Please select a window.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            wnd = (IntPtr)listWindows.SelectedItems[0].Tag;
            Close();
        }
    }
}
