namespace LabelStudio.LabelDesigner.Forms
{
    partial class EditTextElement
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            radio90deg = new RadioButton();
            radio180deg = new RadioButton();
            radio270deg = new RadioButton();
            radio0deg = new RadioButton();
            btnOK = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Data Type: ";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(83, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(248, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // radio90deg
            // 
            radio90deg.AutoSize = true;
            radio90deg.Location = new Point(472, 13);
            radio90deg.Name = "radio90deg";
            radio90deg.Size = new Size(37, 19);
            radio90deg.TabIndex = 2;
            radio90deg.TabStop = true;
            radio90deg.Text = "90";
            radio90deg.UseVisualStyleBackColor = true;
            radio90deg.CheckedChanged += radio90deg_CheckedChanged;
            // 
            // radio180deg
            // 
            radio180deg.AutoSize = true;
            radio180deg.Location = new Point(515, 13);
            radio180deg.Name = "radio180deg";
            radio180deg.Size = new Size(43, 19);
            radio180deg.TabIndex = 3;
            radio180deg.TabStop = true;
            radio180deg.Text = "180";
            radio180deg.UseVisualStyleBackColor = true;
            radio180deg.CheckedChanged += radio180deg_CheckedChanged;
            // 
            // radio270deg
            // 
            radio270deg.AutoSize = true;
            radio270deg.Location = new Point(564, 13);
            radio270deg.Name = "radio270deg";
            radio270deg.Size = new Size(43, 19);
            radio270deg.TabIndex = 4;
            radio270deg.TabStop = true;
            radio270deg.Text = "270";
            radio270deg.UseVisualStyleBackColor = true;
            radio270deg.CheckedChanged += radio270deg_CheckedChanged;
            // 
            // radio0deg
            // 
            radio0deg.AutoSize = true;
            radio0deg.Location = new Point(435, 13);
            radio0deg.Name = "radio0deg";
            radio0deg.Size = new Size(31, 19);
            radio0deg.TabIndex = 5;
            radio0deg.TabStop = true;
            radio0deg.Text = "0";
            radio0deg.UseVisualStyleBackColor = true;
            radio0deg.CheckedChanged += radio0deg_CheckedChanged;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(442, 360);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 6;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(337, 15);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 7;
            label2.Text = "Rotation Angle: ";
            // 
            // EditTextElement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(btnOK);
            Controls.Add(radio0deg);
            Controls.Add(radio270deg);
            Controls.Add(radio180deg);
            Controls.Add(radio90deg);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "EditTextElement";
            Text = "EditElement";
            Load += EditTextElementForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private RadioButton radio90deg;
        private RadioButton radio180deg;
        private RadioButton radio270deg;
        private RadioButton radio0deg;
        private Button btnOK;
        private Label label2;
    }
}