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
    public partial class frmPack_Prod_SuppAddDelete : Form
    {
        public bool isAddP; 
        public Package? package;
        public ProductsSupplier? prodSupp;
        public PackagesProductsSupplier? packProdSupp;
        public Product? product;
        public Supplier? supplier;

        public frmPack_Prod_SuppAddDelete()
        {
            InitializeComponent();
        }

        private void frmPack_Prod_SuppAddDelete_Load(object sender, EventArgs e)
        {
            if (isAddP) // add
            {
                this.Text = "Add a Product from Supplier";
            }
            else // remove
            {
                this.Text = "Remove a Product from Supplier";
            }
            this.DisplayData();
        }

        private void DisplayData()
        {

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                // grab data from db
                dgvProdSupData.Columns.Clear();
                var data = (from products in db.Products
                            join prodSupp in db.ProductsSuppliers
                            on products.ProductId equals prodSupp.ProductId
                            join suppliers in db.Suppliers
                            on prodSupp.SupplierId equals suppliers.SupplierId
                            orderby products.ProdName
                            select new
                            {
                                suppliers.SupName,
                                products.ProdName
                            }).ToList();

                dgvProdSupData.DataSource = data;

                
                var AddColumn = new DataGridViewButtonColumn()
                {
                    UseColumnTextForButtonValue = true,
                    HeaderText = "",
                    Text = "Add"
                };
                dgvProdSupData.Columns.Add(AddColumn);
               
                //var RemoveColumn = new DataGridViewButtonColumn()
                //{
                //    UseColumnTextForButtonValue = true,
                //    HeaderText = "",
                //    Text = "Remove"
                //};
                //dgvProdSupData.Columns.Add(RemoveColumn);

                dgvProdSupData.Columns[0].HeaderText = "Supplier Name";
                dgvProdSupData.Columns[0].Width = 255; 
                dgvProdSupData.Columns[1].HeaderText = "Product Name";
                dgvProdSupData.Columns[1].Width = 140; 
            }
        }

        private void dgvProdSupData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // store index values for Add and Delete button columns
            const int AddIndex = 3;
            //const int DeleteIndex = 4;

            //grab prodSuppID, prodID, and suppID
            if (e.ColumnIndex == AddIndex)
            //if (e.ColumnIndex == AddIndex || e.ColumnIndex == DeleteIndex)
            {
                int prodSuppCode = 0;
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    prodSuppCode = Convert.ToInt32(dgvProdSupData.Rows[e.RowIndex].Cells[0].Value);
                    prodSupp = db.ProductsSuppliers.Find(prodSuppCode);
                }

                if (e.ColumnIndex == AddIndex) AddPackProdSupp(prodSuppCode);
                //if (e.ColumnIndex == DeleteIndex) DeletePackProdSupp();
            }
        }
        private void AddPackProdSupp(int prodSuppCode)
        {
            this.packProdSupp = new PackagesProductsSupplier();
            this.packProdSupp.ProductSupplierId = Convert.ToInt32(prodSuppCode);
            this.packProdSupp.PackageId = package.PackageId;

            this.DialogResult= DialogResult.OK;
        }

        //private void DeletePackProdSupp()
        //{
        //    throw new NotImplementedException();
        //}


    }
}
