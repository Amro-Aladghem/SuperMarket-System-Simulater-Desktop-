namespace Super_Market_Project.Providers
{
    partial class ctrAddUpdateProvider
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbProviderID = new System.Windows.Forms.Label();
            this.txtProName = new System.Windows.Forms.TextBox();
            this.txtPhonNumber = new System.Windows.Forms.TextBox();
            this.txtEmial = new System.Windows.Forms.TextBox();
            this.txtDateOfComing = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provider ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Provider Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Provider Emial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Date Of Coming:";
            // 
            // lbProviderID
            // 
            this.lbProviderID.AutoSize = true;
            this.lbProviderID.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbProviderID.ForeColor = System.Drawing.Color.White;
            this.lbProviderID.Location = new System.Drawing.Point(263, 22);
            this.lbProviderID.Name = "lbProviderID";
            this.lbProviderID.Size = new System.Drawing.Size(67, 31);
            this.lbProviderID.TabIndex = 5;
            this.lbProviderID.Text = "N/A";
            // 
            // txtProName
            // 
            this.txtProName.Location = new System.Drawing.Point(269, 89);
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(232, 27);
            this.txtProName.TabIndex = 6;
            this.txtProName.Validating += new System.ComponentModel.CancelEventHandler(this.txtProName_Validating);
            // 
            // txtPhonNumber
            // 
            this.txtPhonNumber.Location = new System.Drawing.Point(269, 156);
            this.txtPhonNumber.MaxLength = 10;
            this.txtPhonNumber.Name = "txtPhonNumber";
            this.txtPhonNumber.Size = new System.Drawing.Size(232, 27);
            this.txtPhonNumber.TabIndex = 7;
            this.txtPhonNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhonNumber_Validating);
            // 
            // txtEmial
            // 
            this.txtEmial.Location = new System.Drawing.Point(269, 219);
            this.txtEmial.Name = "txtEmial";
            this.txtEmial.Size = new System.Drawing.Size(232, 27);
            this.txtEmial.TabIndex = 8;
            this.txtEmial.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmial_Validating);
            // 
            // txtDateOfComing
            // 
            this.txtDateOfComing.Location = new System.Drawing.Point(269, 289);
            this.txtDateOfComing.Multiline = true;
            this.txtDateOfComing.Name = "txtDateOfComing";
            this.txtDateOfComing.Size = new System.Drawing.Size(232, 85);
            this.txtDateOfComing.TabIndex = 9;
            this.txtDateOfComing.Validating += new System.ComponentModel.CancelEventHandler(this.txtDateOfComing_Validating);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(361, 391);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrAddUpdateProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDateOfComing);
            this.Controls.Add(this.txtEmial);
            this.Controls.Add(this.txtPhonNumber);
            this.Controls.Add(this.txtProName);
            this.Controls.Add(this.lbProviderID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrAddUpdateProvider";
            this.Size = new System.Drawing.Size(515, 449);
            this.Load += new System.EventHandler(this.ctrAddUpdateProvider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbProviderID;
        private System.Windows.Forms.TextBox txtProName;
        private System.Windows.Forms.TextBox txtPhonNumber;
        private System.Windows.Forms.TextBox txtEmial;
        private System.Windows.Forms.TextBox txtDateOfComing;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
