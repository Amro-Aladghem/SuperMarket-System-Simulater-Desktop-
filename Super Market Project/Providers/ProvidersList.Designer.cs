namespace Super_Market_Project.Providers
{
    partial class ProvidersList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProvidersList));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.providerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateProviderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePhoneNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDateOfComingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProviderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.btnUpdatePro = new System.Windows.Forms.Button();
            this.btnAddPro = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(146, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Providers List Managment";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Purple;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.Color.Yellow;
            this.dataGridView1.Location = new System.Drawing.Point(12, 294);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(815, 372);
            this.dataGridView1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.providerInfoToolStripMenuItem,
            this.updateProviderToolStripMenuItem,
            this.changeEmailToolStripMenuItem,
            this.changePhoneNumberToolStripMenuItem,
            this.changeDateOfComingToolStripMenuItem,
            this.deleteProviderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(278, 196);
            // 
            // providerInfoToolStripMenuItem
            // 
            this.providerInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("providerInfoToolStripMenuItem.Image")));
            this.providerInfoToolStripMenuItem.Name = "providerInfoToolStripMenuItem";
            this.providerInfoToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.providerInfoToolStripMenuItem.Text = "Provider Info";
            this.providerInfoToolStripMenuItem.Click += new System.EventHandler(this.providerInfoToolStripMenuItem_Click);
            // 
            // updateProviderToolStripMenuItem
            // 
            this.updateProviderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateProviderToolStripMenuItem.Image")));
            this.updateProviderToolStripMenuItem.Name = "updateProviderToolStripMenuItem";
            this.updateProviderToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.updateProviderToolStripMenuItem.Text = "Update Provider";
            this.updateProviderToolStripMenuItem.Click += new System.EventHandler(this.updateProviderToolStripMenuItem_Click);
            // 
            // changeEmailToolStripMenuItem
            // 
            this.changeEmailToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeEmailToolStripMenuItem.Image")));
            this.changeEmailToolStripMenuItem.Name = "changeEmailToolStripMenuItem";
            this.changeEmailToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.changeEmailToolStripMenuItem.Text = "Change Email";
            this.changeEmailToolStripMenuItem.Click += new System.EventHandler(this.changeEmailToolStripMenuItem_Click);
            // 
            // changePhoneNumberToolStripMenuItem
            // 
            this.changePhoneNumberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePhoneNumberToolStripMenuItem.Image")));
            this.changePhoneNumberToolStripMenuItem.Name = "changePhoneNumberToolStripMenuItem";
            this.changePhoneNumberToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.changePhoneNumberToolStripMenuItem.Text = "Change PhoneNumber";
            this.changePhoneNumberToolStripMenuItem.Click += new System.EventHandler(this.changePhoneNumberToolStripMenuItem_Click);
            // 
            // changeDateOfComingToolStripMenuItem
            // 
            this.changeDateOfComingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeDateOfComingToolStripMenuItem.Image")));
            this.changeDateOfComingToolStripMenuItem.Name = "changeDateOfComingToolStripMenuItem";
            this.changeDateOfComingToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.changeDateOfComingToolStripMenuItem.Text = "Change DateOfComing";
            this.changeDateOfComingToolStripMenuItem.Click += new System.EventHandler(this.changeDateOfComingToolStripMenuItem_Click);
            // 
            // deleteProviderToolStripMenuItem
            // 
            this.deleteProviderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteProviderToolStripMenuItem.Image")));
            this.deleteProviderToolStripMenuItem.Name = "deleteProviderToolStripMenuItem";
            this.deleteProviderToolStripMenuItem.Size = new System.Drawing.Size(277, 32);
            this.deleteProviderToolStripMenuItem.Text = "Delete Provider";
            this.deleteProviderToolStripMenuItem.Click += new System.EventHandler(this.deleteProviderToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(12, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(352, 248);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(215, 27);
            this.txtFilter.TabIndex = 4;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cbxFilter
            // 
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "None",
            "ProviderID",
            "ProviderName"});
            this.cbxFilter.Location = new System.Drawing.Point(154, 248);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(192, 27);
            this.cbxFilter.TabIndex = 5;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Current User:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbUserName.Location = new System.Drawing.Point(123, 9);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(99, 19);
            this.lbUserName.TabIndex = 9;
            this.lbUserName.Text = "UserName:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(683, 672);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 43);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(12, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "#Records:";
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbRecord.Location = new System.Drawing.Point(123, 669);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(23, 24);
            this.lbRecord.TabIndex = 12;
            this.lbRecord.Text = "0";
            // 
            // btnUpdatePro
            // 
            this.btnUpdatePro.BackColor = System.Drawing.Color.White;
            this.btnUpdatePro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdatePro.BackgroundImage")));
            this.btnUpdatePro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdatePro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePro.Location = new System.Drawing.Point(671, 233);
            this.btnUpdatePro.Name = "btnUpdatePro";
            this.btnUpdatePro.Size = new System.Drawing.Size(75, 55);
            this.btnUpdatePro.TabIndex = 7;
            this.btnUpdatePro.UseVisualStyleBackColor = false;
            this.btnUpdatePro.Click += new System.EventHandler(this.btnUpdatePro_Click);
            // 
            // btnAddPro
            // 
            this.btnAddPro.BackColor = System.Drawing.Color.White;
            this.btnAddPro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPro.BackgroundImage")));
            this.btnAddPro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPro.Location = new System.Drawing.Point(752, 233);
            this.btnAddPro.Name = "btnAddPro";
            this.btnAddPro.Size = new System.Drawing.Size(75, 55);
            this.btnAddPro.TabIndex = 6;
            this.btnAddPro.UseVisualStyleBackColor = false;
            this.btnAddPro.Click += new System.EventHandler(this.btnAddPro_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Super_Market_Project.Properties.Resources.product;
            this.pictureBox1.Location = new System.Drawing.Point(313, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ProvidersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(839, 727);
            this.ControlBox = false;
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdatePro);
            this.Controls.Add(this.btnAddPro);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ProvidersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProvidersList";
            this.Load += new System.EventHandler(this.ProvidersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Button btnAddPro;
        private System.Windows.Forms.Button btnUpdatePro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem providerInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateProviderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePhoneNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeDateOfComingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProviderToolStripMenuItem;
    }
}