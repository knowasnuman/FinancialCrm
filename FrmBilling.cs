using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;

namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;  
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bır Şekilde Sisteme Eklendi","Ödeme & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValue = db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bır Şekilde Sistemden Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
          
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;
            int id = int.Parse(txtBillId.Text);

            var values = db.Bills.Find(id);


            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bır Şekilde Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values1 = db.Bills.ToList();
            dataGridView1.DataSource = values1;
        }
        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var value = db.Bills.Where(x=>x.BillId == id).ToList();
            
            dataGridView1.DataSource = value;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
