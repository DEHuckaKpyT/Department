
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
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прошлыеМестаРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.улицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.институтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.КафедрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.степениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.должностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеСотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.профильToolStripMenuItem,
            this.кандидатыToolStripMenuItem,
            this.сотрудникиToolStripMenuItem,
            this.прошлыеМестаРаботыToolStripMenuItem,
            this.справочникиToolStripMenuItem});
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
            this.всеКандидатыToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.всеКандидатыToolStripMenuItem.Text = "Все кандидаты";
            this.всеКандидатыToolStripMenuItem.Click += new System.EventHandler(this.всеКандидатыToolStripMenuItem_Click);
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеСотрудникиToolStripMenuItem});
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(98, 23);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            // 
            // прошлыеМестаРаботыToolStripMenuItem
            // 
            this.прошлыеМестаРаботыToolStripMenuItem.Name = "прошлыеМестаРаботыToolStripMenuItem";
            this.прошлыеМестаРаботыToolStripMenuItem.Size = new System.Drawing.Size(173, 23);
            this.прошлыеМестаРаботыToolStripMenuItem.Text = "Прошлые места работы";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.улицыToolStripMenuItem,
            this.институтыToolStripMenuItem,
            this.КафедрыToolStripMenuItem,
            this.степениToolStripMenuItem,
            this.должностиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(107, 23);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // улицыToolStripMenuItem
            // 
            this.улицыToolStripMenuItem.Name = "улицыToolStripMenuItem";
            this.улицыToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.улицыToolStripMenuItem.Text = "Улицы";
            this.улицыToolStripMenuItem.Click += new System.EventHandler(this.улицыToolStripMenuItem_Click);
            // 
            // институтыToolStripMenuItem
            // 
            this.институтыToolStripMenuItem.Name = "институтыToolStripMenuItem";
            this.институтыToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.институтыToolStripMenuItem.Text = "Институты";
            this.институтыToolStripMenuItem.Click += new System.EventHandler(this.институтыToolStripMenuItem_Click);
            // 
            // КафедрыToolStripMenuItem
            // 
            this.КафедрыToolStripMenuItem.Name = "КафедрыToolStripMenuItem";
            this.КафедрыToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.КафедрыToolStripMenuItem.Text = "Кафедры";
            this.КафедрыToolStripMenuItem.Click += new System.EventHandler(this.КафедрыToolStripMenuItem_Click);
            // 
            // степениToolStripMenuItem
            // 
            this.степениToolStripMenuItem.Name = "степениToolStripMenuItem";
            this.степениToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.степениToolStripMenuItem.Text = "Степени";
            this.степениToolStripMenuItem.Click += new System.EventHandler(this.степениToolStripMenuItem_Click);
            // 
            // должностиToolStripMenuItem
            // 
            this.должностиToolStripMenuItem.Name = "должностиToolStripMenuItem";
            this.должностиToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.должностиToolStripMenuItem.Text = "Должности";
            this.должностиToolStripMenuItem.Click += new System.EventHandler(this.должностиToolStripMenuItem_Click);
            // 
            // всеСотрудникиToolStripMenuItem
            // 
            this.всеСотрудникиToolStripMenuItem.Name = "всеСотрудникиToolStripMenuItem";
            this.всеСотрудникиToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.всеСотрудникиToolStripMenuItem.Text = "Все сотрудники";
            this.всеСотрудникиToolStripMenuItem.Click += new System.EventHandler(this.всеСотрудникиToolStripMenuItem_Click);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainMenu_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem улицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem институтыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem КафедрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem степениToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прошлыеМестаРаботыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеСотрудникиToolStripMenuItem;
    }
}