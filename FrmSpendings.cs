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
    public partial class FrmSpendings : Form
    {
        public FrmSpendings()
        {
            InitializeComponent();
        }

        public void List()
        {
            var values1 = db.Spendings
               .Select(s => new
               {
                   s.SpendingId,
                   s.SpendingTitle,
                   s.SpendingAmount,
                   s.SpendingDate,
                   Category = s.Categories.CategoryName
               })
               .ToList();
            dataGridView1.DataSource = values1;
        }

        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        private void FrmSpendings_Load(object sender, EventArgs e)
        {
            var values = db.Categories.Select(x => new
            {
                x.CategoryId,
                x.CategoryName
            }).ToList();

            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = values;
            List();
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            var removeValue = db.Spendings.Find(id);
            db.Spendings.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bır Şekilde Sistemden Silindi", "Harcamalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List();
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            List();
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtSpendingTitle.Text;
            decimal amount = decimal.Parse(txtSpendingAmount.Text);
            DateTime date = DateTime.Parse(txtSpendingPeriod.Text);
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);

            Spendings spendings = new Spendings();
            spendings.SpendingTitle = title;
            spendings.SpendingAmount = amount;
            spendings.SpendingDate = date;
            spendings.CategoryId = categoryId; 

            db.Spendings.Add(spendings);
            db.SaveChanges();

            MessageBox.Show("Harcama Başarıyla Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            List();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateSpending_Click(object sender, EventArgs e)
        {
            string title = txtSpendingTitle.Text;
            decimal amount = decimal.Parse(txtSpendingAmount.Text);
            DateTime date = DateTime.Parse(txtSpendingPeriod.Text);
            int categoryId = Convert.ToInt32(cmbCategory.SelectedValue);
            int spendingId = int.Parse(txtSpendingId.Text);

            var values = db.Spendings.Find(spendingId);


            values.SpendingTitle = title;
            values.SpendingAmount = amount;
            values.SpendingDate = date;
            values.CategoryId = categoryId;

            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bır Şekilde Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            List();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            

            var values1 = db.Spendings.Where(x => x.SpendingId == id)
                .Select(s => new
                {
                    s.SpendingId,
                    s.SpendingTitle,
                    s.SpendingAmount,
                    s.SpendingDate,
                    Category = s.Categories.CategoryName
                })
                .ToList();
            dataGridView1.DataSource = values1;
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

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmBanks frm = new FrmBanks())
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmDashboard frm = new FrmDashboard())
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
