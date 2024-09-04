namespace Super_Market_Project.VegOrFruit
{
    partial class VegOrFruitInfromation
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrVegOrFruitInfo1 = new Super_Market_Project.VegOrFruit.ctrVegOrFruitInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(519, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veg Or Fruit Information";
            // 
            // ctrVegOrFruitInfo1
            // 
            this.ctrVegOrFruitInfo1.BackColor = System.Drawing.Color.Purple;
            this.ctrVegOrFruitInfo1.Location = new System.Drawing.Point(40, 101);
            this.ctrVegOrFruitInfo1.Name = "ctrVegOrFruitInfo1";
            this.ctrVegOrFruitInfo1.Size = new System.Drawing.Size(900, 394);
            this.ctrVegOrFruitInfo1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(790, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 41);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // VegOrFruitInfromation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(971, 547);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrVegOrFruitInfo1);
            this.Controls.Add(this.label1);
            this.Name = "VegOrFruitInfromation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VegOrFruitInfromation";
            this.Load += new System.EventHandler(this.VegOrFruitInfromation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ctrVegOrFruitInfo ctrVegOrFruitInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}