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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public MySqlConnection getCon()
        {
            string connetstr = "data source=localhost;port=3306;user=root;password=123456;database=hospital system;Charset=utf8";
            MySqlConnection con = new MySqlConnection(connetstr);
            return con;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = getCon();
            con.Open();
            string sql = "SELECT 密码 FROM 登录 where 账号=" + textBox1.Text;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader mdr = cmd.ExecuteReader();
            mdr.Read();
            if (string.Compare(mdr[0].ToString(), textBox2.Text) == 0)
            {
                this.Hide();
                new Form2().Show();
            }
            else
            {
                MessageBox.Show("密码错误", "登录失败");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = getCon();
            con.Open();
            string sql1 = "SELECT 密码 FROM 登录 where 账号=" + textBox1.Text;
            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            MySqlDataReader mdr1 = cmd1.ExecuteReader();
            if(mdr1.Read())
            {
                MessageBox.Show("该账号已注册！");
            }
            else
            {
                string sql = "INSERT INTO 登录 VALUES(" + textBox1.Text+","+textBox2.Text+")";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader mdr = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
                MessageBox.Show("注册成功！");
            }
            
        }
    }
}
