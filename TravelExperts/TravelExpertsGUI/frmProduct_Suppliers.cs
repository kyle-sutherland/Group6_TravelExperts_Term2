using Microsoft.Data.SqlClient;
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
using static TravelExpertsGUI.frmProd_SuppAddModify;

namespace TravelExpertsGUI
{
    public partial class frmProduct_Suppliers : Form
    {
        // form-level data
        private ProductsSupplier? selectedProdSupp;
        private Product? selectedProduct;
        private Supplier? selectedSupplier;

        public frmProduct_Suppliers()
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
            frmProd_SuppAddModify secondForm = new frmProd_SuppAddModify();
            frmProd_SuppAddModify.isAdd = true;
            frmProd_SuppAddModify.prodSupp = selectedProdSupp;
            frmProd_SuppAddModify.product = selectedProduct;
            frmProd_SuppAddModify.supplier = selectedSupplier;

            DialogResult result = secondForm.ShowDialog(); // display second form modal
            if (result == DialogResult.OK)
            {
                // take data from second form
                selectedProdSupp = frmProd_SuppAddModify.prodSupp;
                selectedSupplier = frmProd_SuppAddModify.supplier;
                selectedProduct = frmProd_SuppAddModify.product;

                using (TravelExpertsContext db = new TravelExpertsContext())
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
            //for now exit app
            this.Close();
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
            frmProd_SuppAddModify.isAdd = false;
            frmProd_SuppAddModify.prodSupp = selectedProdSupp;
            frmProd_SuppAddModify.product = selectedProduct;
            frmProd_SuppAddModify.supplier = selectedSupplier;
            var secondFrm = new frmProd_SuppAddModify();
            DialogResult result = secondFrm.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProdSupp = db.ProductsSuppliers.Find(prodSuppCode);

                    if (selectedProdSupp != null)
                    {
                        selectedProdSupp.SupplierId = frmProd_SuppAddModify.prodSupp.SupplierId;
                        selectedProdSupp.ProductId = frmProd_SuppAddModify.prodSupp.ProductId;

                        db.SaveChanges();
                        DisplayData();
                    }
                }
            }
        }

        private void DeleteProdSupp()
        {
            if (selectedProdSupp != null)
            {
                // get confirmation from the user
                DialogResult answer = MessageBox.Show($"Do you want to delete Product Supplier ID: " +
                    $"{selectedProdSupp.ProductSupplierId.ToString().Trim()}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer== DialogResult.Yes)
                {
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())
                        {
                            // find what the user has selected from the list and db
                            db.ProductsSuppliers.Remove(selectedProdSupp);
                            db.SaveChanges(true);
                            DisplayData();
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        string errorMessage = "";
                        var sqlException = (SqlException)ex.InnerException;
                        foreach (SqlError error in sqlException.Errors)
                        {
                            errorMessage += "ERROR CODE:  " + error.Number + " " +
                                            error.Message + "\n";
                        }
                        MessageBox.Show(errorMessage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.GetType().ToString());
                    }
                }
            }
        }

    }
}
