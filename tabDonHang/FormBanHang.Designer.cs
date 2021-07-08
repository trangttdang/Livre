namespace tabDonHang
{
    partial class FormBanHang
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
            this.btnOKBan = new System.Windows.Forms.Button();
            this.lblSoluong = new System.Windows.Forms.Label();
            this.txtSLBan = new System.Windows.Forms.TextBox();
            this.lblSLtonkho = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOKBan
            // 
            this.btnOKBan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKBan.Location = new System.Drawing.Point(444, 66);
            this.btnOKBan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOKBan.Name = "btnOKBan";
            this.btnOKBan.Size = new System.Drawing.Size(112, 35);
            this.btnOKBan.TabIndex = 8;
            this.btnOKBan.Text = "OK";
            this.btnOKBan.UseVisualStyleBackColor = true;
            this.btnOKBan.Click += new System.EventHandler(this.btnOKBan_Click);
            // 
            // lblSoluong
            // 
            this.lblSoluong.AutoSize = true;
            this.lblSoluong.Location = new System.Drawing.Point(72, 74);
            this.lblSoluong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoluong.Name = "lblSoluong";
            this.lblSoluong.Size = new System.Drawing.Size(68, 20);
            this.lblSoluong.TabIndex = 7;
            this.lblSoluong.Text = "Quantity";
            // 
            // txtSLBan
            // 
            this.txtSLBan.Location = new System.Drawing.Point(213, 69);
            this.txtSLBan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSLBan.Name = "txtSLBan";
            this.txtSLBan.Size = new System.Drawing.Size(148, 26);
            this.txtSLBan.TabIndex = 6;
            this.txtSLBan.TextChanged += new System.EventHandler(this.txtSLBan_TextChanged);
            this.txtSLBan.Leave += new System.EventHandler(this.txtSLBan_Leave);
            // 
            // lblSLtonkho
            // 
            this.lblSLtonkho.AutoSize = true;
            this.lblSLtonkho.Location = new System.Drawing.Point(238, 115);
            this.lblSLtonkho.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSLtonkho.Name = "lblSLtonkho";
            this.lblSLtonkho.Size = new System.Drawing.Size(0, 20);
            this.lblSLtonkho.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Inventory Quantity";
            // 
            // FormBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 175);
            this.Controls.Add(this.lblSLtonkho);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOKBan);
            this.Controls.Add(this.lblSoluong);
            this.Controls.Add(this.txtSLBan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBanHang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOKBan;
        private System.Windows.Forms.Label lblSoluong;
        private System.Windows.Forms.TextBox txtSLBan;
        private System.Windows.Forms.Label lblSLtonkho;
        private System.Windows.Forms.Label label1;
    }
}