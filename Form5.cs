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
    public partial class Form5 : Form
    {
        public static string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hhk19\Google Drive\hospitalmanagementProject\WindowsFormsApplication1\WindowsFormsApplication1\Torun.mdf;Integrated Security = True";
        int id;
        string pass;
        
        public Form5(int r1,string r2)
        {
            InitializeComponent();
            id = r1;
            pass = r2;
            bilgilericek();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            //SqlCommand komut = new SqlCommand("update PatientLogin set Id='" + Convert.ToInt32(textBox1.Text) + "',Name='" + textBox2.Text + "' ,Surname='" + textBox4.Text + "' ,Sex='" + comboBox1.SelectedItem.ToString() + "' ,Address='" + richTextBox1.Text + "' ,Email='" +textBox3.Text+ "' ,PhoneNumber='" + textBox5.Text + "' ,DateofBirth='" + dateTimePicker1.Value.Date + "' ,Password='"+textBox6.Text+"' where Id='" + id + "'and Password='"+pass+"'", baglanti);

            SqlCommand komut = new SqlCommand("update PatientLogin set Id=@Id,Name=@name,Surname=@surname,Sex=@sex,Address=@Address,Email=@Email,PhoneNumber=@PhoneNumber,DateofBirth=@dateofbirth,Password=@password where Id=@id1 and Password=@pass1");
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@Id", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@name", textBox2.Text);
            komut.Parameters.AddWithValue("@surname", textBox4.Text);
            komut.Parameters.AddWithValue("@sex", comboBox1.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@Address", richTextBox1.Text);
            komut.Parameters.AddWithValue("@Email", textBox3.Text);
            komut.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
            komut.Parameters.AddWithValue("@dateofbirth", dateTimePicker1.Value.Date);
            komut.Parameters.AddWithValue("@password", textBox6.Text);
            komut.Parameters.AddWithValue("@id1",id);
            komut.Parameters.AddWithValue("@pass1",pass);
            komut.ExecuteNonQuery();
            MessageBox.Show("Updated!");           
            baglanti.Close();
           // temizle();

        }

        public void temizle() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        public void bilgilericek() {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from PatientLogin where Id=" + id + "and Password="+pass);
            komut.Connection = baglanti;
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonuc = new DataSet();
            adaptor.Fill(sonuc);
            baglanti.Close();

            textBox1.Text = Convert.ToString(sonuc.Tables[0].Rows[0]["Id"]);
            textBox2.Text = Convert.ToString(sonuc.Tables[0].Rows[0]["Name"]);
            textBox4.Text = Convert.ToString(sonuc.Tables[0].Rows[0]["Surname"]);
            textBox6.Text = Convert.ToString(sonuc.Tables[0].Rows[0]["Password"]);
            comboBox1.SelectedIndex = comboBox1.FindString(Convert.ToString(sonuc.Tables[0].Rows[0]["Sex"]));
            richTextBox1.Text = Convert.ToString(sonuc.Tables[0].Rows[0]["Address"]);
            textBox3.Text = Convert.ToString(sonuc.Tables[0].Rows[0]["Email"]);
            textBox5.Text = Convert.ToString(sonuc.Tables[0].Rows[0]["PhoneNumber"]);
            dateTimePicker1.Value = Convert.ToDateTime(sonuc.Tables[0].Rows[0]["DateOfBirth"]);

        }
        
    }
}
