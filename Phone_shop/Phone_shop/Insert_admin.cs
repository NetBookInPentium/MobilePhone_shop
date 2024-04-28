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
	public partial class Insert_admin : Form
	{
		Call_DB Call_DB = new Call_DB();
		public Insert_admin()
		{
			InitializeComponent();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if(textBox1.Text != "" && textBox2.Text != "")
			{
				Call_DB.Open();
				Call_DB.Request($"INSERT INTO Administrator (`login`, `password`) VALUES ('{textBox1.Text}', '{textBox2.Text}')");
				MessageBox.Show("Учетная запись создана");
				this.Close();
			}
			else
			{
				MessageBox.Show("Неверно указаны данные");
			}
			
		}
	}
}
