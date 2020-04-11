using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
			List<string[]> RowEstados = Tablas.getTablaEstados();
			List<string> Column = Tablas.getColumnas();
			InitializeComponent();
			foreach (var item in RowFLN)
				Tabla_FLN.Rows.Add(item);
			foreach (var item in RowFollow)
				Tabla_Follow.Rows.Add(item);
			DataGridViewTextBoxColumn C2 = new DataGridViewTextBoxColumn();
			C2.HeaderText = "Estado";
			Tabla_Estados.Columns.Add(C2);
			foreach (var item in Column)
			{
				DataGridViewTextBoxColumn C = new DataGridViewTextBoxColumn();
				C.HeaderText = item;
				Tabla_Estados.Columns.Add(C);
			}
			foreach (var item in RowEstados)
				Tabla_Estados.Rows.Add(item);

			//Dibujar Arbol
			GrafoAB Grafo = new GrafoAB(Arbol);
			string pathApp = Environment.CurrentDirectory;
			pictureBox1.Image = Grafo.CrearGrafo(pathApp);
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
