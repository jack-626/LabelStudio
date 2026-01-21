using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LabelStudio.Database
{
    public partial class DBViewerForm : Form
    {
        private Database _currentDB;

        public DBViewerForm()
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
            DBRecordCreatorForm newRecordForm = new DBRecordCreatorForm(_currentDB);
            newRecordForm.ShowDialog();
        }
    }
}
