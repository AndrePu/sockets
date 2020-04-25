namespace DesktopClient
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fstMxName_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.secMxName_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fromRowRange_textBox = new System.Windows.Forms.TextBox();
            this.toRowRange_textBox = new System.Windows.Forms.TextBox();
            this.fromColRange_textBox = new System.Windows.Forms.TextBox();
            this.toColRange_textBox = new System.Windows.Forms.TextBox();
            this.calculate_button = new System.Windows.Forms.Button();
            this.log_label = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // fstMxName_textBox
            // 
            this.fstMxName_textBox.Location = new System.Drawing.Point(28, 74);
            this.fstMxName_textBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.fstMxName_textBox.Name = "fstMxName_textBox";
            this.fstMxName_textBox.Size = new System.Drawing.Size(268, 32);
            this.fstMxName_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name of first matrix";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name of second matrix";
            // 
            // secMxName_textBox
            // 
            this.secMxName_textBox.Location = new System.Drawing.Point(335, 74);
            this.secMxName_textBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.secMxName_textBox.Name = "secMxName_textBox";
            this.secMxName_textBox.Size = new System.Drawing.Size(268, 32);
            this.secMxName_textBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Columns range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rows result range";
            // 
            // fromRowRange_textBox
            // 
            this.fromRowRange_textBox.Location = new System.Drawing.Point(28, 180);
            this.fromRowRange_textBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.fromRowRange_textBox.Name = "fromRowRange_textBox";
            this.fromRowRange_textBox.Size = new System.Drawing.Size(55, 32);
            this.fromRowRange_textBox.TabIndex = 7;
            this.fromRowRange_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromRowRange_textBox_KeyPress);
            // 
            // toRowRange_textBox
            // 
            this.toRowRange_textBox.Location = new System.Drawing.Point(107, 180);
            this.toRowRange_textBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.toRowRange_textBox.Name = "toRowRange_textBox";
            this.toRowRange_textBox.Size = new System.Drawing.Size(55, 32);
            this.toRowRange_textBox.TabIndex = 11;
            this.toRowRange_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toRowRange_textBox_KeyPress);
            // 
            // fromColRange_textBox
            // 
            this.fromColRange_textBox.Location = new System.Drawing.Point(273, 180);
            this.fromColRange_textBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.fromColRange_textBox.Name = "fromColRange_textBox";
            this.fromColRange_textBox.Size = new System.Drawing.Size(55, 32);
            this.fromColRange_textBox.TabIndex = 12;
            this.fromColRange_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fromColRange_textBox_KeyPress);
            // 
            // toColRange_textBox
            // 
            this.toColRange_textBox.Location = new System.Drawing.Point(355, 180);
            this.toColRange_textBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.toColRange_textBox.Name = "toColRange_textBox";
            this.toColRange_textBox.Size = new System.Drawing.Size(55, 32);
            this.toColRange_textBox.TabIndex = 13;
            this.toColRange_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toColRange_textBox_KeyPress);
            // 
            // calculate_button
            // 
            this.calculate_button.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.calculate_button.Location = new System.Drawing.Point(467, 131);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(136, 81);
            this.calculate_button.TabIndex = 14;
            this.calculate_button.Text = "Calculate";
            this.calculate_button.UseVisualStyleBackColor = false;
            this.calculate_button.Click += new System.EventHandler(this.calculate_button_Click);
            // 
            // log_label
            // 
            this.log_label.Location = new System.Drawing.Point(25, 239);
            this.log_label.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.log_label.Name = "log_label";
            this.log_label.Size = new System.Drawing.Size(578, 162);
            this.log_label.TabIndex = 15;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(30, 239);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(575, 341);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(630, 612);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.log_label);
            this.Controls.Add(this.calculate_button);
            this.Controls.Add(this.toColRange_textBox);
            this.Controls.Add(this.fromColRange_textBox);
            this.Controls.Add(this.toRowRange_textBox);
            this.Controls.Add(this.fromRowRange_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.secMxName_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fstMxName_textBox);
            this.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matrix Multiplication";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fstMxName_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox secMxName_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fromRowRange_textBox;
        private System.Windows.Forms.TextBox toRowRange_textBox;
        private System.Windows.Forms.TextBox fromColRange_textBox;
        private System.Windows.Forms.TextBox toColRange_textBox;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.Label log_label;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

