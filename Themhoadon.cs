using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HAH_3Layer
{
    public partial class Themhoadon : Form
    {
        private string strKetNoi = "Data source = HIEU-HP-DYNAMIC\\SQLEXPRESS; Initial Catalog = QuanLyBanHangDB; Integrated Security=True;";
        public Themhoadon()
        {
            InitializeComponent();
        }

        private void Themhoadon_Load(object sender, EventArgs e)
        {
            Loadmasp();
        }
        private void Loadmasp()
        {
            SqlConnection scon = new SqlConnection(strKetNoi);
            scon.Open();
            SqlCommand com = new SqlCommand("Select TEN from SANPHAM WHERE XOA = 0 ", scon);
            com.ExecuteNonQuery();
            SqlDataAdapter ap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            ap.Fill(ds);
            cmb_sp.DataSource = ds.Tables[0];
            
            cmb_sp.ValueMember = "TEN";
        }
        private void cmb_sp_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection scon = new SqlConnection(strKetNoi);
            SqlCommand com = new SqlCommand("select * From SANPHAM where TEN=@MASP and XOA=0", scon);
            scon.Open();
            com.Parameters.AddWithValue("@MASP", cmb_sp.Text);
            com.ExecuteNonQuery();
            SqlDataReader sdr;
            sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                string a = sdr["MASP"].ToString();
                txt_ten.Text = a;

            }
        }

    }
}
