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

namespace TravelExpertsGUI
{
    public partial class Prod_SuppAddModifyFrm : Form
    {
        public bool isAdd; // to differientiate the second form to either add or modify
        public ProductsSupplier? prodSupp;
        public Product? product;
        public Supplier? supplier;

        public Prod_SuppAddModifyFrm()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                // initialize the prodSupp property with new prodSupp object
                this.prodSupp = new ProductsSupplier();
            }

            prodSupp.SupplierId = Convert.ToInt32(cbSuppliers.SelectedValue);
            prodSupp.ProductId = Convert.ToInt32(cbProducts.SelectedValue);
            this.DialogResult= DialogResult.OK;
        }

        private void Prod_SuppAddModifyFrm_Load(object sender, EventArgs e)
        {
            if (isAdd) // add
            {
                this.Text = "Add a Product from Supplier";
            }
            else // modify
            {
                this.Text = "Modify a Product from Supplier";
            }
            this.DisplayProdSuppInfo();
        }

        // load and display info that was selected to modify
        private void DisplayProdSuppInfo()
        {
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                // list all suppliers to dropdownlist
                cbSuppliers.Items.Clear();
                List<Supplier> s = db.Suppliers.OrderBy(s=>s.SupName).ToList();
                cbSuppliers.DataSource = s;
                cbSuppliers.DisplayMember = "SupName";
                cbSuppliers.ValueMember = "SupplierId";

                // list all products to dropdownlist
                cbProducts.Items.Clear();
                List<Product> p= db.Products.OrderBy(p=>p.ProdName).ToList();
                cbProducts.DataSource = p;
                cbProducts.DisplayMember = "ProdName";
                cbProducts.ValueMember = "ProductId";

                
                if (!isAdd)
                {
                    // display supplier that was selected on first form
                    for (int i = 0; i < s.Count; i++)
                    {
                        // find right id and display it on combobox
                        if (supplier.SupplierId == s[i].SupplierId) cbSuppliers.SelectedIndex = i;
                    }

                    // display product that was selected on first firm
                    for (int i = 0; i < p.Count; i++)
                    {
                        // find right prod id and display it on combobox
                        if (product.ProductId == p[i].ProductId) cbProducts.SelectedIndex = i;
                    }
                }
            }
        }

        private void LoadProdSuppData()
        {
            prodSupp.SupplierId = Convert.ToInt32(cbSuppliers.SelectedValue);
            //MessageBox.Show(prodSupp.SupplierId.ToString());
            prodSupp.ProductId = Convert.ToInt32(cbProducts.SelectedValue);
            //MessageBox.Show(prodSupp.ProductId.ToString());
        }
    }
}
