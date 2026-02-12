using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LabelStudio.Databases;

namespace LabelStudio.LabelDesigner.Forms
{
    public partial class EditTextElement : Form
    {
        private LabelTextElement _element;

        private float _newRotationDeg;
        private string _newText;


        public EditTextElement(LabelTextElement element)
        {
            InitializeComponent();
            _element = element;
        }

        private void EditTextElementForm_Load(object sender, EventArgs e)
        {
            //
            //Populate combo box with database columns.
            //Need to add a way to input current database.
            //
            DataTable _data = new Database("defaultDB").LoadDB();
            var columns = _data.Columns.Cast<DataColumn>().Where(c => c.ColumnName != "ID").Select(c => c.ColumnName).ToList();
            comboBox1.DataSource = columns;

            // Auto check the correct radio buttons
            switch (_element.RotationDeg)
            {
                case 0:
                    radio0deg.Checked = true;
                    break;
                case 90:
                    radio90deg.Checked = true;
                    break;
                case 180:
                    radio180deg.Checked = true;
                    break;
                case 270:
                    radio270deg.Checked = true;
                    break;
            }
        }
        private void radio0deg_CheckedChanged(object sender, EventArgs e)
        {
            _newRotationDeg = 0;
        }
        private void radio90deg_CheckedChanged(object sender, EventArgs e)
        {
            _newRotationDeg = 90;
        }

        private void radio180deg_CheckedChanged(object sender, EventArgs e)
        {
            _newRotationDeg = 180;
        }

        private void radio270deg_CheckedChanged(object sender, EventArgs e)
        {
            _newRotationDeg = 270;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _newText = comboBox1.SelectedItem.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _element.Data = _newText;
            _element.RotationDeg = _newRotationDeg;
            this.DialogResult = DialogResult.OK;
        }
    }
}
