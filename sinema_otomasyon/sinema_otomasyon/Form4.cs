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
    public partial class Form4 : Form
    {
        SqlConnection baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        public Form4()
        {
            InitializeComponent();
            this.Text = "İşlemler Sayfası";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        bool durum;
        void tekrar()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM film_kategori WHERE tur_adi=@tur_adi", baglan);
            cmd.Parameters.AddWithValue("@tur_adi", textBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglan.Close();
        }
        void tekrariki()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM oyuncu WHERE film_oyuncu=@film_oyuncu", baglan);
            cmd.Parameters.AddWithValue("@film_oyuncu", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglan.Close();
        }
        void tekrarson()
        {
            baglan.Open();
            cmd = new SqlCommand("SELECT * FROM yonetmen WHERE yonetmen_adi=@yonetmen_adi", baglan);
            cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglan.Close();
        }
        void doldur()
        {
            baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM film_kategori",baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        void dolduriki()
        {
            baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM oyuncu", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglan.Close();
        }

        void doldurson()
        {
            baglan = new SqlConnection("server=DESKTOP-EOMOPV6\\SQLEXPRESS; Initial Catalog=sinema_otomasyon;Integrated Security=SSPI");
            baglan.Open();
            da = new SqlDataAdapter("SELECT * FROM yonetmen", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglan.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            doldur();
            dolduriki();
            doldurson();
            
        }

        //FİLM KATEGORİ
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tekrar();
            if (durum==true) {
                string sorgu = "INSERT INTO film_kategori(tur_adi) VALUES(@tur_adi)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@tur_adi", textBox1.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldur();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!","Bilgi");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tekrar();
            if (durum == true)
            {
                string sorgu = "UPDATE film_kategori SET tur_adi=@tur_adi WHERE tur_id=@tur_id ";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@tur_id", Convert.ToInt32(textBox4.Text));
                cmd.Parameters.AddWithValue("@tur_adi", textBox1.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                doldur();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM film_kategori WHERE tur_adi=@tur_adi";
            cmd = new SqlCommand(sorgu,baglan);
            cmd.Parameters.AddWithValue("@tur_adi",textBox1.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            doldur();

        }

        //OYUNCU İŞLEMLERİ
        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tekrariki();
            if (durum == true)
            {
                string sorgu = "INSERT INTO oyuncu(film_oyuncu) VALUES(@film_oyuncu)";
                cmd = new SqlCommand(sorgu, baglan);
                cmd.Parameters.AddWithValue("@film_oyuncu", textBox2.Text);
                baglan.Open();
                cmd.ExecuteNonQuery();
                baglan.Close();
                dolduriki();
            }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
                tekrariki();
                if (durum == true)
                {
                    string sorgu = "UPDATE oyuncu SET film_oyuncu=@film_oyuncu WHERE oyuncu_id=@oyuncu_id ";
                    cmd = new SqlCommand(sorgu, baglan);
                    cmd.Parameters.AddWithValue("@oyuncu_id", Convert.ToInt32(textBox5.Text));
                    cmd.Parameters.AddWithValue("@film_oyuncu", textBox2.Text);
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    baglan.Close();
                    dolduriki();
                }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM oyuncu WHERE film_oyuncu=@film_oyuncu";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@oyuncu_adi", textBox2.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            dolduriki();
        }

        //YÖNETMEN İŞLEMLERİ
        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
                    tekrarson();
                    if (durum == true)
                    {
                        string sorgu = "INSERT INTO yonetmen(yonetmen_adi) VALUES(@yonetmen_adi)";
                        cmd = new SqlCommand(sorgu, baglan);
                        cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
                        baglan.Open();
                        cmd.ExecuteNonQuery();
                        baglan.Close();
                        doldurson();
                    }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
                        tekrarson();
                        if (durum == true)
                        {
                            string sorgu = "UPDATE yonetmen SET yonetmen_adi=@yonetmen_adi WHERE yonetmen_id=@yonetmen_id ";
                            cmd = new SqlCommand(sorgu, baglan);
                            cmd.Parameters.AddWithValue("@yonetmen_id", Convert.ToInt32(textBox6.Text));
                            cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
                            baglan.Open();
                            cmd.ExecuteNonQuery();
                            baglan.Close();
                            doldurson();
                        }
            else
            {
                MessageBox.Show("Bu kayıt zaten var!", "Bilgi");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM yonetmen WHERE yonetmen_adi=@yonetmen_adi";
            cmd = new SqlCommand(sorgu, baglan);
            cmd.Parameters.AddWithValue("@yonetmen_adi", textBox3.Text);
            baglan.Open();
            cmd.ExecuteNonQuery();
            baglan.Close();
            doldurson();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
