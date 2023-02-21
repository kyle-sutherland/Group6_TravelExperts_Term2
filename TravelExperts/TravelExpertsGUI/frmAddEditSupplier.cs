using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;
using static TravelExpertsData.DB_Utils;
using static TravelExpertsGUI.frmMain;

namespace TravelExpertsGUI
{
    public partial class frmAddEditSupplier : Form
    {
        public static bool isAdd;
        public static Supplier? supplier = frmMain.selectedSupplier;

        public frmAddEditSupplier()
        {
            InitializeComponent();
        }

        private void frmAddEditSupplier_Load(object sender, EventArgs e)
        {
            if (isAdd)
            {
                this.Text = "Add Supplier";
                txtSuppId.Enabled = true;
            }
            else
            {
                this.Text = "Modify Supplier";
                txtSuppId.Enabled = false;
                DisplaySupplier();
            }
        }

        private void DisplaySupplier()
        {
            if (supplier != null)
            {
                txtSuppId.Text = Convert.ToString(supplier.SupplierId);
                txtSupName.Text = supplier.SupName;
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (Validator.IsProvided(txtSuppId) &&
                Validator.IsProvided(txtSupName))
            {
                if (isAdd)
                {
                    supplier = new Supplier();
                    if (supplier != null)
                    {
                        supplier.SupplierId = Convert.ToInt32(txtSuppId.Text);
                        supplier.SupName = txtSupName.Text;
                        AddSupplier(supplier);
                    }
                }
                else
                {
                    if (supplier != null)
                    {
                        supplier.SupplierId = Convert.ToInt32(txtSuppId.Text);
                        supplier.SupName = txtSupName.Text;
                        ModifySupplier(supplier);
                    }
                }


                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
