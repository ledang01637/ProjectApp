using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectApp
{
    public partial class SinhVien : Form
    {
        public SinhVien()
        {
            InitializeComponent();
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            updateDataGv();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            String MaSV = txtMaSV.Text;
            String TenSV = txtTenSV.Text;
            float DiemSV = float.Parse(txtDiem.Text);
            String query = "Insert into SinhVien Values('" + MaSV + "','" + TenSV + "'," + DiemSV + ")";
            int count = ConnectMySql.Instance.excuteNonQuery(query);
            if (count > 0)
            {
                updateDataGv();
                MessageBox.Show("Thêm thành công");
                ResetAllControls(this);
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }
        private void updateDataGv()
        {
            String query = "Select * From SinhVien";
            DataTable dt = ConnectMySql.Instance.dtExcuteQuery(query);
            dataGridView1.Rows.Clear();
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(
                    row.Field<String>("MaSV"),
                    row.Field<String>("TenSV"),
                    row.Field<float>("Diem")
                    );
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String MaSV = txtMaSV.Text;
            String TenSV = txtTenSV.Text;
            float DiemSV = float.Parse(txtDiem.Text);
            String query = "Update SinhVien Set tenSV = N'" + TenSV + "', Diem = " + DiemSV + " Where MaSV = '" + MaSV + "'";
            int count = ConnectMySql.Instance.excuteNonQuery(query);
            if (count > 0)
            {
                updateDataGv();
                ResetAllControls(this);
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa không thành công");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cell = (sender as DataGridView).CurrentCell;
                var row = dataGridView1.Rows[cell.RowIndex];
                txtMaSV.Text = row.Cells[0].Value.ToString();
                txtTenSV.Text = row.Cells[1].Value.ToString();
                txtDiem.Text = row.Cells[2].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            String MaSV = txtMaSV.Text;
            String TenSV = txtTenSV.Text;
            float DiemSV = float.Parse(txtDiem.Text);
            String query = "Delete From SinhVien Where MaSV = '" + MaSV + "'";
            int count = ConnectMySql.Instance.excuteNonQuery(query);
            if (count > 0)
            {
                MessageBox.Show("Xóa thành công");
                updateDataGv();
                ResetAllControls(this);
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
        }
        public void ResetAllControls(Control form)
        {
            foreach (var control in Controls.OfType<TextBox>())
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = "";
                }
            }

        }
    }
}
