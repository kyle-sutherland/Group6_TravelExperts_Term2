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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Globalization;

namespace TravelExpertsGUI
{
    public partial class frmAddEditPackages : Form
    {
        // form variables
        public static bool isAdd;
        public static TravelExpertsData.Package? package = frmMain.selectedPackage;
        public TravelExpertsData.Product? selectedProduct;
        public TravelExpertsData.ProductsSupplier? selectedProdSupp;
        public TravelExpertsData.PackagesProductsSupplier? selectedPackProdSupp;
        public TravelExpertsData.Supplier? selectedSupplier;

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
                    txtPkgID.Enabled = false;
                    
                }
                else 
                {
                    this.Text = "Edit Package";
                    txtPkgID.ReadOnly = true;
                    DisplayPackage();
                    DisplayProducts();
                    

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

                DateTime pkgStartDate = Convert.ToDateTime(package.PkgStartDate);
                txtPkgStart.Text = pkgStartDate.Date.ToString("d");

                DateTime pkgEndDate = Convert.ToDateTime(package.PkgEndDate);
                txtPkgEnd.Text = pkgEndDate.Date.ToString("d");

                txtPkgDesc.Text = package.PkgDesc;

                decimal Price = Convert.ToDecimal(package.PkgBasePrice);
                txtPkgPrice.Text = Price.ToString("c");

                decimal Commission = Convert.ToDecimal(package.PkgAgencyCommission);
                txtPkgCommission.Text = Commission.ToString("c");
            }
        }

        private void DisplayProducts()
        {

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                dgvProducts.Columns.Clear();

                var data = (from packProdSupp in db.PackagesProductsSuppliers
                            join prodSupp in db.ProductsSuppliers
                            on packProdSupp.ProductSupplierId equals prodSupp.ProductSupplierId
                            join product in db.Products
                            on prodSupp.ProductId equals product.ProductId
                            join supplier in db.Suppliers
                            on prodSupp.SupplierId equals supplier.SupplierId
                            where packProdSupp.PackageId == package.PackageId
                            select new
                            {
                                supplier.SupName,
                                product.ProdName
                            }).ToList();


                dgvProducts.DataSource = data;

                //dgvProducts.DataSource = db.Products.Select(p => new{ p.ProductId, p.ProdName }).ToList();
                dgvProducts.Columns[0].HeaderText = "Supplier Name";
                dgvProducts.Columns[0].Width = 200;
                dgvProducts.Columns[1].HeaderText = "Product Name";
                dgvProducts.Columns[1].Width = 200;
            }
        }

        

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validator.IsProvided(txtPkgName) &&
                Validator.IsProvided(txtPkgDesc) &&
                Validator.IsValidDate(txtPkgStart) &&
                Validator.IsValidDate(txtPkgEnd) &&
                Validator.IsStartBeforeEndDate(txtPkgStart, txtPkgEnd) &&
                Validator.IsLessThanOrEqual(txtPkgCommission, txtPkgPrice) //&&
                
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
                    decimal Price = decimal.Parse(txtPkgPrice.Text,
                        NumberStyles.AllowCurrencySymbol |
                        NumberStyles.AllowThousands |
                        NumberStyles.AllowDecimalPoint);
                    package.PkgBasePrice = Convert.ToDecimal(Price);
                    decimal Commission = decimal.Parse(txtPkgCommission.Text,
                        NumberStyles.AllowCurrencySymbol |
                        NumberStyles.AllowThousands |
                        NumberStyles.AllowDecimalPoint);
                    package.PkgAgencyCommission = Convert.ToDecimal(Commission);
                }
                this.DialogResult = DialogResult.OK;
            }
        }



        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmPack_Prod_SuppAddDelete secondForm = new frmPack_Prod_SuppAddDelete();
            secondForm.isAddP = true;
            secondForm.prodSupp = selectedProdSupp;
            secondForm.product = selectedProduct;
            secondForm.supplier = selectedSupplier;
            secondForm.package = package;

            DialogResult result = secondForm.ShowDialog(); // display second form model
            if (result == DialogResult.OK)
            {
                selectedPackProdSupp = secondForm.packProdSupp;

                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // add to the database
                    db.PackagesProductsSuppliers.Add(selectedPackProdSupp);
                    db.SaveChanges();
                }
                DisplayProducts();
            }
        }



        // btnCancel is set as the Cancel button on this form and will close it automatically
    }
}
