namespace LabelStudio.Databases.Forms
{
    partial class DBViewerForm
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
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            databaseToolStripMenuItem = new ToolStripMenuItem();
            newRecordToolStripMenuItem1 = new ToolStripMenuItem();
            refreshViewToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            gridContext = new ContextMenuStrip(components);
            newRecordToolStripMenuItem = new ToolStripMenuItem();
            deleteRecordToolStripMenuItem = new ToolStripMenuItem();
            editRecordToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            gridContext.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, databaseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1051, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New Database";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open Database";
            // 
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newRecordToolStripMenuItem1, refreshViewToolStripMenuItem });
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new Size(39, 20);
            databaseToolStripMenuItem.Text = "Edit";
            // 
            // newRecordToolStripMenuItem1
            // 
            newRecordToolStripMenuItem1.Name = "newRecordToolStripMenuItem1";
            newRecordToolStripMenuItem1.Size = new Size(180, 22);
            newRecordToolStripMenuItem1.Text = "New Record";
            newRecordToolStripMenuItem1.Click += newRecordToolStripMenuItem1_Click;
            // 
            // refreshViewToolStripMenuItem
            // 
            refreshViewToolStripMenuItem.Name = "refreshViewToolStripMenuItem";
            refreshViewToolStripMenuItem.Size = new Size(180, 22);
            refreshViewToolStripMenuItem.Text = "Refresh View";
            refreshViewToolStripMenuItem.Click += refreshViewToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ContextMenuStrip = gridContext;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(1051, 779);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            // 
            // gridContext
            // 
            gridContext.Items.AddRange(new ToolStripItem[] { newRecordToolStripMenuItem, deleteRecordToolStripMenuItem, editRecordToolStripMenuItem, refreshToolStripMenuItem });
            gridContext.Name = "gridContext";
            gridContext.Size = new Size(148, 92);
            // 
            // newRecordToolStripMenuItem
            // 
            newRecordToolStripMenuItem.Name = "newRecordToolStripMenuItem";
            newRecordToolStripMenuItem.Size = new Size(147, 22);
            newRecordToolStripMenuItem.Text = "New Record";
            newRecordToolStripMenuItem.Click += newRecordToolStripMenuItem_Click;
            // 
            // deleteRecordToolStripMenuItem
            // 
            deleteRecordToolStripMenuItem.Name = "deleteRecordToolStripMenuItem";
            deleteRecordToolStripMenuItem.Size = new Size(147, 22);
            deleteRecordToolStripMenuItem.Text = "Delete Record";
            deleteRecordToolStripMenuItem.Click += deleteRecordToolStripMenuItem_Click;
            // 
            // editRecordToolStripMenuItem
            // 
            editRecordToolStripMenuItem.Name = "editRecordToolStripMenuItem";
            editRecordToolStripMenuItem.Size = new Size(147, 22);
            editRecordToolStripMenuItem.Text = "Edit Record";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(147, 22);
            refreshToolStripMenuItem.Text = "Refresh View";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // DBViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 803);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "DBViewerForm";
            Text = "Database";
            Load += DatabaseForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            gridContext.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private DataGridView dataGridView1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ContextMenuStrip gridContext;
        private ToolStripMenuItem newRecordToolStripMenuItem;
        private ToolStripMenuItem deleteRecordToolStripMenuItem;
        private ToolStripMenuItem editRecordToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private ToolStripMenuItem newRecordToolStripMenuItem1;
        private ToolStripMenuItem refreshViewToolStripMenuItem;
    }
}