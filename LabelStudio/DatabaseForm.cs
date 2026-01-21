using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LabelStudio.DB
{
    public partial class DatabaseForm : Form
    {
        private Database _currentDB;

        public DatabaseForm()
        {
            InitializeComponent();
            _currentDB = new Database("defaultDB");
        }

        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _currentDB.LoadDB();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseNewRecordForm newRecordForm = new DatabaseNewRecordForm(_currentDB);
            newRecordForm.ShowDialog();
        }
    }
}
