namespace TravelExpertsGUI
{
    partial class frmAddEditPackages
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPkgID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtPkgName = new System.Windows.Forms.TextBox();
            this.txtPkgStart = new System.Windows.Forms.TextBox();
            this.txtPkgCommision = new System.Windows.Forms.TextBox();
            this.txtPkgPrice = new System.Windows.Forms.TextBox();
            this.txtPkgDesc = new System.Windows.Forms.TextBox();
            this.txtPkgEnd = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Package ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(88, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Package Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Package Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Package End Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Package Description:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 276);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Package Base Price:";
            // 
            // txtPkgID
            // 
            this.txtPkgID.Location = new System.Drawing.Point(342, 58);
            this.txtPkgID.Name = "txtPkgID";
            this.txtPkgID.Size = new System.Drawing.Size(417, 29);
            this.txtPkgID.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 315);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(208, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Package Agency Commision:";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(420, 445);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 35);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtPkgName
            // 
            this.txtPkgName.Location = new System.Drawing.Point(342, 100);
            this.txtPkgName.Name = "txtPkgName";
            this.txtPkgName.Size = new System.Drawing.Size(417, 29);
            this.txtPkgName.TabIndex = 10;
            // 
            // txtPkgStart
            // 
            this.txtPkgStart.Location = new System.Drawing.Point(342, 142);
            this.txtPkgStart.Name = "txtPkgStart";
            this.txtPkgStart.Size = new System.Drawing.Size(417, 29);
            this.txtPkgStart.TabIndex = 11;
            // 
            // txtPkgCommision
            // 
            this.txtPkgCommision.Location = new System.Drawing.Point(342, 307);
            this.txtPkgCommision.Name = "txtPkgCommision";
            this.txtPkgCommision.Size = new System.Drawing.Size(417, 29);
            this.txtPkgCommision.TabIndex = 12;
            // 
            // txtPkgPrice
            // 
            this.txtPkgPrice.Location = new System.Drawing.Point(342, 268);
            this.txtPkgPrice.Name = "txtPkgPrice";
            this.txtPkgPrice.Size = new System.Drawing.Size(417, 29);
            this.txtPkgPrice.TabIndex = 13;
            // 
            // txtPkgDesc
            // 
            this.txtPkgDesc.Location = new System.Drawing.Point(342, 226);
            this.txtPkgDesc.Name = "txtPkgDesc";
            this.txtPkgDesc.Size = new System.Drawing.Size(417, 29);
            this.txtPkgDesc.TabIndex = 14;
            // 
            // txtPkgEnd
            // 
            this.txtPkgEnd.Location = new System.Drawing.Point(342, 184);
            this.txtPkgEnd.Name = "txtPkgEnd";
            this.txtPkgEnd.Size = new System.Drawing.Size(417, 29);
            this.txtPkgEnd.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(604, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(824, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Available products:";
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(981, 66);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.Size = new System.Drawing.Size(667, 262);
            this.dgvProducts.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(92, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 19;
            this.label9.Text = "Products:";
            // 
            // txtProducts
            // 
            this.txtProducts.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtProducts.Location = new System.Drawing.Point(342, 347);
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.ReadOnly = true;
            this.txtProducts.Size = new System.Drawing.Size(417, 29);
            this.txtProducts.TabIndex = 20;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(1167, 476);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(113, 74);
            this.btnAddProduct.TabIndex = 21;
            this.btnAddProduct.Text = "Add Product to Package";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Location = new System.Drawing.Point(1320, 476);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(113, 74);
            this.btnRemoveProduct.TabIndex = 22;
            this.btnRemoveProduct.Text = "Remove Product from Package";
            this.btnRemoveProduct.UseVisualStyleBackColor = true;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(1320, 362);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(247, 29);
            this.cboProduct.TabIndex = 23;
            this.cboProduct.SelectionChangeCommitted += new System.EventHandler(this.cboProduct_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1156, 370);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 21);
            this.label10.TabIndex = 24;
            this.label10.Text = "Select a product:";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(1320, 423);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(247, 29);
            this.cboSupplier.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1041, 431);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(239, 21);
            this.label11.TabIndex = 26;
            this.label11.Text = "Select a supplier for that product:";
            // 
            // frmAddEditPackages
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1687, 603);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtProducts);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPkgEnd);
            this.Controls.Add(this.txtPkgDesc);
            this.Controls.Add(this.txtPkgPrice);
            this.Controls.Add(this.txtPkgCommision);
            this.Controls.Add(this.txtPkgStart);
            this.Controls.Add(this.txtPkgName);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPkgID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddEditPackages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditPackages";
            this.Load += new System.EventHandler(this.frmAddEditPackages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtPkgID;
        private Label label7;
        private Button btnAccept;
        private TextBox txtPkgName;
        private TextBox txtPkgStart;
        private TextBox txtPkgCommision;
        private TextBox txtPkgPrice;
        private TextBox txtPkgDesc;
        private TextBox txtPkgEnd;
        private Button btnCancel;
        private Label label8;
        private DataGridView dgvProducts;
        private Label label9;
        private TextBox txtProducts;
        private Button btnAddProduct;
        private Button btnRemoveProduct;
        private ComboBox cboProduct;
        private Label label10;
        private ComboBox cboSupplier;
        private Label label11;
    }
}