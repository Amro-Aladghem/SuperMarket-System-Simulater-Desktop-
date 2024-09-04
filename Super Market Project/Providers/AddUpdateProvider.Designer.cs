namespace Super_Market_Project.Providers
{
    partial class AddUpdateProvider
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
            this.lbAdd_Update = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrAddUpdateProvider1 = new Super_Market_Project.Providers.ctrAddUpdateProvider();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAdd_Update
            // 
            this.lbAdd_Update.AutoSize = true;
            this.lbAdd_Update.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdd_Update.Location = new System.Drawing.Point(181, 9);
            this.lbAdd_Update.Name = "lbAdd_Update";
            this.lbAdd_Update.Size = new System.Drawing.Size(212, 39);
            this.lbAdd_Update.TabIndex = 1;
            this.lbAdd_Update.Text = "Add/Update";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(232, 633);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 42);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Super_Market_Project.Properties.Resources.transaction;
            this.pictureBox1.Location = new System.Drawing.Point(197, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ctrAddUpdateProvider1
            // 
            this.ctrAddUpdateProvider1.BackColor = System.Drawing.Color.Purple;
            this.ctrAddUpdateProvider1.Location = new System.Drawing.Point(25, 178);
            this.ctrAddUpdateProvider1.Name = "ctrAddUpdateProvider1";
            this.ctrAddUpdateProvider1.Size = new System.Drawing.Size(515, 449);
            this.ctrAddUpdateProvider1.TabIndex = 0;
            this.ctrAddUpdateProvider1.OnSaveClick += new System.EventHandler<Super_Market_Project.Providers.ctrAddUpdateProvider.GetUpdateProvider>(this.ctrAddUpdateProvider1_OnSaveClick);
            // 
            // AddUpdateProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(563, 679);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbAdd_Update);
            this.Controls.Add(this.ctrAddUpdateProvider1);
            this.Name = "AddUpdateProvider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUpdateProvider";
            this.Load += new System.EventHandler(this.AddUpdateProvider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrAddUpdateProvider ctrAddUpdateProvider1;
        private System.Windows.Forms.Label lbAdd_Update;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
    }
}