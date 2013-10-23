namespace LibraryManagement
{
    partial class FrmCategoryManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("校园");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("爱情");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("叛逆");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("悬疑");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("爆笑");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("青春", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("世界名著");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("外国小说");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("中国古典小说");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("小说", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("中国古诗词");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("文学", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("设计");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("艺术", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("自然/名胜");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("旅游", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("两性之间");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("婚恋", new System.Windows.Forms.TreeNode[] {
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("全部", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode10,
            treeNode12,
            treeNode14,
            treeNode16,
            treeNode18});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategoryManager));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(8, 8);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "校园";
            treeNode1.Text = "校园";
            treeNode2.Name = "爱情";
            treeNode2.Text = "爱情";
            treeNode3.Name = "叛逆";
            treeNode3.Text = "叛逆";
            treeNode4.Name = "悬疑";
            treeNode4.Text = "悬疑";
            treeNode5.Name = "爆笑";
            treeNode5.Text = "爆笑";
            treeNode6.Name = "青春";
            treeNode6.Text = "青春";
            treeNode7.Name = "世界名著";
            treeNode7.Text = "世界名著";
            treeNode8.Name = "外国小说";
            treeNode8.Text = "外国小说";
            treeNode9.Name = "中国古典小说";
            treeNode9.Text = "中国古典小说";
            treeNode10.Name = "小说";
            treeNode10.Text = "小说";
            treeNode11.Name = "中国古诗词";
            treeNode11.Text = "中国古诗词";
            treeNode12.Name = "文学";
            treeNode12.Text = "文学";
            treeNode13.Name = "设计";
            treeNode13.Text = "设计";
            treeNode14.Name = "艺术";
            treeNode14.Text = "艺术";
            treeNode15.Name = "自然/名胜";
            treeNode15.Text = "自然/名胜";
            treeNode16.Name = "旅游";
            treeNode16.Text = "旅游";
            treeNode17.Name = "两性之间";
            treeNode17.Text = "两性之间";
            treeNode18.Name = "婚恋";
            treeNode18.Text = "婚恋";
            treeNode19.Name = "全部";
            treeNode19.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode19});
            this.treeView1.Size = new System.Drawing.Size(275, 394);
            this.treeView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "选中类别";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 423);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "取      消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 464);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "类别";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}