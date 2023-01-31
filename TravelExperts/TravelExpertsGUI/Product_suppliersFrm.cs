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
                var data = db.ProductsSuppliers
                    .OrderBy(p => p.ProductSupplierId)
                    .Select(p => new {p.ProductSupplierId, p.ProductId,p.SupplierId})
                    .ToList();
                dgvProdSupData.DataSource = data; // display

                // format odd numbered rows
                dgvProdSupData.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;
                
                dgvProdSupData.Columns[0].Width = 132; // format first column
                dgvProdSupData.Columns[1].Width = 90; // format 2nd column
            }
        }
    }
}
