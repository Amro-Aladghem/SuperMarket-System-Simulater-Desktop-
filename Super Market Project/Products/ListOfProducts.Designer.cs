namespace Super_Market_Project.Products
{
    partial class ListOfProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfProducts));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCurrentUser = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.updateProductPriceQuantityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProductFromStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productInfromationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isExpiredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.providerDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label1.Location = new System.Drawing.Point(297, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(619, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "List Of All Products in storage";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 264);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1156, 408);
            this.dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By:";
            // 
            // cbxFilter
            // 
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "None",
            "ProductID",
            "ProductQR",
            "ProductName",
            "ProviderID",
            "Price",
            "Quantity"});
            this.cbxFilter.Location = new System.Drawing.Point(150, 230);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(201, 27);
            this.cbxFilter.TabIndex = 4;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(357, 230);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(239, 28);
            this.txtFilter.TabIndex = 5;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(6, 675);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "#Records:";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbRecords.Location = new System.Drawing.Point(121, 675);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(23, 24);
            this.lbRecords.TabIndex = 9;
            this.lbRecords.Text = "0";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1063, 675);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 42);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "CurrentUser:";
            // 
            // lbCurrentUser
            // 
            this.lbCurrentUser.AutoSize = true;
            this.lbCurrentUser.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbCurrentUser.Location = new System.Drawing.Point(154, 12);
            this.lbCurrentUser.Name = "lbCurrentUser";
            this.lbCurrentUser.Size = new System.Drawing.Size(114, 24);
            this.lbCurrentUser.TabIndex = 12;
            this.lbCurrentUser.Text = "UserName";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateProductPriceQuantityToolStripMenuItem,
            this.deleteProductFromStorageToolStripMenuItem,
            this.productInfromationToolStripMenuItem,
            this.isExpiredToolStripMenuItem,
            this.providerDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(340, 164);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(1000, 190);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 64);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(1098, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 64);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // updateProductPriceQuantityToolStripMenuItem
            // 
            this.updateProductPriceQuantityToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateProductPriceQuantityToolStripMenuItem.Image")));
            this.updateProductPriceQuantityToolStripMenuItem.Name = "updateProductPriceQuantityToolStripMenuItem";
            this.updateProductPriceQuantityToolStripMenuItem.Size = new System.Drawing.Size(339, 32);
            this.updateProductPriceQuantityToolStripMenuItem.Text = "Update Product(Price/Quantity)";
            this.updateProductPriceQuantityToolStripMenuItem.Click += new System.EventHandler(this.updateProductPriceQuantityToolStripMenuItem_Click);
            // 
            // deleteProductFromStorageToolStripMenuItem
            // 
            this.deleteProductFromStorageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteProductFromStorageToolStripMenuItem.Image")));
            this.deleteProductFromStorageToolStripMenuItem.Name = "deleteProductFromStorageToolStripMenuItem";
            this.deleteProductFromStorageToolStripMenuItem.Size = new System.Drawing.Size(339, 32);
            this.deleteProductFromStorageToolStripMenuItem.Text = "Delete Product from Storage";
            this.deleteProductFromStorageToolStripMenuItem.Click += new System.EventHandler(this.deleteProductFromStorageToolStripMenuItem_Click);
            // 
            // productInfromationToolStripMenuItem
            // 
            this.productInfromationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("productInfromationToolStripMenuItem.Image")));
            this.productInfromationToolStripMenuItem.Name = "productInfromationToolStripMenuItem";
            this.productInfromationToolStripMenuItem.Size = new System.Drawing.Size(339, 32);
            this.productInfromationToolStripMenuItem.Text = "Product Infromation";
            this.productInfromationToolStripMenuItem.Click += new System.EventHandler(this.productInfromationToolStripMenuItem_Click);
            // 
            // isExpiredToolStripMenuItem
            // 
            this.isExpiredToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("isExpiredToolStripMenuItem.Image")));
            this.isExpiredToolStripMenuItem.Name = "isExpiredToolStripMenuItem";
            this.isExpiredToolStripMenuItem.Size = new System.Drawing.Size(339, 32);
            this.isExpiredToolStripMenuItem.Text = "Is Expired";
            this.isExpiredToolStripMenuItem.Click += new System.EventHandler(this.isExpiredToolStripMenuItem_Click);
            // 
            // providerDetailsToolStripMenuItem
            // 
            this.providerDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("providerDetailsToolStripMenuItem.Image")));
            this.providerDetailsToolStripMenuItem.Name = "providerDetailsToolStripMenuItem";
            this.providerDetailsToolStripMenuItem.Size = new System.Drawing.Size(339, 32);
            this.providerDetailsToolStripMenuItem.Text = "Provider Details";
            this.providerDetailsToolStripMenuItem.Click += new System.EventHandler(this.providerDetailsToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(522, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ListOfProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(1180, 722);
            this.ControlBox = false;
            this.Controls.Add(this.lbCurrentUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "ListOfProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListOfProducts";
            this.Load += new System.EventHandler(this.ListOfProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCurrentUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateProductPriceQuantityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProductFromStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productInfromationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isExpiredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem providerDetailsToolStripMenuItem;
    }
}