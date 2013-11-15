using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace LibraryManagement
{
    public partial class frmBookPressManager : Form
    {
        public frmBookPressManager()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearchString.Text))
            {
                listPresses.SelectedIndex = listPresses.FindString(txtSearchString.Text);
                ISetCAP target = this.Owner as ISetCAP;
                if (target != null)
                {
                    target.SetPress(listPresses.SelectedItem as Press);
                }
            }
        }

        private DbSet<Press> presses;
        private void frmBookPressManager_Load(object sender, EventArgs e)
        {
            try
            {
                presses = DBHelper.Entities.Presses;

                listPresses.Items.Clear();
                listPresses.DisplayMember = "PressName";
                listPresses.DataSource = presses.ToArray<Press>();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("出版社数据加载失败");
            }

            //foreach (Press p in presses)
            //{
            //    listPresses.Items.Add(p);
            //}
            //listPresses.DataSource = presses;
            //listPresses.DisplayMember = "PressName";
            //listPresses.ValueMember = "PressName";

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearchString.Text) && listPresses.FindStringExact(txtSearchString.Text) == -1)
            {
                DialogResult result = MessageBox.Show(string.Format("是否添加出版社“{0}”？", txtSearchString.Text), "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    int res = 0;
                    try
                    {
                        Press p = new Press();
                        p.PressName = txtSearchString.Text;
                        DBHelper.Entities.Presses.Add(p);
                        res = DBHelper.Entities.SaveChanges();
                        presses = DBHelper.Entities.Presses;
                        listPresses.DataSource = presses.ToArray<Press>();
                        listPresses.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex);
                        //MessageBox.Show("添加出版社出现错误");
                    }

                    if (res > 0)
                    {
                        listPresses.SelectedIndex = listPresses.FindStringExact(txtSearchString.Text);

                        ISetCAP target = this.Owner as ISetCAP;
                        if (target != null)
                        {
                            target.SetPress(listPresses.SelectedItem as Press);
                        }
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Press p = listPresses.SelectedItem as Press;

            if (p != null)
            {
                DialogResult result = MessageBox.Show(string.Format("是否要删除出版社“{0}”？", p.PressName), "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int res = 0;
                    try
                    {
                        DBHelper.Entities.Presses.Remove(p);
                        res = DBHelper.Entities.SaveChanges();
                        presses = DBHelper.Entities.Presses;
                        listPresses.DataSource = presses.ToArray<Press>();
                        listPresses.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex);
                    }

                    if (res > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("删除失败，只能删除未关联的出版社", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listPresses.SelectedIndex = -1;
            ISetCAP target = this.Owner as ISetCAP;
            if (target != null)
            {
                target.SetPress(null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listPresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            ISetCAP target = this.Owner as ISetCAP;
            if (target != null)
            {
                target.SetPress(listPresses.SelectedItem as Press);
            }
        }
    }
}
