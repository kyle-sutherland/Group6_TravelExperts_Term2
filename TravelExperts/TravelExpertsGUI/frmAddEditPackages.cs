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
                    
                }
                else 
                {
                    this.Text = "Edit Package";
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
                dgvProducts.Columns.Clear();

                var data = (from packProdSupp in db.PackagesProductsSuppliers
                            join prodSupp in db.ProductsSuppliers
                            on packProdSupp.ProductSupplierId equals prodSupp.ProductSupplierId
                            join product in db.Products
                            on prodSupp.ProductId equals product.ProductId
                            where packProdSupp.PackageId == package.PackageId
                            select new
                            {
                                packProdSupp.ProductSupplierId,
                                product.ProdName,
                            }).ToList();


                dgvProducts.DataSource = data;

                //dgvProducts.DataSource = db.Products.Select(p => new{ p.ProductId, p.ProdName }).ToList();
                dgvProducts.Columns[0].HeaderText = "Product Supplier ID";
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
                Validator.IsLessThanOrEqual(txtPkgCommision, txtPkgPrice) //&&
                
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



        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmPack_Prod_SuppAddDelete secondForm = new frmPack_Prod_SuppAddDelete();
            secondForm.isAddP = true;
            secondForm.prodSupp = selectedProdSupp;
            secondForm.product = selectedProduct;
            secondForm.supplier = selectedSupplier;
            secondForm.package = package;

            DialogResult result = secondForm.ShowDialog(); // display second form modal
            if (result == DialogResult.OK)
            {
                // take data from second form
                selectedProdSupp = secondForm.prodSupp;
                selectedSupplier = secondForm.supplier;
                selectedProduct = secondForm.product;

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
