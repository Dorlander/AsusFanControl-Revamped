using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsusFanControl;
using Timer = System.Windows.Forms.Timer;

namespace AsusFanControlGUI
{
    public partial class Form1 : Form
    {
        AsusControl asusControl = new AsusControl();

        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
            Update();
        }

        private void setFanSpeed(int value)
        {
            if (value < 5)
                value = 0;
            if (value > 99)
                value = 99;

            labelValue.Text = value == 0 ? "turned off (set value between 5 and 100)" : value.ToString();
            asusControl.SetFansSpeed(value);
        }

        private void trackBar1_MouseCaptureChanged(object sender, EventArgs e)
        {
            setFanSpeed(trackBar1.Value);
        }

        private void trackBar1_KeyUp(object sender, KeyEventArgs e)
        {
            setFanSpeed(trackBar1.Value);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelRPM.Text = string.Join(" ", asusControl.GetFanSpeeds());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelRPM_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
