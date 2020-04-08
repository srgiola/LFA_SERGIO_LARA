using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFA_Sergio_Lara
{
	class Tablas
	{
		Nodo Arbol = new Nodo();
		List<string[]> RowFLN = new List<string[]>();
		List<string[]> RowFollow = new List<string[]>();
		public Tablas(Nodo Arbol)
		{
			this.Arbol = Arbol;
		}
		public void GenerarTablas()
		{
			int n = 1;
			AsignarHojas(Arbol, ref n);
			AsignarFLN(Arbol);
			AsignarFollow(Arbol);
			LlenarTablaFLN(Arbol);
			LlenarTablaFollow(Arbol);
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
				n++;
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
			
			if (Nodo.Derecho != null)
				LlenarTablaFLN(Nodo.Derecho);
		}
		private void LlenarTablaFollow(Nodo Nodo)
		{
		}
		public List<string[]> getTablaFLN()
		{ return RowFLN; }
		public List<string[]> getTablaFollow()
		{
			return RowFollow; 
		}
	}
}
