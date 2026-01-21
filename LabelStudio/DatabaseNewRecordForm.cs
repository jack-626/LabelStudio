using LabelStudio.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabelStudio
{
    public partial class DatabaseNewRecordForm : Form
    {
        private Database _currentDB;
        public DatabaseNewRecordForm(Database currentDB)
        {
            InitializeComponent();
            _currentDB = currentDB;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            Plant plant = new Plant();
            string type = txtType.Text.Trim();

            if (type == "")
            {
                MessageBox.Show("Type Required");
                return;
            }

            plant.Type = type;

            _currentDB.AddRecord(plant);
        }
    }
}
