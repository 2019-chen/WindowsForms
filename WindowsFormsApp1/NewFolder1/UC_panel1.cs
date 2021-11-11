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
            MySqlConnection con = getCon();
            con.Open();
            string sql = "SELECT * FROM 挂号信息 WHERE 诊疗卡号=" + textBox1.Text;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader mdr = cmd.ExecuteReader();
            if (mdr.Read())
            {
                for (int i = 00; i < dataGridView1.RowCount; i++)
                {
                    if (textBox1.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        dataGridView1.Rows[i].Selected = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("没有相应诊疗卡挂号信息");
            }
            con.Close();
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
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void UC_panel1_Paint(object sender, PaintEventArgs e)
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

        private void dataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                drv.Delete();
            }
        }
    }
}
