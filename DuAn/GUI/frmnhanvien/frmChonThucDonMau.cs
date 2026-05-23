using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public class frmChonThucDonMau : Form
    {
        private readonly List<ThucDonMauModel> _templates;
        private ListBox lstMau;
        private Label lblMoTa;
        private Button btnChon;
        private Button btnHuy;

        public ThucDonMauModel MauDaChon { get; private set; }

        public frmChonThucDonMau()
        {
            _templates = ThucDonMauDAO.Instance.GetAll();
            BuildLayout();
            Load += frmChonThucDonMau_Load;
        }

        private void BuildLayout()
        {
            Text = "Chọn thực đơn mẫu";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(560, 420);
            MinimumSize = new Size(480, 360);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 56,
                BackColor = Color.FromArgb(33, 48, 64),
                Padding = new Padding(16, 0, 16, 0)
            };
            Label lblTitle = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Chọn thực đơn mẫu để điền tuần",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            header.Controls.Add(lblTitle);

            lstMau = new ListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                IntegralHeight = false
            };
            lstMau.SelectedIndexChanged += lstMau_SelectedIndexChanged;
            lstMau.DoubleClick += (s, e) => ConfirmSelection();

            lblMoTa = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 72,
                Padding = new Padding(16, 8, 16, 8),
                ForeColor = Color.FromArgb(60, 70, 80),
                Text = "Chọn một mẫu trong danh sách."
            };

            Panel footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 58,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(16, 10, 16, 10)
            };

            btnChon = CreateButton("Áp dụng mẫu", Color.FromArgb(38, 132, 255), Color.White);
            btnChon.Dock = DockStyle.Right;
            btnChon.Click += (s, e) => ConfirmSelection();

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

            Panel body = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };
            body.Controls.Add(lstMau);
            body.Controls.Add(lblMoTa);

            Controls.Add(body);
            Controls.Add(footer);
            Controls.Add(header);
        }

        private void frmChonThucDonMau_Load(object sender, EventArgs e)
        {
            lstMau.DisplayMember = "HienThiCombo";
            lstMau.DataSource = _templates;

            if (_templates.Count == 0)
            {
                btnChon.Enabled = false;
                lblMoTa.Text = "Chưa có thực đơn mẫu trong hệ thống.";
                return;
            }

            int defaultIndex = _templates.FindIndex(x => x.LaMacDinh);
            lstMau.SelectedIndex = defaultIndex >= 0 ? defaultIndex : 0;
        }

        private void lstMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucDonMauModel mau = lstMau.SelectedItem as ThucDonMauModel;
            if (mau == null)
            {
                lblMoTa.Text = string.Empty;
                return;
            }

            lblMoTa.Text = string.IsNullOrWhiteSpace(mau.MauMoTa)
                ? "Không có mô tả."
                : mau.MauMoTa;
        }

        private void ConfirmSelection()
        {
            MauDaChon = lstMau.SelectedItem as ThucDonMauModel;
            if (MauDaChon == null)
            {
                MessageBox.Show("Vui lòng chọn một thực đơn mẫu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static Button CreateButton(string text, Color backColor, Color foreColor)
        {
            Button button = new Button
            {
                Text = text,
                Width = 120,
                Height = 36,
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
