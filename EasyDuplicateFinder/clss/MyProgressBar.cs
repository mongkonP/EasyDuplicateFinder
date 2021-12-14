using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyDuplicateFinder.clss
{
    public partial class MyProgressBar : ProgressBar
    {
        public MyProgressBar()
        {//
         //  InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //Draw percentage
            Rectangle rect = this.ClientRectangle;
            Graphics g = pe.Graphics;
            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            if (this.Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)this.Value / this.Maximum) * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }
            using (Font f = new Font(FontFamily.GenericMonospace, 18))
            {
                string _v = $"File {this.Value} in {this.Maximum}  { (Convert.ToDouble(this.Value) / Convert.ToDouble(this.Maximum )* 100d).ToString("N3")}  %";
                SizeF size = g.MeasureString(_v, f);
                Point location = new Point((int)((rect.Width / 2) - (size.Width / 2)), (int)((rect.Height / 2) - (size.Height / 2) + 2));
                g.DrawString(_v, f, Brushes.Black, location);
            }
            //base.OnPaint(pe);
        }
    }

}
