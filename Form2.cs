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
		List<Set> ListaSets;
		List<Token> ListaTokens;
		List<Action> ListaActions;
		List<string> ST = new List<string>();
		string Inicial;
		List<Estado> Estados = new List<Estado>();
		List<string> EAceptacion = new List<string>();
		int Error;
		Dictionary<string, string> Hojas = new Dictionary<string, string>();
		string UH;
		public Form2(Nodo Arbol, List<Set> SETs, List<Token> TOKENs, List<Action> ACTIONs, int E_)
		{
			this.Arbol = Arbol;
			Tablas Tablas = new Tablas(Arbol, TOKENs, SETs);
			Tablas.GenerarTablas();
			List<string[]> RowFLN = Tablas.getTablaFLN();
			List<string[]> RowFollow = Tablas.getTablaFollow();
			List<string[]> RowEstados = Tablas.getTablaEstados();
			List<string> Column = Tablas.getColumnas();
			Error = E_;

			ListaActions = ACTIONs;
			ListaSets = SETs;
			ListaTokens = TOKENs;
			ST = Tablas.getColumnas();
			Estados = Tablas.returnEstados();
			EAceptacion = Tablas.getEAceptacion();
			Inicial = Tablas.getInicial();
			Hojas = Tablas.getMandarHojas();
			UH = Tablas.getUltimaHoja();
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
			try
			{
				GrafoAB Grafo = new GrafoAB(Arbol);
				string pathApp = Environment.CurrentDirectory;
				pictureBox1.Image = Grafo.CrearGrafo(pathApp);
			}
			catch { };
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

		private void button1_Click(object sender, EventArgs e)
		{
			string pathCarpeta = "";
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
				pathCarpeta = fbd.SelectedPath;
			fbd.Dispose();

			Dictionary<string, Estado> E = new Dictionary<string, Estado>();
			foreach (var item in Estados)
			{
				E.Add(item.ID, item);
			}

			GeneradorAutomata G = new GeneradorAutomata(ListaSets, ListaTokens, ListaActions, E, Inicial, EAceptacion, Error, Hojas, UH);
			G.GenerarPrograma(pathCarpeta + "\\Automata" );
			this.Close();
		}
	}
}
