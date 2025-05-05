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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities2 db= new FinancialCrmDbEntities2();


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SignIn frm = new SignIn())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            
            if (userName == "" || password == "")
            {
                MessageBox.Show("Lutfen Tum Alanlari Doldurunuz");

            }
            else
            {
                Users users = new Users();
                users.UserName = userName;
                users.Password = password;
                db.Users.Add(users);
                db.SaveChanges();
                MessageBox.Show("Yeni Kayit Başarılı Bir Şekilde Olusturuldu" +
                    "Giris Yapma Sayfasina Yonlendiriliyorsunuz!!", "KAYIT OLDUNUZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                using (SignIn frm = new SignIn())
                {
                    frm.ShowDialog();
                }
                this.Show();
            }


        }
    }
}
