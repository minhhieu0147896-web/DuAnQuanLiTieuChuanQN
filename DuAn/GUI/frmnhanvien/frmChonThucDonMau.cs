using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmChonThucDonMau : Form
    {
        private readonly List<ThucDonMauModel> _templates;

        public ThucDonMauModel MauDaChon { get; private set; }

        public frmChonThucDonMau()
        {
            _templates = ThucDonMauDAO.Instance.GetAll();
            InitializeComponent();

            // Gán sự kiện lambda (không để được trong Designer)
            lstMau.DoubleClick += (s, e) => ConfirmSelection();
            btnChon.Click += (s, e) => ConfirmSelection();
            btnHuy.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
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
    }
}
