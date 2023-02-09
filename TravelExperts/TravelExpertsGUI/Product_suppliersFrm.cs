using Microsoft.EntityFrameworkCore;
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
    public partial class Product_suppliersFrm : Form
    {
        // form-level data
        private ProductsSupplier? selectedProdSupp;
        private Product? selectedProduct;
        private Supplier? selectedSupplier;

        public Product_suppliersFrm()
        {
            InitializeComponent();
        }

        private void Product_suppliersFrm_Load(object sender, EventArgs e)
        {
            DisplayData();
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
                           orderby suppliers.SupName
                           select new
                           {
                               prodSupp.ProductSupplierId,
                               suppliers.SupplierId,
                               suppliers.SupName,
                               products.ProductId,
                               products.ProdName
                           }).ToList();

                dgvProdSupData.DataSource = data; // display

                // add column for modify button
                var modifyColumn = new DataGridViewButtonColumn()
                { // object initializer
                    UseColumnTextForButtonValue = true,
                    HeaderText = "",
                    Text = "Modify"
                };
                dgvProdSupData.Columns.Add(modifyColumn);
                // add column for delete button
                var deleteColumn = new DataGridViewButtonColumn()
                {
                    UseColumnTextForButtonValue = true,
                    HeaderText = "",
                    Text = "Delete"
                };
                dgvProdSupData.Columns.Add(deleteColumn);

                // format odd numbered rows
                dgvProdSupData.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;
                
                dgvProdSupData.Columns[0].Width = 132; // format ProdSupID column
                dgvProdSupData.Columns[2].HeaderText = "Supplier Name";
                dgvProdSupData.Columns[2].Width = 255; // format Supname column
                dgvProdSupData.Columns[3].Width = 90; // format ProdID column
                dgvProdSupData.Columns[4].HeaderText = "Product Name";
                dgvProdSupData.Columns[4].Width = 140; // format the ProdName column
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Prod_SuppAddModifyFrm secondForm = new Prod_SuppAddModifyFrm();
            secondForm.isAdd = true;
            secondForm.prodSupp = selectedProdSupp;
            secondForm.product = selectedProduct;
            secondForm.supplier = selectedSupplier;

            DialogResult result = secondForm.ShowDialog(); // display second form modal
            if(result == DialogResult.OK)
            {
                // take data from second form
                selectedProdSupp = secondForm.prodSupp;
                selectedSupplier = secondForm.supplier;
                selectedProduct = secondForm.product;

                using(TravelExpertsContext db = new TravelExpertsContext())
                {
                    // add to the database
                    db.ProductsSuppliers.Add(selectedProdSupp);
                    db.SaveChanges();
                }
                DisplayData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdSupData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // store index values for Modify and Delete button columsn
            const int ModifyIndex = 5;
            const int DeleteIndex = 6;

            //grab prodSuppID, prodID, and suppID
            if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
            {
                int prodSuppCode = 0;
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    prodSuppCode = Convert.ToInt32(dgvProdSupData.Rows[e.RowIndex].Cells[0].Value);
                    selectedProdSupp = db.ProductsSuppliers.Find(prodSuppCode);

                    int suppCode = Convert.ToInt32(dgvProdSupData.Rows[e.RowIndex].Cells[1].Value);
                    selectedSupplier = db.Suppliers.Find(suppCode);

                    int productCode = Convert.ToInt32(dgvProdSupData.Rows[e.RowIndex].Cells[3].Value);
                    selectedProduct = db.Products.Find(productCode);
                }

                if (e.ColumnIndex == ModifyIndex) ModifyProdSupp(prodSuppCode);
                if (e.ColumnIndex == DeleteIndex) DeleteProdSupp();
            }           
        }

        private void ModifyProdSupp(int prodSuppCode)
        {
            var secondFrm = new Prod_SuppAddModifyFrm()
            {
                isAdd = false,
                prodSupp = selectedProdSupp,
                product = selectedProduct,
                supplier = selectedSupplier
            };
            DialogResult result = secondFrm.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                using(TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProdSupp = db.ProductsSuppliers.Find(prodSuppCode);

                    if (selectedProdSupp != null)
                    {
                        selectedProdSupp.SupplierId = secondFrm.prodSupp.SupplierId;
                        selectedProdSupp.ProductId = secondFrm.prodSupp.ProductId;

                        db.SaveChanges();
                        DisplayData(); 
                    }
                }
            }
        }

        private void DeleteProdSupp()
        {

        }


    }
}
