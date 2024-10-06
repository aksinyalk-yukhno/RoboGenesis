namespace RoboGenesis.UserControls
{
    partial class UC_Test_Result
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bnCloseResult = new Guna.UI2.WinForms.Guna2Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPerNumber = new System.Windows.Forms.Label();
            this.lblCorrectNumber = new System.Windows.Forms.Label();
            this.lblWrongNumber = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnCloseResult
            // 
            this.bnCloseResult.Animated = true;
            this.bnCloseResult.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bnCloseResult.BorderRadius = 5;
            this.bnCloseResult.BorderThickness = 2;
            this.bnCloseResult.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnCloseResult.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnCloseResult.CheckedState.Parent = this.bnCloseResult;
            this.bnCloseResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnCloseResult.CustomImages.Parent = this.bnCloseResult;
            this.bnCloseResult.FillColor = System.Drawing.Color.White;
            this.bnCloseResult.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bnCloseResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bnCloseResult.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnCloseResult.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnCloseResult.HoverState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bnCloseResult.HoverState.Parent = this.bnCloseResult;
            this.bnCloseResult.ImageSize = new System.Drawing.Size(23, 22);
            this.bnCloseResult.Location = new System.Drawing.Point(9, 379);
            this.bnCloseResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnCloseResult.Name = "bnCloseResult";
            this.bnCloseResult.ShadowDecoration.Parent = this.bnCloseResult;
            this.bnCloseResult.Size = new System.Drawing.Size(830, 37);
            this.bnCloseResult.TabIndex = 59;
            this.bnCloseResult.Text = "ОК";
            this.bnCloseResult.Click += new System.EventHandler(this.bnCloseResult_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoEllipsis = true;
            this.lbl1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl1.Location = new System.Drawing.Point(17, 5);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(262, 44);
            this.lbl1.TabIndex = 55;
            this.lbl1.Text = "Ваши результаты: ";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(18, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 44);
            this.label1.TabIndex = 60;
            this.label1.Text = "Правильных ответов:";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(19, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 44);
            this.label2.TabIndex = 61;
            this.label2.Text = "Неправильных ответов:";
            // 
            // lblPerNumber
            // 
            this.lblPerNumber.AutoEllipsis = true;
            this.lblPerNumber.Font = new System.Drawing.Font("Century Gothic", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPerNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPerNumber.Location = new System.Drawing.Point(233, 4);
            this.lblPerNumber.Name = "lblPerNumber";
            this.lblPerNumber.Size = new System.Drawing.Size(429, 44);
            this.lblPerNumber.TabIndex = 62;
            this.lblPerNumber.Text = "100%";
            // 
            // lblCorrectNumber
            // 
            this.lblCorrectNumber.AutoEllipsis = true;
            this.lblCorrectNumber.Font = new System.Drawing.Font("Century Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCorrectNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCorrectNumber.Location = new System.Drawing.Point(234, 52);
            this.lblCorrectNumber.Name = "lblCorrectNumber";
            this.lblCorrectNumber.Size = new System.Drawing.Size(129, 31);
            this.lblCorrectNumber.TabIndex = 63;
            this.lblCorrectNumber.Text = "7";
            // 
            // lblWrongNumber
            // 
            this.lblWrongNumber.AutoEllipsis = true;
            this.lblWrongNumber.Font = new System.Drawing.Font("Century Gothic", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWrongNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblWrongNumber.Location = new System.Drawing.Point(259, 83);
            this.lblWrongNumber.Name = "lblWrongNumber";
            this.lblWrongNumber.Size = new System.Drawing.Size(143, 38);
            this.lblWrongNumber.TabIndex = 64;
            this.lblWrongNumber.Text = "2";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescription.Location = new System.Drawing.Point(10, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 23);
            this.lblDescription.TabIndex = 65;
            this.lblDescription.Text = "Детали";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Location = new System.Drawing.Point(9, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 258);
            this.panel1.TabIndex = 66;
            // 
            // UC_Test_Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblWrongNumber);
            this.Controls.Add(this.lblCorrectNumber);
            this.Controls.Add(this.lblPerNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnCloseResult);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Test_Result";
            this.Size = new System.Drawing.Size(846, 441);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button bnCloseResult;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPerNumber;
        private System.Windows.Forms.Label lblCorrectNumber;
        private System.Windows.Forms.Label lblWrongNumber;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panel1;
    }
}
