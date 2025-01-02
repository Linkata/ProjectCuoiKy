using CoffeeManagement.BL;
using System;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng toàn bộ ứng dụng
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin đăng nhập qua UserService
            bool isValid = UserService.IsValidUser(txtUser.Text.Trim(), txtPass.Text.Trim());

            if (!isValid)
            {
                guna2MessageDialog1.Show("Thông tin tài khoản hoặc mật khẩu sai! Vui lòng nhập lại");
                return;
            }

            // Nếu hợp lệ, chuyển sang form chính
            this.Hide();
            formMain mainForm = new formMain();
            mainForm.Show();
        }
    }
}
