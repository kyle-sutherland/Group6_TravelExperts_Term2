namespace TravelExpertsGUI
{
    partial class frmPack_Prod_SuppAddDelete
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSupData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdSupData
            // 
            this.dgvProdSupData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdSupData.Location = new System.Drawing.Point(27, 13);
            this.dgvProdSupData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProdSupData.Name = "dgvProdSupData";
            this.dgvProdSupData.RowTemplate.Height = 25;
            this.dgvProdSupData.Size = new System.Drawing.Size(878, 425);
            this.dgvProdSupData.TabIndex = 1;
            this.dgvProdSupData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdSupData_CellClick);
            // 
            // frmPack_Prod_SuppAddDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 483);
            this.Controls.Add(this.dgvProdSupData);
            this.Name = "frmPack_Prod_SuppAddDelete";
            this.Text = "frmPack_Prod_SuppAddDelete";
            this.Load += new System.EventHandler(this.frmPack_Prod_SuppAddDelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdSupData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvProdSupData;
        private Button btnAdd;
        private Button btnClose;
        private Button btnAccept;
    }
}