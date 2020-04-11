using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFA_Sergio_Lara
{
	class GrafoAB
	{
		private Nodo Arbol = new Nodo();
		public GrafoAB(Nodo Nodo)
		{
			Arbol = Nodo;
		}
		public Bitmap CrearGrafo(string pathApp)
		{
			int n = 0;
			AsignarID(Arbol, ref n);
			Bitmap bm = FileDotEngine.Run(ComandoDot());
			return bm;
		}
		private string ComandoDot()
		{
			StringBuilder b = new StringBuilder();
			StringBuilder c = new StringBuilder();
			Declaraciones(Arbol, ref c);
			b.Append("digraph G {" + Environment.NewLine);
			b.Append(c.ToString() + Environment.NewLine);
			b.Append(DibujarArbol(Arbol));
			b.Append("}");
			return b.ToString();
		}
		private string DibujarArbol(Nodo Nodo)
		{
			StringBuilder b = new StringBuilder();
			if (Nodo.Izquierdo != null)
			{
				string Q0 = Nodo.Contenido;
				string Q1 = Nodo.Izquierdo.Contenido;
				if (Q0[0] == '/')
					Q0 = Q0[1].ToString();
				if (Q1[0] == '/')
					Q1 = Q1[1].ToString();
				if (Q0 == "\"")
					Q0 = "''";
				if (Q1 == "\"")
					Q1 = "''";
				b.AppendFormat("\"{0}\" -> \"{1}\";{2}", (Nodo.ID + "[" + Q0 + "]"), (Nodo.Izquierdo.ID + "[" + Q1 + "]"), Environment.NewLine);
				b.Append(DibujarArbol(Nodo.Izquierdo));
			}

			if (Nodo.Derecho != null)
			{
				string Q0 = Nodo.Contenido;
				string Q1 = Nodo.Derecho.Contenido;
				if (Q0[0] == '/')
					Q0 = Q0[1].ToString();
				if (Q1[0] == '/')
					Q1 = Q1[1].ToString();
				if (Q0 == "\"")
					Q0 = "''";
				if (Q1 == "\"")
					Q1 = "''";
				b.AppendFormat("\"{0}\" -> \"{1}\";{2}", (Nodo.ID + "[" + Q0 + "]"), (Nodo.Derecho.ID + "[" + Q1 + "]"), Environment.NewLine);
				b.Append(DibujarArbol(Nodo.Derecho));
			}
			return b.ToString();
		}
		private void AsignarID(Nodo Nodo, ref int n)
		{
			if (Nodo.Izquierdo != null)
				AsignarID(Nodo.Izquierdo, ref n);
			Nodo.ID = n;
			n++;
			if (Nodo.Derecho != null)
				AsignarID(Nodo.Derecho, ref n);
		}
		private void Declaraciones(Nodo Nodo, ref StringBuilder b)
		{
			if (Nodo.Izquierdo != null)
				Declaraciones(Nodo.Izquierdo, ref b);
			
			string Q0 = Nodo.Contenido;
			if (Q0[0] == '/')
				Q0 = Q0[1].ToString();
			if (Q0 == "\"")
				Q0 = "''";
			b.AppendFormat("\"{0}\";{1}", (Nodo.ID + "[" + Q0 + "]"), Environment.NewLine);

			if (Nodo.Derecho != null)
				Declaraciones(Nodo.Derecho, ref b);
		}
	}
}
