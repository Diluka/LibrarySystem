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

        //覆盖原有的Text属性，外部访问Text属性获取的将会是用户输入的文本，而不是显示的文本（可能为标签）
        public new string Text
        {
            get
            {
                if (hasData)
                {
                    return base.Text;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    base.UseSystemPasswordChar = false;
                    base.PasswordChar = '\0';
                    ForeColor = LabelColor;
                    base.Text = labelText;
                    hasData = false;
                }
                else
                {
                    base.UseSystemPasswordChar = UseSystemPasswordChar;
                    base.PasswordChar = PasswordChar;
                    ForeColor = TextColor;
                    base.Text = value;
                    hasData = true;
                }
            }
        }

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
                    base.Text = value;
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
        public new bool UseSystemPasswordChar { get; set; }
        public new char PasswordChar { get; set; }


        /// <summary>
        /// 带标签的文本框
        /// </summary>
        public LabelTextBox()
        {
            InitializeComponent();

            TextColor = SystemColors.ControlText;
            LabelColor = SystemColors.ControlDark;

            this.ForeColor = LabelColor;
            
            base.Text = LabelText;
            hasData = false;
        }

        private void LabelTextBox_Enter(object sender, EventArgs e)
        {
            if (!hasData)
            {
                base.Text = string.Empty;
                this.ForeColor = TextColor;
                base.UseSystemPasswordChar = UseSystemPasswordChar;
                base.PasswordChar = PasswordChar;
            }
        }

        private void LabelTextBox_Leave(object sender, EventArgs e)
        {
            hasData = base.Text != string.Empty;

            if (!hasData)
            {
                base.Text = LabelText;
                this.ForeColor = LabelColor;
                base.UseSystemPasswordChar = false;
                base.PasswordChar = '\0';
            }
        }

        private void LabelTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            hasData = base.Text != string.Empty;
        }

        private void LabelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (hasData)
            {
                hasData = base.Text != string.Empty;
            }
        }
    }
}
