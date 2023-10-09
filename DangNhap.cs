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
    public partial class DangNhap : Form
    {
        
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLoginDangNhap_Click(object sender, EventArgs e)
        {
            String UserNameDn = txtUserName.Text;
            String PassWordDn = txtPassWord.Text;
            String query = "Select * From dangnhap Where TaiKhoan = '"+UserNameDn+"'And MatKhau = '"+PassWordDn+"'";
            DataTable dt = ConnectMySql.Instance.dtExcuteQuery(query);
            if(dt.Rows.Count > 0)
            {
                SinhVien sv = new SinhVien();
                sv.Show();
                this.Hide();
            }
        }
    }
}
