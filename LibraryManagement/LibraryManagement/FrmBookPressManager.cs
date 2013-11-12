using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryDB;
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

        private List<Press> presses;
        private void frmBookPressManager_Load(object sender, EventArgs e)
        {
            try
            {
                DBHelper.conn.Open();
                presses = Press.GetAllPresses(DBHelper.conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.conn.Close();
            }

            listPresses.DataSource = presses;
            listPresses.DisplayMember = "PressName";
            listPresses.ValueMember = "PressID";
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSearchString.Text = txtSearchString.Text.Trim();

            if (!string.IsNullOrEmpty(txtSearchString.Text) && listPresses.FindStringExact(txtSearchString.Text) == -1)
            {
                DialogResult result = MessageBox.Show(string.Format("是否添加出版社“{0}”？", txtSearchString.Text), "迅邦温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    int res = 0;
                    try
                    {
                        DBHelper.conn.Open();
                        Press p = new Press(txtSearchString.Text);
                        res = ((IDBOperate)p).Insert(DBHelper.conn);
                        presses = Press.GetAllPresses(DBHelper.conn);
                        listPresses.DataSource = presses;
                        listPresses.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DBHelper.conn.Close();
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
                        MessageBox.Show("添加失败", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Press p = listPresses.SelectedItem as Press;

            if (p != null)
            {
                DialogResult result = MessageBox.Show(string.Format("是否要删除出版社“{0}”？", p.PressName), "迅邦温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int res = 0;
                    try
                    {
                        DBHelper.conn.Open();
                        res = ((IDBOperate)p).Delete(DBHelper.conn);
                        presses = Press.GetAllPresses(DBHelper.conn);
                        listPresses.DataSource = presses;
                        listPresses.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DBHelper.conn.Close();
                    }

                    if (res > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("删除失败", "迅邦温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
