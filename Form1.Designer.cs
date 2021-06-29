
namespace Repin_kursovaya
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Primitives_List = new System.Windows.Forms.ListBox();
            this.Operation_List = new System.Windows.Forms.ListBox();
            this.TMO_List = new System.Windows.Forms.ListBox();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.Color_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Mode_List = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Primitives_List
            // 
            this.Primitives_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Primitives_List.FormattingEnabled = true;
            this.Primitives_List.Items.AddRange(new object[] {
            "Отрезок прямой",
            "Кривая Эрмита",
            "Правильный крест",
            "Флаг"});
            this.Primitives_List.Location = new System.Drawing.Point(668, 94);
            this.Primitives_List.Name = "Primitives_List";
            this.Primitives_List.Size = new System.Drawing.Size(120, 56);
            this.Primitives_List.TabIndex = 0;
            this.Primitives_List.SelectedIndexChanged += new System.EventHandler(this.Primitives_List_SelectedIndexChanged);
            // 
            // Operation_List
            // 
            this.Operation_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Operation_List.Enabled = false;
            this.Operation_List.FormattingEnabled = true;
            this.Operation_List.Items.AddRange(new object[] {
            "Перемещение",
            "Поворот ",
            "Поворот 60°",
            "Масштабирование"});
            this.Operation_List.Location = new System.Drawing.Point(668, 173);
            this.Operation_List.Name = "Operation_List";
            this.Operation_List.Size = new System.Drawing.Size(120, 56);
            this.Operation_List.TabIndex = 1;
            this.Operation_List.SelectedIndexChanged += new System.EventHandler(this.Operation_List_SelectedIndexChanged);
            // 
            // TMO_List
            // 
            this.TMO_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TMO_List.Enabled = false;
            this.TMO_List.FormattingEnabled = true;
            this.TMO_List.Items.AddRange(new object[] {
            "Объединение",
            "Разность"});
            this.TMO_List.Location = new System.Drawing.Point(668, 252);
            this.TMO_List.Name = "TMO_List";
            this.TMO_List.Size = new System.Drawing.Size(120, 30);
            this.TMO_List.TabIndex = 2;
            this.TMO_List.SelectedIndexChanged += new System.EventHandler(this.TMO_List_SelectedIndexChanged);
            // 
            // Clear_Button
            // 
            this.Clear_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_Button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Clear_Button.Location = new System.Drawing.Point(668, 326);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(120, 23);
            this.Clear_Button.TabIndex = 3;
            this.Clear_Button.Text = "Очистить";
            this.Clear_Button.UseVisualStyleBackColor = false;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // Color_Button
            // 
            this.Color_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Color_Button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Color_Button.Location = new System.Drawing.Point(668, 355);
            this.Color_Button.Name = "Color_Button";
            this.Color_Button.Size = new System.Drawing.Size(120, 23);
            this.Color_Button.TabIndex = 4;
            this.Color_Button.Text = "Цвет";
            this.Color_Button.UseVisualStyleBackColor = false;
            this.Color_Button.Click += new System.EventHandler(this.Color_Button_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.MinimumSize = new System.Drawing.Size(650, 355);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 366);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(650, 355);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 366);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Mode_List
            // 
            this.Mode_List.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Mode_List.FormattingEnabled = true;
            this.Mode_List.Items.AddRange(new object[] {
            "Ввод ",
            "Операция ",
            "ТМО"});
            this.Mode_List.Location = new System.Drawing.Point(668, 28);
            this.Mode_List.Name = "Mode_List";
            this.Mode_List.Size = new System.Drawing.Size(120, 43);
            this.Mode_List.TabIndex = 6;
            this.Mode_List.SelectedIndexChanged += new System.EventHandler(this.Mode_List_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(668, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выбор режима";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(668, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выбор примитива";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Выбор операции";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(665, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Выбор ТМО";
            // 
            // Delete_Button
            // 
            this.Delete_Button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Delete_Button.Location = new System.Drawing.Point(668, 297);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(120, 23);
            this.Delete_Button.TabIndex = 11;
            this.Delete_Button.Text = "Удалить";
            this.Delete_Button.UseVisualStyleBackColor = false;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 384);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Mode_List);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Color_Button);
            this.Controls.Add(this.Clear_Button);
            this.Controls.Add(this.TMO_List);
            this.Controls.Add(this.Operation_List);
            this.Controls.Add(this.Primitives_List);
            this.MinimumSize = new System.Drawing.Size(816, 416);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Primitives_List;
        private System.Windows.Forms.ListBox Operation_List;
        private System.Windows.Forms.ListBox TMO_List;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Button Color_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListBox Mode_List;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Delete_Button;
    }
}

