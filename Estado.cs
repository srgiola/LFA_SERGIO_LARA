using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFA_Sergio_Lara
{
	public class Estado
	{
		public string ID { get; set; }
		public Dictionary<string, string> Transiciones { get; set; }
		public string getTransicion(string A)
		{
			string R = "";
			bool B = Transiciones.TryGetValue(A, out R);
			if (B)
				return R;
			else
				return null;
		}
	}
}
