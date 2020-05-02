using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Automata
{
	class Automata
	{
		List<Set> ListaSets = new List<Set>();
		List<Token> ListaTokens = new List<Token>();
		List<Action> ListaActions = new List<Action>();
		List<string> ST = new List<string>();
		Dictionary<string, Estado> Estados = new Dictionary<string, Estado>();
		string EstadoInicial;
		List<string> EAceptacion = new List<string>();
		private void Inicializar()
		{
			//------------------------ SETS ----------------------------------
			Set S0 = new Set();
			S0.ID = "LETRA";
			S0.Rangos = new List<Rango>();
			Rango R0 = new Rango();
			R0.Inicio = 65;
			R0.Fin = 90;
			S0.Rangos.Add(R0);
			Rango R1 = new Rango();
			R1.Inicio = 97;
			R1.Fin = 122;
			S0.Rangos.Add(R1);
			Rango R2 = new Rango();
			R2.Inicio = 95;
			R2.Fin = 95;
			S0.Rangos.Add(R2);
			ListaSets.Add(S0);
			Set S1 = new Set();
			S1.ID = "DIGITO";
			S1.Rangos = new List<Rango>();
			Rango R3 = new Rango();
			R3.Inicio = 48;
			R3.Fin = 57;
			S1.Rangos.Add(R3);
			ListaSets.Add(S1);
			//------------------------ TOKENS --------------------------------
			Token T0 = new Token();
			T0.ID = 1;
			T0.ER = "DIGITODIGITO*";
			ListaTokens.Add(T0);
			Token T1 = new Token();
			T1.ID = 2;
			T1.ER = "'='";
			ListaTokens.Add(T1);
			Token T2 = new Token();
			T2.ID = 3;
			T2.ER = "':''='";
			ListaTokens.Add(T2);
			Token T3 = new Token();
			T3.ID = 5;
			T3.ER = "'A''N''D'";
			ListaTokens.Add(T3);
			Token T4 = new Token();
			T4.ID = 4;
			T4.ER = "LETRA(LETRA|DIGITO)*{RESERVADAS()}";
			ListaTokens.Add(T4);
			//------------------------ ACTIONS --------------------------------
			Action A0 = new Action();
			A0.ID = "RESERVADAS()";
			A0.Actions = new Dictionary<string, int>();
			A0.Actions.Add("PROGRAM", 5);
			A0.Actions.Add("INCLUDE", 6);
			A0.Actions.Add("CONST", 7);
			A0.Actions.Add("TYPE", 8);
			ListaActions.Add(A0);
			//------------------------ ESTADOS --------------------------------
			EstadoInicial = "1, 3, 4, 6, 9";
			EAceptacion.Add("2, 12"); EAceptacion.Add("12"); EAceptacion.Add("10, 11, 12"); Estado E0 = new Estado();
			E0.ID = "1, 3, 4, 6, 9";
			E0.Transiciones = new Dictionary<string, string>();
			E0.TokenTransicion = new Dictionary<string, string>();
			E0.Transiciones.Add("<DIGITO>", "2, 12");
			E0.Transiciones.Add("=", "12");
			E0.Transiciones.Add(":", "5");
			E0.Transiciones.Add("A", "7");
			E0.Transiciones.Add("<LETRA>", "10, 11, 12");
			E0.TokenTransicion.Add("<DIGITO>", "1");
			E0.TokenTransicion.Add("=", "2");
			E0.TokenTransicion.Add(":", "3");
			E0.TokenTransicion.Add("A", "5");
			E0.TokenTransicion.Add("<LETRA>", "4");
			Estados.Add("1, 3, 4, 6, 9", E0);
			Estado E1 = new Estado();
			E1.ID = "2, 12";
			E1.Transiciones = new Dictionary<string, string>();
			E1.TokenTransicion = new Dictionary<string, string>();
			E1.Transiciones.Add("<DIGITO>", "2, 12");
			E1.TokenTransicion.Add("<DIGITO>", "1");
			E1.TokenTransicion.Add("#", "-1");
			Estados.Add("2, 12", E1);
			Estado E2 = new Estado();
			E2.ID = "12";
			E2.Transiciones = new Dictionary<string, string>();
			E2.TokenTransicion = new Dictionary<string, string>();
			E2.TokenTransicion.Add("#", "-1");
			Estados.Add("12", E2);
			Estado E3 = new Estado();
			E3.ID = "5";
			E3.Transiciones = new Dictionary<string, string>();
			E3.TokenTransicion = new Dictionary<string, string>();
			E3.Transiciones.Add("=", "12");
			E3.TokenTransicion.Add("=", "3");
			Estados.Add("5", E3);
			Estado E4 = new Estado();
			E4.ID = "7";
			E4.Transiciones = new Dictionary<string, string>();
			E4.TokenTransicion = new Dictionary<string, string>();
			E4.Transiciones.Add("N", "8");
			E4.TokenTransicion.Add("N", "5");
			Estados.Add("7", E4);
			Estado E5 = new Estado();
			E5.ID = "8";
			E5.Transiciones = new Dictionary<string, string>();
			E5.TokenTransicion = new Dictionary<string, string>();
			E5.Transiciones.Add("D", "12");
			E5.TokenTransicion.Add("D", "5");
			Estados.Add("8", E5);
			Estado E6 = new Estado();
			E6.ID = "10, 11, 12";
			E6.Transiciones = new Dictionary<string, string>();
			E6.TokenTransicion = new Dictionary<string, string>();
			E6.Transiciones.Add("<DIGITO>", "10, 11, 12");
			E6.Transiciones.Add("<LETRA>", "10, 11, 12");
			E6.TokenTransicion.Add("<LETRA>", "4");
			E6.TokenTransicion.Add("<DIGITO>", "4");
			E6.TokenTransicion.Add("#", "-1");
			Estados.Add("10, 11, 12", E6);
		}
		public List<string> Analizar(string cadena)
		{
			string cadena2 = "";
			Inicializar();
			List<string> Retorno = new List<string>();
			string[] A = cadena.Split(' ');
			foreach (var item in A)
			{
				List<string> R = AnalizarActions(item);
				if (R.Count > 0) { Retorno.AddRange(R); }
				else { cadena2 += item + " "; }
			}
			if (cadena2.Length > 0) { cadena2 = cadena2.Substring(0, cadena2.Length - 1); }
			while (cadena2.Length > 0)
			{
				string AB = "";
				Analizador(ref cadena2, EstadoInicial, cadena2[0].ToString(), ref Retorno, ref AB, false);
			}
			return Retorno;
		}
		public List<string> AnalizarActions(string A)
		{
			A = A.ToUpper();
			List<string> Retorno = new List<string>();
			foreach (var item in ListaActions)
			{
				int R = 0;
				bool B = item.Actions.TryGetValue(A, out R);
				if (B)
				{ Retorno.Add((A + " = " + R)); }
			}
			return Retorno;
		}
		public bool Analizador(ref string A, string E, string Tk, ref List<string> L, ref string AB, bool W)
		{
			Estado T;
			if (E == null) { return false; }
			bool B = Estados.TryGetValue(E, out T);
			string ENuevo = "";
			if (Tk.Length <= 0) { ENuevo = null; }
			else
			{
				ENuevo = T.getTrancicion(Tk);
				string A2 = A;
				string AB2 = "";
				bool Work = false;
				try { A2 = A2.Substring(1, A2.Length - 1); } catch { }
				if (A2.Length > 0) { Work = Analizador(ref A2, ENuevo, A2[0].ToString(), ref L, ref AB2, true); }
				else { Work = Analizador(ref A2, ENuevo, "", ref L, ref AB2, true); }
				if (ENuevo == null || !Work)
				{
					foreach (var item in ListaSets)
					{
						if (item.Pertenece(Tk[0]) && Tk.Length == 1)
						{
							Tk = "<" + item.ID + ">";
							ENuevo = T.getTrancicion(Tk);
							break;
						}
					}
				}
			}
			if (ENuevo != null)
			{
				try { AB += A.Substring(0, 1); A = A.Substring(1, A.Length - 1); } catch { }
				if (A.Length > 0) { return Analizador(ref A, ENuevo, A[0].ToString(), ref L, ref AB, W); }
				else { return Analizador(ref A, ENuevo, "", ref L, ref AB, W); }
			}
			else
			{
				if (EAceptacion.Contains(E))
				{
					if (!W)
					{
						L.Add("ACEPTADA [ " + AB + " ]");
						AB = "";
					}
					return true;
				}
				else
				{
					if (A.Length > 0) { AB += A.Substring(0, 1); A = A.Substring(1, A.Length - 1); }
					if (!W)
					{
						L.Add("RECHAZADA [ " + AB + " ]");
						AB = "";
					}
					return false;
				}
			}
		}
	}
	class Action
	{
		public string ID { get; set; }
		public Dictionary<string, int> Actions { get; set; }
	}
	class Rango
	{
		public int Inicio { get; set; }
		public int Fin { get; set; }
	}
	class Set
	{
		public string ID { get; set; }
		public List<Rango> Rangos { get; set; }
		public bool Pertenece(char A)
		{
			foreach (var item in Rangos)
			{
				if (A >= item.Inicio && A <= item.Fin)
				{ return true; }
			}
			return false;
		}
	}
	class Token
	{
		public int ID { get; set; }
		public string ER { get; set; }
	}
	class Estado
	{
		public string ID { get; set; }
		public Dictionary<string, string> Transiciones { get; set; }
		public Dictionary<string, string> TokenTransicion { get; set; }
		public string getTrancicion(string A)
		{
			string R = "";
			bool B = Transiciones.TryGetValue(A, out R);
			if (B) { return R; }
			else
			{ return null; }
		}
		public string getTokenTransicion(string A)
		{
			string R = "";
			bool B = TokenTransicion.TryGetValue(A, out R);
			if (B) { return R; }
			else
			{ return null; }
		}
	}
}
