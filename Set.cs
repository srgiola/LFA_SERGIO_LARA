using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFA_Sergio_Lara
{
	public class Set
	{
		public string ID { get; set; }
		public List<Rango> Rangos { get; set; }

		public bool Pertenece(char A)
		{
			foreach (var item in Rangos)
			{
				if (A >= item.Inicio && A <= item.Fin)
					return true;
			}
			return false;
		}
	}
}
