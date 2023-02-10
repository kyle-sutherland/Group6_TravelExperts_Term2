namespace TravelExpertsGUI
{
    partial class frmProduct_Suppliers
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
 
this.dgvProdSupData = new System.Windows.Forms.DataGridView();
this.btnAdd = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
((System.ComponentModel.ISupportInitialize)(this.dgvProdSupData)).BeginInit();
this.SuspendLayout();
// 
// dgvProdSupData
// 
this.dgvProdSupData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
this.dgvProdSupData.Location = new System.Drawing.Point(14, 16);
this.dgvProdSupData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
this.dgvProdSupData.Name = "dgvProdSupData";
this.dgvProdSupData.RowTemplate.Height = 25;
this.dgvProdSupData.Size = new System.Drawing.Size(878, 425);
this.dgvProdSupData.TabIndex = 0;
this.dgvProdSupData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdSupData_CellClick);
// 
// btnAdd
// 
this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
this.btnAdd.Location = new System.Drawing.Point(14, 469);
this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
this.btnAdd.Name = "btnAdd";
this.btnAdd.Size = new System.Drawing.Size(114, 47);
this.btnAdd.TabIndex = 1;
this.btnAdd.Text = "Add";
this.btnAdd.UseVisualStyleBackColor = true;
this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
// 
// btnClose
// 
this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
this.btnClose.Location = new System.Drawing.Point(778, 469);
this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(114, 47);
this.btnClose.TabIndex = 4;
this.btnClose.Text = "Close";
this.btnClose.UseVisualStyleBackColor = true;
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// Product_suppliersFrm
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(904, 529);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.btnAdd);
this.Controls.Add(this.dgvProdSupData);
this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
this.Name = "Product_suppliersFrm";
this.Text = "Product Suppliers Data";
this.Load += new System.EventHandler(this.Product_suppliersFrm_Load);
((System.ComponentModel.ISupportInitialize)(this.dgvProdSupData)).EndInit();
this.ResumeLayout(false);

        }

#endregion

private DataGridView dgvProdSupData;
private Button btnAdd;
private Button btnClose;
    }
}