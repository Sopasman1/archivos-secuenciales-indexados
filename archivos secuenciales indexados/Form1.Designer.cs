namespace archivos_secuenciales_indexados
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbBrand = new ComboBox();
            txtName = new TextBox();
            txtPrice = new TextBox();
            btnRegister = new Button();
            btnLoad = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            lstGames = new ListBox();
            txtSearch = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // cmbBrand
            // 
            cmbBrand.FormattingEnabled = true;
            cmbBrand.Location = new Point(12, 12);
            cmbBrand.Name = "cmbBrand";
            cmbBrand.Size = new Size(121, 23);
            cmbBrand.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 87);
            txtName.Name = "txtName";
            txtName.Size = new Size(216, 23);
            txtName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(12, 165);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(216, 23);
            txtPrice.TabIndex = 2;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(291, 11);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(75, 23);
            btnRegister.TabIndex = 3;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(399, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(504, 11);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(612, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lstGames
            // 
            lstGames.FormattingEnabled = true;
            lstGames.ItemHeight = 15;
            lstGames.Location = new Point(291, 77);
            lstGames.Name = "lstGames";
            lstGames.Size = new Size(396, 334);
            lstGames.TabIndex = 7;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 234);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(216, 23);
            txtSearch.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 19);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 9;
            label1.Text = "Brand";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 10;
            label2.Text = "Name Game";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 147);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 11;
            label3.Text = "Price";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(512, 422);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(lstGames);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);
            Controls.Add(btnRegister);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(cmbBrand);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBrand;
        private TextBox txtName;
        private TextBox txtPrice;
        private Button btnRegister;
        private Button btnLoad;
        private Button btnDelete;
        private Button btnSearch;
        private ListBox lstGames;
        private TextBox txtSearch;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblStatus;
    }
}
