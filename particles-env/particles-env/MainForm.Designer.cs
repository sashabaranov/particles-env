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
            this.�����������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.����������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.��������������������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������������������ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.�����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExperimentType = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.experimentAddControl1 = new particles_env.ExperimentAddControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.openExperimentDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(957, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�����������ToolStripMenuItem,
            this.�����ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(957, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // �����������ToolStripMenuItem
            // 
            this.�����������ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.����������ToolStripMenuItem,
            this.toolStripSeparator2,
            this.��������������������ToolStripMenuItem,
            this.��������������������ToolStripMenuItem});
            this.�����������ToolStripMenuItem.Name = "�����������ToolStripMenuItem";
            this.�����������ToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.�����������ToolStripMenuItem.Text = "�����������";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::particles_env.Properties.Resources.flag;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(230, 22);
            this.toolStripMenuItem1.Text = "����� �����������";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.����������������ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // ����������ToolStripMenuItem
            // 
            this.����������ToolStripMenuItem.Image = global::particles_env.Properties.Resources.diagram;
            this.����������ToolStripMenuItem.Name = "����������ToolStripMenuItem";
            this.����������ToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.����������ToolStripMenuItem.Text = "����������";
            this.����������ToolStripMenuItem.Click += new System.EventHandler(this.����������ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // ��������������������ToolStripMenuItem
            // 
            this.��������������������ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.��������������������ToolStripMenuItem.Image = global::particles_env.Properties.Resources.save;
            this.��������������������ToolStripMenuItem.Name = "��������������������ToolStripMenuItem";
            this.��������������������ToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.��������������������ToolStripMenuItem.Text = "��������� �����������";
            this.��������������������ToolStripMenuItem.Click += new System.EventHandler(this.SaveExperiment);
            // 
            // ��������������������ToolStripMenuItem
            // 
            this.��������������������ToolStripMenuItem.Image = global::particles_env.Properties.Resources.folder;
            this.��������������������ToolStripMenuItem.Name = "��������������������ToolStripMenuItem";
            this.��������������������ToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.��������������������ToolStripMenuItem.Text = "��������� �����������";
            this.��������������������ToolStripMenuItem.Click += new System.EventHandler(this.LoadExperiment);
            // 
            // �����ToolStripMenuItem
            // 
            this.�����ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.�����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExperimentType});
            this.�����ToolStripMenuItem.Name = "�����ToolStripMenuItem";
            this.�����ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.�����ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.�����ToolStripMenuItem.Text = "�����";
            this.�����ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // addExperimentType
            // 
            this.addExperimentType.Image = global::particles_env.Properties.Resources.gear;
            this.addExperimentType.Name = "addExperimentType";
            this.addExperimentType.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.addExperimentType.Size = new System.Drawing.Size(304, 22);
            this.addExperimentType.Text = "�������� ��� ������������";
            this.addExperimentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addExperimentType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addExperimentType.Click += new System.EventHandler(this.addExperimentType_Click);
            // 
            // Tabs
            // 
            this.Tabs.AccessibleName = "TabView";
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Location = new System.Drawing.Point(0, 27);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(957, 564);
            this.Tabs.TabIndex = 2;
            this.Tabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Tabs_Selecting);
            this.Tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.Tabs_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.experimentAddControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(949, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "��������� ��������";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "�������� �����������:";
            // 
            // experimentAddControl1
            // 
            this.experimentAddControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.experimentAddControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.experimentAddControl1.Location = new System.Drawing.Point(8, 49);
            this.experimentAddControl1.Name = "experimentAddControl1";
            this.experimentAddControl1.Size = new System.Drawing.Size(917, 468);
            this.experimentAddControl1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "���������� DLL|*.dll|��� �����|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 616);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "����� ��� ������ � ������������� ���������";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.Tabs_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem �����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExperimentType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem �����������ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ����������ToolStripMenuItem;
        public System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.ToolStripMenuItem ��������������������ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ��������������������ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openExperimentDialog;
        private System.Windows.Forms.TabPage tabPage1;
        private ExperimentAddControl experimentAddControl1;
        private System.Windows.Forms.Label label1;
    }
}

