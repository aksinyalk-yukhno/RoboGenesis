namespace OutlookDemo.UserControls
{
    partial class UC_Test_Question_Example
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Test_Question_Example));
            this.pbIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.bnOption1 = new Guna.UI2.WinForms.Guna2Button();
            this.bnOption3 = new Guna.UI2.WinForms.Guna2Button();
            this.bnOption2 = new Guna.UI2.WinForms.Guna2Button();
            this.bnOption4 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.BackColor = System.Drawing.Color.White;
            this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
            this.pbIcon.Location = new System.Drawing.Point(17, 42);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.ShadowDecoration.Parent = this.pbIcon;
            this.pbIcon.Size = new System.Drawing.Size(796, 168);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescription.Location = new System.Drawing.Point(15, 3);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(813, 44);
            this.lblDescription.TabIndex = 39;
            this.lblDescription.Text = "Вопрос";
            // 
            // bnOption1
            // 
            this.bnOption1.Animated = true;
            this.bnOption1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bnOption1.BorderRadius = 5;
            this.bnOption1.BorderThickness = 2;
            this.bnOption1.CheckedState.Parent = this.bnOption1;
            this.bnOption1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnOption1.CustomImages.Parent = this.bnOption1;
            this.bnOption1.FillColor = System.Drawing.Color.White;
            this.bnOption1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bnOption1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bnOption1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption1.HoverState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bnOption1.HoverState.Parent = this.bnOption1;
            this.bnOption1.ImageSize = new System.Drawing.Size(23, 22);
            this.bnOption1.Location = new System.Drawing.Point(37, 228);
            this.bnOption1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnOption1.Name = "bnOption1";
            this.bnOption1.ShadowDecoration.Parent = this.bnOption1;
            this.bnOption1.Size = new System.Drawing.Size(370, 77);
            this.bnOption1.TabIndex = 50;
            this.bnOption1.Text = "Ответ №1";
            this.bnOption1.Click += new System.EventHandler(this.bnOption1_Click);
            this.bnOption1.DoubleClick += new System.EventHandler(this.bnOption1_DoubleClick);
            // 
            // bnOption3
            // 
            this.bnOption3.Animated = true;
            this.bnOption3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bnOption3.BorderRadius = 5;
            this.bnOption3.BorderThickness = 2;
            this.bnOption3.CheckedState.Parent = this.bnOption3;
            this.bnOption3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnOption3.CustomImages.Parent = this.bnOption3;
            this.bnOption3.FillColor = System.Drawing.Color.White;
            this.bnOption3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bnOption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bnOption3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption3.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption3.HoverState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bnOption3.HoverState.Parent = this.bnOption3;
            this.bnOption3.ImageSize = new System.Drawing.Size(23, 22);
            this.bnOption3.Location = new System.Drawing.Point(37, 323);
            this.bnOption3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnOption3.Name = "bnOption3";
            this.bnOption3.ShadowDecoration.Parent = this.bnOption3;
            this.bnOption3.Size = new System.Drawing.Size(370, 77);
            this.bnOption3.TabIndex = 51;
            this.bnOption3.Text = "Ответ №3";
            this.bnOption3.Click += new System.EventHandler(this.bnOption3_Click);
            this.bnOption3.DoubleClick += new System.EventHandler(this.bnOption3_DoubleClick);
            // 
            // bnOption2
            // 
            this.bnOption2.Animated = true;
            this.bnOption2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bnOption2.BorderRadius = 5;
            this.bnOption2.BorderThickness = 2;
            this.bnOption2.CheckedState.Parent = this.bnOption2;
            this.bnOption2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnOption2.CustomImages.Parent = this.bnOption2;
            this.bnOption2.FillColor = System.Drawing.Color.White;
            this.bnOption2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bnOption2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bnOption2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption2.HoverState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bnOption2.HoverState.Parent = this.bnOption2;
            this.bnOption2.ImageSize = new System.Drawing.Size(23, 22);
            this.bnOption2.Location = new System.Drawing.Point(425, 228);
            this.bnOption2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnOption2.Name = "bnOption2";
            this.bnOption2.ShadowDecoration.Parent = this.bnOption2;
            this.bnOption2.Size = new System.Drawing.Size(370, 77);
            this.bnOption2.TabIndex = 52;
            this.bnOption2.Text = "Ответ №2";
            this.bnOption2.Click += new System.EventHandler(this.bnOption2_Click);
            this.bnOption2.DoubleClick += new System.EventHandler(this.bnOption2_DoubleClick);
            // 
            // bnOption4
            // 
            this.bnOption4.Animated = true;
            this.bnOption4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bnOption4.BorderRadius = 5;
            this.bnOption4.BorderThickness = 2;
            this.bnOption4.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption4.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption4.CheckedState.Parent = this.bnOption4;
            this.bnOption4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnOption4.CustomImages.Parent = this.bnOption4;
            this.bnOption4.FillColor = System.Drawing.Color.White;
            this.bnOption4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bnOption4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bnOption4.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption4.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.bnOption4.HoverState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bnOption4.HoverState.Parent = this.bnOption4;
            this.bnOption4.ImageSize = new System.Drawing.Size(23, 22);
            this.bnOption4.Location = new System.Drawing.Point(425, 323);
            this.bnOption4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bnOption4.Name = "bnOption4";
            this.bnOption4.ShadowDecoration.Parent = this.bnOption4;
            this.bnOption4.Size = new System.Drawing.Size(370, 77);
            this.bnOption4.TabIndex = 53;
            this.bnOption4.Text = "Ответ №4";
            this.bnOption4.Click += new System.EventHandler(this.bnOption4_Click);
            this.bnOption4.DoubleClick += new System.EventHandler(this.bnOption4_DoubleClick);
            // 
            // UC_Test_Question_Example
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bnOption4);
            this.Controls.Add(this.bnOption2);
            this.Controls.Add(this.bnOption3);
            this.Controls.Add(this.bnOption1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pbIcon);
            this.Name = "UC_Test_Question_Example";
            this.Size = new System.Drawing.Size(846, 441);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pbIcon;
        private System.Windows.Forms.Label lblDescription;
        private Guna.UI2.WinForms.Guna2Button bnOption1;
        private Guna.UI2.WinForms.Guna2Button bnOption3;
        private Guna.UI2.WinForms.Guna2Button bnOption2;
        private Guna.UI2.WinForms.Guna2Button bnOption4;
    }
}
