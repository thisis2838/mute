using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mute
{
    public partial class Notify : Form
    {
        private Timer _timer;
        public Notify()
        {
            InitializeComponent();
            TopMost = true;
            _timer = new Timer();

            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            Hide();
        }

        public void SetText(bool muted)
        {
            Hide();
            Show();
            label1.Text = "Devices " + (muted ? "muted" : "unmuted");
            this.BackColor = (muted) ? Color.Red : Color.Green;
            DesktopLocation = new Point(5, 5);
            this.Size = new Size(109, 33);
            _timer.Stop();
            _timer.Start();
        }
    }
}
