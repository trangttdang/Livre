using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tabDonHang.Sản_phẩm;

namespace tabDonHang
{
    public partial class FormNhapHang : Form
    {
        public long SL { get; set; }
        long SLTK { get; set; }
        public FormNhapHang()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SL = long.Parse(txtSL.Text);
        }

        public void LaySLTonKho(long sltonkho)
        {
            lblSLtonkho.Text = sltonkho.ToString();
            SLTK = sltonkho;
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            if(txtSL.Text=="")
            {
                return;
            }    
            if( long.TryParse(txtSL.Text,out long SL)== false)
            {
                MessageBox.Show("Please enter integer input");
                txtSL.Text = "";
            }

        }
        private void txtSL_Leave(object sender, EventArgs e)
        {
            //SL = long.Parse(txtSL.Text);
            //if (SL > SLTK || SL < 0)
            //{
             //   MessageBox.Show("Exceed inventory quantity");
               // txtSL.Text = "";
            //}
        }
    }
}
