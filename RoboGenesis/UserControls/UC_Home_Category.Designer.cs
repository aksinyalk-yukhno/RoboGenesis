using System.Windows.Forms;

namespace RoboGenesis.UserControls
{
    partial class UC_Home_Category
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
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2Button4
            // 
            this.guna2Button4.Animated = true;
            this.guna2Button4.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2Button4.BorderRadius = 7;
            this.guna2Button4.BorderThickness = 2;
            this.guna2Button4.CheckedState.Parent = this.guna2Button4;
            this.guna2Button4.CustomImages.Parent = this.guna2Button4;
            this.guna2Button4.FillColor = System.Drawing.Color.White;
            this.guna2Button4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2Button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button4.HoverState.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2Button4.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button4.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button4.HoverState.Parent = this.guna2Button4;
            this.guna2Button4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button4.Location = new System.Drawing.Point(0, 0);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.PressedColor = System.Drawing.SystemColors.MenuHighlight;
            this.guna2Button4.ShadowDecoration.Parent = this.guna2Button4;
            this.guna2Button4.Size = new System.Drawing.Size(171, 24);
            this.guna2Button4.TabIndex = 22;
            this.guna2Button4.Text = "Мастерская";
            this.guna2Button4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button4.TextOffset = new System.Drawing.Point(0, -1);
            this.guna2Button4.Click += new System.EventHandler(this.guna2Button4_Click);
            this.guna2Button4.Resize += new System.EventHandler(this.Guna2Button4_Resize);
            // 
            // UC_Home_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Button4);
            this.Name = "UC_Home_Category";
            this.Size = new System.Drawing.Size(171, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button4;
    }
}
