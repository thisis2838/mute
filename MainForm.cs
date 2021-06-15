using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using KeyboardHook;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Media;

namespace mute
{
    public partial class MainForm : Form
    {
        private List<Guid> _selectedGuids;
        private CoreAudioController _audioController;
        private bool _monitorKeys = false;
        private KeyboardHook.KeyboardHook _hook = new KeyboardHook.KeyboardHook();
        private bool _muted = true;
        private bool _lastMuted = true;
        private KeyboardHook.Hotkey _currentHotKey;
        private Notify _notify;
        private Timer _timer;
        private Timer _timer2;
        private bool _timer2Started = false;
        private bool _timerStarted = false;

        public MainForm()
        {
            _selectedGuids = new List<Guid>();
            _audioController = new CoreAudioController();

            this.KeyDown += MainForm_KeyDown;
            this.Resize += MainForm_Resize;
            this.FormClosing += MainForm_FormClosing;
            this.Load += MainForm_Load;

            InitializeComponent();

            chkTrayStart.Checked = Properties.Settings.Default.TrayStart;
            if (chkTrayStart.Checked)
            {
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }

            this.notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;

            this.boxHotkey.GotFocus += BeginMonitoringKeys;
            this.boxHotkey.LostFocus += StopMonitoringKeys;

            _notify = new Notify();

            _timer = new Timer();

            _timer2 = new Timer();
            _timer2.Tick += CheckMuteInSync;
            _timer2.Interval = 5000;

            _hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(Mute);
        }

        private void CheckMuteInSync(object sender, EventArgs e)
        {
            foreach (CoreAudioDevice device in _audioController.GetCaptureDevices())
                if (_selectedGuids.Contains(device.Id) && device.IsMuted != _lastMuted)
                {
                    SetNotifyIcon(2);
                    return;
                }

            SetNotifyIcon(_lastMuted ? 1 : 0);
        }

        private void RecheckAndSetMute(object sender, EventArgs e)
        {
            if (!chkPrevent.Checked)
                return;

            bool changed = false;

            foreach (CoreAudioDevice device in _audioController.GetCaptureDevices())
                if (_selectedGuids.Contains(device.Id) && device.IsMuted != _lastMuted)
                {
                    changed = true;
                    device.Mute(_lastMuted);
                    UpdateCheckInterval(null, null);
                }

            if (changed)
                Notify();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Guids != null)
                foreach (string id in Properties.Settings.Default.Guids)
                {
                    Guid realId = Guid.Parse(id);
                    _selectedGuids.Add(realId);
                }

            boxHotkey.Text = Properties.Settings.Default.Hotkey;
            ParseKeys(boxHotkey.Text);
            this.butRefresh_Click(null, null);

            chkInitialMute.Checked = Properties.Settings.Default.InitialMute;
            chkSound.Checked = Properties.Settings.Default.Sound;
            chkPrevent.Checked = Properties.Settings.Default.Prevent;
            numInterval.Value = Properties.Settings.Default.PreventInterval;

            if (chkInitialMute.Checked)
                Mute(null, null);

            _timer = new Timer();
            _timer.Interval = (int)numInterval.Value * 1000;
            _timer.Tick += RecheckAndSetMute;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Collections.Specialized.StringCollection guids = new System.Collections.Specialized.StringCollection();
            foreach (Guid id in _selectedGuids)
                guids.Add(id.ToString());

            Properties.Settings.Default.Guids = guids;
            Properties.Settings.Default.Hotkey = boxHotkey.Text;
            Properties.Settings.Default.InitialMute = chkInitialMute.Checked;
            Properties.Settings.Default.Sound = chkSound.Checked;
            Properties.Settings.Default.Prevent = chkPrevent.Checked;
            Properties.Settings.Default.PreventInterval = (int)numInterval.Value;
            Properties.Settings.Default.TrayStart = chkTrayStart.Checked;

            Properties.Settings.Default.Save();

            _hook.KeyPressed -= Mute;
            _hook.Dispose();

            _notify.Dispose();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            gridDevices.Rows.Clear();
            var devices = _audioController.GetCaptureDevices();
            foreach (CoreAudioDevice info in devices)
                gridDevices.Rows.Add(_selectedGuids.Contains(info.Id), info.FullName, info.Id.ToString());
        }

