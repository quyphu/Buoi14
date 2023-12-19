using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace NguyenNgocPhuQuy_2033210170
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlDataAdapter TT_GV;
        DataSet TT_CSGV;
        DataColumn[] key = new DataColumn[1];
        SqlCommand cmd = new SqlCommand();
        string strsql;
        public Form1()
        {
            InitializeComponent();
            
        }
        void Databingding(DataTable pDT)
        {
            txtTenMay.DataBindings.Clear();
            txtCSDL.DataBindings.Clear();
            txtUser.DataBindings.Clear();
            txtPassword.DataBindings.Clear();

            txtTenMay.DataBindings.Add("Text", pDT, "TenMay");
            txtCSDL.DataBindings.Add("Text", pDT, "CSDL");
            txtUser.DataBindings.Add("Text", pDT, "User");
            txtPassword.DataBindings.Add("Text", pDT, "Password");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
{
    string serverName = txtTenMay.Text.Trim();
    string databaseName = txtCSDL.Text.Trim();
    string username = txtUser.Text.Trim();
    string password = txtPassword.Text;

    string connectionString = "Data Source="+ serverName +";Initial Catalog="+ databaseName +";User ID="+ username +";Password= "+ password +"";

    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
        try
        {
            sqlConnection.Open();

            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nếu đăng nhập thành công, bạn có thể chuyển đến form hoặc thực hiện các thao tác khác tại đây.
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show("Lỗi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả
            if (result == DialogResult.Yes)
            {
                // Người dùng chọn "Yes", thoát ứng dụng
                Application.Exit();
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
