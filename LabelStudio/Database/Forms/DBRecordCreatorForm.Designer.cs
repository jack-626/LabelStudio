namespace LabelStudio.Database.Forms
{
    partial class DBRecordCreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtType = new TextBox();
            lblType = new Label();
            btnAddRecord = new Button();
            SuspendLayout();
            // 
            // txtType
            // 
            txtType.Location = new Point(50, 6);
            txtType.Name = "txtType";
            txtType.Size = new Size(100, 23);
            txtType.TabIndex = 0;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(12, 9);
            lblType.Name = "lblType";
            lblType.Size = new Size(32, 15);
            lblType.TabIndex = 1;
            lblType.Text = "Type";
            // 
            // btnAddRecord
            // 
            btnAddRecord.Location = new Point(12, 415);
            btnAddRecord.Name = "btnAddRecord";
            btnAddRecord.Size = new Size(108, 23);
            btnAddRecord.TabIndex = 2;
            btnAddRecord.Text = "Add Record";
            btnAddRecord.UseVisualStyleBackColor = true;
            btnAddRecord.Click += btnAddRecord_Click;
            // 
            // DBRecordCreatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddRecord);
            Controls.Add(lblType);
            Controls.Add(txtType);
            Name = "DBRecordCreatorForm";
            Text = "DatabaseNewRecordForm";
            FormClosed += DBRecordCreatorForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtType;
        private Label lblType;
        private Button btnAddRecord;
    }
}