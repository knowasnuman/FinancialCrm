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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        public void List()
        {
            var values1 = db.Categories
               .Select(s => new
               {
                   s.CategoryId,
                   s.CategoryName
               })
               .ToList();
            dataGridView1.DataSource = values1;
        }

        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            List();
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void btnCategoryBill_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryTitle.Text;
            Categories categories = new Categories();
            categories.CategoryName = categoryName;
            db.Categories.Add(categories);
            db.SaveChanges();
            MessageBox.Show("Yeni Kategori Başarılı Bır Şekilde Sisteme Eklendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryd.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bır Şekilde Sistemden Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryd.Text);
            string categoryName = txtCategoryTitle.Text;

            var values = db.Categories.Find(id);

            values.CategoryName = categoryName;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bır Şekilde Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryd.Text);
            

            var values1 = db.Categories.Where(x => x.CategoryId == id)
               .Select(s => new
               {
                   s.CategoryId,
                   s.CategoryName
               })
               .ToList();
            dataGridView1.DataSource = values1;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBanks frm = new FrmBanks())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmDashboard frm = new FrmDashboard())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBilling frm = new FrmBilling())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmCategories frm = new FrmCategories())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmSpendings frm = new FrmSpendings())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SignIn frm = new SignIn())
            {
                frm.ShowDialog();
            }
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBankTransactions frm = new FrmBankTransactions())
            {
                frm.ShowDialog();
            }
            this.Show();
        }
    }
}
