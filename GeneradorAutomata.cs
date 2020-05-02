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
		Dictionary<string, Estado> Estados = new Dictionary<string, Estado>();
		string Inicial;
		int Error;
		List<string> EAceptacion = new List<string>();

		public GeneradorAutomata(List<Set> S, List<Token> T, List<Action> A, Dictionary<string, Estado> E, string I, List<string> EA, int Error_)
		{
			ListaSets = S;
			ListaTokens = T;
			ListaActions = A;
			Estados = E;
			Inicial = I;
			EAceptacion = EA;
			Error = Error_;
		}
		public void GenerarPrograma(string pathCarpeta)
		{
			string AutomataPath = @".\Automata\Automata.cs";
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
			B.Append("Dictionary<string, Estado> Estados = new Dictionary<string, Estado>();" + Environment.NewLine);
			B.Append("string EstadoInicial;" + Environment.NewLine);
			B.Append("List<string> EAceptacion = new List<string>();" + Environment.NewLine);
			B.Append("int ERROR;" + Environment.NewLine);

			B.Append("private void Inicializar()" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("ERROR = " + Error + ";" + Environment.NewLine);
			B.Append("//------------------------ SETS ----------------------------------" + Environment.NewLine);
			B.Append(EscribirSet());
			B.Append("//------------------------ TOKENS --------------------------------" + Environment.NewLine);
			B.Append(EscribirToken());
			B.Append("//------------------------ ACTIONS --------------------------------" + Environment.NewLine);
			B.Append(EscribirActions());
			B.Append("//------------------------ ESTADOS --------------------------------" + Environment.NewLine);
			B.Append(EscribirEstados());
			B.Append("}" + Environment.NewLine);
			
			// ----------------- Codigo para analizar -----------------------------------
			B.Append("public List<string> Analizar(string cadena)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("string cadena2 = \"\";" + Environment.NewLine);
			B.Append("Inicializar();" + Environment.NewLine);
			B.Append("List<string> Retorno = new List<string>();" + Environment.NewLine);
			B.Append("string[] A = cadena.Split(' ');" + Environment.NewLine);
			B.Append("foreach (var item in A)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("List<string> R = AnalizarActions(item);" + Environment.NewLine);
			B.Append("if (R.Count > 0) { Retorno.AddRange(R); }" + Environment.NewLine);
			B.Append("else { cadena2 += item + \" \"; }" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("if (cadena2.Length > 0) { cadena2 = cadena2.Substring(0, cadena2.Length - 1); } " + Environment.NewLine);
			B.Append("while (cadena2.Length > 0)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("string AB = \"\";" + Environment.NewLine);
			B.Append("Analizador(ref cadena2, EstadoInicial, cadena2[0].ToString(), ref Retorno, ref AB, false, \"-1\");" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("return Retorno;" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("public List<string> AnalizarActions (string A)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("A = A.ToUpper();" + Environment.NewLine);
			B.Append("List<string> Retorno = new List<string>();" + Environment.NewLine);
			B.Append("foreach (var item in ListaActions)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("int R = 0;" + Environment.NewLine);
			B.Append("bool B = item.Actions.TryGetValue(A, out R);" + Environment.NewLine);
			B.Append("if (B)" + Environment.NewLine);
			B.Append("{ Retorno.Add((A + \" = \" + R)); }" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("return Retorno;" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("public bool Analizador (ref string A, string E, string Tk, ref List<string> L, ref string AB, bool W, string Token)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("Estado T;" + Environment.NewLine);
			B.Append("if (E == null) { return false; }" + Environment.NewLine);
			B.Append("bool B = Estados.TryGetValue(E, out T);" + Environment.NewLine);
			B.Append("string ENuevo = \"\";" + Environment.NewLine);
			B.Append("if (Tk.Length <= 0) { ENuevo = null; }" + Environment.NewLine);
			B.Append("else" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("ENuevo = T.getTrancicion(Tk);" + Environment.NewLine);
			B.Append("string A2 = A;" + Environment.NewLine);
			B.Append("string AB2 = \"\";" + Environment.NewLine);
			B.Append("bool Work = false;" + Environment.NewLine);
			B.Append("try { A2 = A2.Substring(1, A2.Length - 1); } catch { }" + Environment.NewLine);
			B.Append("if(A2.Length > 0) { Work = Analizador(ref A2, ENuevo, A2[0].ToString(), ref L, ref AB2, true, Token); }" + Environment.NewLine);
			B.Append("else { Work = Analizador(ref A2, ENuevo, \"\", ref L, ref AB2, true, Token); }" + Environment.NewLine);
			B.Append("if (ENuevo == null || !Work)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("foreach (var item in ListaSets)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("if (item.Pertenece(Tk[0]) && Tk.Length == 1)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("Tk = \"<\" + item.ID + \">\";" + Environment.NewLine);
			B.Append("ENuevo = T.getTrancicion(Tk);" + Environment.NewLine);
			B.Append("break;" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("if (ENuevo != null)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("Token = T.getTokenTransicion(Tk);" + Environment.NewLine);
			B.Append("try { AB += A.Substring(0, 1); A = A.Substring(1, A.Length - 1); } catch { }" + Environment.NewLine);
			B.Append("if (A.Length > 0) { return Analizador(ref A, ENuevo, A[0].ToString(), ref L, ref AB, W, Token); }" + Environment.NewLine);
			B.Append("else { return Analizador(ref A, ENuevo, \"\", ref L, ref AB, W, Token); }" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("else" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("if (EAceptacion.Contains(E))" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("if (!W)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("L.Add(AB + \"=\" + Token);" + Environment.NewLine);
			B.Append("AB = \"\";" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("return true;" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("else" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("if(A.Length > 0) { AB += A.Substring(0, 1); A = A.Substring(1, A.Length - 1); }" + Environment.NewLine);
			B.Append("if (!W)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("if(AB == \" \") { L.Add(AB); }" + Environment.NewLine);
			B.Append("else { L.Add(AB + \" = ERROR \" + ERROR); }" + Environment.NewLine);
			B.Append("AB = \"\";" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("return false;" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			// ----------------- CLASS ACTION -----------------------------------
			B.Append("class Action" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public string ID {get; set;}" + Environment.NewLine);
			B.Append("public Dictionary<string, int> Actions {get; set;}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			// ----------------- CLASS RANGO -----------------------------------
			B.Append("class Rango" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public int Inicio {get; set;}" + Environment.NewLine);
			B.Append("public int Fin {get; set;}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			// ----------------- CLASS SET -----------------------------------
			B.Append("class Set" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public string ID {get; set;}" + Environment.NewLine);
			B.Append("public List<Rango> Rangos {get; set;}" + Environment.NewLine);
			B.Append("public bool Pertenece (char A)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("foreach (var item in Rangos)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("if(A >= item.Inicio && A <= item.Fin)" + Environment.NewLine);
			B.Append("{ return true; }" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("return false;" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			// ----------------- CLASS TOKEN -----------------------------------
			B.Append("class Token" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public int ID {get; set;}" + Environment.NewLine);
			B.Append("public string ER {get; set;}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			// ----------------- CLASS ESTADO -----------------------------------
			B.Append("class Estado" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("public string ID {get; set;}" + Environment.NewLine);
			B.Append("public Dictionary<string, string> Transiciones {get; set;}" + Environment.NewLine);
			B.Append("public Dictionary<string, string> TokenTransicion {get; set;}" + Environment.NewLine);
			B.Append("public string getTrancicion (string A)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("string R = \"\";" + Environment.NewLine);
			B.Append("bool B = Transiciones.TryGetValue(A, out R);" + Environment.NewLine);
			B.Append("if(B)");
			B.Append("{ return R; }" + Environment.NewLine);
			B.Append("else" + Environment.NewLine);
			B.Append("{ return null; }" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("public string getTokenTransicion (string A)" + Environment.NewLine);
			B.Append("{" + Environment.NewLine);
			B.Append("string R = \"\";" + Environment.NewLine);
			B.Append("bool B = TokenTransicion.TryGetValue(A, out R);" + Environment.NewLine);
			B.Append("if(B)");
			B.Append("{ return R; }" + Environment.NewLine);
			B.Append("else" + Environment.NewLine);
			B.Append("{ return null; }" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);
			B.Append("}" + Environment.NewLine);

			B.Append("}" + Environment.NewLine);

			File.WriteAllText(AutomataPath, B.ToString());
			string sourcePath = @".\Automata";
			CopiarArchivos(sourcePath, pathCarpeta);
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
		private string EscribirSet()
		{
			StringBuilder B = new StringBuilder();
			int C = 0;
			int Z = 0;
			foreach (var item in ListaSets)
			{
				B.Append("Set S" + C + " = new Set();" + Environment.NewLine);
				B.Append("S"+ C + ".ID = \"" + item.ID + "\";" + Environment.NewLine);
				B.Append("S" + C + ".Rangos = new List<Rango>();" + Environment.NewLine);
				foreach (var item2 in item.Rangos)
				{
					B.Append("Rango R" + Z + " = new Rango();" + Environment.NewLine);
					B.Append("R" + Z + ".Inicio = " + item2.Inicio + ";" + Environment.NewLine);
					B.Append("R" + Z + ".Fin = " + item2.Fin + ";" + Environment.NewLine);
					B.Append("S" + C + ".Rangos.Add(R" + Z + ");" + Environment.NewLine);
					Z++;
				}
				B.Append("ListaSets.Add(S" + C + ");" + Environment.NewLine);
				C++;
			}
			return B.ToString();
		}
		private string EscribirToken()
		{
			StringBuilder B = new StringBuilder();
			int C = 0;
			foreach (var item in ListaTokens)
			{
				B.Append("Token T" + C + " = new Token();" + Environment.NewLine);
				B.Append("T" + C + ".ID = " + item.ID + ";" + Environment.NewLine);
				B.Append("T" + C + ".ER = \"" + EscribirER(item.ER) + "\";" + Environment.NewLine);
				B.Append("ListaTokens.Add(T" + C + ");" + Environment.NewLine);
				C++;
			}
			return B.ToString();
		}
		private string EscribirER(string ER)
		{
			string R = "";
			foreach (var item in ER)
			{
				if (item == '"')
					R += "\\" + item;
				else
					R += item;
			}
			return R;
		}
		private string EscribirActions()
		{
			StringBuilder B = new StringBuilder();
			int C = 0;
			foreach (var item in ListaActions)
			{
				B.Append("Action A" + C + " = new Action();" + Environment.NewLine);
				B.Append("A" + C + ".ID = \"" + item.ID + "\";" + Environment.NewLine);
				B.Append("A" + C + ".Actions = new Dictionary<string, int>();" + Environment.NewLine);
				foreach (var item2 in item.Actions)
				{
					B.Append("A" + C + ".Actions.Add(\"" + item2.Key + "\", " + item2.Value + ");" + Environment.NewLine);
				}
				B.Append("ListaActions.Add(A" + C + ");" + Environment.NewLine);
				C++;
			}
			return B.ToString();
		}
		private string EscribirEstados()
		{
			StringBuilder B = new StringBuilder();
			B.Append("EstadoInicial = \"" + Inicial + "\";" + Environment.NewLine);
			foreach (var item in EAceptacion)
			{
				B.Append("EAceptacion.Add(\"" + item + "\");");
			}
			int C = 0;
			foreach (var item in Estados)
			{
				B.Append("Estado E" + C + "= new Estado();" + Environment.NewLine);
				B.Append("E" + C + ".ID = \"" + item.Key + "\";" + Environment.NewLine);
				B.Append("E" + C + ".Transiciones = new Dictionary<string, string>();" + Environment.NewLine);
				B.Append("E" + C + ".TokenTransicion = new Dictionary<string, string>();" + Environment.NewLine);
				foreach (var item2 in item.Value.Transiciones)
				{ 
					if(item2.Key[0] == '/' && item2.Key.Length >= 2)
						B.Append("E" + C + ".Transiciones.Add(\"" + item2.Key[1] + "\", \"" + item2.Value + "\");" + Environment.NewLine);
					else if(item2.Key == "\"")
						B.Append("E" + C + ".Transiciones.Add(\"\\" + item2.Key + "\", \"" + item2.Value + "\");" + Environment.NewLine);
					else
						B.Append("E" + C + ".Transiciones.Add(\"" + item2.Key + "\", \"" + item2.Value + "\");" + Environment.NewLine);
				}
				foreach (var item2 in item.Value.TokenTransicion)
				{
					if(item2.Key[0] == '/' && item2.Key.Length >= 2)
						B.Append("E" + C + ".TokenTransicion.Add(\"" + item2.Key[1] + "\", \"" + item2.Value + "\");" + Environment.NewLine);
					else if(item2.Key == "\"")
						B.Append("E" + C + ".TokenTransicion.Add(\"\\" + item2.Key + "\", \"" + item2.Value + "\");" + Environment.NewLine);
					else
						B.Append("E" + C + ".TokenTransicion.Add(\"" + item2.Key + "\", \"" + item2.Value + "\");" + Environment.NewLine);
				}
				B.Append("Estados.Add(\"" + item.Key + "\", E" + C + ");" + Environment.NewLine);
				C++;
			}
			return B.ToString();
		}
	}
}
