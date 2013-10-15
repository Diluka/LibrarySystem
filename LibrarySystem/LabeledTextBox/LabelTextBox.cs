using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabeledTextBox
{
    public partial class LabelTextBox: TextBox
    {
        private bool hasData;
        private string labelText;

        /// <summary>
        /// 标签文本
        /// </summary>
        public string LabelText {
            get
            {
                return labelText;
            }
            set
            {
                labelText = value;
                if (!hasData)
                {
                    this.Text = value;
                }
            }
        }
        /// <summary>
        /// 标签颜色
        /// </summary>
        public Color LabelColor { get; set; }
        /// <summary>
        /// 文本颜色
        /// </summary>
        public Color TextColor { get; set; }
        /// <summary>
        /// 是否为密码框
        /// </summary>
        public bool IsPassword { get; set; }
        /// <summary>
        /// 用户输入的文本
        /// </summary>
        public string UserText
        {
            get
            {
                if (hasData)
                {
                    return this.Text;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                this.Text = value;

                hasData = this.Text != string.Empty;
                if (!hasData)
                {
                    this.Text = LabelText;
                    this.ForeColor = LabelColor;
                    this.UseSystemPasswordChar = false;
                }
                else
                {
                    this.ForeColor = TextColor;
                    this.UseSystemPasswordChar = IsPassword;
                }
            }
        }
        /// <summary>
        /// 带标签的文本框
        /// </summary>
        public LabelTextBox()
        {
            InitializeComponent();

            TextColor = this.ForeColor;
            LabelColor = Color.Gray;

            this.ForeColor = LabelColor;
            hasData = false;
        }

        private void LabelTextBox_Enter(object sender, EventArgs e)
        {
            if (!hasData)
            {
                this.Text = string.Empty;
                this.ForeColor = TextColor;
                this.UseSystemPasswordChar = IsPassword;
            }
        }

        private void LabelTextBox_Leave(object sender, EventArgs e)
        {
            hasData = this.Text != string.Empty;

            if (!hasData)
            {
                this.Text = LabelText;
                this.ForeColor = LabelColor;
                this.UseSystemPasswordChar = false;
            }
        }

        private void LabelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hasData = this.Text != string.Empty;
        }

        private void LabelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (hasData)
            {
                hasData = this.Text != string.Empty;
            }
        }
    }
}
