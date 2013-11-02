using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabeledTextBox
{
    /// <summary>
    /// 带标签的文本框
    /// </summary>
    public class LabelTextBox : TextBox
    {
        private const int WM_PAINT = 0x000F;
        private string labelText;

        public LabelTextBox()
        {

        }

        /// <summary>
        /// 标签文本
        /// </summary>
        [Description("标签文本")]
        public string LabelText
        {
            get
            {
                return labelText;
            }
            set
            {
                labelText = value;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                DrawLabel();
            }
        }

        private void DrawLabel()
        {

            if (string.IsNullOrEmpty(Text))
            {
                using (Graphics g = CreateGraphics())
                {
                    if (!string.IsNullOrEmpty(labelText))
                    {
                        SizeF size = g.MeasureString(labelText, Font);
                        g.DrawString(labelText, Font, Brushes.Gray, new PointF(1, 1/*(Height - size.Height) / 2*/));
                    }
                }
            }
        }
    }
}
