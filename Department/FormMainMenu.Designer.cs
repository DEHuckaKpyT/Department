
namespace Department
{
    partial class FormMainMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.профильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кандидатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеКандидатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.профильToolStripMenuItem,
            this.кандидатыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // профильToolStripMenuItem
            // 
            this.профильToolStripMenuItem.Name = "профильToolStripMenuItem";
            this.профильToolStripMenuItem.Size = new System.Drawing.Size(79, 23);
            this.профильToolStripMenuItem.Text = "Профиль";
            // 
            // кандидатыToolStripMenuItem
            // 
            this.кандидатыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеКандидатыToolStripMenuItem});
            this.кандидатыToolStripMenuItem.Name = "кандидатыToolStripMenuItem";
            this.кандидатыToolStripMenuItem.Size = new System.Drawing.Size(91, 23);
            this.кандидатыToolStripMenuItem.Text = "Кандидаты";
            // 
            // всеКандидатыToolStripMenuItem
            // 
            this.всеКандидатыToolStripMenuItem.Name = "всеКандидатыToolStripMenuItem";
            this.всеКандидатыToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.всеКандидатыToolStripMenuItem.Text = "Все кандидаты";
            this.всеКандидатыToolStripMenuItem.Click += new System.EventHandler(this.всеКандидатыToolStripMenuItem_Click);
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMainMenu";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem профильToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кандидатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеКандидатыToolStripMenuItem;
    }
}