using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LFA_Sergio_Lara
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			listBoxEntrada.Text = "";
			listBoxEntrada.Items.Add("Arrastre su documento .txt aqui para iniciar");
			listBoxMensaje.Text = "";
		}
		private void listBoxEntrada_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		//DragDrop aca analizo que sea valido el formato del archivo, asi mismo empieza la 
		//ejecución de analisis lexico
		private void listBoxEntrada_DragDrop(object sender, DragEventArgs e)
		{
			string[] paths = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
			if(paths.Length > 1)
				MessageBox.Show("No debe de ingresar mas de un archivo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			if (Path.GetExtension(paths[0]) != ".txt")
				MessageBox.Show("Debe ingresar un archivo con la extención .txt", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
			{
				//Escribe el txt ingresado en la listView1
				using (var file = new StreamReader(paths[0]))
				{
					string linea = "";
					while ((linea = file.ReadLine()) != null)
					{
						listBoxTXT.Items.Add(linea);
					}
				}

				//Muestra el los mensajes de error al usuario de su gramatica
				Procesos H = new Procesos();
				H.Inicializar();
				Mensaje M = H.AnalisarTexto(paths[0]);

				if (M != null)
				{
					listBoxMensaje.Items.Add("ERROR");
					listBoxMensaje.Items.Add("Linea  : " + M.linea);
					listBoxMensaje.Items.Add("Cerca de Columna: " + M.columna);
					if (M.texto != null)
						listBoxMensaje.Items.Add(M.texto);
					try
					{
						listBoxTXT.SetSelected(M.linea - 1, true);
					}
					catch { }
				}
				else
				{
					//No hay errores en la primer Entrega
					Form2 F2 = new Form2(H.ArbolTokens(), H.getSets(), H.getTokens(), H.getActions());
					F2.ShowDialog();
				} 	
			}
		}

		//DragEnter para que permita deslizar un objeto sobre el ListBoxEntrada
		private void listBoxEntrada_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.All;
			else
				e.Effect = DragDropEffects.None;

			listBoxTXT.Items.Clear();
			listBoxMensaje.Items.Clear();
		}

		private void listBoxTXT_DrawItem(object sender, DrawItemEventArgs e)
		{

		}
	}
}
