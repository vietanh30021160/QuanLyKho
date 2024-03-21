namespace QuanLyKho
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
            dataGridView1 = new DataGridView();
            gbFilter = new GroupBox();
            btnSupplier = new Button();
            btnViewOrder = new Button();
            btnViewCategory = new Button();
            btnViewProduct = new Button();
            lbTitle = new Label();
            rBtnLightMode = new RadioButton();
            rBtnDarkMode = new RadioButton();
            btnCustomizeColors = new Button();
            btnHome = new Button();
            rBtnVNMode = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(685, 493);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // gbFilter
            // 
            gbFilter.Location = new Point(703, 12);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(367, 435);
            gbFilter.TabIndex = 1;
            gbFilter.TabStop = false;
            gbFilter.Text = "Filter";
            // 
            // btnSupplier
            // 
            btnSupplier.Location = new Point(982, 453);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(88, 36);
            btnSupplier.TabIndex = 7;
            btnSupplier.Text = "View Supplier";
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnViewOrder
            // 
            btnViewOrder.Location = new Point(901, 453);
            btnViewOrder.Name = "btnViewOrder";
            btnViewOrder.Size = new Size(75, 36);
            btnViewOrder.TabIndex = 6;
            btnViewOrder.Text = "View Order";
            btnViewOrder.UseVisualStyleBackColor = true;
            btnViewOrder.Click += btnViewOrder_Click;
            // 
            // btnViewCategory
            // 
            btnViewCategory.Location = new Point(794, 453);
            btnViewCategory.Name = "btnViewCategory";
            btnViewCategory.Size = new Size(101, 36);
            btnViewCategory.TabIndex = 5;
            btnViewCategory.Text = "View Category";
            btnViewCategory.UseVisualStyleBackColor = true;
            btnViewCategory.Click += btnViewCategory_Click;
            // 
            // btnViewProduct
            // 
            btnViewProduct.Location = new Point(703, 453);
            btnViewProduct.Name = "btnViewProduct";
            btnViewProduct.Size = new Size(85, 36);
            btnViewProduct.TabIndex = 3;
            btnViewProduct.Text = "View Product";
            btnViewProduct.UseVisualStyleBackColor = true;
            btnViewProduct.Click += btnViewProduct_Click;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lbTitle.Location = new Point(12, 519);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(825, 86);
            lbTitle.TabIndex = 8;
            lbTitle.Text = "HỆ THỐNG QUẢN LÝ KHO";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rBtnLightMode
            // 
            rBtnLightMode.AutoSize = true;
            rBtnLightMode.Checked = true;
            rBtnLightMode.Location = new Point(774, 497);
            rBtnLightMode.Name = "rBtnLightMode";
            rBtnLightMode.Size = new Size(86, 19);
            rBtnLightMode.TabIndex = 9;
            rBtnLightMode.TabStop = true;
            rBtnLightMode.Text = "Light mode";
            rBtnLightMode.UseVisualStyleBackColor = true;
            rBtnLightMode.CheckedChanged += rBtnLightMode_CheckedChanged;
            // 
            // rBtnDarkMode
            // 
            rBtnDarkMode.AutoSize = true;
            rBtnDarkMode.Location = new Point(866, 497);
            rBtnDarkMode.Name = "rBtnDarkMode";
            rBtnDarkMode.Size = new Size(83, 19);
            rBtnDarkMode.TabIndex = 10;
            rBtnDarkMode.Text = "Dark mode";
            rBtnDarkMode.UseVisualStyleBackColor = true;
            rBtnDarkMode.CheckedChanged += rBtnDarkMode_CheckedChanged;
            // 
            // btnCustomizeColors
            // 
            btnCustomizeColors.Location = new Point(955, 495);
            btnCustomizeColors.Name = "btnCustomizeColors";
            btnCustomizeColors.Size = new Size(115, 23);
            btnCustomizeColors.TabIndex = 11;
            btnCustomizeColors.Text = "Customize Colors";
            btnCustomizeColors.UseVisualStyleBackColor = true;
            btnCustomizeColors.Click += btnCustomizeColors_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(703, 494);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(57, 23);
            btnHome.TabIndex = 12;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // rBtnVNMode
            // 
            rBtnVNMode.AutoSize = true;
            rBtnVNMode.Location = new Point(862, 524);
            rBtnVNMode.Name = "rBtnVNMode";
            rBtnVNMode.Size = new Size(208, 19);
            rBtnVNMode.TabIndex = 13;
            rBtnVNMode.Text = "VietNam Number One Server Earth";
            rBtnVNMode.UseVisualStyleBackColor = true;
            rBtnVNMode.CheckedChanged += rBtnVNMode_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1074, 601);
            Controls.Add(rBtnVNMode);
            Controls.Add(btnHome);
            Controls.Add(dataGridView1);
            Controls.Add(btnCustomizeColors);
            Controls.Add(rBtnDarkMode);
            Controls.Add(rBtnLightMode);
            Controls.Add(lbTitle);
            Controls.Add(gbFilter);
            Controls.Add(btnSupplier);
            Controls.Add(btnViewProduct);
            Controls.Add(btnViewOrder);
            Controls.Add(btnViewCategory);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox gbFilter;
        private Button btnViewOrder;
        private Button btnViewCategory;
        private Button btnViewProduct;
        private Button btnSupplier;
        private Label lbTitle;
        private RadioButton rBtnLightMode;
        private RadioButton rBtnDarkMode;
        private Button btnCustomizeColors;
        private Button btnHome;
        private RadioButton rBtnVNMode;
    }
}
