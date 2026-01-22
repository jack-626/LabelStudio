using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LabelStudio.Database.Forms
{
    public partial class DBNewDatabase : Form
    {
        public string newDBName { get; private set; }

        public DBNewDatabase()
        {
            InitializeComponent();
        }

        private void DBNewDatabase_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            newDBName = txtDBName.Text;
            Database newDB = new Database(newDBName);
            if(File.Exists(Path.Combine(Database.dbFolder, newDBName + ".db")))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
