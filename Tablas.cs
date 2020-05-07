using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFA_Sergio_Lara
{
	class Tablas
	{
		Nodo Arbol = new Nodo();
		List<string[]> RowFLN = new List<string[]>();
		List<string[]> RowFollow = new List<string[]>();
		List<string[]> RowEstados = new List<string[]>();
		List<Token> ListaTokens = new List<Token>();
		List<Set> ListaSETS = new List<Set>();
		List<string> ST = new List<string>();
		Dictionary<int, List<int>> Follow = new Dictionary<int, List<int>>();
		Dictionary<int, string> Hojas = new Dictionary<int, string>();
		Dictionary<string, string[]> Estados = new Dictionary<string, string[]>();
		Dictionary<int, string> Follows = new Dictionary<int, string>();
		Dictionary<string, string> HojasMandar = new Dictionary<string, string>();

		string EstadoInicial;
		List<string> EAceptacion = new List<string>();
		List<Estado> EstadosR = new List<Estado>();
		string UF;

		public Tablas(Nodo Arbol, List<Token> LT, List<Set> LS)
		{
			this.Arbol = Arbol;
			ListaTokens = LT;
			ListaSETS = LS;
		}
		public void GenerarTablas()
		{
			int n = 1;
			AsignarHojas(Arbol, ref n);
			AsignarFLN(Arbol);
			AsignarFollow(Arbol);

			for (int i = 1; i < n; i++)
				Follow.Add(i, new List<int>());

			LlenarTablaFLN(Arbol);
			LlenarTablaFollow(Arbol);
			UF = UFollow();
			Ecloshure(Arbol.First);
			AsignarEA();
			AsignarToken(Arbol);
			PonerTT();
			Dictionary<string, string> Aux = new Dictionary<string, string>();
			ConseguirHojas(Arbol, ref Aux);
			HojasMandar = Aux;
		}
		private void AsignarHojas(Nodo Nodo, ref int n)
		{
			if (Nodo.Izquierdo != null)
				AsignarHojas(Nodo.Izquierdo, ref n);

			Nodo.First = new List<int>();
			Nodo.Last = new List<int>();
			Nodo.Follow = new List<int>();
			if (Nodo.Contenido == "*")
				Nodo.Nullable = true;
			if (Nodo.Contenido == "+")
				Nodo.Nullable = false;
			if (Nodo.Izquierdo == null && Nodo.Derecho == null)
			{
				List<int> L = new List<int>();
				L.Add(n);
				Nodo.First = Nodo.Last = L;
				if (!Hojas.ContainsKey(n))
					Hojas.Add(n, Nodo.Contenido);
				if (!ST.Contains(Nodo.Contenido))
					ST.Add(Nodo.Contenido);
				n++;

				Nodo.TokenID = -1;
			}

			if (Nodo.Derecho != null)
				AsignarHojas(Nodo.Derecho, ref n);
		}
		private void AsignarFLN(Nodo Nodo)
		{
			if (Nodo.Izquierdo != null)
				AsignarFLN(Nodo.Izquierdo);
			if (Nodo.Derecho != null)
				AsignarFLN(Nodo.Derecho);
			if (Nodo.Contenido == "|")
			{
				if (Nodo.Izquierdo.Nullable == true || Nodo.Derecho.Nullable == true)
					Nodo.Nullable = true;
				Nodo.First.AddRange(Nodo.Izquierdo.First);
				Nodo.First.AddRange(Nodo.Derecho.First);
				Nodo.Last.AddRange(Nodo.Izquierdo.Last);
				Nodo.Last.AddRange(Nodo.Derecho.Last);
			}
			if (Nodo.Contenido == ".")
			{
				if (Nodo.Izquierdo.Nullable == true && Nodo.Derecho.Nullable == true)
					Nodo.Nullable = true;
				if (Nodo.Izquierdo.Nullable == true)
				{
					Nodo.First.AddRange(Nodo.Izquierdo.First);
					Nodo.First.AddRange(Nodo.Derecho.First);
				}
				else
					Nodo.First.AddRange(Nodo.Izquierdo.First);
				if (Nodo.Derecho.Nullable == true)
				{
					Nodo.Last.AddRange(Nodo.Izquierdo.Last);
					Nodo.Last.AddRange(Nodo.Derecho.Last);
				}
				else
					Nodo.Last.AddRange(Nodo.Derecho.Last);
			}
			if (Nodo.Contenido == "*" || Nodo.Contenido == "+")
			{
				Nodo.First.AddRange(Nodo.Izquierdo.First);
				Nodo.Last.AddRange(Nodo.Izquierdo.Last);
			}
			if (Nodo.First.Count > 0)
				Nodo.First.Sort();
			if (Nodo.Last.Count > 0)
				Nodo.Last.Sort();
		}
		private void AsignarFollow(Nodo Nodo)
		{
			if (Nodo.Izquierdo != null)
				AsignarFollow(Nodo.Izquierdo);
			if (Nodo.Derecho != null)
				AsignarFollow(Nodo.Derecho);

			if (Nodo.Contenido == ".")
				Nodo.Izquierdo.Follow.AddRange(Nodo.Derecho.First);
			if (Nodo.Contenido == "*")
				Nodo.Izquierdo.Follow.AddRange(Nodo.Izquierdo.First);
		}
		private void LlenarTablaFLN(Nodo Nodo)
		{
			if (Nodo.Izquierdo != null)
				LlenarTablaFLN(Nodo.Izquierdo);

			string Fs = "";
			string Ls = "";
			foreach (var item in Nodo.First)
				Fs += item + ", ";
			foreach (var item in Nodo.Last)
				Ls += item + ", ";
			string[] row = new string[] { Nodo.Contenido, Fs, Ls, Nodo.Nullable.ToString() };
			RowFLN.Add(row);
			if (Nodo.Izquierdo == null && Nodo.Derecho == null && Nodo.First.Count == 1 && Nodo.Last.Count == 1)
				Follows.Add(Nodo.First[0], Nodo.Contenido);
			
			if (Nodo.Derecho != null)
				LlenarTablaFLN(Nodo.Derecho);
		}
		private void LlenarTablaFollow(Nodo Nodo)
		{
			if (Nodo.Izquierdo != null)
				LlenarTablaFollow(Nodo.Izquierdo);

			if (Nodo.Follow.Count > 0)
			{
				foreach (var last in Nodo.Last)
					Follow[last].AddRange(Nodo.Follow);
			}

			if (Nodo.Derecho != null)
				LlenarTablaFollow(Nodo.Derecho);
		}
		private void Ecloshure(List<int> Estado)
		{
			string S3 = "";
			foreach (var item in Estado)
				S3 += item + ", ";
			S3 = S3.Substring(0, S3.Length - 2);

			if (!Estados.ContainsKey(S3))
			{
				string S = "";
				string[] T = new string[ST.Count()];
				List<List<int>> AuxEstados = new List<List<int>>();

				foreach (var item in Estado)
				{
					string value = "";
					Hojas.TryGetValue(item, out value);
					List<int> Follows = new List<int>();
					Follow.TryGetValue(item, out Follows);
					int i = getIndex(value);
					Follows.Sort();
					string S2 = "";
					foreach (var item_ in Follows)
						S2 += item_ + ", ";

					if (S2.Length > 2)
					{
						if (T[i] != null)
						{
							T[i] = T[i].Replace(" ","");
							string[] C = T[i].Split(',');
							List<int> numeroInT = new List<int>();
							foreach (var numeroString in C)
							{
								if (numeroString.Length > 0)
									numeroInT.Add(int.Parse(numeroString));
							}
							foreach (var item2 in Follows)
							{
								if (!numeroInT.Contains(item2))
									numeroInT.Add(item2);
							}
							S2 = "";
							numeroInT.Sort();
							foreach (var item2 in numeroInT)
							{
								S2 += item2 + ", ";
							}
							S2 = S2.Substring(0, S2.Length - 2);
							T[i] = S2;
						}
						else
						{
							S2 = S2.Substring(0, S2.Length - 2);
							T[i] = S2;
						}
					}
					S += item + ", ";
				}
				S = S.Substring(0, S.Length - 2);

				if (Estados.Count <= 0)
				{
					EstadoInicial = S;
				}

				Estados.Add(S, T);

				Estado E = new Estado();
				E.ID = S;
				E.Transiciones = setTranciciones(T);
				EstadosR.Add(E);

				AuxEstados = getListas(T);
				foreach (var item in AuxEstados)
					Ecloshure(item);
			}
		}
		public List<string[]> getTablaFLN()
		{ return RowFLN; }
		public List<string[]> getTablaFollow()
		{
			foreach (var item in Follow)
			{
				string f = "";
				foreach (var item_ in item.Value)
					f += item_ + ", ";
				string[] row = new string[] { item.Key.ToString(), f};
				RowFollow.Add(row);
			}
			return RowFollow; 
		}
		public List<string[]> getTablaEstados()
		{
			foreach (var item in Estados)
			{
				string[] row = new string[ST.Count() + 1];
				row[0] = item.Key;
				for (int i = 1; i < ST.Count() + 1; i++)
				{
					if (item.Value[i - 1] == null)
						row[i] = "---";
					else
						row[i] = item.Value[i - 1];
				}
				RowEstados.Add(row);
			}
			return RowEstados;
		}
		public List<string> getColumnas()
		{
			return ST;
		}
		private int getIndex(string value)
		{
			for (int i = 0; i < ST.Count(); i++)
			{
				if (ST[i] == value)
					return i;
			}
			return -1;
		}
		private List<List<int>> getListas(string [] Columnas)
		{
			List<List<int>> Retorno = new List<List<int>>();
			foreach (string item in Columnas)
			{
				if (item != null)
				{
					List<int> Colum = new List<int>();
					string NS = item.Replace(" ", "");
					string[] C = NS.Split(',');
					foreach (var item2 in C)
					{
						if (item2.Length > 0)
							Colum.Add(int.Parse(item2));
					}
					Colum.Sort();
					Retorno.Add(Colum);
				}
			}
			return Retorno;
		}
		public Dictionary<string, string[]> getEstados()
		{
			return Estados;
		}
		private Dictionary<string, string> setTranciciones(string[] E)
		{
			Dictionary<string, string> T = new Dictionary<string, string>();
			for (int i = 0; i < E.Length; i++)
			{
				if (E[i] != null)
				{
					T.Add(ST[i], E[i]);
				}
			}
			return T;
		}
		public string getInicial()
		{
			return EstadoInicial;
		}
		public List<Estado> returnEstados()
		{
			return EstadosR;
		}
		public List<string> getEAceptacion()
		{
			return EAceptacion;
		}
		private string UFollow()
		{
			string U = "";
			foreach (var item in Follow)
			{
				if (item.Value.Count == 0)
				{
					U = item.Key.ToString();
				}
			}
			return U;
		}
		private void AsignarEA()
		{
			foreach (var item in EstadosR)
			{
				string[] P = item.ID.Split(',');
				foreach (var item2 in P)
				{
					string IT = item2;
					IT = IT.Replace(" ", "");
					if (IT == UF)
						EAceptacion.Add(item.ID);
				}
			}
		}
		private void AsignarToken(Nodo Arbol)
		{
			foreach (var item in ListaTokens)
			{
				int cantItems = revisarER(item.ER);
				int P = 0;
				PonerToken(Arbol, ref P, cantItems, item.ID);
			}
		}
		private int revisarER(string linea)
		{
			int cant = 0;
			List<string> PalabrasReservadas = new List<string>();
			foreach (var item in ListaSETS)
			{
				PalabrasReservadas.Add(item.ID);
			}
			PalabrasReservadas.Add("RESERVADAS");
			string palabra = "";

			for (int i = 0; i < linea.Length; i++)
			{
				if (linea[i] == '\'' && linea[i + 2] == '\'')
				{
					if (linea[i + 1] == '*' || linea[i + 1] == '|' || linea[i + 1] == '?' || linea[i + 1] == '+' || linea[i + 1] == ')' || linea[i + 1] == '(' || linea[i + 1] == '.' || linea[i + 1] == '<')
						cant++;
					else
						cant++;
					
					i += 2;
				}
				else if (linea[i] == '{' && linea[i + 1] == 'R' && linea[i + 12] == ')' && linea[i + 13] == '}')
				{ i += 13; }
				else if (Char.IsLetter(linea[i]))
				{
					if (Char.IsUpper(linea[i]))
					{
						palabra += linea[i];
					}
					if (palabra.Length <= 10 && PalabrasReservadas.Contains(palabra))
					{
						if (palabra == "RESERVADAS" && linea[i + 1] == '(' && linea[i + 2] == ')')
							i += 2;
						else
							cant++;
						
						palabra = "";
					}
				}
			}
			return cant;
		}
		private bool PonerToken(Nodo Nodo, ref int I, int Cant, int ID)
		{
			if (I == Cant)
				return true;

			if (Nodo.Izquierdo != null)
				PonerToken(Nodo.Izquierdo, ref I, Cant, ID);

			if (Nodo.Izquierdo == null && Nodo.Derecho == null && Nodo.TokenID == -1)
			{
				Nodo.TokenID = ID;
				I++;
			}

			if (Nodo.Derecho != null)
				PonerToken(Nodo.Derecho, ref I, Cant, ID);

			return false;
		}
		private void PonerTT()
		{
			var EstadosX = EstadosR;
			EstadosR = new List<Estado>();
			foreach (Estado item in EstadosX)
			{
				item.TokenTransicion = setTokenTransicion(item);
				EstadosR.Add(item);
			}
		}
		private Dictionary<string, string> setTokenTransicion(Estado E)
		{
			E.TokenTransicion = new Dictionary<string, string>();
			string aux = E.ID;
			aux = aux.Replace(" ", "");
			string[] Llaves = aux.Split(',');
			foreach (var item in Llaves)
			{
				string K = "";
				bool B = Follows.TryGetValue(int.Parse(item), out K);
				int TID = BuscarToken(Arbol, int.Parse(item));
				if (B)
				{
					string A = E.getTokenTransicion(K);
					if (E.TokenTransicion.ContainsKey(K))
						E.TokenTransicion[K] = E.TokenTransicion[K] + " " + TID.ToString();
					else
						E.TokenTransicion.Add(K, TID.ToString());
				}
			}
			return E.TokenTransicion;
		}
		private int BuscarToken(Nodo Nodo, int ID)
		{
			int R = -1;
			if (Nodo.Izquierdo != null)
				R = BuscarToken(Nodo.Izquierdo, ID);

			if (Nodo.Izquierdo == null && Nodo.Derecho == null && Nodo.First[0] == ID && Nodo.Last[0] == ID)
				return Nodo.TokenID;

			if (Nodo.Derecho != null && R == -1)
				R = BuscarToken(Nodo.Derecho, ID);

			return R;
		}
		private void  ConseguirHojas(Nodo Nodo, ref Dictionary<string, string> Hojas)
		{
			if (Nodo.Izquierdo != null)
				ConseguirHojas(Nodo.Izquierdo, ref Hojas);

			if (Nodo.Izquierdo == null && Nodo.Derecho == null && Nodo.Last.Count == 1 && Nodo.First.Count == 1)
				Hojas.Add(Nodo.First[0].ToString(), Nodo.Contenido);

			if (Nodo.Derecho != null)
				ConseguirHojas(Nodo.Derecho, ref Hojas);
		}
		public Dictionary<string, string> getMandarHojas()
		{
			return HojasMandar;
		}
	}
}
