using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeAnGK_Lttt
{
    /// <summary>
    /// Interaction logic for DangKyCV.xaml
    /// </summary>
    public partial class DangKyCV : Window
    {
        private String ConnectionString;
        private SqlConnection connection;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader reader;
        public DataTable getDangKyCV()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM DangKyCV", ConnectionString);
            DataTable dtDangKyCV = new DataTable();
            da.Fill(dtDangKyCV);
            return dtDangKyCV;
        }
        public DangKyCV()
        {
            InitializeComponent();
            ConnectionString = @"Data Source=LAPTOP-LTSR3KDB;Initial Catalog=QLNguoiDung;Integrated Security=True";
            connection = new SqlConnection(ConnectionString);
            grid1.DataContext = getDangKyCV();    
        }

        private void butadd_Click(object sender, RoutedEventArgs e)
        {
            string tungay=tngay.Text;
            string denngay = dngay.Text;
            string tugio = tgio.Text;
            string dengio = dgio.Text;
            string ten = name.Text;
            string lydodk = lydo.Text;
            try
            {
                cmd.CommandText = "INSERT INTO DangKyCV(TuNgay, DenNgay, TuGio, DenGio, NguoiDk, LyDoLamThem) VALUES (@param1,@param2,@param3,@param4,@param5,@param6)";

                cmd.Parameters.AddWithValue("@param1", tungay);
                cmd.Parameters.AddWithValue("@param2", denngay);
                cmd.Parameters.AddWithValue("@param3", tugio);
                cmd.Parameters.AddWithValue("@param4", dengio);
                cmd.Parameters.AddWithValue("@param5", ten);
                cmd.Parameters.AddWithValue("@param6", lydodk);
                Console.WriteLine(cmd.CommandText);
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    i++;
                }


                if (i == 1)
                {
                    MessageBox.Show("Thêm Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Thêm Thành Công!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Catch Block = " + ex);
            }
            finally
            {

                connection.Close();
            }
            grid1.DataContext = getDangKyCV();
        }

        private void butsua_Click(object sender, RoutedEventArgs e)
        {
            string id = idtxt.Text;
            string tungay = tngay.Text;
            string denngay = dngay.Text;
            string tugio = tgio.Text;
            string dengio = dgio.Text;
            string ten = name.Text;
            string lydodk = lydo.Text;
            try
            {
                cmd.CommandText = "UPDATE DangKyCV SET TuNgay=@param1, DenNgay=@param2, TuGio=@param3, DenGio=@param4, NguoiDk=@param5, LyDoLamThem=@param6 where Id=@param7";

                cmd.Parameters.AddWithValue("@param1", tungay);
                cmd.Parameters.AddWithValue("@param2", denngay);
                cmd.Parameters.AddWithValue("@param3", tugio);
                cmd.Parameters.AddWithValue("@param4", dengio);
                cmd.Parameters.AddWithValue("@param5", ten);
                cmd.Parameters.AddWithValue("@param6", lydodk);
                cmd.Parameters.AddWithValue("@param7", id);
                Console.WriteLine(cmd.CommandText);
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    i++;
                }


                if (i == 1)
                {
                    MessageBox.Show("Sửa Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Sửa Thành Công!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Catch Block = " + ex);
            }
            finally
            {

                connection.Close();
            }
            grid1.DataContext = getDangKyCV();
        }

        private void butxoa_Click(object sender, RoutedEventArgs e)
        {
            string id = idtxt.Text;
            try
            {

                cmd.CommandText = "DELETE FROM DangKyCV WHERE Id = @param1";

                cmd.Parameters.AddWithValue("@param1", id);

                Console.WriteLine(cmd.CommandText);
                cmd.Connection = connection;
                connection.Open();
                reader = cmd.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    i++;
                }


                if (i == 1)
                {
                    MessageBox.Show("Đã Xóa Thành Công");
                }
                else
                {
                    MessageBox.Show("Đã Xóa Thành Công");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch Block = " + ex);
            }
            finally
            {

                connection.Close();
            }
            grid1.DataContext = getDangKyCV();
        }

        public DataTable findThongTinDK(string tt)
        {
            connection.Open();
            string sql = string.Format("SELECT * FROM DangKyCV WHERE NguoiDk like '%" + tt.Trim() + "%'", tt);
            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            DataTable dtTimKiem = new DataTable();
            da.Fill(dtTimKiem);
            connection.Close();
            return dtTimKiem;
        }

        private void butfind_Click(object sender, RoutedEventArgs e)
        {
            string values = timtxt.Text;
            if (!string.IsNullOrEmpty(values))
            {
                DataTable dt = findThongTinDK(values);
                grid1.DataContext = dt;
            }
            else
            {
                grid1.DataContext = getDangKyCV();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReportForm2 rp = new ReportForm2();
            rp.ShowDialog();
        }

        private void butthoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
