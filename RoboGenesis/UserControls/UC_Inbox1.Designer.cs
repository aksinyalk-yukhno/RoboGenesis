namespace OutlookDemo.UserControls
{
    partial class UC_Inbox1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Inbox1));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.uC_Inbox21 = new OutlookDemo.UserControls.UC_Inbox2();
            this.uC_InboxAuthorization1 = new OutlookDemo.UserControls.UC_InboxAuthorization();
            this.panelContent.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 24;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.panelContent;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.uC_Inbox21);
            this.panelContent.Controls.Add(this.panelContainer);
            this.panelContent.Controls.Add(this.guna2Panel2);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.label2);
            this.panelContent.Controls.Add(this.guna2PictureBox1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(901, 608);
            this.panelContent.TabIndex = 2;
            // 
            // panelContainer
            // 
            this.panelContainer.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.panelContainer.BorderThickness = 1;
            this.panelContainer.Controls.Add(this.uC_InboxAuthorization1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelContainer.Location = new System.Drawing.Point(598, 35);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.ShadowDecoration.Parent = this.panelContainer;
            this.panelContainer.Size = new System.Drawing.Size(303, 573);
            this.panelContainer.TabIndex = 10;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(901, 35);
            this.guna2Panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(38, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(571, 57);
            this.label3.TabIndex = 4;
            this.label3.Text = "Зарегистрируйтесь или пройдите авторизацию, чтобы увидеть вашу статистику.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(35, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(574, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Добро пожаловать в «RoboGenesis» !\r\n";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(42, 155);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(516, 450);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 12;
            this.guna2PictureBox1.TabStop = false;
            // 
            // uC_Inbox21
            // 
            this.uC_Inbox21.BackColor = System.Drawing.Color.White;
            this.uC_Inbox21.Location = new System.Drawing.Point(0, 0);
            this.uC_Inbox21.Margin = new System.Windows.Forms.Padding(0);
            this.uC_Inbox21.Name = "uC_Inbox21";
            this.uC_Inbox21.Size = new System.Drawing.Size(901, 608);
            this.uC_Inbox21.TabIndex = 11;
            this.uC_Inbox21.Visible = false;
            // 
            // uC_InboxAuthorization1
            // 
            this.uC_InboxAuthorization1.BackColor = System.Drawing.Color.White;
            this.uC_InboxAuthorization1.Location = new System.Drawing.Point(2, 0);
            this.uC_InboxAuthorization1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_InboxAuthorization1.Name = "uC_InboxAuthorization1";
            this.uC_InboxAuthorization1.Size = new System.Drawing.Size(65535, 65535);
            this.uC_InboxAuthorization1.TabIndex = 0;
            // 
            // UC_Inbox1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelContent);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Inbox1";
            this.Size = new System.Drawing.Size(901, 608);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Panel panelContainer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private UC_InboxAuthorization uC_InboxAuthorization1;
        private UC_Inbox2 uC_Inbox21;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
