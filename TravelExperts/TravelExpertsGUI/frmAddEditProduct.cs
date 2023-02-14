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

namespace TravelExpertsGUI
{
    public partial class frmAddEditProduct : Form
    {
        public static bool isAdd;
        public static Product? product;
        public frmAddEditProduct()
        {
            InitializeComponent();
        }

        private void txtProdName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                product.ProdName = txtProdName.Text.Trim();
                AddProduct(product);
            }
            else
            {
                product.ProdName = txtProdName.Text.Trim();
                ModifyProduct (product);
            }
        }

        private void frmAddEditProduct_Load(object sender, EventArgs e)
        {
            if (!isAdd)
            {
                txtProdName.Text = product.ProdName;
            }
        }
    }
}
