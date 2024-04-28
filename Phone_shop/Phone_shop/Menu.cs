using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phone_shop
{
	public partial class Menu : Form
	{
		Call_DB Call_DB = new Call_DB();
		public int button_num = 0;
		public Menu()
		{
			InitializeComponent();
		}
		private void Menu_Load(object sender, EventArgs e)
		{
			textBox10.Text = DateTime.Now.ToShortDateString();
			DataSet tables;
			Call_DB.Open();
			tables = Call_DB.Request("SELECT * FROM Brends");
			for (int i = 0; i < tables.Tables[0].Rows.Count; i++)
			{
				comboBox1.Items.Add(tables.Tables[0].Rows[i][1]);
			}

			tables = Call_DB.Request("SELECT * FROM Mobile_phone");
			for (int i = 0; i < tables.Tables[0].Rows.Count; i++)
			{
				comboBox2.Items.Add(tables.Tables[0].Rows[i][0]);
			}

			tables = Call_DB.Request("SELECT * FROM Saler");
			for (int i = 0; i < tables.Tables[0].Rows.Count; i++)
			{
				comboBox3.Items.Add(tables.Tables[0].Rows[i][0]);
			}
			Call_DB.Close();
		}
		private void button1_Click(object sender, EventArgs e)
		{Select_table("Brends");}
		private void button2_Click(object sender, EventArgs e)
		{Select_table("Mobile_phone");}
		private void button3_Click(object sender, EventArgs e)
		{Select_table("Saler");}
		private void button4_Click(object sender, EventArgs e)
		{Select_table("Sales");}

		public void Select_table(string table)
		{
			Call_DB.Open();
			DataSet dts = Call_DB.Request($"SELECT * FROM {table}");
			dataGridView1.DataSource = dts.Tables[0];
			Call_DB.Close();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if(textBox1.Text.Length > 0) 
			{
				Call_DB.Open();
				Call_DB.Request($"INSERT INTO Brends (`namess`) VALUES ('{textBox1.Text}')");
				dataGridView1.DataSource = Call_DB.Request("SELECT * FROM Brends").Tables[0];

				comboBox1.Items.Clear();
				DataSet tables = Call_DB.Request("SELECT * FROM Brends");
				for (int i = 0; i < tables.Tables[0].Rows.Count; i++)
				{
					comboBox1.Items.Add(tables.Tables[0].Rows[i][1]);
				}
				Call_DB.Close();
			}
			else
			{
				MessageBox.Show("Поля не заполнены");
			}
		}
		private void button9_Click(object sender, EventArgs e)
		{textBox1.Text = "";}

		private void button7_Click(object sender, EventArgs e)
		{
			if (comboBox1.Text.Length > 0 && 
				textBox4.Text.Length > 0 && 
				textBox3.Text.Length > 0 && 
				textBox5.Text.Length > 0)
			{
				Call_DB.Open();
				Call_DB.Request($"INSERT INTO Mobile_phone " +
					$"(`id_brends`," +
					$"`Model`," +
					$"`Ram`," +
					$"`Memory`) VALUES " +
					$"('{comboBox1.Text}'," +
					$"'{textBox4.Text}'," +
					$"'{textBox5.Text}'," +
					$"'{textBox3.Text}')");
				dataGridView1.DataSource = Call_DB.Request("SELECT * FROM Mobile_phone").Tables[0];

				comboBox2.Items.Clear();
				DataSet tables = Call_DB.Request("SELECT * FROM Mobile_phone");
				for (int i = 0; i < tables.Tables[0].Rows.Count; i++)
				{
					comboBox2.Items.Add(tables.Tables[0].Rows[i][0]);
				}
				Call_DB.Close();
			}
			else
			{
				MessageBox.Show("Поля не заполнены");
			}
		}
		private void button10_Click(object sender, EventArgs e)
		{
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			comboBox1.Text = "";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (textBox6.Text.Length > 0 &&
				textBox7.Text.Length > 0 &&
				textBox8.Text.Length > 0)
			{
				Call_DB.Open();
				Call_DB.Request($"INSERT INTO Saler " +
					$"(`Surename`," +
					$"`Namess`," +
					$"`Father_name`) VALUES " +
					$"('{textBox6.Text}'," +
					$"'{textBox7.Text}'," +
					$"'{textBox8.Text}')");
				dataGridView1.DataSource = Call_DB.Request("SELECT * FROM Saler").Tables[0];

				comboBox3.Items.Clear();
				DataSet tables = Call_DB.Request("SELECT * FROM Saler");
				for (int i = 0; i < tables.Tables[0].Rows.Count; i++)
				{
					comboBox3.Items.Add(tables.Tables[0].Rows[i][0]);
				}
				Call_DB.Close();
			}
			else
			{
				MessageBox.Show("Поля не заполнены");
			}
		}
		private void button11_Click(object sender, EventArgs e)
		{
			textBox6.Text = "";
			textBox7.Text = "";
			textBox8.Text = "";
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (comboBox2.Text.Length > 0 &&
				comboBox3.Text.Length > 0 &&
				textBox10.Text.Length > 0 )
			{
				Call_DB.Open();
				Call_DB.Request($"INSERT INTO Sales " +
					$"(`Mobile_phone`," +
					$"`Saler_id`," +
					$"`Date_sale`) VALUES " +
					$"('{comboBox2.Text}'," +
					$"'{comboBox3.Text}'," +
					$"'{textBox10.Text}')");
				dataGridView1.DataSource = Call_DB.Request("SELECT * FROM Sales").Tables[0];
				Call_DB.Close();
			}
			else
			{
				MessageBox.Show("Поля не заполнены");
			}
		}
		private void button12_Click(object sender, EventArgs e)
		{
			comboBox2.Text = "";
			comboBox3.Text = "";
			textBox10.Text = "";
		}

		private void button17_Click(object sender, EventArgs e)
		{button_num = 1;
			Select_value("Brends", 1);}
		private void button16_Click(object sender, EventArgs e)
		{button_num = 2;
			Select_value("Mobile_phone", 0);}
		private void button15_Click(object sender, EventArgs e)
		{button_num = 3;
			Select_value("Saler", 1);}
		private void button14_Click(object sender, EventArgs e)
		{button_num = 4;
			Select_value("Sales", 0);}
		public void Select_value(string table, int row)
		{
			Call_DB.Open();
			comboBox4.Items.Clear();
			DataSet tables = Call_DB.Request($"SELECT * FROM {table}");
			for (int i = 0; i < tables.Tables[0].Rows.Count; i++)
			{
				comboBox4.Items.Add(tables.Tables[0].Rows[i][row]);
			}
			Call_DB.Close();
		}

		private void button18_Click(object sender, EventArgs e)
		{
			if(button_num != 0 && comboBox4.Text.Length > 0)
			{
				Call_DB.Open();
				switch(button_num)
				{
					case 1:
						break; 
					case 2:
						break;
					case 3:
						break;
					case 4:
						break;
				}
			}
			else
			{
				MessageBox.Show("Неверное значение");
			}
		}
	}
}