        private void NotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void butApply_Click(object sender, EventArgs e)
        {
            _selectedGuids.Clear();
            foreach (DataGridViewRow row in gridDevices.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value)
                    _selectedGuids.Add(Guid.Parse(row.Cells[2].Value.ToString()));
            }
        }

        private void BeginMonitoringKeys(object sender, EventArgs e)
        {
            _monitorKeys = true;
            labHotkeyEditStopNote.Visible = true;
            boxHotkey.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void StopMonitoringKeys(object sender, EventArgs e)
        {
            _monitorKeys = false;
            labHotkeyEditStopNote.Visible = false;
            boxHotkey.BackColor = Color.FromArgb(227, 227, 227);
            ParseKeys(boxHotkey.Text);
        }

        private void MainForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!_monitorKeys)
                return;

            if (e.KeyCode == Keys.Back)
            {
                this.labHotkeyText.Focus();
                return;
            }

            List<string> keys = new List<string>();

            if (e.Control == true)
                keys.Add("CTRL");

            if (e.Alt == true)
                keys.Add("ALT");

            if (e.Shift == true)
                keys.Add("SHIFT");

            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                case Keys.Alt:
                case Keys.ShiftKey:
                case Keys.Menu:
                    break;
                default:
                    keys.Add(e.KeyCode.ToString().Replace("Oem", string.Empty));
                    break;
            }

            e.Handled = true;
            boxHotkey.Text = string.Join(" + ", keys);
        }

        private void SetNotifyIcon(int state)
        {
            switch (state)
            {
                case 0:
                    notifyIcon.Icon = Properties.Resources.on;
                    this.Icon = Properties.Resources.on;
                    notifyIcon.Text = "All unmuted!";
                    break;
                case 1:
                    notifyIcon.Icon = Properties.Resources.off;
                    this.Icon = Properties.Resources.off;
                    notifyIcon.Text = "All muted!";
                    break;
                case 2:
                    notifyIcon.Icon = Properties.Resources.semi;
                    this.Icon = Properties.Resources.semi;
                    notifyIcon.Text = "Mute settings of Devices different than tool's!";
                    break;
            }
        }

        private void Notify()
        {
            _notify.SetText(_lastMuted);

            UpdateCheckInterval(null, null);

            ((ToolStripMenuItem)contextMenuStrip.Items[1]).Checked = _lastMuted;

            SetNotifyIcon(_lastMuted ? 1 : 0);

            if (chkSound.Checked)
            {
                Stream str = _lastMuted ? Properties.Resources.mute : Properties.Resources.unmute;
                SoundPlayer audio = new SoundPlayer(str);
                audio.Play();
            }
        }

        private void Mute(object sender, EventArgs e)
        {
            if (!_timer2Started)
            {
                _timer2Started = true;
                _timer2.Start();
            }

            if (!_timerStarted)
            {
                _timerStarted = true;
                _timer.Start();
            }

            var devices = _audioController.GetCaptureDevices();
            foreach (CoreAudioDevice device in devices)
            {
                if (_selectedGuids.Contains(device.Id))
                    device.Mute(_muted);
            }
            this.labHotkeyText.Focus();

            _lastMuted = _muted;

            Notify();
            _muted = !_muted;
        }

        private void ParseKeys(string keys)
        {
            if (string.IsNullOrWhiteSpace(keys))
                return;

            string[] entries = keys.Split(new string[] { " + " }, StringSplitOptions.None);

            ModifierKeys modifierKeys = new KeyboardHook.ModifierKeys();
            Keys normalKey = new Keys();

            foreach (string entry in entries)
            {
                switch (entry)
                {
                    case "SHIFT":
                        modifierKeys |= KeyboardHook.ModifierKeys.Shift;
                        break;

                    case "ALT":
                        modifierKeys |= KeyboardHook.ModifierKeys.Alt;
                        break;

                    case "CTRL":
                        modifierKeys |= KeyboardHook.ModifierKeys.Control;
                        break;

                    default:
                        normalKey = (Keys)Enum.Parse(typeof(Keys), entry);
                        break;
                }
            }

            _hook.UnregisterAll();
            _hook.RegisterHotKey(modifierKeys, normalKey);
            _currentHotKey = new KeyboardHook.Hotkey()
            {
                Modifier = modifierKeys,
                Key = normalKey
            };
        }

        private void suspendHotkeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)contextMenuStrip.Items[0]).Checked)
                _hook.UnregisterAll();
            else
                _hook.RegisterHotKey(_currentHotKey.Modifier, _currentHotKey.Key);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCheckInterval(object sender, EventArgs e)
        {
            _timer.Interval = (int)numInterval.Value * 1000;

            if (_timer.Interval < 5000)
                _timer2.Interval = (int)(_timer.Interval / 3) + 10;
            else _timer2.Interval = 5000;

            _timer.Stop();
            _timer.Start();

            if (sender == null)
            {
                _timer2.Stop();
                _timer2.Start();
            }
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _muted = ((ToolStripMenuItem)(contextMenuStrip.Items[1])).Checked;
            Mute(null, null);
        }
    }
}
