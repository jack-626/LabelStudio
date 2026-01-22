using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LabelStudio.Database.Forms
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
            this.Text = "LabelStudio - " + _currentDB._dbName;
        }
        public void RefreshGrid()
        {
            dataGridView1.DataSource = _currentDB.LoadDB();
            this.Text = "LabelStudio - " + _currentDB._dbName;
        }


        // File -> New
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new DBNewDatabase())
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    _currentDB = new Database(form.newDBName);
                    RefreshGrid();
                }
            }
        }

        //Right Click -> New Record
        private void newRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBRecordCreatorForm newRecordForm = new DBRecordCreatorForm(_currentDB);
            newRecordForm.ShowDialog();
        }

        //Right Click -> Delete Record
        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check a row is selected, if not return.
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //Get the ID of the currently selected row
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            var confirm = MessageBox.Show("Are you sure?\nDeleting a record is permanent.", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                _currentDB.DeleteRecord(id);
                RefreshGrid();
            }

        }

        //Right Click -> Refresh
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        //When right clicking on a cell, make sure it selects the whole row.
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
            }
        }
    }
}
