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
using static TravelExpertsGUI.frmMain;

namespace TravelExpertsGUI
{
    public partial class frmAddEditSupplier : Form
    {
        public static bool isAdd;
        public static Supplier? supplier = frmMain.selectedSupplier;

        public frmAddEditSupplier()
        {
            InitializeComponent();
        }

        private void frmAddEditSupplier_Load(object sender, EventArgs e)
        {
            if(!isAdd)
            {
                txtSupName.Text = supplier.SupName;
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                supplier.SupName = txtSupName.Text;
                AddSupplier(supplier);
            }
            else
            {
                supplier.SupName = txtSupName.Text;
                ModifySupplier(supplier);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
