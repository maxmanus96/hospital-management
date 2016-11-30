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
    public partial class Form4 : Form
    {
        public static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hhk19\Google Drive\hospitalmanagementProject\WindowsFormsApplication1\WindowsFormsApplication1\Torun.mdf;Integrated Security = True";
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {           
            Form3 a = new Form3();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into PatientLogin values(@pID,@pName,@pSurname,@pSex,@pAddress,@pEmail,@pPhoneNumber,@pDateOfBirth,@pPassword)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@pID", textBox1.Text);
            komut.Parameters.AddWithValue("@pName", textBox2.Text);
            komut.Parameters.AddWithValue("@pSurname", textBox4.Text);
            komut.Parameters.AddWithValue("@pSex", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@pAddress", richTextBox1.Text);
            komut.Parameters.AddWithValue("@pEmail", textBox5.Text);
            komut.Parameters.AddWithValue("@pPhoneNumber", textBox6.Text);
            komut.Parameters.AddWithValue("@pDateOfBirth",(dateTimePicker1.Value.Date));
            komut.Parameters.AddWithValue("@pPassword", textBox3.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Registration Successful !");
            button2.PerformClick();
            Form3 a = new Form3();
            a.Show();
            this.Hide();
         
        }
    }
}
