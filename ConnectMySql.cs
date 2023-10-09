using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjectApp
{
    public class ConnectMySql
    {
        private static ConnectMySql instance; //Ctr + R + E // Đóng gói
        public static ConnectMySql Instance
        {
            get { if (instance == null) instance = new ConnectMySql(); return instance; }
            private set => instance = value;
        }
        private ConnectMySql() { } //hàm tạo không tham số

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        private String Connet = @"Server = localhost; Database = Demo; UId = root; Pwd = dang01637201554; Pooling=false;Character Set=utf8;";

        //Trả về 1 DataTable
        public DataTable dtExcuteQuery(String query)
        {
            using (MySqlConnection sqlconn = new MySqlConnection(Connet))
            {
                sqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter sda = new MySqlDataAdapter(command);
                dt.Clear();
                sda.Fill(dt);
                sqlconn.Close();
                return dt;
            }
        }
        //Trả về 1 tập hợp các DataTable
        public DataSet dsExcuteQuery(String query)
        {
            using (MySqlConnection sqlconn = new MySqlConnection(Connet))
            {
                sqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter sda = new MySqlDataAdapter(command);

                //Đổi tên Table
                sda.TableMappings.Add("Table", "NhaTro");
                sda.TableMappings.Add("Table1", "KhachHang");
                ds.Clear();
                sda.Fill(ds);
                sqlconn.Close();
                return ds;
            }
        }
        //Trả về số dòng thực thi
        public int excuteNonQuery(String query)
        {
            int data = 1;
            using (MySqlConnection sqlconn = new MySqlConnection(Connet))
            {
                sqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter sda = new MySqlDataAdapter(command);
                data = command.ExecuteNonQuery();
                sqlconn.Close();
                return data;
            }
        }
        //Trả về ô đầu của kết quả // VD: Select Count(*) From...
        public object excuteScalar(String query)
        {
            object data = 0;
            using (MySqlConnection sqlconn = new MySqlConnection(Connet))
            {
                sqlconn.Open();

                MySqlCommand command = new MySqlCommand(query, sqlconn);
                MySqlDataAdapter sda = new MySqlDataAdapter(command);
                sda.Fill(dt);
                data = command.ExecuteScalar();
                sqlconn.Close();
                return data;
            }
        }
    }
}
