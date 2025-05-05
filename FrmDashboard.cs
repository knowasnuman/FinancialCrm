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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities2 db = new FinancialCrmDbEntities2();

        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString();

            var lastTransferAmount = db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).Select(y=>y.Amount).FirstOrDefault();
            lblLastTransferAmount.Text = lastTransferAmount.ToString() + "₺";


            // chart1 kodlari
            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance

            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }
            //chart2 kodlari

            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach(var item1 in billData)
            {
                series2.Points.AddXY(item1.BillTitle, item1.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 4 == 1)
            {
                var bill_1 = db.Bills.Where(x => x.BillTitle == "Elektrik Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturasi";
                lblBillAmount.Text = bill_1.ToString() + "₺";   
            }
            if (count % 4 == 2)
            {
                var bill_1 = db.Bills.Where(x => x.BillTitle == "Dogalgaz Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Dogalgaz Faturasi";
                lblBillAmount.Text = bill_1.ToString() + "₺";
            }
            if (count % 4 == 3)
            {
                var bill_1 = db.Bills.Where(x => x.BillTitle == "Su Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturasi";
                lblBillAmount.Text = bill_1.ToString() + "₺";
               
            }
            if (count % 4 == 0)
            {
                var bill_1 = db.Bills.Where(x => x.BillTitle == "Internet Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Internet Faturasi";
                lblBillAmount.Text = bill_1.ToString() + "₺";
                
                
            }
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

        private void lblBillAmount_Click(object sender, EventArgs e)
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
