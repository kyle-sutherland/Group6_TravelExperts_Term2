﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TravelExpertsData.DB_Utils;

namespace TravelExpertsGUI
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void PopulateDgv()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.DataSource = GetAllProducts();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            PopulateDgv();
        }

    }
}
