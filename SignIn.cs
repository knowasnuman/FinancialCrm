using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        private void button1_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;

            // Kullanıcıyı veritabanından al
            var user = db.Users.FirstOrDefault(x => x.UserName == userName);

            // Eğer kullanıcı varsa ve şifre doğruysa
            if (user != null && user.Password == password)
            {
                this.Hide();
                using (FrmDashboard frm = new FrmDashboard())
                {
                    frm.ShowDialog();
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Girdiğiniz şifre veya kullanıcı adı yanlış", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SignUp frm = new SignUp())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
