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
            this.ôàéëToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.íîâûéİêñïåğèìåíòToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.âûõîäToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.îïöèèToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExpirementType = new System.Windows.Forms.ToolStripMenuItem();
            this.ıêñïåğèìåíòToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ñòàòèñòèêàToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ôàéëToolStripMenuItem,
            this.îïöèèToolStripMenuItem,
            this.ıêñïåğèìåíòToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ôàéëToolStripMenuItem
            // 
            this.ôàéëToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ôàéëToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.íîâûéİêñïåğèìåíòToolStripMenuItem,
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem,
            this.âûõîäToolStripMenuItem});
            this.ôàéëToolStripMenuItem.Name = "ôàéëToolStripMenuItem";
            this.ôàéëToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ôàéëToolStripMenuItem.Text = "Ôàéë";
            this.ôàéëToolStripMenuItem.Click += new System.EventHandler(this.ôàéëToolStripMenuItem_Click);
            // 
            // íîâûéİêñïåğèìåíòToolStripMenuItem
            // 
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.Name = "íîâûéİêñïåğèìåíòToolStripMenuItem";
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.Text = "Íîâûé ıêñïåğèìåíò";
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.Click += new System.EventHandler(this.íîâûéİêñïåğèìåíòToolStripMenuItem_Click);
            // 
            // îòêğûòüİñïåğèìåíòToolStripMenuItem
            // 
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem.Name = "îòêğûòüİñïåğèìåíòToolStripMenuItem";
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem.Text = "Îòêğûòü ıñïåğèìåíò";
            // 
            // âûõîäToolStripMenuItem
            // 
            this.âûõîäToolStripMenuItem.Name = "âûõîäToolStripMenuItem";
            this.âûõîäToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.âûõîäToolStripMenuItem.Text = "Âûõîä";
            this.âûõîäToolStripMenuItem.Click += new System.EventHandler(this.âûõîäToolStripMenuItem_Click);
            // 
            // îïöèèToolStripMenuItem
            // 
            this.îïöèèToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.îïöèèToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExpirementType});
            this.îïöèèToolStripMenuItem.Name = "îïöèèToolStripMenuItem";
            this.îïöèèToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.îïöèèToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.îïöèèToolStripMenuItem.Text = "Îïöèè";
            this.îïöèèToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // addExpirementType
            // 
            this.addExpirementType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addExpirementType.Name = "addExpirementType";
            this.addExpirementType.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.addExpirementType.Size = new System.Drawing.Size(304, 22);
            this.addExpirementType.Text = "Äîáàâèòü òèï ıêñïåğèìåíòà";
            this.addExpirementType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addExpirementType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addExpirementType.Click += new System.EventHandler(this.addExpirementType_Click);
            // 
            // ıêñïåğèìåíòToolStripMenuItem
            // 
            this.ıêñïåğèìåíòToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ñòàòèñòèêàToolStripMenuItem,
            this.testToolStripMenuItem});
            this.ıêñïåğèìåíòToolStripMenuItem.Name = "ıêñïåğèìåíòToolStripMenuItem";
            this.ıêñïåğèìåíòToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.ıêñïåğèìåíòToolStripMenuItem.Text = "İêñïåğèìåíò";
            // 
            // ñòàòèñòèêàToolStripMenuItem
            // 
            this.ñòàòèñòèêàToolStripMenuItem.Name = "ñòàòèñòèêàToolStripMenuItem";
            this.ñòàòèñòèêàToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ñòàòèñòèêàToolStripMenuItem.Text = "Ñòàòèñòèêà";
            this.ñòàòèñòèêàToolStripMenuItem.Click += new System.EventHandler(this.ñòàòèñòèêàToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
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
            this.Tabs.TabIndexChanged += new System.EventHandler(this.Tabs_TabIndexChanged);
            this.Tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Áèáëèîòåêè DLL|*.dll|Âñå ôàéëû|*.*";
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
            this.Text = "Ñğåäà äëÿ ğàáîòû ñ ıëåìåíòàğíûìè ÷àñòèöàìè";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ôàéëToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem íîâûéİêñïåğèìåíòToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem îòêğûòüİñïåğèìåíòToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem îïöèèToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExpirementType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem âûõîäToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ıêñïåğèìåíòToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ñòàòèñòèêàToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        public System.Windows.Forms.TabControl Tabs;
    }
}

