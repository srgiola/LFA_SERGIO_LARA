using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFA_Sergio_Lara
{
	class Mensaje
	{
		//Mensaje: texto mostrado al usuario sobre errores en la gramatica ingresada
		public string texto { get; set; }
		public int linea { get; set; }
		public int columna { get; set; }

		public Mensaje(int linea, int columna)
		{
			this.linea = linea;
			this.columna = columna;
		}
	}
}
