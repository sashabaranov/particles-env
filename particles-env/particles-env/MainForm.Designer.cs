namespace particles_env
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����������������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExpirementType = new System.Windows.Forms.ToolStripMenuItem();
            this.�����������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.����������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(845, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem,
            this.�����ToolStripMenuItem,
            this.�����������ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����������������ToolStripMenuItem,
            this.�����ToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.����ToolStripMenuItem.Text = "����";
            this.����ToolStripMenuItem.Click += new System.EventHandler(this.����ToolStripMenuItem_Click);
            // 
            // ����������������ToolStripMenuItem
            // 
            this.����������������ToolStripMenuItem.Image = global::particles_env.Properties.Resources.flag;
            this.����������������ToolStripMenuItem.Name = "����������������ToolStripMenuItem";
            this.����������������ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.����������������ToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.����������������ToolStripMenuItem.Text = "����� �����������";
            this.����������������ToolStripMenuItem.Click += new System.EventHandler(this.����������������ToolStripMenuItem_Click);
            // 
            // �����ToolStripMenuItem
            // 
            this.�����ToolStripMenuItem.Image = global::particles_env.Properties.Resources.stop;
            this.�����ToolStripMenuItem.Name = "�����ToolStripMenuItem";
            this.�����ToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.�����ToolStripMenuItem.Text = "�����";
            this.�����ToolStripMenuItem.Click += new System.EventHandler(this.�����ToolStripMenuItem_Click);
            // 
            // �����ToolStripMenuItem
            // 
            this.�����ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.�����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExpirementType});
            this.�����ToolStripMenuItem.Name = "�����ToolStripMenuItem";
            this.�����ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.�����ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.�����ToolStripMenuItem.Text = "�����";
            this.�����ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // addExpirementType
            // 
            this.addExpirementType.Image = global::particles_env.Properties.Resources.gear;
            this.addExpirementType.Name = "addExpirementType";
            this.addExpirementType.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.addExpirementType.Size = new System.Drawing.Size(304, 22);
            this.addExpirementType.Text = "�������� ��� ������������";
            this.addExpirementType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addExpirementType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addExpirementType.Click += new System.EventHandler(this.addExpirementType_Click);
            // 
            // �����������ToolStripMenuItem
            // 
            this.�����������ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����������ToolStripMenuItem});
            this.�����������ToolStripMenuItem.Name = "�����������ToolStripMenuItem";
            this.�����������ToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.�����������ToolStripMenuItem.Text = "�����������";
            // 
            // ����������ToolStripMenuItem
            // 
            this.����������ToolStripMenuItem.Image = global::particles_env.Properties.Resources.diagram;
            this.����������ToolStripMenuItem.Name = "����������ToolStripMenuItem";
            this.����������ToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.����������ToolStripMenuItem.Text = "����������";
            this.����������ToolStripMenuItem.Click += new System.EventHandler(this.����������ToolStripMenuItem_Click);
            // 
            // Tabs
            // 
            this.Tabs.AccessibleName = "TabView";
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Location = new System.Drawing.Point(0, 27);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(845, 485);
            this.Tabs.TabIndex = 2;
            this.Tabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Tabs_Selecting);
            this.Tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.Tabs_Selected);
            this.Tabs.Resize += new System.EventHandler(this.Tabs_Resize);
            this.Tabs.TabIndexChanged += new System.EventHandler(this.Tabs_TabIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "���������� DLL|*.dll|��� �����|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 537);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "����� ��� ������ � ������������� ���������";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.Tabs_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����������������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExpirementType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem �����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem �����������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����������ToolStripMenuItem;
        public System.Windows.Forms.TabControl Tabs;
    }
}

