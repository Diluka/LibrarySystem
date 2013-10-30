using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsUtilities;

namespace LabeledTextBox
{
    /// <summary>
    /// 带标签的文本框
    /// </summary>
    public class LabelTextBox: TextBox
    {
        private string labelText;

        /// <summary>
        /// 标签文本
        /// </summary>
        [Description("标签文本")]
        public string LabelText {
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
            if (m.Msg == (int)WindowsMessages.WM_PAINT)
            {
                using (Graphics g = CreateGraphics())
                {
                    if (string.IsNullOrEmpty(Text) && !Focused)
                    {
                        SizeF size = g.MeasureString(labelText, Font);
                        g.DrawString(labelText, Font, Brushes.LightGray, new PointF(0, (Height - size.Height) / 2));
                    }
                }
            }
        }
    }
}
