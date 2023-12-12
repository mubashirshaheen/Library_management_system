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
    public partial class frmstock : Form
    {
        public frmstock()
        {
            InitializeComponent();
        }
        fdata fd = new fdata();
        private void frmstock_Load(object sender, EventArgs e)
        {
            
            string query = "select * from tblstock";
            fd.dataload(dgv, query);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (textBox1.Text != "")
            {                                
                string query = "select * from tblstock where book_name like ('%" + textBox1.Text.ToString() + "%')";
                fd.dataload(dgv, query);
            }
            else
            {
                string query = "select * from tblstock";
                fd.dataload(dgv, query);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into tblstock (book_name,author, rent_price) values('"+txtbook.Text+"','"+txtauthor.Text+"','"+txtretail.Text+"'); ";
            fd.datasave(query);
             query = "select * from tblstock";
            fd.dataload(dgv, query);
            txtauthor.Clear();
            txtretail.Clear();
            txtbook.Clear();
        }
    }
}
