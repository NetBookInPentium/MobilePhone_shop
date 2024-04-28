using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phone_shop
{
	public partial class Form1 : Form
	{
		Call_DB Call_db = new Call_DB();
		public Form1()
		{
			InitializeComponent();
			textBox1.Text = "FirstovDen";
			textBox2.Text = "297183";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Call_db.Open();
			if (Call_db.Select_user(textBox1.Text, textBox2.Text))
			{
				Menu menu = new Menu();
				menu.ShowDialog();
				this.Close();
			}
			else
			{
				MessageBox.Show("Не правильный логин или пароль");
				textBox2.Text = "";
			}
			Call_db.Close();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Insert_admin insert_Admin = new Insert_admin();
			insert_Admin.ShowDialog();

		}
	}
}
