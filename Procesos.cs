using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LFA_Sergio_Lara
{
	class Procesos
	{
		private Nodo ArbolSETS = null;
		private Nodo ArbolTOKENS = null;
		private Nodo ArbolError = null;
		private Nodo ArbolActions = null;
		private List<string> ListaSETS = new List<string>();
		Arbol_ER A = new Arbol_ER();
		private bool TOKENS_ = false;
		private bool ACTIONS_ = false;
		private bool RESERVADAS_ = false;
		private bool ERROR_ = false;
		private int cantTokens = 0;

		public void Inicializar()
		{		
			ArbolSETS = A.Arbol("(<id>.=.(('.<C>.')|(C.H.R./(.<D>./))).(('.<C>.')|(C.H.R./(.<D>./))|(/+.'.<C>.')|(/+.C.H.R./(.<D>./))|(/../..'.<C>.')|(/../..C.H.R./(.<D>./)))*)");
			ArbolTOKENS = A.Arbol("(T.O.K.E.N.<D>.=.<ER>)");
			ArbolError = A.Arbol("(E.R.R.O.R.=.<D>)");
			ArbolActions = A.Arbol("(<PR>./(./).<t>.{.(<t>.<D>.=.'.<PR>.')*.<t>.})");
		}
		public Mensaje AnalisarTexto(string pathArchivo)
		{
			string linea = "";
			bool SETS = false;
			bool TOKENS = false;
			bool ACTIONS = false;
			int LineaError = 0;
			
			//Se lee el archivo linea por linea, Se busca encontrar las palabras SETS, TOKENS, ACTIONS,
			//ERROR y FUNCTION para luego analisar las lineas posteriores individualmente.
			using (var file = new StreamReader(pathArchivo))
			{
				while ((linea = file.ReadLine()) != null)
				{
					LineaError++;
					int espaciosQuitados = 0;
					foreach (char item in linea)
					{
						if (item == ' ')
							espaciosQuitados++;
						if (item == 9)
							espaciosQuitados++;
					}
					linea = linea.Replace(" ", "");
					linea = linea.Replace("	", "");
					if (linea == "SETS")
					{ SETS = true; TOKENS = false; ACTIONS = false; }
					else if (linea == "TOKENS")
					{ SETS = false; TOKENS = true; ACTIONS = false; TOKENS_ = true; }
					else if (linea == "ACTIONS")
					{ SETS = false; TOKENS = false; ACTIONS = true; ACTIONS_ = true; }
					else if (linea.Length >= 7 && linea.Length <= 9 && TOKENS_ && ACTIONS_ && RESERVADAS_)
					{
						try
						{
							if (linea.Substring(0, 5) == "ERROR")
							{
								SETS = false; TOKENS = false; ACTIONS = false;
								ERROR_ = true;
								int Index = 0;
								bool Aceptacion = false;
								string lineaQuitar = "";
								Mensaje Mensaje = RecorrerArbol(ArbolError, ref linea, ref Index, ref Aceptacion, ref LineaError, ref lineaQuitar);
								if (Mensaje != null)
								{
									Mensaje.linea = LineaError;
									return Mensaje; 
								}
							}
						}
						catch { }
					}
					else if (SETS && linea != "\t" && linea != "")
					{
						int Index = 0;
						bool Aceptacion = false;
						string lineaQuitar = "";
						Mensaje Mensaje = RecorrerArbol(ArbolSETS, ref linea, ref Index, ref Aceptacion, ref LineaError, ref lineaQuitar);
						if (Mensaje != null)
						{
							Mensaje.linea = LineaError;
							Mensaje.columna = Mensaje.columna + espaciosQuitados;
							return Mensaje;
						}
						if (Mensaje == null)
							ListaSETS.Add(getIDSet(linea));
					}
					else if (TOKENS && linea != "\t" && linea != "")
					{
						int Index = 0;
						bool Aceptacion = false;
						string lineaQuitar = "";
						Mensaje Mensaje = RecorrerArbol(ArbolTOKENS, ref linea, ref Index, ref Aceptacion, ref LineaError, ref lineaQuitar);
						if (Mensaje != null)
						{
							Mensaje.linea = LineaError;
							Mensaje.columna = Mensaje.columna + espaciosQuitados;
							return Mensaje;
						}
						cantTokens++;
					}
					else if (ACTIONS && linea != "")
					{
						Mensaje Mensaje = null;
						string ActionString = linea + "t";
						int auxContador = 0;
						while ((linea = file.ReadLine()) != null)
						{
							auxContador++;
							int espaciosQuitados2 = 0;
							foreach (char item in linea)
							{
								if (item == ' ')
									espaciosQuitados2++;
								if (item == 9)
									espaciosQuitados2++;
							}
							linea = linea.Replace(" ", "");
							linea = linea.Replace("	", "");

							if (linea == "\t" || linea == "") { }
							else
							{
								if (linea == "}")
								{
									ActionString += "}";
									bool Aceptacion = false;
									int Index = 0;
									string lineaQuitar = "";
									Mensaje = RecorrerArbol(ArbolActions, ref ActionString, ref Index, ref Aceptacion, ref LineaError, ref lineaQuitar);
									break;
								}
								else
									ActionString += linea + "t";
							}
							try
							{
								if (linea.Substring(0, 5) == "ERROR")
								{
									Mensaje = new Mensaje(LineaError + auxContador - 2, 0);
									Mensaje.texto = "Posible solucion: Se esperaba }";
									return Mensaje;
								}
							}
							catch { }
						}
						if (Mensaje != null)
						{
							Mensaje.linea = LineaError - 1;
							Mensaje.columna = Mensaje.columna + espaciosQuitados;
							return Mensaje;
						}
					}
					else if (linea.ToUpper() == "TOKENS" || linea.ToUpper() == "SETS" || linea.ToUpper() == "ACTIONS")
					{
						Mensaje Mensaje = null;
						try
						{
							if (linea.Substring(0, 5).ToUpper() == "ERROR")
							{
								Mensaje = new Mensaje(LineaError, 1);
								Mensaje.texto = "Posible solucion: El identificador debe ser escrito en Mayusculas";
								return Mensaje;
							}
						}
						catch { }
						Mensaje = new Mensaje(LineaError, 1);
						Mensaje.texto = "Posible solucion: El identificador debe ser escrito en Mayusculas";
						return Mensaje;
					}
					else
					{
						if (linea == "" || linea.Length <= 0)
						{ }
						else
						{
							Mensaje Mensaje = new Mensaje(LineaError, 1);
							Mensaje.texto = "Posible error: Identificador/Operador erroneo";
							return Mensaje;
						}
					}
				}
			}

			Mensaje MensajeR = new Mensaje(LineaError, 0);
			if (!TOKENS_ || cantTokens < 1)
			{
				MensajeR.texto = "No se han declarado correctamente y/o no existen TOKENS";
				return MensajeR;
			}
			if (!ACTIONS_)
			{
				MensajeR.texto = "No se han declarado correctamente y/o no existen ACTIONS";
				return MensajeR;
			}
			if (!RESERVADAS_)
			{
				MensajeR.texto = "No se han declarado correctamente y/o no existe RESERVADAS()";
				return MensajeR;
			}
			return null; //Si el Mensaje es "nulo" no hubo errores en la sitaxis
		}
		
		private Mensaje RecorrerArbol(Nodo Nodo, ref string linea, ref int Index, ref bool Aceptacion, ref int lineaError, ref string lineaQuitar, Mensaje Mensaje = null)
		{
			if (Nodo.Contenido == "|" || Nodo.Contenido == "*")
			{
				if (Aceptacion)
				{
					lineaQuitar = "";
				}
			}

			if (Nodo.Izquierdo != null)
				Mensaje = RecorrerArbol(Nodo.Izquierdo, ref linea, ref Index, ref Aceptacion, ref lineaError, ref lineaQuitar, Mensaje);

			try
			{
				if (Nodo.Contenido == "<id>")
				{
					string palabra = "";
					string ID = "";
					//Se comprueba si existe un ID
					foreach (char item in linea)
					{
						palabra += item;

						if (palabra.Length > 2 && item == '\'' && !palabra.Contains('='))
						{
							//No hay simbolo igual pero si nombre
							Mensaje = new Mensaje(1, palabra.Length);
							Mensaje.texto = "Posible solucion: Se esperaba =";
							Aceptacion = false;
						}
						if (palabra.Length == 1 && item == '=')
						{
							//No hay nombre del identificador
							Mensaje = new Mensaje(1, 1);
							Mensaje.texto = "Posible solucion: Se esperaba un Identificador";
							Aceptacion = false;
						}
					}
					//Se guarda el ID
					foreach (char item in linea)
					{
						if (item == '=')
							break;
						else
							ID += item;
					}
					//Es verdadero si contiene alguna letra minuscula
					if (ID.Any(x => char.IsLower(x)))
					{
						Mensaje = new Mensaje(1, ID.Length);
						Mensaje.texto = "Posible error: Identificador invalido";
						Aceptacion = false;
						return Mensaje;
					}
					Index += ID.Length;
					linea = linea.Substring(ID.Length, (linea.Length - ID.Length));
					Aceptacion = true;
				}
				else if (Nodo.Contenido == "<C>")
				{
					if (Nodo.Contenido == "'")
					{ 
						Mensaje = new Mensaje(1, Index);
					}
					else
					{
						Index++;
						lineaQuitar += linea.Substring(0, 1);
						linea = linea.Substring(1, linea.Length - 1);
						Aceptacion = true;
						Mensaje = null;
					}
				}
				else if (Nodo.Contenido == "<D>")
				{
					try
					{
						if (linea.Substring(0, 3).All(o => char.IsDigit(o)))
						{
							Index += 3;
							lineaQuitar += linea.Substring(0, 3);
							linea = linea.Substring(3, linea.Length - 3);
							Aceptacion = true;
							Mensaje = null;
						}
						else if (linea.Substring(0, 2).All(o => char.IsDigit(o)))
						{
							Index += 2;
							lineaQuitar += linea.Substring(0, 2);
							linea = linea.Substring(2, linea.Length - 2);
							Aceptacion = true;
							Mensaje = null;
						}
						else if (linea.Substring(0, 1).All(o => char.IsDigit(o)))
						{
							Index += 1;
							lineaQuitar += linea.Substring(0, 1);
							linea = linea.Substring(1, linea.Length - 1);
							Aceptacion = true;
							Mensaje = null;
						}
						else
						{
							Mensaje = new Mensaje(1, Index);
							Mensaje.texto = "Posible solucion: Se esperaba Numero";
							return Mensaje;
						}
					}
					catch
					{
						if (linea.Substring(0, 2).All(o => char.IsDigit(o)))
						{
							Index += 2;
							lineaQuitar += linea.Substring(0, 2);
							linea = linea.Substring(2, linea.Length - 2);
							Aceptacion = true;
							Mensaje = null;
						}
						else if (linea.Substring(0, 1).All(o => char.IsDigit(o)))
						{
							Index += 1;
							lineaQuitar += linea.Substring(0, 1);
							linea = linea.Substring(1, linea.Length - 1);
							Aceptacion = true;
							Mensaje = null;
						}
						else
						{
							Mensaje = new Mensaje(1, Index);
							Mensaje.texto = "Posible solucion: Se esperaba Numero";
							return Mensaje;
						}
					}
				}
				else if (Nodo.Contenido == "<ER>")
				{
					Mensaje = AnalizarER(linea);
					if (Mensaje != null)
					{
						Mensaje.columna = Mensaje.columna + Index;
						Aceptacion = false;
					}
					else
						Aceptacion = true;
				}
				else if (Nodo.Contenido == "<PR>")
				{
					if (!Char.IsUpper(linea[0]))
					{
						Mensaje = new Mensaje(lineaError, Index);
						Mensaje.texto = "Posible solucion: Se esperaba letra Mayuscula";
						Aceptacion = false;
						return Mensaje;
					}
					else
					{
						string PalabraReservada = "";
						while (Char.IsUpper(linea[0]))
						{
							PalabraReservada += linea[0];
							lineaQuitar += linea.Substring(0, 1);
							linea = linea.Substring(1, linea.Length - 1);
							Index++;
						}
						if (PalabraReservada == "RESERVADAS" && linea[0] == '(' && linea[1] == ')')
							RESERVADAS_ = true;
						Aceptacion = true;
					}
				}
				else if (Nodo.Contenido == "<t>")
				{
					if (Aceptacion)
						lineaQuitar = "";
					if (linea[0] == 't')
					{
						Index = 0;
						lineaError++;
						lineaQuitar += linea.Substring(0, 1);
						linea = linea.Substring(1, linea.Length - 1);
						Aceptacion = true;
					}
					else
					{
						Mensaje = new Mensaje(lineaError, Index);
						Mensaje.texto = "Las palabra reservadas deben estar declaradas en diferente linea";
						Aceptacion = false;
						return Mensaje;
					}
				}
				else if (Nodo.Contenido == "." || Nodo.Contenido == "#")
				{
					if (!Aceptacion && Nodo.Contenido == ".")
					{
						linea = lineaQuitar + linea;
						lineaQuitar = "";
						goto SaltarDerecho; 
					}
				}
				else if (Nodo.Contenido == "|")
				{
					if (Aceptacion)
					{
						lineaQuitar = "";
						goto SaltarDerecho;
					}
					else
					{
						linea = lineaQuitar + linea;
						lineaQuitar = "";
					}
				}
				else if (Nodo.Contenido == "*")
				{
					//Aceptacion = true;
					while (Aceptacion && linea.Length > 0)
					{
						//Aceptacion = false;
						Mensaje = RecorrerArbol(Nodo.Izquierdo, ref linea, ref Index, ref Aceptacion, ref lineaError, ref lineaQuitar, Mensaje);
					}
					if (!Aceptacion && linea.Length > 0) { Aceptacion = true; }
					//Mensaje = null;  // Se mete aca ya que ningun sub-arbol hizo match con la linea
					if (linea.Length == 0 && Aceptacion == false) { }
					else if (linea.Length == 0)
						Mensaje = null;
				}
				else if (Nodo.Contenido == "+")
				{
					//Aceptacion = true;
					while (Aceptacion && linea.Length > 0)
					{
						Aceptacion = false;
						Mensaje = RecorrerArbol(Nodo.Izquierdo, ref linea, ref Index, ref Aceptacion, ref lineaError, ref lineaQuitar, Mensaje);
					}
					if (!Aceptacion && linea.Length > 0) { Aceptacion = true; }
					//Mensaje = null;  // Se mete aca ya que ningun sub-arbol hizo match con la linea
					if (linea.Length == 0 && Aceptacion == false) { }
					else if (linea.Length == 0)
						Mensaje = null;
				}
				else if (Nodo.Contenido[0] == '/' && linea[0] == Nodo.Contenido[1])
				{
					Index++;
					lineaQuitar += linea.Substring(0, 1);
					linea = linea.Substring(1, linea.Length - 1);
					Aceptacion = true;
					Mensaje = null;
				}
				else if (Nodo.Contenido[0] == '/' && linea[0] != Nodo.Contenido[1])
				{
					Mensaje = new Mensaje(1, Index);
					Mensaje.texto = "Posible solucion: Se esperaba " + Nodo.Contenido[1];
					Aceptacion = false;
					return Mensaje;
				}
				else if (Nodo.Contenido != linea[0].ToString())
				{
					Mensaje = new Mensaje(1, Index);
					Mensaje.texto = "Posible solucion: Se esperaba " + Nodo.Contenido;
					Aceptacion = false;
					return Mensaje;
				}
				else if (Nodo.Contenido == linea[0].ToString())
				{
					Index++;
					lineaQuitar += linea.Substring(0, 1);
					linea = linea.Substring(1, linea.Length - 1);
					Aceptacion = true;
					Mensaje = null;
				}
			}
			catch { Mensaje = new Mensaje(1, Index); Aceptacion = false; }
			
			if (Nodo.Derecho != null)
				Mensaje = RecorrerArbol(Nodo.Derecho, ref linea, ref Index, ref Aceptacion, ref lineaError, ref lineaQuitar, Mensaje);
			SaltarDerecho:
			return Mensaje;
		}

		public string getIDSet(string linea)
		{
			string ID = "";
			
			//Se guarda el ID
			foreach (char item in linea)
			{
				if (item == '=')
					break;
				else
					ID += item;
			}
			return ID;
		}

		public Mensaje AnalizarER(string linea)
		{
			Mensaje Mensaje = null;
			List<string> PalabrasReservadas = new List<string>();
			PalabrasReservadas.Add("CHARSET");
			PalabrasReservadas.Add("DIGITO");
			PalabrasReservadas.Add("LETRA");
			PalabrasReservadas.Add("RESERVADAS");
			string palabra = "";
			string ER = "";

			for (int i = 0; i < linea.Length; i++)
			{
				try
				{
					if (linea[i] == '\'' && linea[i + 2] == '\'')
					{
						if (linea[i + 1] == '*' || linea[i + 1] == '|' || linea[i + 1] == '?' || linea[i + 1] == '+' || linea[i + 1] == ')' || linea[i + 1] == '(' || linea[i + 1] == '.' || linea[i + 1] == '<')
							ER += "/" + linea[i + 1];
						else
							ER += linea[i + 1];
						try
						{
							if (linea[i + 3] != ')' && linea[i + 3] != '|')
								ER += '.';
						}
						catch { }
						i += 2;
					}
					else if (Char.IsLetter(linea[i]))
					{
						if (Char.IsLower(linea[i]))
							Mensaje = new Mensaje(1, i);
						if (Char.IsUpper(linea[i]))
						{
							palabra += linea[i];
						}
						if (palabra.Length <= 10 && PalabrasReservadas.Contains(palabra))
						{
							if (palabra == "RESERVADAS" && linea[i + 1] == '(' && linea[i + 2] == ')')
							{
								ER += "<" + palabra + ">";
								i += 2;
							}
							else
								ER += "<" + palabra + ">";
							try
							{
								if (linea[i + 1] != ')' && linea[i + 1] != '|' && linea[i + 1] != '*' && linea[i + 1] != '+' && linea[i + 1] != '?')
									ER += '.';
							}
							catch { }
							palabra = "";
						}
						if (palabra.Length >= 10 && !PalabrasReservadas.Contains(palabra))
						{
							Mensaje = new Mensaje(1, (i - palabra.Length + 1));
							return Mensaje;
						}
					}
					else
					{
						char tmp = linea[i];
						if (linea[i] == '\'')
						{
							Mensaje = new Mensaje(1, i);
							return Mensaje;
						}
						else
							ER += linea[i];
						try
						{
							if (linea[i] == '|' || linea[i] == '(' || linea[i] == ')') { }
							else if (linea[i + 1] != ')' && linea[i + 1] != '|')
								ER += '.';
						}
						catch { }
					}
				}
				catch 
				{
					Mensaje = new Mensaje(1, i);
					return Mensaje;
				}
			}
			ER = "(" + ER + ")";
			Nodo ArbolToken = A.Arbol(ER);
			if (ArbolToken.Contenido.Length > 1)
			{
				Mensaje = new Mensaje(1, 0);
				string[] tmp = ArbolToken.Contenido.Split('|');
				Mensaje.columna = Convert.ToInt32(tmp[1]);
				Mensaje.texto = "Posible error: " + tmp[0];
				return Mensaje;
			}
			else
				return null;
		}

		public void SETS()
		{
			
		}
	}
}
