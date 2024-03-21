using QuanLyKho.Models;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

namespace QuanLyKho
{
    public partial class Form1 : Form
    {
        QuanLyKhoContext context = new QuanLyKhoContext();

        private bool isProgrammaticChange = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            gbFilter.Controls.Clear();
            lbTitle.Text = "HỆ THỐNG QUẢN LÝ KHO HÀNG";
        }

        public void ChangeTheme(bool isDarkMode)
        {
            Color backColor, foreColor;

            if (isDarkMode)
            {
                backColor = Color.Black;
                foreColor = Color.White;
            }
            else
            {
                backColor = SystemColors.Control;
                foreColor = Color.Black;
            }

            this.BackColor = backColor;
            foreach (Control control in this.Controls)
            {
                control.ForeColor = foreColor;
                control.BackColor = backColor;

                if (control is DataGridView dataGridView)
                {
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = backColor;
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
                    dataGridView.DefaultCellStyle.BackColor = backColor;
                    dataGridView.DefaultCellStyle.ForeColor = foreColor;
                }
            }
        }

        private void rBtnLightMode_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTheme(!rBtnLightMode.Checked);
        }

        private void rBtnDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTheme(rBtnDarkMode.Checked);
        }
        private void rBtnVNMode_CheckedChanged(object sender, EventArgs e)
        {
            CustomizeColors(Color.Red, Color.Yellow);
        }

        public void CustomizeColors(Color backColor, Color foreColor)
        {
            this.BackColor = backColor;
            foreach (Control control in this.Controls)
            {
                control.BackColor = backColor;
                control.ForeColor = foreColor;

                if (control is DataGridView dataGridView)
                {
                    dataGridView.EnableHeadersVisualStyles = false;
                    dataGridView.ColumnHeadersDefaultCellStyle.BackColor = backColor;
                    dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
                    dataGridView.DefaultCellStyle.BackColor = backColor;
                    dataGridView.DefaultCellStyle.ForeColor = foreColor;
                }
            }
        }

        private void btnCustomizeColors_Click(object sender, EventArgs e)
        {
            Color backColor;
            Color foreColor;

            using (ColorDialog backColorDialog = new ColorDialog())
            {
                if (backColorDialog.ShowDialog() == DialogResult.OK)
                {
                    backColor = backColorDialog.Color;
                }
                else
                {
                    // User cancelled the dialog, return without making changes
                    return;
                }
            }

            using (ColorDialog foreColorDialog = new ColorDialog())
            {
                if (foreColorDialog.ShowDialog() == DialogResult.OK)
                {
                    foreColor = foreColorDialog.Color;
                }
                else
                {
                    // User cancelled the dialog, return without making changes
                    return;
                }
            }

            // Apply the chosen colors
            rBtnDarkMode.Checked = false;
            rBtnLightMode.Checked = false;
            CustomizeColors(backColor, foreColor);

        }

        private void btnViewCategory_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "Quản lý danh mục";
            gbFilter.Controls.Clear();
            Label labelId = new()
            {
                Name = "lbId",
                Text = "Mã danh mục",
                Size = new Size(82, 15),
                Location = new Point(37, 42)
            };

            TextBox textBoxId = new()
            {
                Name = "txtIdCate",
                Size = new Size(213, 23),
                Location = new Point(144, 39)
            };

            Label label = new()
            {
                Name = "lbName",
                Text = "Tên danh mục",
                Size = new Size(82, 15),
                Location = new Point(37, 82)
            };

            TextBox textBox = new()
            {
                Name = "txtNameCate",
                Size = new Size(213, 23),
                Location = new Point(144, 79)
            };

            TextBox textBoxSearch = new()
            {
                Name = "txtSearch",
                Size = new Size(294, 23),
                Location = new Point(6, 355)
            };

            Button buttonSearch = new()
            {
                Name = "btnSearchCate",
                Text = "Search",
                Size = new Size(55, 23),
                Location = new Point(306, 355)
            };
            buttonSearch.Click += new EventHandler(btnSearchCate_Click);

            Button buttonAdd = new()
            {
                Name = "btnAddCate",
                Text = "Add",
                Size = new Size(106, 36),
                Location = new Point(22, 393)
            };
            buttonAdd.Click += new EventHandler(btnAddCate_Click);

            Button buttomUpdate = new()
            {
                Name = "btnUpdateCate",
                Text = "Update",
                Size = new Size(106, 36),
                Location = new Point(129, 393)
            };
            buttomUpdate.Click += new EventHandler(btnUpdateCate_Click);

            Button buttonDelete = new()
            {
                Name = "btnDeleteCate",
                Text = "Delete",
                Size = new Size(106, 36),
                Location = new Point(236, 393)
            };
            buttonDelete.Click += new EventHandler(btnDeleteCate_Click);

            gbFilter.Controls.Add(labelId);
            gbFilter.Controls.Add(textBoxId);
            gbFilter.Controls.Add(label);
            gbFilter.Controls.Add(textBox);
            gbFilter.Controls.Add(buttonAdd);
            gbFilter.Controls.Add(buttomUpdate);
            gbFilter.Controls.Add(buttonDelete);
            gbFilter.Controls.Add(textBoxSearch);
            gbFilter.Controls.Add(buttonSearch);

            List<DanhMuc> danhMucs = context.DanhMucs.ToList();
            dataGridView1.DataSource = danhMucs;
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "Quản lý sản phẩm";
            gbFilter.Controls.Clear();

            TextBox textBoxId = new()
            {
                Name = "txtIdPro",
                Location = new Point(334, 0),
                Size = new Size(27, 23)
            };

            Label labelName = new()
            {
                Name = "lbName",
                Text = "Tên sản phẩm",
                Size = new Size(82, 15),
                Location = new Point(37, 42)
            };

            Label labelCate = new()
            {
                Name = "lbCate",
                Text = "Tên danh mục",
                Size = new Size(82, 15),
                Location = new Point(37, 82)
            };

            Label labelSupl = new()
            {
                Name = "lbSupl",
                Text = "Tên nhà cung cấp",
                Size = new Size(82, 15),
                Location = new Point(37, 122)
            };

            Label labelNum = new()
            {
                Name = "lbNum",
                Text = "Số lượng",
                Size = new Size(82, 15),
                Location = new Point(37, 162)
            };

            Label labelPrice = new()
            {
                Name = "lbPrice",
                Text = "Đơn giá",
                Size = new Size(82, 15),
                Location = new Point(37, 202)
            };

            TextBox textBoxName = new()
            {
                Name = "txtNamePro",
                Size = new Size(213, 23),
                Location = new Point(144, 39)
            };

            ComboBox comboBoxCate = new()
            {
                Name = "cbCate",
                Size = new Size(213, 23),
                Location = new Point(144, 79)
            };
            List<DanhMuc> danhMucs = context.DanhMucs.ToList();
            comboBoxCate.DataSource = danhMucs;
            comboBoxCate.SelectedIndexChanged += new EventHandler(comboBoxCate_SelectedIndexChanged);
            comboBoxCate.DisplayMember = "TenDanhMuc";
            comboBoxCate.ValueMember = "MaDanhMuc";

            ComboBox comboBoxSupl = new()
            {
                Name = "cbSupl",
                Size = new Size(213, 23),
                Location = new Point(144, 119)
            };
            List<NhaCungCap> nhaCungCaps = context.NhaCungCaps.ToList();
            comboBoxSupl.DataSource = nhaCungCaps;
            comboBoxSupl.SelectedIndexChanged += new EventHandler(comboBoxSupl_SelectedIndexChanged);
            comboBoxSupl.DisplayMember = "TenNhaCungCap";
            comboBoxSupl.ValueMember = "MaNhaCungCap";

            NumericUpDown numericUpDown = new()
            {
                Name = "numNum",
                Size = new Size(213, 23),
                Location = new Point(144, 159),
                Maximum = 10000000000000000
            };

            NumericUpDown numericUpDownPrice = new()
            {
                Name = "numPrice",
                Size = new Size(213, 23),
                Location = new Point(144, 199),
                Maximum = 10000000000000000
            };

            TextBox textBoxSearch = new()
            {
                Name = "txtSearch",
                Size = new Size(294, 23),
                Location = new Point(6, 355)
            };

            Button buttonSearch = new()
            {
                Name = "btnSearchPro",
                Text = "Search",
                Size = new Size(55, 23),
                Location = new Point(306, 355)
            };
            buttonSearch.Click += new EventHandler(btnSearchProduct_Click);

            Button buttonAdd = new()
            {
                Name = "btnAddPro",
                Text = "Add",
                Size = new Size(106, 36),
                Location = new Point(22, 393)
            };
            buttonAdd.Click += new EventHandler(btnAddProduct_Click);

            Button buttomUpdate = new()
            {
                Name = "btnUpdatePro",
                Text = "Update",
                Size = new Size(106, 36),
                Location = new Point(129, 393)
            };
            buttomUpdate.Click += new EventHandler(btnUpdateProduct_Click);

            Button buttonDelete = new()
            {
                Name = "btnDeletePro",
                Text = "Delete",
                Size = new Size(106, 36),
                Location = new Point(236, 393)
            };
            buttonDelete.Click += new EventHandler(btnDeleteProduct_Click);

            gbFilter.Controls.Add(textBoxId);
            gbFilter.Controls.Add(labelName);
            gbFilter.Controls.Add(labelCate);
            gbFilter.Controls.Add(labelSupl);
            gbFilter.Controls.Add(labelNum);
            gbFilter.Controls.Add(labelPrice);
            gbFilter.Controls.Add(textBoxName);
            gbFilter.Controls.Add(comboBoxCate);
            gbFilter.Controls.Add(comboBoxSupl);
            gbFilter.Controls.Add(numericUpDown);
            gbFilter.Controls.Add(numericUpDownPrice);
            gbFilter.Controls.Add(buttonAdd);
            gbFilter.Controls.Add(buttomUpdate);
            gbFilter.Controls.Add(buttonDelete);
            gbFilter.Controls.Add(textBoxSearch);
            gbFilter.Controls.Add(buttonSearch);

            List<SanPham> sanPhams = context.SanPhams.ToList();
            dataGridView1.DataSource = sanPhams;
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "Quản lý đơn hàng";
            gbFilter.Controls.Clear();

            TextBox textBoxId = new()
            {
                Name = "txtIdOrder",
                Location = new Point(334, 0),
                Size = new Size(23, 37)
            };

            Label label = new()
            {
                Name = "lbShowOrderDetail",
                Text = "Xem chi tiết đơn hàng",
                Size = new Size(124, 15),
                Location = new Point(23, 37)
            };

            ComboBox comboBox = new()
            {
                Name = "cbOrder",
                Size = new Size(197, 23),
                Location = new Point(164, 34)
            };
            List<DonDatHang> donDatHangs = context.DonDatHangs.ToList();
            comboBox.DataSource = donDatHangs;
            comboBox.DisplayMember = "MaDonHang";
            comboBox.ValueMember = "MaDonHang";
            comboBox.SelectedIndexChanged += new EventHandler(comboBoxOrder_SelectedIndexChanged);

            Label lbDateOrder = new()
            {
                Name = "lbDateOrder",
                Text = "Ngày đặt hàng",
                Size = new Size(124, 15),
                Location = new Point(23, 77)
            };

            DateTimePicker dateTimePicker = new()
            {
                Name = "dtpDateOrder",
                Size = new Size(197, 23),
                Location = new Point(164, 74)
            };

            Label lbTongTien = new()
            {
                Name = "lbTongTien",
                Text = "Tổng tiền: ",
                Size = new Size(91, 21),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(6, 303)
            };

            Label lbTongTienValue = new()
            {
                Name = "lbTongTienValue",
                Text = "",
                Size = new Size(91, 21),
                Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(91, 303)
            };

            TextBox textBoxSearch = new()
            {
                Name = "txtSearch",
                Size = new Size(294, 23),
                Location = new Point(6, 355)
            };

            Button buttonSearch = new()
            {
                Name = "btnSearchOrder",
                Text = "Search",
                Size = new Size(55, 23),
                Location = new Point(306, 355)
            };
            buttonSearch.Click += new EventHandler(btnSearchOrder_Click);

            Button buttonDelete = new()
            {
                Name = "btnDeleteOrder",
                Text = "Delete",
                Size = new Size(106, 36),
                Location = new Point(236, 393)
            };
            buttonDelete.Click += new EventHandler(btnDeleteOrder_Click);

            gbFilter.Controls.Add(textBoxId);
            gbFilter.Controls.Add(label);
            gbFilter.Controls.Add(comboBox);
            gbFilter.Controls.Add(lbDateOrder);
            gbFilter.Controls.Add(dateTimePicker);
            gbFilter.Controls.Add(lbTongTien);
            gbFilter.Controls.Add(lbTongTienValue);
            gbFilter.Controls.Add(buttonDelete);
            gbFilter.Controls.Add(textBoxSearch);
            gbFilter.Controls.Add(buttonSearch);

            List<DonDatHang> donDatHangs1 = context.DonDatHangs.ToList();
            dataGridView1.DataSource = donDatHangs1;
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            lbTitle.Text = "Quản lý nhà cung cấp";
            gbFilter.Controls.Clear();

            TextBox textBoxId = new()
            {
                Name = "txtIdSupplier",
                Location = new Point(334, 0),
                Size = new Size(27, 23)
            };

            Label labelName = new()
            {
                Name = "lbName",
                Text = "Tên nhà cung cấp",
                Size = new Size(82, 15),
                Location = new Point(37, 42)
            };

            Label labelAddress = new()
            {
                Name = "lbAddress",
                Text = "Địa chỉ",
                Size = new Size(82, 15),
                Location = new Point(37, 82)
            };

            Label labelPhone = new()
            {
                Name = "lbPhone",
                Text = "Số điện thoại",
                Size = new Size(82, 15),
                Location = new Point(37, 122)
            };

            TextBox textBoxName = new()
            {
                Name = "txtNameSupl",
                Size = new Size(213, 23),
                Location = new Point(144, 39)
            };

            TextBox textBoxAddress = new()
            {
                Name = "txtAddress",
                Size = new Size(213, 23),
                Location = new Point(144, 79)
            };

            TextBox textBoxPhone = new()
            {
                Name = "txtPhone",
                Size = new Size(213, 23),
                Location = new Point(144, 119)
            };

            TextBox textBoxSearch = new()
            {
                Name = "txtSearch",
                Size = new Size(294, 23),
                Location = new Point(6, 355)
            };

            Button buttonSearch = new()
            {
                Name = "btnSearchSupplier",
                Text = "Search",
                Size = new Size(55, 23),
                Location = new Point(306, 355)
            };
            buttonSearch.Click += new EventHandler(btnSearchSuppl_Click);


            Button buttonAdd = new()
            {
                Name = "btnAddSupplier",
                Text = "Add",
                Size = new Size(106, 36),
                Location = new Point(22, 393)
            };
            buttonAdd.Click += new EventHandler(btnAddSupplier_Click);

            Button buttomUpdate = new()
            {
                Name = "btnUpdateSupplier",
                Text = "Update",
                Size = new Size(106, 36),
                Location = new Point(129, 393)
            };
            buttomUpdate.Click += new EventHandler(btnUpdateSupplier_Click);

            Button buttonDelete = new()
            {
                Name = "btnDeleteSupplier",
                Text = "Delete",
                Size = new Size(106, 36),
                Location = new Point(236, 393)
            };
            buttonDelete.Click += new EventHandler(btnDeleteSupplier_Click);

            gbFilter.Controls.Add(textBoxId);
            gbFilter.Controls.Add(labelName);
            gbFilter.Controls.Add(labelAddress);
            gbFilter.Controls.Add(labelPhone);
            gbFilter.Controls.Add(textBoxName);
            gbFilter.Controls.Add(textBoxAddress);
            gbFilter.Controls.Add(textBoxPhone);
            gbFilter.Controls.Add(buttonAdd);
            gbFilter.Controls.Add(buttomUpdate);
            gbFilter.Controls.Add(buttonDelete);
            gbFilter.Controls.Add(textBoxSearch);
            gbFilter.Controls.Add(buttonSearch);

            List<NhaCungCap> nhaCungCaps = context.NhaCungCaps.ToList();
            dataGridView1.DataSource = nhaCungCaps;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());

            if (gbFilter.Controls.ContainsKey("btnAddCate"))
            {
                DanhMuc danhMuc = context.DanhMucs.Find(id);
                gbFilter.Controls["txtIdCate"].Text = danhMuc.MaDanhMuc.ToString();
                gbFilter.Controls["txtNameCate"].Text = danhMuc.TenDanhMuc;
            }
            else if (gbFilter.Controls.ContainsKey("btnAddPro"))
            {
                SanPham sanPham = context.SanPhams.Find(id);
                gbFilter.Controls["txtIdPro"].Text = id.ToString();
                gbFilter.Controls["txtNamePro"].Text = sanPham.TenSanPham;
                isProgrammaticChange = true;
                if (sanPham.MaDanhMucNavigation != null)
                {
                    gbFilter.Controls["cbCate"].Text = sanPham.MaDanhMucNavigation.TenDanhMuc;
                }
                else
                {
                    gbFilter.Controls["cbCate"].Text = "";
                }
                isProgrammaticChange = true;
                gbFilter.Controls["cbSupl"].Text = sanPham.MaNhaCungCapNavigation.TenNhaCungCap;
                gbFilter.Controls["numNum"].Text = sanPham.SoLuong.ToString();
                gbFilter.Controls["numPrice"].Text = sanPham.DonGia.ToString();
            }
            else if (gbFilter.Controls.ContainsKey("btnDeleteOrder"))
            {
                DonDatHang donDatHang = context.DonDatHangs.Find(id);
                gbFilter.Controls["txtIdOrder"].Text = donDatHang.MaDonHang.ToString();
                isProgrammaticChange = true;
                gbFilter.Controls["cbOrder"].Text = donDatHang.MaDonHang.ToString();
                gbFilter.Controls["dtpDateOrder"].Text = donDatHang.NgayDat.ToString();
                gbFilter.Controls["lbTongTienValue"].Text = donDatHang.TongTien.ToString();
            }
            else if (gbFilter.Controls.ContainsKey("btnAddSupplier"))
            {
                NhaCungCap nhaCungCap = context.NhaCungCaps.Find(id);
                gbFilter.Controls["txtIdSupplier"].Text = nhaCungCap.MaNhaCungCap.ToString();
                gbFilter.Controls["txtNameSupl"].Text = nhaCungCap.TenNhaCungCap;
                gbFilter.Controls["txtAddress"].Text = nhaCungCap.DiaChi;
                gbFilter.Controls["txtPhone"].Text = nhaCungCap.DienThoai;
            }
            else if (gbFilter.Controls.ContainsKey("btnUpdateOrderDetail"))
            {
                ChiTietDonDatHang chiTietDonDatHang = context.ChiTietDonDatHangs.Find(id);
                gbFilter.Controls["txtIdOrderDetail"].Text = chiTietDonDatHang.MaChiTiet.ToString();
                isProgrammaticChange = true;
                gbFilter.Controls["cbOrderDetail"].Text = chiTietDonDatHang.MaDonHang.ToString();
                gbFilter.Controls["dtpDateOrder"].Text = chiTietDonDatHang.MaDonHangNavigation.NgayDat.ToString();
                gbFilter.Controls["txtNamePro"].Text = context.SanPhams.Find(chiTietDonDatHang.MaSanPham).TenSanPham;
                gbFilter.Controls["numNum"].Text = chiTietDonDatHang.SoLuong.ToString();
                gbFilter.Controls["numPrice"].Text = chiTietDonDatHang.GiaTien.ToString();
                gbFilter.Controls["lbTongTienValue"].Text = chiTietDonDatHang.MaDonHangNavigation.TongTien.ToString();
            }
        }

        private void comboBoxCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxCate = gbFilter.Controls["cbCate"] as ComboBox;

            if (isProgrammaticChange)
            {
                // Ignore programmatic changes
                isProgrammaticChange = false;
                return;
            }

            // Handle user changes

            // Kiểm tra xem comboBoxCate có giá trị null hay không
            if (comboBoxCate != null)
            {
                // Lấy đối tượng DanhMuc được chọn từ comboBoxCate
                DanhMuc selectedDanhMuc = comboBoxCate.SelectedItem as DanhMuc;

                // Kiểm tra xem selectedDanhMuc có giá trị null hay không
                if (selectedDanhMuc != null)
                {
                    // Lấy mã danh mục từ đối tượng DanhMuc và sử dụng nó làm categoryId
                    int categoryId = selectedDanhMuc.MaDanhMuc;

                    // Truy vấn các sản phẩm tương ứng từ cơ sở dữ liệu
                    List<SanPham> sanPhams = context.SanPhams.Where(sp => sp.MaDanhMuc == categoryId).ToList();

                    // Hiển thị kết quả trong dataGridView1
                    dataGridView1.DataSource = sanPhams;
                }
            }
        }

        private void comboBoxSupl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxSupl = gbFilter.Controls["cbSupl"] as ComboBox;

            if (isProgrammaticChange)
            {
                // Ignore programmatic changes
                isProgrammaticChange = false;
                return;
            }

            // Handle user changes

            // Kiểm tra xem comboBoxSupl có giá trị null hay không
            if (comboBoxSupl != null)
            {
                // Lấy đối tượng NhaCungCap được chọn từ comboBoxSupl
                NhaCungCap selectedNhaCungCap = comboBoxSupl.SelectedItem as NhaCungCap;

                // Kiểm tra xem selectedNhaCungCap có giá trị null hay không
                if (selectedNhaCungCap != null)
                {
                    // Lấy mã nhà cung cấp từ đối tượng NhaCungCap và sử dụng nó làm supplierId
                    int supplierId = selectedNhaCungCap.MaNhaCungCap;

                    // Truy vấn các sản phẩm tương ứng từ cơ sở dữ liệu
                    List<SanPham> sanPhams = context.SanPhams.Where(sp => sp.MaNhaCungCap == supplierId).ToList();

                    // Hiển thị kết quả trong dataGridView1
                    dataGridView1.DataSource = sanPhams;
                }
            }
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            string name = gbFilter.Controls["txtNameCate"].Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên danh mục không được để trống");
                return;
            }
            else if (context.DanhMucs.Any(x => x.TenDanhMuc.Equals(name)))
            {
                MessageBox.Show("Tên danh mục đã tồn tại");
                return;
            }
            else
            {
                DanhMuc danhMuc = new DanhMuc
                {
                    TenDanhMuc = name
                };
                context.DanhMucs.Add(danhMuc);
                context.SaveChanges();
                btnViewCategory_Click(sender, e);
            }

        }

        private void btnUpdateCate_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdCate"].Text;
            string name = gbFilter.Controls["txtNameCate"].Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên danh mục không được để trống");
                return;
            }
            else if (context.DanhMucs.Any(x => x.TenDanhMuc.Equals(name)))
            {
                MessageBox.Show("Tên danh mục đã tồn tại");
                return;
            }
            else
            {
                DanhMuc danhMuc = context.DanhMucs.Find(int.Parse(id));
                danhMuc.TenDanhMuc = name;
                context.SaveChanges();
                btnViewCategory_Click(sender, e);
            }
        }

        private void btnDeleteCate_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdCate"].Text;
            DanhMuc danhMuc = context.DanhMucs.Find(int.Parse(id));

            // Check if the Category is referenced by any products
            if (context.SanPhams.Any(sp => sp.MaDanhMuc == danhMuc.MaDanhMuc))
            {
                // Ask the user for confirmation
                var result = MessageBox.Show("This category is referenced by one or more products. Do you want to delete all products referencing this category?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Delete all products referencing the Category
                    var products = context.SanPhams.Where(sp => sp.MaDanhMuc == danhMuc.MaDanhMuc).ToList();
                    foreach (var product in products)
                    {
                        // Delete all order details referencing the Product
                        var orderDetails = context.ChiTietDonDatHangs.Where(ct => ct.MaSanPham == product.MaSanPham).ToList();
                        foreach (var orderDetail in orderDetails)
                        {
                            context.ChiTietDonDatHangs.Remove(orderDetail);
                        }

                        context.SanPhams.Remove(product);
                    }
                }
                else
                {
                    // If the user doesn't confirm, return without deleting the Category
                    return;
                }
            }

            // Delete the Category
            context.DanhMucs.Remove(danhMuc);
            context.SaveChanges();
            btnViewCategory_Click(sender, e);
        }

        private void btnSearchCate_Click(object sender, EventArgs e)
        {
            string name = gbFilter.Controls["txtSearch"].Text;
            List<DanhMuc> danhMucs = context.DanhMucs.Where(x => x.TenDanhMuc.Contains(name)).ToList();
            dataGridView1.DataSource = danhMucs;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = gbFilter.Controls["txtNamePro"].Text;
            ComboBox cbCate = gbFilter.Controls["cbCate"] as ComboBox;
            string cate = cbCate.SelectedValue.ToString();
            ComboBox cbSupl = gbFilter.Controls["cbSupl"] as ComboBox;
            string supl = cbSupl.SelectedValue.ToString();
            string num = gbFilter.Controls["numNum"].Text;
            string price = gbFilter.Controls["numPrice"].Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên sản phẩm không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(cate))
            {
                MessageBox.Show("Danh mục không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(supl))
            {
                MessageBox.Show("Nhà cung cấp không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("Số lượng không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Đơn giá không được để trống");
                return;
            }
            else
            {
                int.TryParse(cate, out int cateInt);
                int.TryParse(supl, out int suplInt);
                int.TryParse(num, out int numInt);
                decimal.TryParse(price, out decimal priceDec);

                SanPham sanPham = new SanPham
                {
                    TenSanPham = name,
                    MaDanhMuc = cateInt,
                    MaDanhMucNavigation = context.DanhMucs.Find(cateInt),
                    MaNhaCungCap = suplInt,
                    MaNhaCungCapNavigation = context.NhaCungCaps.Find(suplInt),
                    SoLuong = numInt,
                    DonGia = priceDec
                };
                context.SanPhams.Add(sanPham);
                context.SaveChanges();
                btnViewProduct_Click(sender, e);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdPro"].Text;
            string name = gbFilter.Controls["txtNamePro"].Text;
            ComboBox cbCate = gbFilter.Controls["cbCate"] as ComboBox;
            string cate = cbCate.SelectedValue.ToString();
            ComboBox cbSupl = gbFilter.Controls["cbSupl"] as ComboBox;
            string supl = cbSupl.SelectedValue.ToString();
            string num = gbFilter.Controls["numNum"].Text;
            string price = gbFilter.Controls["numPrice"].Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên sản phẩm không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(cate))
            {
                MessageBox.Show("Danh mục không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(supl))
            {
                MessageBox.Show("Nhà cung cấp không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("Số lượng không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Đơn giá không được để trống");
                return;
            }
            else
            {
                SanPham sanPham = context.SanPhams.Find(int.Parse(id));
                sanPham.TenSanPham = name;
                sanPham.MaDanhMuc = int.Parse(cate);
                sanPham.MaDanhMucNavigation = context.DanhMucs.Find(int.Parse(cate));
                sanPham.MaNhaCungCap = int.Parse(supl);
                sanPham.MaNhaCungCapNavigation = context.NhaCungCaps.Find(int.Parse(supl));
                sanPham.SoLuong = int.Parse(num);
                sanPham.DonGia = decimal.Parse(price);
                context.SaveChanges();
                btnViewProduct_Click(sender, e);

            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdPro"].Text;
            SanPham sanPham = context.SanPhams.Find(int.Parse(id));
            context.SanPhams.Remove(sanPham);
            context.SaveChanges();
            btnViewProduct_Click(sender, e);
        }

        private void btnSearchSuppl_Click(object sender, EventArgs e)
        {
            string name = gbFilter.Controls["txtSearch"].Text;
            List<NhaCungCap> nhaCungCaps = context.NhaCungCaps.Where(x => x.TenNhaCungCap.Contains(name)).ToList();
            dataGridView1.DataSource = nhaCungCaps;
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string name = gbFilter.Controls["txtNameSupl"].Text;
            string address = gbFilter.Controls["txtAddress"].Text;
            string phone = gbFilter.Controls["txtPhone"].Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            else
            {
                NhaCungCap nhaCungCap = new NhaCungCap
                {
                    TenNhaCungCap = name,
                    DiaChi = address,
                    DienThoai = phone
                };
                context.NhaCungCaps.Add(nhaCungCap);
                context.SaveChanges();
                btnSupplier_Click(sender, e);
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdSupplier"].Text;
            string name = gbFilter.Controls["txtNameSupl"].Text;
            string address = gbFilter.Controls["txtAddress"].Text;
            string phone = gbFilter.Controls["txtPhone"].Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Địa chỉ không được để trống");
                return;
            }
            else if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return;
            }
            else
            {
                NhaCungCap nhaCungCap = context.NhaCungCaps.Find(int.Parse(id));
                nhaCungCap.TenNhaCungCap = name;
                nhaCungCap.DiaChi = address;
                nhaCungCap.DienThoai = phone;
                context.SaveChanges();
                btnSupplier_Click(sender, e);
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdSupplier"].Text;
            NhaCungCap nhaCungCap = context.NhaCungCaps.Find(int.Parse(id));

            // Check if the Supplier is referenced by any products
            if (context.SanPhams.Any(sp => sp.MaNhaCungCap == nhaCungCap.MaNhaCungCap))
            {
                // Ask the user for confirmation
                var result = MessageBox.Show("This supplier is referenced by one or more products. Do you want to delete all products referencing this supplier?", "Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Delete all products referencing the Category
                    var products = context.SanPhams.Where(sp => sp.MaNhaCungCap == nhaCungCap.MaNhaCungCap).ToList();
                    foreach (var product in products)
                    {
                        // Delete all order details referencing the Product
                        var orderDetails = context.ChiTietDonDatHangs.Where(ct => ct.MaSanPham == product.MaSanPham).ToList();
                        foreach (var orderDetail in orderDetails)
                        {
                            context.ChiTietDonDatHangs.Remove(orderDetail);
                        }

                        context.SanPhams.Remove(product);
                    }
                }
                else
                {
                    // If the user doesn't confirm, return without deleting the Supplier
                    return;
                }
            }

            // Delete the Supplier
            context.NhaCungCaps.Remove(nhaCungCap);
            context.SaveChanges();
            btnSupplier_Click(sender, e);
        }

        private void comboBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxOrder = gbFilter.Controls["cbOrder"] as ComboBox;

            if (isProgrammaticChange)
            {
                // Ignore programmatic changes
                isProgrammaticChange = false;
                return;
            }

            // Handle user changes

            // Kiểm tra xem comboBoxOrder có giá trị null hay không
            if (comboBoxOrder != null)
            {
                // Lấy đối tượng DonDatHang được chọn từ comboBoxOrder
                DonDatHang selectedDonDatHang = comboBoxOrder.SelectedItem as DonDatHang;

                // Kiểm tra xem selectedDonDatHang có giá trị null hay không
                if (selectedDonDatHang != null)
                {
                    // Lấy mã đơn hàng từ đối tượng DonDatHang và sử dụng nó làm orderId
                    int orderId = selectedDonDatHang.MaDonHang;

                    // Truy vấn các chi tiết đơn hàng tương ứng từ cơ sở dữ liệu
                    List<ChiTietDonDatHang> chiTietDonDatHangs = context.ChiTietDonDatHangs.Where(ct => ct.MaDonHang == orderId).ToList();

                    // Hiển thị kết quả trong dataGridView1
                    dataGridView1.DataSource = chiTietDonDatHangs;

                    gbFilter.Controls.Clear();

                    TextBox textBoxId = new()
                    {
                        Name = "txtIdOrderDetail",
                        Location = new Point(334, 0),
                        Size = new Size(23, 37)
                    };

                    Label label = new()
                    {
                        Name = "lbShowOrderDetail",
                        Text = "Xem chi tiết đơn hàng",
                        Size = new Size(124, 15),
                        Location = new Point(23, 37)
                    };

                    ComboBox comboBoxOrderDetail = new()
                    {
                        Name = "cbOrderDetail",
                        Size = new Size(197, 23),
                        Location = new Point(164, 34)
                    };
                    List<DonDatHang> donDatHangs = context.DonDatHangs.ToList();
                    comboBoxOrderDetail.DataSource = donDatHangs;
                    comboBoxOrderDetail.DisplayMember = "MaDonHang";
                    comboBoxOrderDetail.ValueMember = "MaDonHang";
                    comboBoxOrderDetail.SelectedIndexChanged += new EventHandler(comboBoxOrderDetail_SelectedIndexChanged);

                    Label lbDateOrder = new()
                    {
                        Name = "lbDateOrder",
                        Text = "Ngày đặt hàng",
                        Size = new Size(124, 15),
                        Location = new Point(23, 77)
                    };

                    DateTimePicker dateTimePicker = new()
                    {
                        Name = "dtpDateOrder",
                        Size = new Size(197, 23),
                        Location = new Point(164, 74)
                    };

                    Label lbNamePro = new()
                    {
                        Name = "lbNamePro",
                        Text = "Tên sản phẩm",
                        Size = new Size(124, 15),
                        Location = new Point(23, 117)
                    };

                    TextBox txtNamePro = new()
                    {
                        Name = "txtNamePro",
                        Size = new Size(197, 23),
                        Location = new Point(164, 114)
                    };

                    Label lbNum = new()
                    {
                        Name = "lbNum",
                        Text = "Số lượng",
                        Size = new Size(124, 15),
                        Location = new Point(23, 157)
                    };

                    NumericUpDown numNum = new()
                    {
                        Name = "numNum",
                        Size = new Size(197, 23),
                        Location = new Point(164, 154),
                        Maximum = 10000000000000000
                    };

                    Label lbPrice = new()
                    {
                        Name = "lbPrice",
                        Text = "Đơn giá",
                        Size = new Size(124, 15),
                        Location = new Point(23, 197)
                    };

                    NumericUpDown numPrice = new()
                    {
                        Name = "numPrice",
                        Size = new Size(197, 23),
                        Location = new Point(164, 194),
                        Maximum = 10000000000000000
                    };

                    Label lbTongTien = new()
                    {
                        Name = "lbTongTien",
                        Text = "Tổng tiền: ",
                        Size = new Size(91, 21),
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                        Location = new Point(6, 303)
                    };

                    Label lbTongTienValue = new()
                    {
                        Name = "lbTongTienValue",
                        Text = "",
                        Size = new Size(91, 21),
                        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                        Location = new Point(91, 303)
                    };
                    lbTongTienValue.Text = selectedDonDatHang.TongTien.ToString();

                    Button buttomUpdate = new()
                    {
                        Name = "btnUpdateOrderDetail",
                        Text = "Update",
                        Size = new Size(106, 36),
                        Location = new Point(129, 393)
                    };
                    buttomUpdate.Click += new EventHandler(btnUpdateOrderDetail_Click);

                    Button buttonDelete = new()
                    {
                        Name = "btnDeleteOrderDetail",
                        Text = "Delete",
                        Size = new Size(106, 36),
                        Location = new Point(236, 393)
                    };
                    buttonDelete.Click += new EventHandler(btnDeleteOrderDetail_Click);

                    gbFilter.Controls.Add(textBoxId);
                    gbFilter.Controls.Add(label);
                    gbFilter.Controls.Add(comboBoxOrderDetail);
                    gbFilter.Controls.Add(lbDateOrder);
                    gbFilter.Controls.Add(dateTimePicker);
                    gbFilter.Controls.Add(lbNamePro);
                    gbFilter.Controls.Add(txtNamePro);
                    gbFilter.Controls.Add(lbNum);
                    gbFilter.Controls.Add(numNum);
                    gbFilter.Controls.Add(lbPrice);
                    gbFilter.Controls.Add(numPrice);
                    gbFilter.Controls.Add(lbTongTien);
                    gbFilter.Controls.Add(lbTongTienValue);
                    gbFilter.Controls.Add(buttomUpdate);
                    gbFilter.Controls.Add(lbDateOrder);
                    gbFilter.Controls.Add(dateTimePicker);
                    gbFilter.Controls.Add(buttonDelete);
                }
            }
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtSearch"].Text;
            List<DonDatHang> donDatHangs = context.DonDatHangs.Where(x => x.MaDonHang.ToString().Contains(id)).ToList();
            dataGridView1.DataSource = donDatHangs;
        }

        private void comboBoxOrderDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxOrder = gbFilter.Controls["cbOrderDetail"] as ComboBox;

            if (isProgrammaticChange)
            {
                // Ignore programmatic changes
                isProgrammaticChange = false;
                return;
            }

            // Handle user changes

            // Kiểm tra xem comboBoxOrder có giá trị null hay không
            if (comboBoxOrder != null)
            {
                // Lấy đối tượng DonDatHang được chọn từ comboBoxOrder
                DonDatHang selectedDonDatHang = comboBoxOrder.SelectedItem as DonDatHang;

                // Kiểm tra xem selectedDonDatHang có giá trị null hay không
                if (selectedDonDatHang != null)
                {
                    // Lấy mã đơn hàng từ đối tượng DonDatHang và sử dụng nó làm orderId
                    int orderId = selectedDonDatHang.MaDonHang;

                    // Truy vấn các chi tiết đơn hàng tương ứng từ cơ sở dữ liệu
                    List<ChiTietDonDatHang> chiTietDonDatHangs = context.ChiTietDonDatHangs.Where(ct => ct.MaDonHang == orderId).ToList();

                    // Hiển thị kết quả trong dataGridView1
                    dataGridView1.DataSource = chiTietDonDatHangs;

                    gbFilter.Controls.Clear();

                    TextBox textBoxId = new()
                    {
                        Name = "txtIdOrderDetail",
                        Location = new Point(334, 0),
                        Size = new Size(23, 37)
                    };

                    Label label = new()
                    {
                        Name = "lbShowOrderDetail",
                        Text = "Xem chi tiết đơn hàng",
                        Size = new Size(124, 15),
                        Location = new Point(23, 37)
                    };

                    ComboBox comboBoxOrderDetail = new()
                    {
                        Name = "cbOrderDetail",
                        Size = new Size(197, 23),
                        Location = new Point(164, 34)
                    };
                    List<DonDatHang> donDatHangs = context.DonDatHangs.ToList();
                    comboBoxOrderDetail.DataSource = donDatHangs;
                    comboBoxOrderDetail.DisplayMember = "MaDonHang";
                    comboBoxOrderDetail.ValueMember = "MaDonHang";
                    comboBoxOrderDetail.SelectedIndexChanged += new EventHandler(comboBoxOrderDetail_SelectedIndexChanged);

                    Label lbDateOrder = new()
                    {
                        Name = "lbDateOrder",
                        Text = "Ngày đặt hàng",
                        Size = new Size(124, 15),
                        Location = new Point(23, 77)
                    };

                    DateTimePicker dateTimePicker = new()
                    {
                        Name = "dtpDateOrder",
                        Size = new Size(197, 23),
                        Location = new Point(164, 74)
                    };

                    Label lbNamePro = new()
                    {
                        Name = "lbNamePro",
                        Text = "Tên sản phẩm",
                        Size = new Size(124, 15),
                        Location = new Point(23, 117)
                    };

                    TextBox txtNamePro = new()
                    {
                        Name = "txtNamePro",
                        Size = new Size(197, 23),
                        Location = new Point(164, 114)
                    };

                    Label lbNum = new()
                    {
                        Name = "lbNum",
                        Text = "Số lượng",
                        Size = new Size(124, 15),
                        Location = new Point(23, 157)
                    };

                    NumericUpDown numNum = new()
                    {
                        Name = "numNum",
                        Size = new Size(197, 23),
                        Location = new Point(164, 154),
                        Maximum = 10000000000000000
                    };

                    Label lbPrice = new()
                    {
                        Name = "lbPrice",
                        Text = "Đơn giá",
                        Size = new Size(124, 15),
                        Location = new Point(23, 197)
                    };

                    NumericUpDown numPrice = new()
                    {
                        Name = "numPrice",
                        Size = new Size(197, 23),
                        Location = new Point(164, 194),
                        Maximum = 10000000000000000
                    };

                    Label lbTongTien = new()
                    {
                        Name = "lbTongTien",
                        Text = "Tổng tiền: ",
                        Size = new Size(91, 21),
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
                        Location = new Point(6, 303)
                    };

                    Label lbTongTienValue = new()
                    {
                        Name = "lbTongTienValue",
                        Text = "",
                        Size = new Size(91, 21),
                        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point),
                        Location = new Point(91, 303)
                    };

                    Button buttomUpdate = new()
                    {
                        Name = "btnUpdateOrderDetail",
                        Text = "Update",
                        Size = new Size(106, 36),
                        Location = new Point(129, 393)
                    };
                    buttomUpdate.Click += new EventHandler(btnUpdateOrderDetail_Click);

                    Button buttonDelete = new()
                    {
                        Name = "btnDeleteOrderDetail",
                        Text = "Delete",
                        Size = new Size(106, 36),
                        Location = new Point(236, 393)
                    };
                    buttonDelete.Click += new EventHandler(btnDeleteOrderDetail_Click);

                    gbFilter.Controls.Add(textBoxId);
                    gbFilter.Controls.Add(label);
                    gbFilter.Controls.Add(comboBoxOrderDetail);
                    gbFilter.Controls.Add(lbDateOrder);
                    gbFilter.Controls.Add(dateTimePicker);
                    gbFilter.Controls.Add(lbNamePro);
                    gbFilter.Controls.Add(txtNamePro);
                    gbFilter.Controls.Add(lbNum);
                    gbFilter.Controls.Add(numNum);
                    gbFilter.Controls.Add(lbPrice);
                    gbFilter.Controls.Add(numPrice);
                    gbFilter.Controls.Add(lbTongTien);
                    gbFilter.Controls.Add(lbTongTienValue);
                    gbFilter.Controls.Add(buttomUpdate);
                    gbFilter.Controls.Add(lbDateOrder);
                    gbFilter.Controls.Add(dateTimePicker);
                    gbFilter.Controls.Add(buttonDelete);
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdOrder"].Text;
            DonDatHang donDatHang = context.DonDatHangs.Find(int.Parse(id));

            // Delete the order details first
            foreach (var detail in donDatHang.ChiTietDonDatHangs.ToList())
            {
                context.ChiTietDonDatHangs.Remove(detail);
            }

            // Then delete the order
            context.DonDatHangs.Remove(donDatHang);
            context.SaveChanges();
            btnViewOrder_Click(sender, e);
        }

        private void btnDeleteOrderDetail_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdOrderDetail"].Text;
            ChiTietDonDatHang chiTietDonDatHang = context.ChiTietDonDatHangs.Find(int.Parse(id));
            int maDonHang = chiTietDonDatHang.MaDonHangNavigation.MaDonHang;
            context.ChiTietDonDatHangs.Remove(chiTietDonDatHang);
            context.SaveChanges();

            // Recalculate and update TongTien of the order
            DonDatHang order = context.DonDatHangs.Find(maDonHang);
            order.TongTien = order.ChiTietDonDatHangs.Sum(ct => ct.GiaTien);
            context.SaveChanges();

            List<ChiTietDonDatHang> chiTietDonDatHangs = context.ChiTietDonDatHangs.Where(ct => ct.MaDonHang == maDonHang).ToList();
            Label lbTongTienValue = gbFilter.Controls["lbTongTienValue"] as Label;
            lbTongTienValue.Text = context.DonDatHangs.Find(maDonHang).TongTien.ToString();
            dataGridView1.DataSource = chiTietDonDatHangs;
        }

        private void btnUpdateOrderDetail_Click(object sender, EventArgs e)
        {
            string id = gbFilter.Controls["txtIdOrderDetail"].Text;
            string num = gbFilter.Controls["numNum"].Text;
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("Số lượng không được để trống");
                return;
            }
            else
            {
                ChiTietDonDatHang chiTietDonDatHang = context.ChiTietDonDatHangs.Find(int.Parse(id));
                int quantity = int.Parse(num);
                chiTietDonDatHang.SoLuong = quantity;
                // Retrieve the product associated with the order detail
                SanPham product = context.SanPhams.Find(chiTietDonDatHang.MaSanPham);
                // Calculate GiaTien based on num and product price
                chiTietDonDatHang.GiaTien = chiTietDonDatHang.SoLuong * product.DonGia;
                context.SaveChanges();

                // Calculate and update TongTien of the order
                DonDatHang order = context.DonDatHangs.Find(chiTietDonDatHang.MaDonHang);
                order.TongTien = order.ChiTietDonDatHangs.Sum(ct => ct.GiaTien);
                context.SaveChanges();

                List<ChiTietDonDatHang> chiTietDonDatHangs = context.ChiTietDonDatHangs.Where(ct => ct.MaDonHang == chiTietDonDatHang.MaDonHang).ToList();
                Label lbTongTienValue = gbFilter.Controls["lbTongTienValue"] as Label;
                lbTongTienValue.Text = context.DonDatHangs.Find(chiTietDonDatHang.MaDonHang).TongTien.ToString();
                dataGridView1.DataSource = chiTietDonDatHangs;
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string text = gbFilter.Controls["txtSearch"].Text;
            text = text.Trim();
            text = Regex.Replace(text, @"\s+", " ");
            text = RemoveDiacritics(text.ToLower());

            var sanPhams = context.SanPhams
                .ToList() // Fetch data from database
                .Where(x => (x.TenSanPham != null && RemoveDiacritics(x.TenSanPham.ToLower()).Contains(text)) ||
                    (x.MaDanhMucNavigation?.TenDanhMuc != null && RemoveDiacritics(x.MaDanhMucNavigation.TenDanhMuc.ToLower()).Contains(text)) ||
                    (x.MaNhaCungCapNavigation?.TenNhaCungCap != null && RemoveDiacritics(x.MaNhaCungCapNavigation.TenNhaCungCap.ToLower()).Contains(text)));


            var orderedSanPhams = sanPhams
                 .Select(x => new
                 {
                     Product = x,
                     Rank = ((RemoveDiacritics(x.TenSanPham?.ToLower()).StartsWith(text) ? 6 : (RemoveDiacritics(x.TenSanPham?.ToLower()).Contains(text) ? 3 : 0))
                         + (RemoveDiacritics(x.MaDanhMucNavigation?.TenDanhMuc?.ToLower()).StartsWith(text) ? 4 : (RemoveDiacritics(x.MaDanhMucNavigation?.TenDanhMuc?.ToLower()).Contains(text) ? 2 : 0))
                         + (RemoveDiacritics(x.MaNhaCungCapNavigation?.TenNhaCungCap?.ToLower()).StartsWith(text) ? 2 : (RemoveDiacritics(x.MaNhaCungCapNavigation?.TenNhaCungCap?.ToLower()).Contains(text) ? 1 : 0)))
                 })
                 .OrderByDescending(x => x.Rank)
                 .ThenBy(x => x.Product.TenSanPham) // To sort products with the same rank
                 .Select(x => x.Product)
                 .ToList();

            dataGridView1.DataSource = orderedSanPhams;
        }

        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
