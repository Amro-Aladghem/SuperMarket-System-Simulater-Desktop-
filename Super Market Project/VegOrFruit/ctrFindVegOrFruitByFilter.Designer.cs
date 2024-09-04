namespace Super_Market_Project.VegOrFruit
{
    partial class ctrFindVegOrFruitByFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrFindVegOrFruitByFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbEnter = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnDateSearch = new System.Windows.Forms.Button();
            this.ctrVegOrFruitInfo1 = new Super_Market_Project.VegOrFruit.ctrVegOrFruitInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "VegORFruitQR:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(230, 23);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(489, 27);
            this.txtFilter.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(725, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 55);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbEnter
            // 
            this.lbEnter.AutoSize = true;
            this.lbEnter.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbEnter.ForeColor = System.Drawing.Color.White;
            this.lbEnter.Location = new System.Drawing.Point(139, 77);
            this.lbEnter.Name = "lbEnter";
            this.lbEnter.Size = new System.Drawing.Size(204, 27);
            this.lbEnter.TabIndex = 4;
            this.lbEnter.Text = "Enter EnrollDate:";
            this.lbEnter.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(340, 77);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(231, 27);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.Visible = false;
            // 
            // btnDateSearch
            // 
            this.btnDateSearch.BackColor = System.Drawing.Color.White;
            this.btnDateSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDateSearch.BackgroundImage")));
            this.btnDateSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDateSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDateSearch.Location = new System.Drawing.Point(577, 73);
            this.btnDateSearch.Name = "btnDateSearch";
            this.btnDateSearch.Size = new System.Drawing.Size(45, 39);
            this.btnDateSearch.TabIndex = 6;
            this.btnDateSearch.UseVisualStyleBackColor = false;
            this.btnDateSearch.Visible = false;
            this.btnDateSearch.Click += new System.EventHandler(this.btnDateSearch_Click);
            // 
            // ctrVegOrFruitInfo1
            // 
            this.ctrVegOrFruitInfo1.BackColor = System.Drawing.Color.Gold;
            this.ctrVegOrFruitInfo1.Location = new System.Drawing.Point(15, 128);
            this.ctrVegOrFruitInfo1.Name = "ctrVegOrFruitInfo1";
            this.ctrVegOrFruitInfo1.Size = new System.Drawing.Size(830, 386);
            this.ctrVegOrFruitInfo1.TabIndex = 0;
            // 
            // ctrFindVegOrFruitByFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.Controls.Add(this.btnDateSearch);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lbEnter);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrVegOrFruitInfo1);
            this.Name = "ctrFindVegOrFruitByFilter";
            this.Size = new System.Drawing.Size(861, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrVegOrFruitInfo ctrVegOrFruitInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lbEnter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnDateSearch;
    }
}
