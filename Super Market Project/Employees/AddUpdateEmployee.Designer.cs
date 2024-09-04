namespace Super_Market_Project
{
    partial class AddUpdateEmployee
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.ctrAddUpdateEmployee1 = new Super_Market_Project.ctrAddUpdateEmployee();
            this.SuspendLayout();
            // 
            // lbAdd_Update
            // 
            this.lbAdd_Update.AutoSize = true;
            this.lbAdd_Update.Font = new System.Drawing.Font("Tahoma", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbAdd_Update.ForeColor = System.Drawing.Color.Black;
            this.lbAdd_Update.Location = new System.Drawing.Point(113, 25);
            this.lbAdd_Update.Name = "lbAdd_Update";
            this.lbAdd_Update.Size = new System.Drawing.Size(369, 39);
            this.lbAdd_Update.TabIndex = 1;
            this.lbAdd_Update.Text = "Add/UpdateEmployee";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(411, 688);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 45);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(35, 688);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current User:\r\n";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbUserName.ForeColor = System.Drawing.Color.Black;
            this.lbUserName.Location = new System.Drawing.Point(174, 688);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(104, 22);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "UserName";
            // 
            // ctrAddUpdateEmployee1
            // 
            this.ctrAddUpdateEmployee1.AutoSize = true;
            this.ctrAddUpdateEmployee1.BackColor = System.Drawing.Color.Purple;
            this.ctrAddUpdateEmployee1.Location = new System.Drawing.Point(39, 87);
            this.ctrAddUpdateEmployee1.Name = "ctrAddUpdateEmployee1";
            this.ctrAddUpdateEmployee1.Size = new System.Drawing.Size(509, 595);
            this.ctrAddUpdateEmployee1.TabIndex = 0;
            this.ctrAddUpdateEmployee1.OnSaveClick += new System.EventHandler<Super_Market_Project.ctrAddUpdateEmployee.OnEmployeeID>(this.ctrAddUpdateEmployee1_OnSaveClick);
            this.ctrAddUpdateEmployee1.Load += new System.EventHandler(this.ctrAddUpdateEmployee1_Load);
            // 
            // AddUpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(586, 741);
            this.ControlBox = false;
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbAdd_Update);
            this.Controls.Add(this.ctrAddUpdateEmployee1);
            this.Name = "AddUpdateEmployee";
            this.Text = "AddUpdateEmployee";
            this.Load += new System.EventHandler(this.AddUpdateEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrAddUpdateEmployee ctrAddUpdateEmployee1=new ctrAddUpdateEmployee();
        private System.Windows.Forms.Label lbAdd_Update;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUserName;
    }
}