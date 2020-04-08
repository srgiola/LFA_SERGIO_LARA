using System;
using System.Collections.Generic;

namespace LFA_Sergio_Lara
{
	public class Nodo
	{
		public string Contenido { get; set; }
		public Nodo Izquierdo { get; set; }
		public Nodo Derecho { get; set; }
		public List<int> First { get; set; }
		public List<int> Last { get; set; }
		public bool Nullable { get; set; }
		public List<int> Follow { get; set; }
	}
}
