namespace OpenTwitchPlays
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelGameWindow = new System.Windows.Forms.Label();
            this.labelSourceFile = new System.Windows.Forms.Label();
            this.labelKeyPresses = new System.Windows.Forms.Label();
            this.labelCommandsPerSec = new System.Windows.Forms.Label();
            this.labelUptime = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuOpenSource = new System.Windows.Forms.MenuItem();
            this.menuAttach = new System.Windows.Forms.MenuItem();
            this.menuSaveConfig = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuStart = new System.Windows.Forms.MenuItem();
            this.menuStop = new System.Windows.Forms.MenuItem();
            this.menuReset = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuAutosave = new System.Windows.Forms.MenuItem();
            this.menuUsePostMessage = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerProcessMessages = new System.Windows.Forms.Timer(this.components);
            this.timerUptime = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textSaveCombo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textAutosaveInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonClearKeyBindings = new System.Windows.Forms.Button();
            this.buttonRemoveKeyBinding = new System.Windows.Forms.Button();
            this.comboKeyBindings = new System.Windows.Forms.ComboBox();
            this.textCommand = new System.Windows.Forms.TextBox();
            this.buttonAddKeyBinding = new System.Windows.Forms.Button();
            this.listKeyBindings = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCommands.FormattingEnabled = true;
            this.listBoxCommands.Location = new System.Drawing.Point(10, 20);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(500, 77);
            this.listBoxCommands.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listBoxCommands);
            this.groupBox1.Location = new System.Drawing.Point(12, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 10);
            this.groupBox1.Size = new System.Drawing.Size(520, 107);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command log";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelGameWindow);
            this.groupBox2.Controls.Add(this.labelSourceFile);
            this.groupBox2.Controls.Add(this.labelKeyPresses);
            this.groupBox2.Controls.Add(this.labelCommandsPerSec);
            this.groupBox2.Controls.Add(this.labelUptime);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(520, 139);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stats:";
            // 
            // labelGameWindow
            // 
            this.labelGameWindow.AutoSize = true;
            this.labelGameWindow.Location = new System.Drawing.Point(12, 74);
            this.labelGameWindow.Name = "labelGameWindow";
            this.labelGameWindow.Size = new System.Drawing.Size(86, 13);
            this.labelGameWindow.TabIndex = 6;
            this.labelGameWindow.Text = "Game window: 0";
            // 
            // labelSourceFile
            // 
            this.labelSourceFile.AutoSize = true;
            this.labelSourceFile.Location = new System.Drawing.Point(12, 113);
            this.labelSourceFile.Name = "labelSourceFile";
            this.labelSourceFile.Size = new System.Drawing.Size(87, 13);
            this.labelSourceFile.TabIndex = 5;
            this.labelSourceFile.Text = "Source chat file: ";
            // 
            // labelKeyPresses
            // 
            this.labelKeyPresses.AutoSize = true;
            this.labelKeyPresses.Location = new System.Drawing.Point(12, 100);
            this.labelKeyPresses.Name = "labelKeyPresses";
            this.labelKeyPresses.Size = new System.Drawing.Size(73, 13);
            this.labelKeyPresses.TabIndex = 4;
            this.labelKeyPresses.Text = "Keypresses: 0";
            // 
            // labelCommandsPerSec
            // 
            this.labelCommandsPerSec.AutoSize = true;
            this.labelCommandsPerSec.Location = new System.Drawing.Point(12, 87);
            this.labelCommandsPerSec.Name = "labelCommandsPerSec";
            this.labelCommandsPerSec.Size = new System.Drawing.Size(81, 13);
            this.labelCommandsPerSec.TabIndex = 3;
            this.labelCommandsPerSec.Text = "Commands/s: 0";
            // 
            // labelUptime
            // 
            this.labelUptime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUptime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUptime.Location = new System.Drawing.Point(9, 18);
            this.labelUptime.Name = "labelUptime";
            this.labelUptime.Size = new System.Drawing.Size(503, 44);
            this.labelUptime.TabIndex = 2;
            this.labelUptime.Text = "Uptime: 0d 0h 0m 0s";
            this.labelUptime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem4,
            this.menuItem2,
            this.menuItem8});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpenSource,
            this.menuAttach,
            this.menuSaveConfig,
            this.menuExit});
            this.menuItem1.Text = "File";
            // 
            // menuOpenSource
            // 
            this.menuOpenSource.Index = 0;
            this.menuOpenSource.Text = "Open source...";
            this.menuOpenSource.Click += new System.EventHandler(this.menuOpenSource_Click);
            // 
            // menuAttach
            // 
            this.menuAttach.Index = 1;
            this.menuAttach.Text = "Attach";
            this.menuAttach.Click += new System.EventHandler(this.menuAttach_Click);
            // 
            // menuSaveConfig
            // 
            this.menuSaveConfig.Index = 2;
            this.menuSaveConfig.Text = "Save config";
            this.menuSaveConfig.Click += new System.EventHandler(this.menuSaveConfig_Click);
            // 
            // menuExit
            // 
            this.menuExit.Index = 3;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuStart,
            this.menuStop,
            this.menuReset});
            this.menuItem4.Text = "Tools";
            // 
            // menuStart
            // 
            this.menuStart.Index = 0;
            this.menuStart.Text = "Start";
            this.menuStart.Click += new System.EventHandler(this.menuStart_Click);
            // 
            // menuStop
            // 
            this.menuStop.Index = 1;
            this.menuStop.Text = "Stop";
            this.menuStop.Click += new System.EventHandler(this.menuStop_Click);
            // 
            // menuReset
            // 
            this.menuReset.Index = 2;
            this.menuReset.Text = "Reset";
            this.menuReset.Click += new System.EventHandler(this.menuReset_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAutosave,
            this.menuUsePostMessage});
            this.menuItem2.Text = "Settings";
            // 
            // menuAutosave
            // 
            this.menuAutosave.Checked = true;
            this.menuAutosave.Index = 0;
            this.menuAutosave.Text = "Autosave";
            this.menuAutosave.Click += new System.EventHandler(this.menuAutosave_Click);
            // 
            // menuUsePostMessage
            // 
            this.menuUsePostMessage.Index = 1;
            this.menuUsePostMessage.Text = "Use PostMessage";
            this.menuUsePostMessage.Click += new System.EventHandler(this.menuUsePostMessage_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuItem8.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "About...";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 539);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(544, 22);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "Idle.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "chatlog.txt";
            this.openFileDialog1.Title = "Select your IRC logfile";
            // 
            // timerProcessMessages
            // 
            this.timerProcessMessages.Tick += new System.EventHandler(this.timerProcessMessages_Tick);
            // 
            // timerUptime
            // 
            this.timerUptime.Interval = 500;
            this.timerUptime.Tick += new System.EventHandler(this.timerUptime_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textSaveCombo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textAutosaveInterval);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(520, 48);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Autosave";
            // 
            // textSaveCombo
            // 
            this.textSaveCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSaveCombo.Location = new System.Drawing.Point(405, 17);
            this.textSaveCombo.Name = "textSaveCombo";
            this.textSaveCombo.Size = new System.Drawing.Size(100, 20);
            this.textSaveCombo.TabIndex = 4;
            this.textSaveCombo.Text = "+{F2}";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Key combination:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds";
            // 
            // textAutosaveInterval
            // 
            this.textAutosaveInterval.Location = new System.Drawing.Point(55, 17);
            this.textAutosaveInterval.Name = "textAutosaveInterval";
            this.textAutosaveInterval.Size = new System.Drawing.Size(100, 20);
            this.textAutosaveInterval.TabIndex = 1;
            this.textAutosaveInterval.Text = "60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Every ";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.textDelay);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.buttonClearKeyBindings);
            this.groupBox4.Controls.Add(this.buttonRemoveKeyBinding);
            this.groupBox4.Controls.Add(this.comboKeyBindings);
            this.groupBox4.Controls.Add(this.textCommand);
            this.groupBox4.Controls.Add(this.buttonAddKeyBinding);
            this.groupBox4.Controls.Add(this.listKeyBindings);
            this.groupBox4.Location = new System.Drawing.Point(12, 213);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(520, 200);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Key bindings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Delay (ms):";
            // 
            // textDelay
            // 
            this.textDelay.Location = new System.Drawing.Point(246, 169);
            this.textDelay.Name = "textDelay";
            this.textDelay.Size = new System.Drawing.Size(100, 20);
            this.textDelay.TabIndex = 8;
            this.textDelay.Text = "130";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Command:";
            // 
            // buttonClearKeyBindings
            // 
            this.buttonClearKeyBindings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearKeyBindings.Location = new System.Drawing.Point(435, 139);
            this.buttonClearKeyBindings.Name = "buttonClearKeyBindings";
            this.buttonClearKeyBindings.Size = new System.Drawing.Size(75, 23);
            this.buttonClearKeyBindings.TabIndex = 5;
            this.buttonClearKeyBindings.Text = "Clear";
            this.buttonClearKeyBindings.UseVisualStyleBackColor = true;
            this.buttonClearKeyBindings.Click += new System.EventHandler(this.buttonClearKeyBindings_Click);
            // 
            // buttonRemoveKeyBinding
            // 
            this.buttonRemoveKeyBinding.Location = new System.Drawing.Point(91, 139);
            this.buttonRemoveKeyBinding.Name = "buttonRemoveKeyBinding";
            this.buttonRemoveKeyBinding.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveKeyBinding.TabIndex = 4;
            this.buttonRemoveKeyBinding.Text = "Remove";
            this.buttonRemoveKeyBinding.UseVisualStyleBackColor = true;
            this.buttonRemoveKeyBinding.Click += new System.EventHandler(this.buttonRemoveKeyBinding_Click);
            // 
            // comboKeyBindings
            // 
            this.comboKeyBindings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKeyBindings.FormattingEnabled = true;
            this.comboKeyBindings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboKeyBindings.Location = new System.Drawing.Point(410, 169);
            this.comboKeyBindings.Name = "comboKeyBindings";
            this.comboKeyBindings.Size = new System.Drawing.Size(100, 21);
            this.comboKeyBindings.TabIndex = 3;
            // 
            // textCommand
            // 
            this.textCommand.Location = new System.Drawing.Point(71, 169);
            this.textCommand.Name = "textCommand";
            this.textCommand.Size = new System.Drawing.Size(100, 20);
            this.textCommand.TabIndex = 2;
            this.textCommand.Text = "left";
            // 
            // buttonAddKeyBinding
            // 
            this.buttonAddKeyBinding.Location = new System.Drawing.Point(10, 139);
            this.buttonAddKeyBinding.Name = "buttonAddKeyBinding";
            this.buttonAddKeyBinding.Size = new System.Drawing.Size(75, 23);
            this.buttonAddKeyBinding.TabIndex = 1;
            this.buttonAddKeyBinding.Text = "Add";
            this.buttonAddKeyBinding.UseVisualStyleBackColor = true;
            this.buttonAddKeyBinding.Click += new System.EventHandler(this.buttonAddKeyBinding_Click);
            // 
            // listKeyBindings
            // 
            this.listKeyBindings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listKeyBindings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listKeyBindings.FullRowSelect = true;
            this.listKeyBindings.Location = new System.Drawing.Point(10, 19);
            this.listKeyBindings.Name = "listKeyBindings";
            this.listKeyBindings.Size = new System.Drawing.Size(500, 114);
            this.listKeyBindings.TabIndex = 0;
            this.listKeyBindings.UseCompatibleStateImageBehavior = false;
            this.listKeyBindings.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Command";
            this.columnHeader1.Width = 173;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Key";
            this.columnHeader2.Width = 174;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Delay";
            this.columnHeader3.Width = 86;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 561);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(560, 600);
            this.Name = "Form1";
            this.Text = "OpenTwitchPlays";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelSourceFile;
        private System.Windows.Forms.Label labelKeyPresses;
        private System.Windows.Forms.Label labelCommandsPerSec;
        private System.Windows.Forms.Label labelUptime;
        private System.Windows.Forms.Label labelGameWindow;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuOpenSource;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuStart;
        private System.Windows.Forms.MenuItem menuStop;
        private System.Windows.Forms.MenuItem menuReset;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuAbout;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuAutosave;
        private System.Windows.Forms.Timer timerProcessMessages;
        private System.Windows.Forms.Timer timerUptime;
        private System.Windows.Forms.MenuItem menuAttach;
        private System.Windows.Forms.MenuItem menuUsePostMessage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textSaveCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textAutosaveInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboKeyBindings;
        private System.Windows.Forms.TextBox textCommand;
        private System.Windows.Forms.Button buttonAddKeyBinding;
        private System.Windows.Forms.ListView listKeyBindings;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonRemoveKeyBinding;
        private System.Windows.Forms.Button buttonClearKeyBindings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textDelay;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.MenuItem menuSaveConfig;
    }
}

