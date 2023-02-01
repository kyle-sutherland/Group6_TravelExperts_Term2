using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TravelExpertsData;
using static System.Windows.Forms.AxHost;

namespace TravelExpertsGUI
{
    public partial class frmAddEditPackages : Form
    {
        // form variables
        public bool isAdd;
        public TravelExpertsData.Package? package;

        public frmAddEditPackages()
        {
            InitializeComponent();
        }

        private void frmAddEditPackages_Load(object sender, EventArgs e)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // list of products for the data grid view
                    List<Product> products = db.Products.OrderBy(p => p.ProdName).ToList();
                    dgvProducts.DataSource = products;
                }

                if (isAdd) 
                {
                    
                    this.Text = "Add Package";
                }
                else 
                {
                    this.Text = "Edit Package";
                    DisplayPackage();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when retrieving products: " + ex.Message,
                                ex.GetType().ToString());
            }
        }

        private void DisplayPackage()
        {
            if (package != null)
            {
                txtPkgID.Text = Convert.ToString(package.PackageId);
                txtPkgName.Text = package.PkgName;
                txtPkgStart.Text = Convert.ToString(package.PkgStartDate);
                txtPkgEnd.Text = Convert.ToString(package.PkgEndDate);
                txtPkgDesc.Text = package.PkgDesc;
                txtPkgPrice.Text = Convert.ToString(package.PkgBasePrice);
                txtPkgCommision.Text = Convert.ToString(package.PkgAgencyCommission);
            }
        }


        // btnCancel is set as Cancel button on this form
    }
}
