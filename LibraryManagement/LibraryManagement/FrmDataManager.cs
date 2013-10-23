using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class FrmDataManager : Form
    {
        public FrmDataManager()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////选择文件
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Multiselect = true;
            ////文件格式
            //openFileDialog.Filter = "所有文件|*.*";
            ////还原当前目录
            //openFileDialog.RestoreDirectory = true;
            ////默认的文件格式
            //openFileDialog.FilterIndex = 1;
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    textBox1.Text = openFileDialog.FileName;
            //}



            FolderBrowserDialog ff = new FolderBrowserDialog();
            ff.Description = "AAAA";
            ff.ShowDialog();
            string a = ff.SelectedPath;

            //选择文件夹
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择备份数据路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // 设置根在桌面
            //dialog .RootFolder = SpecialFolder.Desktop;

            //// 设置当前选择的路径
            //folderBrowserDialog1.SelectedPath = "C:";

            //// 允许在对话框中包括一个新建目录的按钮
            //folderBrowserDialog1.ShowNewFolderButton = true;

            //// 设置对话框的说明信息
            //folderBrowserDialog1.Description = "请选择输出目录";

            //if (folderBrowser.Dialog1.ShowDialog() == DialogResult.OK)
            //{

            //    // 在此添加代码,选择的路径为 folderBrowserDialog1.SelectedPath

            //}
        }
    }
}
