using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDuplicateFinder.test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        long t = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            t = 0;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            this.Invoke(new Action(() => this.Text = TimeSpan.FromSeconds(t).ToString()));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            t = 0;
            timer1.Enabled = true;
            timer1.Start();
        }
    }
}
