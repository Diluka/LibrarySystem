using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
namespace LibraryManagement
{
    class DBHelper
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Library;Integrated Security=True");

        private static LibraryEntities entities;

        public static LibraryEntities Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = new LibraryEntities();
                }
                return entities;
            }
        }

        /// <summary>
        /// 生成类别树状图
        /// </summary>
        /// <param name="tree">树形视图控件</param>
        /// <param name="conn">连接</param>
        public static void MakeCategoryTree(TreeView tree)
        {
            if (tree != null)
            {
                tree.Nodes.Clear();
                tree.Nodes.Add(new TreeNode("全部"));


                DbSet<Category> categories = Entities.Categories;

                foreach (Category c in categories)
                {
                    string[] cats = c.CategoryName.Split('/');
                    TreeNode root = tree.Nodes[0];
                    for (int i = 0; i < cats.Length; i++)
                    {
                        if (!root.Nodes.ContainsKey(cats[i]))
                        {
                            TreeNode node = new TreeNode(cats[i]);
                            node.Name = cats[i];
                            node.Tag = c;
                            root.Nodes.Add(node);
                            root = node;
                        }
                        else
                        {
                            root = root.Nodes.Find(cats[i], false)[0];
                        }
                    }
                }
            }

        }

    }
}
