using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lms
{
    public partial class frmrent : Form
    {
        int sum = 0;
        public frmrent()
        {
            InitializeComponent();
        }

        public void disabledgv()
        {
            dgv2.Visible = false;
            try
            {
                dgv2.Rows.Clear();
            }
            catch (Exception)
            {

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                fdata fdp = new fdata();
                dgv2.Visible = true;
                string query = "SELECT book_name ,author, rent_price FROM tblstock where book_name like ('%" + textBox1.Text.ToString() + "%')";
                fdp.dataload(dgv2, query);
            }
            else
            {
                disabledgv();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.ActiveControl = dgv2;
                dgv2.Focus();
            }
        }

        private void dgv2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.KeyData & Keys.KeyCode) == Keys.Enter))
            {
                base.OnKeyDown(e);

            }
            else
            {
                var n = dgv1.Rows.Cast<DataGridViewRow>()
                .Where(row => !(row.Cells[0].Value == null || row.Cells[0].Value == DBNull.Value))
                 .Count();

                dgv1.Rows[n].Cells[0].Value = dgv2.SelectedRows[0].Cells[0].Value;
                dgv1.Rows[n].Cells[2].Value = dgv2.SelectedRows[0].Cells[2].Value;
                disabledgv();
                txtinvc.Select();
            }
        }
        public void refreshfrm()
        {
            fdata fd = new fdata();           
            string q = "select book_name,author quantity,tilldate, rent_price as 'R.P' from tblrent";
            fd.dataload(dgv1, q);           
            q = "select max(rent_invoice) from tblrent";            
            fd.dataload(txtinvc, q);
        }
        private void frmsale_Load(object sender, EventArgs e)
        {
            // refreshfrm();
            string q = "select max(rent_invoice) from tblrent";
            fdata fd = new fdata();
            fd.dataload(txtinvc, q);
            
            dgv1.Rows.Add(10);
            dgv1.Columns[1].Width = 50;
            dgv1.Columns[2].Width = 50;
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
              //  var n = dgv1.RowCount;               
                var n = dgv1.SelectedRows[0].Cells[1].RowIndex;
                dgv1.SelectedRows[0].Cells[1].Value = dateTimePicker1.Value;
                dgv1.Rows[n].Selected = false;
                dgv1.Rows[n+1].Selected = true;
            }
        }

        private void dgv1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            sum = 0;
            var count = dgv1.Rows.Count;
            for (var i = 0; i < count; i++)
            {
                sum = sum + Convert.ToInt32(dgv1.Rows[i].Cells[2].Value);
            }
            lblbalance.Text = sum.ToString();
        }

        private void dgv1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex > -1 && (txtqty !=null || Convert.ToInt32(txtqty.Text)!=0))
            //{
            //    DataGridViewRow row = dgv1.Rows[e.RowIndex];
            //    string valueA = row.Cells[quantity.Index].Value.ToString();
            //    string valueB = row.Cells[rp.Index].Value.ToString();
            //    int result;
            //    if (Int32.TryParse(valueA, out result)
            //        && Int32.TryParse(valueB, out result))
            //    {
            //        row.Cells[total.Index].Value = valueA + valueB;
            //    }
            //}
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sum = 0; 
            var count=dgv1.Rows.Count;
            for(var i = 0; i < count; i++)
            {
                 sum = sum + Convert.ToInt32(dgv1.Rows[i].Cells[2].Value)* Convert.ToInt32(dgv1.Rows[i].Cells[1].Value);
            }
            lblbalance.Text = sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int sum = 0;
            var count = dgv1.Rows.Count;
            for (var i = 0; i < count; i++)
            {
                sum = sum + Convert.ToInt32(dgv1.Rows[i].Cells[2].Value);
            }

            var n = dgv1.Rows.Cast<DataGridViewRow>()
                .Where(row => !(row.Cells[0].Value == null || row.Cells[0].Value == DBNull.Value))
                 .Count();

            DialogResult r = MessageBox.Show("Do you want to Rent it? ", "Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                for (int i = 0; i < n; i++)
                {
                    string q = "INSERT INTO tblrent(rent_invoice, book_name,borrower, rent_price,tilldate,total) VALUES ('" + txtinvc.Text + "','" + dgv1.Rows[i].Cells[0].Value + "','" + dgv1.Rows[i].Cells[1].Value + "','" + dgv1.Rows[i].Cells[2].Value + "','"+ dgv1.Rows[i].Cells[3].Value.ToString() + "','"+sum+"'); ";
                    fdata fd = new fdata();
                    fd.datasave(q);
                }
            }
            lblbalance.Text = sum.ToString();
            reportfrm rf = new reportfrm(txtinvc.Text);
            rf.ShowDialog();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var n = dgv1.SelectedRows[0].Cells[1].RowIndex;
            dgv1.SelectedRows[0].Cells[3].Value = dateTimePicker1.Value.ToString();
            dgv1.Rows[n].Selected = false;
            dgv1.Rows[n + 1].Selected = true;
        }

        private void txtborrower_TextChanged(object sender, EventArgs e)
        {
            var n = dgv1.SelectedRows[0].Cells[1].RowIndex;
            dgv1.SelectedRows[0].Cells[1].Value = txtborrower.Text;
        }
    }
}
