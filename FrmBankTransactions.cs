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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace FinancialCrm
{
    public partial class FrmBankTransactions : Form
    {
        public FrmBankTransactions()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SignIn frm = new SignIn())
            {
                frm.ShowDialog();
            }
            this.Show();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 6 == 1)
            {
                var bill_1 = db.Banks.Where(x => x.BankTitle == "Ziraat Bankasi").Select(y => y.BankBalance).FirstOrDefault();
                lblBillTitle.Text = "Ziraat Bankasi";
                lblBillAmount.Text = bill_1.ToString() + "₺";
            }
            if (count % 6 == 3)
            {
                var bill_1 = db.Banks.Where(x => x.BankTitle == "VakifBank").Select(y => y.BankBalance).FirstOrDefault();
                lblBillTitle.Text = "VakifBank";
                lblBillAmount.Text = bill_1.ToString() + "₺";
            }
            if (count % 6 == 5)
            {
                var bill_1 = db.Banks.Where(x => x.BankTitle == "Is Bankasi").Select(y => y.BankBalance).FirstOrDefault();
                lblBillTitle.Text = "Is Bankasi";
                lblBillAmount.Text = bill_1.ToString() + "₺";

            }
            
        }

        private void FrmBankTransactions_Load(object sender, EventArgs e)
        {


            var values1 = db.BankProcesses
               .Select(s => new
               {
                   s.Description,
                   s.ProcessDate,
                   s.ProcessType,
                   s.Amount,
                   Banks = s.Banks.BankTitle
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FrmSpendings frm = new FrmSpendings())
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
    }
}
