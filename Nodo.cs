using System;
using System.Collections.Generic;

namespace LFA_Sergio_Lara
{
	class Nodo
	{
		public string Contenido { get; set; }
		public Nodo Izquierdo { get; set; }
		public Nodo Derecho { get; set; }
		public List<int> Firt { get; set; }
		public List<int> Last { get; set; }
		public bool Nullable { get; set; }
	}
}
