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
    public partial class UC_panel1 : UserControl
    {
        public MySqlConnection getCon()
        {
            string connetstr = "data source=localhost;port=3306;user=root;password=123456;database=hospital system;Charset=utf8";
            MySqlConnection con = new MySqlConnection(connetstr);
            return con;
        }
        public UC_panel1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            DataGridViewRow row = dataGridView1.Rows[i];
            MySqlConnection con = getCon();
            con.Open();
            string sql = "DELETE  FROM 挂号信息 WHERE 诊疗卡号=" + dataGridView1.CurrentRow.Cells[0].Value.ToString(); 
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            dataGridView1.Rows.Remove(row);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            MySqlConnection con = getCon();
            con.Open();
            string sql = "SELECT * FROM 挂号信息" ;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter mdr = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            mdr.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
    }
}
