﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LibraryManagement
{
    public partial class frmBookPressManager : Form
    {
        public frmBookPressManager()
        {
            InitializeComponent();
        }

        private void FrmBookconcernManager_Load(object sender, EventArgs e)
        {
            aaa();
        }

        private void aaa()
        {
            lvBookconcern.Items.Clear();
            string sql = string.Format("select * from Presses order by upper(PressName)");
            try
            {
                SqlCommand com = new SqlCommand(sql, DBHelper.conn);
                DBHelper.conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                ListViewItem item = null;
                while (dr.Read())
                {

                    string name = dr["PressName"].ToString();
                    item = new ListViewItem(name);
                    lvBookconcern.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                DBHelper.conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( labelTextBox1.Text == "")
            {
                aaa();
            }
            else
            {

                lvBookconcern.Items.Clear();
                string sql = string.Format("select * from Presses where PressName like '%{0}%'", labelTextBox1.Text);
                try
                {
                    DBHelper.conn.Open();
                    SqlCommand com = new SqlCommand(sql, DBHelper.conn);
                    SqlDataReader dr = com.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        MessageBox.Show("没有该出版社，请自行添加！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        while (dr.Read())
                        {
                            string name1 = dr["PressName"].ToString();
                            ListViewItem item = new ListViewItem(name1);
                            
                            lvBookconcern.Items.Add(item);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DBHelper.conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lvBookconcern.SelectedIndices!= null && lvBookconcern.SelectedIndices.Count > 0)
            {
                DBHelper.name = lvBookconcern.Items[0].Text;
                this.Close();


            }
            else
            {
                MessageBox.Show("请选择出版社！");
            }
        }
    }
}
