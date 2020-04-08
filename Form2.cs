using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFA_Sergio_Lara
{
	public partial class Form2 : Form
	{
		Nodo Arbol = new Nodo();
		public Form2(Nodo Arbol)
		{
			this.Arbol = Arbol;
			Tablas Tablas = new Tablas(Arbol);
			Tablas.GenerarTablas();
			List<string[]> RowFLN = Tablas.getTablaFLN();
			List<string[]> RowFollow = Tablas.getTablaFollow();
			InitializeComponent();
			foreach (var item in RowFLN)
				Tabla_FLN.Rows.Add(item);
			foreach (var item in RowFollow)
				Tabla_Follow.Rows.Add(item);
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}
	}
}
