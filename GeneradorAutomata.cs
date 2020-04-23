using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LFA_Sergio_Lara
{
	class GeneradorAutomata
	{
		List<Set> ListaSets;
		List<Token> ListaTokens;
		List<Action> ListaActions;
		List<string> ST = new List<string>();
		Dictionary<string, string[]> Estados = new Dictionary<string, string[]>();

		public GeneradorAutomata(List<Set> S, List<Token> T, List<Action> A, List<string> ST_, Dictionary<string, string[]>E)
		{
			ListaSets = S;
			ListaTokens = T;
			ListaActions = A;
			ST = ST_;
			Estados = E;
		}
		public void GenerarPrograma(string pathCarpeta)
		{
			string sourcePath = @".\Automata";
			CopiarArchivos(sourcePath, pathCarpeta);
			StringBuilder B = new StringBuilder();

			B.Append("using System;" + Environment.NewLine);
			B.Append("using System.Collections.Generic;" + Environment.NewLine);
			B.Append("using System.Linq;" + Environment.NewLine);
			B.Append("using System.Text;" + Environment.NewLine);
			B.Append("namespace Automata" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);

			B.Append("class Automata" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);

			B.Append("List<Set> ListaSets = new List<Set>();" + Environment.NewLine);
			B.Append("List<Token> ListaTokens = new List<Token>();" + Environment.NewLine);
			B.Append("List<Action> ListaActions = new List<Action>();" + Environment.NewLine);
			B.Append("List<string> ST = new List<string>();" + Environment.NewLine);
			B.Append("Dictionary<string, string[]> Estados = new Dictionary<string, string[]>();" + Environment.NewLine);

			B.Append("public List<string> Analizar(string cadena)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("List<string> Retorno = new List<string>();" + Environment.NewLine);
			B.Append("return Retorno;" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("}" + Environment.NewLine);

			B.Append("class Action" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public string ID {get; set;}" + Environment.NewLine);
			B.Append("public Dictionary<string, int> Actions {get; set;}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("class Rango" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public int inicio {get; set;}" + Environment.NewLine);
			B.Append("public int fin {get; set;}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("class Set" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public string ID {get; set;}" + Environment.NewLine);
			B.Append("public List<Rango> Rangos {get; set;}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("class Token" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public int ID {get; set;}" + Environment.NewLine);
			B.Append("public string ER {get; set;}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("}" + Environment.NewLine);
		}
		private void CopiarArchivos(string pathOrigen, string pathDestino)
		{
			Directory.CreateDirectory(pathDestino);
			if (Directory.Exists(pathDestino))
			{
				string[] files = Directory.GetFiles(pathOrigen);
				string[] directorys = Directory.GetDirectories(pathOrigen);

				foreach (string s in files)
				{
					string fileName = Path.GetFileName(s);
					string destFile = Path.Combine(pathDestino, fileName);
					File.Copy(s, destFile, true);
				}
				foreach (string s in directorys)
				{
					var x = s.Split('\\');
					var x2 = x.Length;
					var destino = pathDestino + '\\' + x[x2 - 1];
					CopiarArchivos(s, destino);
				}
			}
		}
		
	}
}
