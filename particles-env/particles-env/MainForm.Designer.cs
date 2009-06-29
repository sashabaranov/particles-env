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
            this.îïöèèToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ôàéëToolStripMenuItem
            // 
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
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.Text = "Íîâûé ıêñïåğèìåíò";
            this.íîâûéİêñïåğèìåíòToolStripMenuItem.Click += new System.EventHandler(this.íîâûéİêñïåğèìåíòToolStripMenuItem_Click);
            // 
            // îòêğûòüİñïåğèìåíòToolStripMenuItem
            // 
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem.Name = "îòêğûòüİñïåğèìåíòToolStripMenuItem";
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.îòêğûòüİñïåğèìåíòToolStripMenuItem.Text = "Îòêğûòü ıñïåğèìåíò";
            // 
            // âûõîäToolStripMenuItem
            // 
            this.âûõîäToolStripMenuItem.Name = "âûõîäToolStripMenuItem";
            this.âûõîäToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.âûõîäToolStripMenuItem.Text = "Âûõîä";
            this.âûõîäToolStripMenuItem.Click += new System.EventHandler(this.âûõîäToolStripMenuItem_Click);
            // 
            // îïöèèToolStripMenuItem
            // 
            this.îïöèèToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExpirementType});
            this.îïöèèToolStripMenuItem.Name = "îïöèèToolStripMenuItem";
            this.îïöèèToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.îïöèèToolStripMenuItem.Text = "Îïöèè";
            // 
            // addExpirementType
            // 
            this.addExpirementType.Name = "addExpirementType";
            this.addExpirementType.Size = new System.Drawing.Size(229, 22);
            this.addExpirementType.Text = "Äîáàâèòü òèï ıêñïåğèìåíòà";
            this.addExpirementType.Click += new System.EventHandler(this.addExpirementType_Click);
            // 
            // Tabs
            // 
            this.Tabs.Location = new System.Drawing.Point(0, 27);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(851, 485);
            this.Tabs.TabIndex = 2;
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
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.ToolStripMenuItem îïöèèToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExpirementType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem âûõîäToolStripMenuItem;
    }
}

