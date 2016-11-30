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

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hhk19\Google Drive\hospitalmanagementProject\WindowsFormsApplication1\WindowsFormsApplication1\Torun.mdf;Integrated Security = True";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            this.Hide();
            a.Show();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            string sql = "select count(*) as satirSayisi from PatientLogin where Id='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonuc = new DataSet();            
            adaptor.Fill(sonuc);
            baglanti.Close();

            if (Convert.ToInt32(sonuc.Tables[0].Rows[0]["satirSayisi"]) == 1) {
                MessageBox.Show("Login Successful");
                Form5 a = new Form5(Convert.ToInt32(textBox1.Text),textBox2.Text);               
                this.Hide();                
                a.Show();
            }
            else {
                MessageBox.Show("Id or Password wrong!Try again...");
            }
        }
    }
}
