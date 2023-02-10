using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class frmMain : Form
    {
        private Package? selectedPackage = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPackages secondForm = new frmAddEditPackages();
            secondForm.isAdd = true;
            secondForm.package = null;

            DialogResult result = secondForm.ShowDialog(); // display second form modal

            if (result == DialogResult.OK) // second form accepted new data
            {
                // take customer from the second form and add to the database
                selectedPackage = secondForm.package;
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        if (selectedPackage != null)
                        {
                            db.Packages.Add(selectedPackage);
                            db.SaveChanges();
                        }
                        DisplayPackage(); // display added package
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
                    MessageBox.Show("Error while adding package" + ex.Message,
                        ex.GetType().ToString());
                }
            }
        }

        private void DisplayPackage()
        {
            //throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {

        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = cmbTables.SelectedItem.ToString();
            switch (selection)
            {
                case "Products":
                    Form _frmProducts = new frmProducts();
                    _frmProducts.Show();
                    break;
                case "Packages":
                    Form _frmAddEditPackages = new frmAddEditPackages();
                    _frmAddEditPackages.Show();
                    break;
                case "Products-Suppliers":
                    Form _frmProduct_Suppliers = new frmProduct_Suppliers();
                    _frmProduct_Suppliers.Show();
                    break;
            }
        }
    }
}