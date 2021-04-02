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

namespace sinema_otomasyon
{
    public partial class Form3 : Form
    {
        SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand();
        
        SqlDataAdapter da;

        /*SqlDataReader dr;
        ;
        DataSet ds;
        */

        public Form3()
        {
            InitializeComponent();
        }

        
     


        private void Form3_Load(object sender, EventArgs e)
        {
            // Kategori Listeleme
            comboBox1.Items.Clear();
            SqlDataReader dr;
            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandText = "SELECT * FROM film_kategori";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["tur_adi"]);
            }
            baglan.Close();

            comboBox2.Items.Clear();
            baglan.Open();
            cmd.Connection = baglan;
            cmd.CommandText = "SELECT * FROM yonetmen";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["yonetmen_adi"]);
                
            }
            baglan.Close();

            dolduriki();
            
            


        }

        void dolduriki()
        {
            baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            baglan.Open();
            da = new SqlDataAdapter("SELECT film_oyuncu FROM oyuncu", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
            textBox2.Text = openFileDialog1.FileName;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)

            {
                SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
                baglan.Open();
                SqlCommand cmd = new SqlCommand("insert into filmler(film_adi,film_turu,yonetmen_adi,film_oyuncu,film_tarih,film_resim)values" + "(@film_adi,@film_turu,@yonetmen_adi,@film_oyuncu,@film_tarih,@film_resim)", baglan);
                cmd.Parameters.AddWithValue("@film_adi", textBox1.Text);
                cmd.Parameters.AddWithValue("@film_turu", comboBox1.Text);
                cmd.Parameters.AddWithValue("@yonetmen_adi", comboBox2.Text);
                cmd.Parameters.AddWithValue("@film_oyuncu", dataGridView1.SelectedRows[i].Cells["film_oyuncu"].Value.ToString());
                cmd.Parameters.AddWithValue("@film_tarih", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@film_resim", textBox2.Text);
                cmd.ExecuteNonQuery();
                baglan.Close();
            }
            MessageBox.Show("Başarıyla Eklendi", "Bilgi");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
