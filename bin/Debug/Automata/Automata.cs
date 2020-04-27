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
			Set S2 = new Set();
			S2.ID = "CHARSET";
			S2.Rangos = new List<Rango>();
			Rango R4 = new Rango();
			R4.Inicio = 32;
			R4.Fin = 254;
			S2.Rangos.Add(R4);
			ListaSets.Add(S2);
			//------------------------ TOKENS --------------------------------
			Token T0 = new Token();
			T0.ID = 1;
			T0.ER = "(<DIGITO>.<DIGITO>*)";
			ListaTokens.Add(T0);
			Token T1 = new Token();
			T1.ID = 8;
			T1.ER = "(>.=)";
			ListaTokens.Add(T1);
			Token T2 = new Token();
			T2.ID = 9;
			T2.ER = "(/<.=)";
			ListaTokens.Add(T2);
			Token T3 = new Token();
			T3.ID = 12;
			T3.ER = "(O.R)";
			ListaTokens.Add(T3);
			Token T4 = new Token();
			T4.ID = 3;
			T4.ER = "(<LETRA>.(<LETRA>|<DIGITO>)*)";
			ListaTokens.Add(T4);
			//------------------------ ACTIONS --------------------------------
			Action A0 = new Action();
			A0.ID = "RESERVADAS()";
			A0.Actions = new Dictionary<string, int>();
			A0.Actions.Add("PROGRAM", 18);
			A0.Actions.Add("INCLUDE", 19);
			A0.Actions.Add("CONST", 20);
			A0.Actions.Add("TYPE", 21);
			A0.Actions.Add("VAR", 22);
			A0.Actions.Add("RECORD", 23);
			A0.Actions.Add("ARRAY", 24);
			A0.Actions.Add("OF", 25);
			A0.Actions.Add("PROCEDURE", 26);
			A0.Actions.Add("FUNCTION", 27);
			A0.Actions.Add("IF", 28);
			A0.Actions.Add("THEN", 29);
			A0.Actions.Add("ELSE", 30);
			A0.Actions.Add("FOR", 31);
			A0.Actions.Add("TO", 32);
			A0.Actions.Add("WHILE", 33);
			A0.Actions.Add("DO", 34);
			A0.Actions.Add("EXIT", 35);
			A0.Actions.Add("END", 36);
			A0.Actions.Add("CASE", 37);
			A0.Actions.Add("BREAK", 38);
			A0.Actions.Add("DOWNTO", 39);
			ListaActions.Add(A0);
			//------------------------ ESTADOS --------------------------------
			EstadoInicial = "1, 3, 5, 7, 9";
			EAceptacion.Add("2, 12"); EAceptacion.Add("12"); EAceptacion.Add("10, 11, 12"); Estado E0 = new Estado();
			E0.ID = "1, 3, 5, 7, 9";
			E0.Transiciones = new Dictionary<string, string>(); E0.Transiciones.Add("<DIGITO>", "2, 12");
			E0.Transiciones.Add(">", "4");
			E0.Transiciones.Add("/<", "6");
			E0.Transiciones.Add("O", "8");
			E0.Transiciones.Add("<LETRA>", "10, 11, 12");
			Estados.Add("1, 3, 5, 7, 9", E0);
			Estado E1 = new Estado();
			E1.ID = "2, 12";
			E1.Transiciones = new Dictionary<string, string>(); E1.Transiciones.Add("<DIGITO>", "2, 12");
			Estados.Add("2, 12", E1);
			Estado E2 = new Estado();
			E2.ID = "4";
			E2.Transiciones = new Dictionary<string, string>(); E2.Transiciones.Add("=", "12");
			Estados.Add("4", E2);
			Estado E3 = new Estado();
			E3.ID = "12";
			E3.Transiciones = new Dictionary<string, string>(); Estados.Add("12", E3);
			Estado E4 = new Estado();
			E4.ID = "6";
			E4.Transiciones = new Dictionary<string, string>(); E4.Transiciones.Add("=", "12");
			Estados.Add("6", E4);
			Estado E5 = new Estado();
			E5.ID = "8";
			E5.Transiciones = new Dictionary<string, string>(); E5.Transiciones.Add("R", "12");
			Estados.Add("8", E5);
			Estado E6 = new Estado();
			E6.ID = "10, 11, 12";
			E6.Transiciones = new Dictionary<string, string>(); E6.Transiciones.Add("<DIGITO>", "10, 11, 12");
			E6.Transiciones.Add("<LETRA>", "10, 11, 12");
			Estados.Add("10, 11, 12", E6);
		}
		public List<string> Analizar(string cadena)
		{
			Inicializar();
			List<string> Retorno = new List<string>();
			string[] A = cadena.Split(' ');
			foreach (var item in A)
			{
				List<string> R = AnalizarActions(item);
				if (R.Count > 0)
				{ Retorno.AddRange(R); }
				else
				{
					R = Analizador(item, EstadoInicial);
					if (R != null)
					{ Retorno.AddRange(R); }
					else
					{
						Retorno.Add("La cadena [ " + item + " ] no coincide con la gramatica");
					}
				}
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
		public List<string> Analizador(string A, string E)
		{
			List<string> Retorno = new List<string>();
			Estado T;
			bool B = Estados.TryGetValue(E, out T);
			if (B)
			{
				foreach (var item in ListaSets)
				{
					if (item.Pertenece(A[0]))
					{
						
					}
				}
				string NE = T.getTrancicion(A);
			}
			else
			{
			}
			return null;
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
		public string getTrancicion(string A)
		{
			string R = "";
			bool B = Transiciones.TryGetValue(A, out R);
			if (B) { return R; }
			else
			{ return null; }
		}
	}
}
