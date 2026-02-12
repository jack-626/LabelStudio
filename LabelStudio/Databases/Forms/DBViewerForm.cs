using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LabelStudio.Databases.Forms
{
    public partial class DBViewerForm : Form
    {
        private Database _currentDB;

        public DBViewerForm()
        {
            InitializeComponent();
            //Create and use a template database on startup.
            _currentDB = new Database("defaultDB");
        }

        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            //Setup data grid view columns and load data source.
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _currentDB.LoadDB();

            //Hide the ID column as it doesnt need to be seen
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns["ID"].Visible = false;
            }

            //Set form title
            this.Text = "LabelStudio - " + _currentDB._dbName;
        }
        //Refresh the data grid view
        private void RefreshView()
        {
            dataGridView1.DataSource = _currentDB.LoadDB();
            this.Text = "LabelStudio - " + _currentDB._dbName;
        }
        //Open the new record form.
        private void NewRecord()
        {
            using (var form = new DBRecordCreatorForm(_currentDB))
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    RefreshView();
                }
            }
        }
        private void DeleteRecord()
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
                RefreshView();
            }
        }

        // File -> New
        // Opens the new database form.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new DBNewDatabase())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _currentDB = new Database(form.newDBName);
                    RefreshView();
                }
            }
        }

        //Right Click -> New Record
        private void newRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRecord();
        }

        //Right Click -> Delete Record
        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        //Right Click -> Refresh View
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        //When right clicking on a cell, make sure it selects the whole row.
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        //Edit -> New Record
        private void newRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewRecord();
        }
        //Edit -> Refresh View
        private void refreshViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshView();
        }
    }
}
