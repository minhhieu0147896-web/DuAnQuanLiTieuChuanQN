using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public class frmchonmon : Form
    {
        private readonly string _loaiMon;
        private DataGridView dgvMonAn;
        private Label lblTitle;
        private Label lblEmpty;
        private Button btnChon;
        private Button btnHuy;

        public MonAnModel MonDaChon { get; private set; }

        public frmchonmon(string loaiMon)
        {
            _loaiMon = loaiMon;
            BuildLayout();
            Load += frmchonmon_Load;
        }

        private void BuildLayout()
        {
            Text = "Chọn món";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(620, 520);
            MinimumSize = new Size(560, 440);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                BackColor = Color.FromArgb(33, 48, 64),
                Padding = new Padding(18, 0, 18, 0)
            };

            lblTitle = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            header.Controls.Add(lblTitle);

            dgvMonAn = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MonAnId",
                HeaderText = "Mã",
                Width = 70
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenMon",
                HeaderText = "Tên món",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiMon",
                HeaderText = "Loại món",
                Width = 130
            });
            dgvMonAn.CellDoubleClick += (s, e) => ChooseSelected();

            lblEmpty = new Label
            {
                Dock = DockStyle.Top,
                Height = 36,
                ForeColor = Color.FromArgb(180, 60, 60),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(18, 0, 18, 0),
                Visible = false
            };

            Panel footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 62,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(18, 10, 18, 10)
            };

            btnChon = CreateButton("Chọn món", Color.FromArgb(38, 132, 255), Color.White);
            btnChon.Dock = DockStyle.Right;
            btnChon.Click += (s, e) => ChooseSelected();

            btnHuy = CreateButton("Hủy", Color.FromArgb(236, 241, 247), Color.FromArgb(33, 48, 64));
            btnHuy.Dock = DockStyle.Right;
            btnHuy.Margin = new Padding(0, 0, 10, 0);
            btnHuy.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            footer.Controls.Add(btnChon);
            footer.Controls.Add(btnHuy);

            Controls.Add(dgvMonAn);
            Controls.Add(lblEmpty);
            Controls.Add(footer);
            Controls.Add(header);
        }

        private void frmchonmon_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Chọn món " + _loaiMon;

            List<MonAnModel> dishes = MonAnDAO.Instance.GetByNhomLoaiMon(_loaiMon);
            dgvMonAn.DataSource = dishes;

            bool hasData = dishes.Count > 0;
            lblEmpty.Visible = !hasData;
            lblEmpty.Text = "Không tìm thấy món có loại món phù hợp: " + _loaiMon;
            btnChon.Enabled = hasData;

            if (hasData)
                dgvMonAn.Rows[0].Selected = true;
        }

        private void ChooseSelected()
        {
            if (dgvMonAn.CurrentRow == null || dgvMonAn.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn một món.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MonDaChon = dgvMonAn.CurrentRow.DataBoundItem as MonAnModel;
            if (MonDaChon == null)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private static Button CreateButton(string text, Color backColor, Color foreColor)
        {
            Button button = new Button
            {
                Text = text,
                Width = 112,
                Height = 40,
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 218, 226);
            return button;
        }
    }
}
