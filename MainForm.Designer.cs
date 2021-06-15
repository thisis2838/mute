
namespace mute
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butRefresh = new System.Windows.Forms.Button();
            this.butApply = new System.Windows.Forms.Button();
            this.gridDevices = new System.Windows.Forms.DataGridView();
            this.columnSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnGUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.suspendHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gHotkey = new System.Windows.Forms.GroupBox();
            this.labHotkeyEditStopNote = new System.Windows.Forms.Label();
            this.labHotkeyText = new System.Windows.Forms.Label();
            this.boxHotkey = new System.Windows.Forms.TextBox();
            this.gChecks = new System.Windows.Forms.GroupBox();
            this.gPeriodicCheck = new System.Windows.Forms.GroupBox();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.chkPrevent = new System.Windows.Forms.CheckBox();
            this.labCheckInterval = new System.Windows.Forms.Label();
            this.chkInitialMute = new System.Windows.Forms.CheckBox();
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.chkTrayStart = new System.Windows.Forms.CheckBox();
            this.labCredits = new System.Windows.Forms.Label();
            this.gSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDevices)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.gHotkey.SuspendLayout();
            this.gChecks.SuspendLayout();
            this.gPeriodicCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // gSettings
            // 
            this.gSettings.Controls.Add(this.label1);
            this.gSettings.Controls.Add(this.butRefresh);
            this.gSettings.Controls.Add(this.butApply);
            this.gSettings.Controls.Add(this.gridDevices);
            this.gSettings.Location = new System.Drawing.Point(13, 13);
            this.gSettings.Name = "gSettings";
            this.gSettings.Size = new System.Drawing.Size(640, 290);
            this.gSettings.TabIndex = 0;
            this.gSettings.TabStop = false;
            this.gSettings.Text = "Devices";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select which devices to Toggle Mute when the program is notified.";
            // 
            // butRefresh
            // 
            this.butRefresh.Location = new System.Drawing.Point(477, 259);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(75, 23);
            this.butRefresh.TabIndex = 1;
            this.butRefresh.Text = "Refresh";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // butApply
            // 
            this.butApply.Location = new System.Drawing.Point(558, 259);
            this.butApply.Name = "butApply";
            this.butApply.Size = new System.Drawing.Size(75, 23);
            this.butApply.TabIndex = 2;
            this.butApply.Text = "Apply";
            this.butApply.UseVisualStyleBackColor = true;
            this.butApply.Click += new System.EventHandler(this.butApply_Click);
            // 
            // gridDevices
            // 
            this.gridDevices.AllowUserToAddRows = false;
            this.gridDevices.AllowUserToDeleteRows = false;
            this.gridDevices.AllowUserToResizeRows = false;
            this.gridDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSelected,
            this.columnName,
            this.columnGUID});
            this.gridDevices.Location = new System.Drawing.Point(6, 36);
            this.gridDevices.Name = "gridDevices";
            this.gridDevices.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDevices.Size = new System.Drawing.Size(627, 217);
            this.gridDevices.TabIndex = 0;
            // 
            // columnSelected
            // 
            this.columnSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnSelected.HeaderText = "";
            this.columnSelected.Name = "columnSelected";
            this.columnSelected.Width = 5;
            // 
            // columnName
            // 
            this.columnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.Width = 60;
            // 
            // columnGUID
            // 
            this.columnGUID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnGUID.HeaderText = "GUID";
            this.columnGUID.Name = "columnGUID";
            this.columnGUID.ReadOnly = true;
            this.columnGUID.Width = 59;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "DDDD";
            this.notifyIcon.BalloonTipTitle = "dddddddddddddddd";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Mute";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suspendHotkeysToolStripMenuItem,
            this.muteToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(166, 70);
            // 
            // suspendHotkeysToolStripMenuItem
            // 
            this.suspendHotkeysToolStripMenuItem.CheckOnClick = true;
            this.suspendHotkeysToolStripMenuItem.Name = "suspendHotkeysToolStripMenuItem";
            this.suspendHotkeysToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.suspendHotkeysToolStripMenuItem.Text = "Suspend Hotkeys";
            this.suspendHotkeysToolStripMenuItem.Click += new System.EventHandler(this.suspendHotkeysToolStripMenuItem_Click);
            // 
            // muteToolStripMenuItem
            // 
            this.muteToolStripMenuItem.CheckOnClick = true;
            this.muteToolStripMenuItem.Name = "muteToolStripMenuItem";
            this.muteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.muteToolStripMenuItem.Text = "Muted";
            this.muteToolStripMenuItem.Click += new System.EventHandler(this.muteToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gHotkey
            // 
            this.gHotkey.Controls.Add(this.labHotkeyEditStopNote);
            this.gHotkey.Controls.Add(this.labHotkeyText);
            this.gHotkey.Controls.Add(this.boxHotkey);
            this.gHotkey.Location = new System.Drawing.Point(13, 310);
            this.gHotkey.Name = "gHotkey";
            this.gHotkey.Size = new System.Drawing.Size(314, 84);
            this.gHotkey.TabIndex = 1;
            this.gHotkey.TabStop = false;
            this.gHotkey.Text = "Hotkey";
            // 
            // labHotkeyEditStopNote
            // 
            this.labHotkeyEditStopNote.AutoSize = true;
            this.labHotkeyEditStopNote.Location = new System.Drawing.Point(7, 60);
            this.labHotkeyEditStopNote.Name = "labHotkeyEditStopNote";
            this.labHotkeyEditStopNote.Size = new System.Drawing.Size(98, 13);
            this.labHotkeyEditStopNote.TabIndex = 3;
            this.labHotkeyEditStopNote.Text = "Backspace to Stop";
            this.labHotkeyEditStopNote.Visible = false;
            // 
            // labHotkeyText
            // 
            this.labHotkeyText.AutoSize = true;
            this.labHotkeyText.Location = new System.Drawing.Point(7, 20);
            this.labHotkeyText.Name = "labHotkeyText";
            this.labHotkeyText.Size = new System.Drawing.Size(81, 13);
            this.labHotkeyText.TabIndex = 1;
            this.labHotkeyText.Text = "Current Hotkey:";
            // 
            // boxHotkey
            // 
            this.boxHotkey.BackColor = System.Drawing.SystemColors.ControlLight;
            this.boxHotkey.Location = new System.Drawing.Point(10, 37);
            this.boxHotkey.Name = "boxHotkey";
            this.boxHotkey.ReadOnly = true;
            this.boxHotkey.Size = new System.Drawing.Size(298, 20);
            this.boxHotkey.TabIndex = 0;
            // 
            // gChecks
            // 
            this.gChecks.Controls.Add(this.chkTrayStart);
            this.gChecks.Controls.Add(this.gPeriodicCheck);
            this.gChecks.Controls.Add(this.chkInitialMute);
            this.gChecks.Controls.Add(this.chkSound);
            this.gChecks.Location = new System.Drawing.Point(339, 310);
            this.gChecks.Name = "gChecks";
            this.gChecks.Size = new System.Drawing.Size(314, 157);
            this.gChecks.TabIndex = 2;
            this.gChecks.TabStop = false;
            this.gChecks.Text = "Misc";
            // 
            // gPeriodicCheck
            // 
            this.gPeriodicCheck.Controls.Add(this.numInterval);
            this.gPeriodicCheck.Controls.Add(this.chkPrevent);
            this.gPeriodicCheck.Controls.Add(this.labCheckInterval);
            this.gPeriodicCheck.Location = new System.Drawing.Point(7, 77);
            this.gPeriodicCheck.Name = "gPeriodicCheck";
            this.gPeriodicCheck.Size = new System.Drawing.Size(300, 71);
            this.gPeriodicCheck.TabIndex = 4;
            this.gPeriodicCheck.TabStop = false;
            this.gPeriodicCheck.Text = "Periodic Checking";
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(6, 39);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(51, 20);
            this.numInterval.TabIndex = 4;
            this.numInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.UpdateCheckInterval);
            // 
            // chkPrevent
            // 
            this.chkPrevent.AutoSize = true;
            this.chkPrevent.Location = new System.Drawing.Point(6, 19);
            this.chkPrevent.Name = "chkPrevent";
            this.chkPrevent.Size = new System.Drawing.Size(266, 17);
            this.chkPrevent.TabIndex = 1;
            this.chkPrevent.Text = "Prevent Other Applications from Muting / Unmuting";
            this.chkPrevent.UseVisualStyleBackColor = true;
            this.chkPrevent.CheckedChanged += new System.EventHandler(this.UpdateCheckInterval);
            // 
            // labCheckInterval
            // 
            this.labCheckInterval.AutoSize = true;
            this.labCheckInterval.Location = new System.Drawing.Point(63, 41);
            this.labCheckInterval.Name = "labCheckInterval";
            this.labCheckInterval.Size = new System.Drawing.Size(132, 13);
            this.labCheckInterval.TabIndex = 3;
            this.labCheckInterval.Text = "Seconds between Checks";
            // 
            // chkInitialMute
            // 
            this.chkInitialMute.AutoSize = true;
            this.chkInitialMute.Location = new System.Drawing.Point(7, 20);
            this.chkInitialMute.Name = "chkInitialMute";
            this.chkInitialMute.Size = new System.Drawing.Size(220, 17);
            this.chkInitialMute.TabIndex = 0;
            this.chkInitialMute.Text = "Mute Saved Devices on Program Startup";
            this.chkInitialMute.UseVisualStyleBackColor = true;
            // 
            // chkSound
            // 
            this.chkSound.AutoSize = true;
            this.chkSound.Location = new System.Drawing.Point(7, 37);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(200, 17);
            this.chkSound.TabIndex = 2;
            this.chkSound.Text = "Play Sound when Muting / Unmuting";
            this.chkSound.UseVisualStyleBackColor = true;
            // 
            // chkTrayStart
            // 
            this.chkTrayStart.AutoSize = true;
            this.chkTrayStart.Location = new System.Drawing.Point(7, 54);
            this.chkTrayStart.Name = "chkTrayStart";
            this.chkTrayStart.Size = new System.Drawing.Size(133, 17);
            this.chkTrayStart.TabIndex = 5;
            this.chkTrayStart.Text = "Start Minimized to Tray";
            this.chkTrayStart.UseVisualStyleBackColor = true;
            // 
            // labCredits
            // 
            this.labCredits.AutoSize = true;
            this.labCredits.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labCredits.Location = new System.Drawing.Point(10, 419);
            this.labCredits.Name = "labCredits";
            this.labCredits.Size = new System.Drawing.Size(57, 39);
            this.labCredits.TabIndex = 3;
            this.labCredits.Text = "Mute\r\nby 2838\r\nJune 2021";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 478);
            this.Controls.Add(this.labCredits);
            this.Controls.Add(this.gChecks);
            this.Controls.Add(this.gHotkey);
            this.Controls.Add(this.gSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Mute";
            this.gSettings.ResumeLayout(false);
            this.gSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDevices)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.gHotkey.ResumeLayout(false);
            this.gHotkey.PerformLayout();
            this.gChecks.ResumeLayout(false);
            this.gChecks.PerformLayout();
            this.gPeriodicCheck.ResumeLayout(false);
            this.gPeriodicCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gSettings;
        private System.Windows.Forms.DataGridView gridDevices;
        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button butApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gHotkey;
        private System.Windows.Forms.Label labHotkeyEditStopNote;
        private System.Windows.Forms.Label labHotkeyText;
        private System.Windows.Forms.TextBox boxHotkey;
        private System.Windows.Forms.GroupBox gChecks;
        private System.Windows.Forms.CheckBox chkPrevent;
        private System.Windows.Forms.CheckBox chkInitialMute;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem suspendHotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnGUID;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.GroupBox gPeriodicCheck;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Label labCheckInterval;
        private System.Windows.Forms.ToolStripMenuItem muteToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkTrayStart;
        private System.Windows.Forms.Label labCredits;
    }
}

