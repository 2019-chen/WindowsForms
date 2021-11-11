using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.NewFolder1
{
    public partial class UC_panel2 : UserControl
    {
        public MySqlConnection getCon()
        {
            string connetstr = "data source=localhost;port=3306;user=root;password=123456;database=hospital system;Charset=utf8";
            MySqlConnection con = new MySqlConnection(connetstr);
            return con;
        }
        public UC_panel2()
        {
            InitializeComponent();
        }

        private void UC_panel2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = getCon();
            con.Open();
            string sql = "SELECT * FROM 电子病历 WHERE 诊疗卡号=" + textBox8.Text;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                textBox1.Text = mdr["病人姓名"].ToString();
                textBox1.ReadOnly = true;
                textBox2.Text = mdr["手机号码"].ToString();
                textBox2.ReadOnly = true;
                textBox3.Text = mdr["性别"].ToString();
                textBox3.ReadOnly = true;
                textBox4.Text = mdr["年龄"].ToString();
                textBox4.ReadOnly = true;
                textBox5.Text = mdr["诊疗卡号"].ToString();
                textBox5.ReadOnly = true;
                textBox6.Text = mdr["主诉"].ToString();
                textBox6.ReadOnly = true;
                textBox7.Text = mdr["诊断"].ToString();
                textBox7.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("没有相应诊疗卡的电子病历信息");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox1.ReadOnly = false;
            textBox2.Text = string.Empty;
            textBox2.ReadOnly = false;
            textBox3.Text = string.Empty;
            textBox3.ReadOnly = false;
            textBox4.Text = string.Empty;
            textBox4.ReadOnly = false;
            textBox5.Text = string.Empty;
            textBox5.ReadOnly = false;
            textBox6.Text = string.Empty;
            textBox6.ReadOnly = false;
            textBox7.Text = string.Empty;
            textBox7.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = getCon();
            con.Open();
            string sql = "SELECT * FROM 电子病历 WHERE 诊疗卡号=" + textBox5.Text;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                con.Close();
                con.Open();
                string sql1 = "UPDATE 电子病历 SET 病人姓名= '"+textBox1.Text +"' ,手机号码=  '" + textBox2.Text + "' , 性别= '" + 
                textBox3.Text + "' , 年龄= '" + textBox4.Text +"' ,主诉= '" + textBox6.Text+ "',诊断 ='" + textBox7.Text+ "'" +
                " WHERE 诊疗卡号=" + textBox5.Text;
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                con.Close();
            }
            else 
            {
                con.Close();
                con.Open();
                string sql1 = "INSERT INTO 电子病历 VALUES(" + textBox5.Text + "," + textBox1.Text + "," + textBox4.Text +
                    "," + textBox3.Text + "," + textBox2.Text + "," + textBox6.Text + "," + textBox7.Text + ")";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("创建成功");
                con.Close();
            }
        }
    }
}
