using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsGUI
{
    public partial class frmAddEditPackages : Form
    {
        // form variables
        public static bool isAdd;
        public static TravelExpertsData.Package? package;
        public TravelExpertsData.Product? selectedProduct;
        public TravelExpertsData.ProductsSupplier? selectedProdSupp;

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
                    cboProduct.DataSource = products;
                }

                if (isAdd) 
                {
                    
                    this.Text = "Add Package";
                    DisplayProducts();
                    DisplayCBOProduct();
                }
                else 
                {
                    this.Text = "Edit Package";
                    DisplayPackage();
                    DisplayProducts();
                    DisplayCBOProduct();

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

        private void DisplayProducts()
        {

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                dgvProducts.DataSource = db.Products.Select(p => new{ p.ProductId, p.ProdName }).ToList();
                dgvProducts.Columns[0].HeaderText = "Product ID";
                dgvProducts.Columns[0].Width = 50;
                dgvProducts.Columns[1].HeaderText = "Product Name";
                dgvProducts.Columns[1].Width = 200;
            }
        }

        private void DisplayCBOProduct()
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {

                    List<Product> products = db.Products.ToList();
                    cboProduct.DataSource = products;
                    cboProduct.DisplayMember = "ProdName";
                    cboProduct.ValueMember = "ProductId";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when retrieving Product: " + ex.Message,
                                ex.GetType().ToString());
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validator.IsProvided(txtPkgName) &&
                Validator.IsProvided(txtPkgDesc) &&
                Validator.IsValidDate(txtPkgStart) &&
                Validator.IsValidDate(txtPkgEnd) &&
                Validator.IsStartBeforeEndDate(txtPkgStart, txtPkgEnd) &&
                Validator.IsLessThanOrEqual(txtPkgCommision, txtPkgPrice) //&&
                //Validator.IsSelected(txtPkg) &&
                //Validator.IsProvided(txtPkg)
              )
            {
                if (isAdd)
                {
                    package = new TravelExpertsData.Package();
                }
                
                if (package != null)
                {
                    package.PackageId =  Convert.ToInt32(txtPkgID.Text);
                    package.PkgName = txtPkgName.Text;
                    package.PkgStartDate = Convert.ToDateTime(txtPkgStart.Text);
                    package.PkgEndDate = Convert.ToDateTime(txtPkgEnd.Text);
                    package.PkgDesc = txtPkgDesc.Text;
                    package.PkgBasePrice = Convert.ToDecimal(txtPkgPrice.Text);
                    package.PkgAgencyCommission = Convert.ToDecimal(txtPkgCommision.Text);
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(cboProduct.SelectedValue);
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProduct = db.Products.Find(productID);
                    if (selectedProduct != null)
                    {
                        db.Products.Add(selectedProduct);
                        db.SaveChanges();
                    }
                    DisplayCBOProduct();
                    DisplayProducts();
                }
            }
            catch (DbUpdateException ex)
            {
                string errorMessage = "";
                var sqlException = (SqlException)ex.InnerException;
                foreach (SqlError error in sqlException.Errors)
                {
                    errorMessage += "ERROR CODE:  " + error.Number +
                                    " " + error.Message + "\n";
                }
                MessageBox.Show(errorMessage);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error while adding product:" + ex.Message,
                    ex.GetType().ToString());
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(cboProduct.SelectedValue);
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProduct = db.Products.Find(productID);
                    if (selectedProduct != null)
                    {
                        db.Products.Remove(selectedProduct);
                        db.SaveChanges();
                    }
                    DisplayCBOProduct();
                    DisplayProducts();
                }
            }
            catch (DbUpdateException ex)
            {
                string errorMessage = "";
                var sqlException = (SqlException)ex.InnerException;
                foreach (SqlError error in sqlException.Errors)
                {
                    errorMessage += "ERROR CODE:  " + error.Number +
                                    " " + error.Message + "\n";
                }
                MessageBox.Show(errorMessage);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error while adding product:" + ex.Message,
                    ex.GetType().ToString());
            }
        }

        // btnCancel is set as the Cancel button on this form and will close it automatically
    }
}
