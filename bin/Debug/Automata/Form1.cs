using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automata
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			Automata A = new Automata();
			List<string> Rows =  A.Analizar(textBox.Text);
			listBox.Items.Clear();
			foreach (var item in Rows)
				listBox.Items.Add(item);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
