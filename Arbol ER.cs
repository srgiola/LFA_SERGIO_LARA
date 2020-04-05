using System;
using System.Collections.Generic;
using System.Linq;

namespace LFA_Sergio_Lara
{
	class Arbol_ER
	{
		List<string> ListaUnarios = new List<string>();
		List<string> ListaNoUnarios = new List<string>();
		Stack<string> PilaTokens = new Stack<string>();
		Stack<Nodo> PilaArboles = new Stack<Nodo>();

		public Nodo Arbol(string ERL)
		{
			List<string> ER = AnalizadorER(ERL);
			ListaUnarios.Add("+");
			ListaUnarios.Add("*");
			ListaUnarios.Add("?");
			ListaNoUnarios.Add(".");
			ListaNoUnarios.Add("(");
			ListaNoUnarios.Add(")");
			ListaNoUnarios.Add("|");
			int Columna = 0;

			foreach (var token in ER)
			{
				Columna++;

				if (!ListaNoUnarios.Contains(token) && !ListaUnarios.Contains(token))
				{
					Nodo Nodo = new Nodo();
					Nodo.Contenido = token;
					Nodo.Izquierdo = null;
					Nodo.Derecho = null;
					PilaArboles.Push(Nodo);
				}
				else if (token == "(")
					PilaTokens.Push(token);
				else if (token == ")")
				{
					while (PilaTokens.Count() > 0 && PilaTokens.First() != "(")
					{
						if (PilaTokens.Count() == 0)
						{
							Nodo Error = new Nodo();
							Error.Contenido = "Existe error, faltan Operandos|" + Columna;
							return Error;
						}
						else if (PilaArboles.Count < 2)
						{
							Nodo Error = new Nodo();
							Error.Contenido = "Existe errorr, faltan Operandos|" + Columna;
							return Error;
						}
						else
						{
							Nodo NodoTemp = new Nodo();
							NodoTemp.Contenido = PilaTokens.Pop();

							NodoTemp.Derecho = PilaArboles.Pop();
							NodoTemp.Izquierdo = PilaArboles.Pop();
							PilaArboles.Push(NodoTemp);
						}
					}
					PilaTokens.Pop();
				}
				else if (ListaUnarios.Contains(token) || ListaNoUnarios.Contains(token))
				{
					if (ListaUnarios.Contains(token))
					{
						Nodo Nodo = new Nodo();
						Nodo.Contenido = token;

						if (PilaArboles.Count < 0)
						{
							Nodo.Contenido = "Error faltan Operandos|" + Columna;
							return Nodo;
						}
						else
						{
							Nodo.Izquierdo = PilaArboles.Pop();
							PilaArboles.Push(Nodo);
						}
					}
					else if (PilaTokens.Count() > 0 && PilaTokens.First() != "(")
					{
						var tokenTemp = PilaTokens.First();
						bool EsMenorPrecedencia = false;
						if (token == "*")
							EsMenorPrecedencia = false;
						else if (token == "." && tokenTemp == "*")
							EsMenorPrecedencia = true;
						else if (token == "|" && (tokenTemp == "*" || tokenTemp == "."))
							EsMenorPrecedencia = true;
						else if (token == tokenTemp)
							EsMenorPrecedencia = true;

						if (EsMenorPrecedencia)
						{
							Nodo NodoTemp = new Nodo();
							NodoTemp.Contenido = PilaTokens.Pop();
							if (PilaArboles.Count() < 2)
							{
								NodoTemp.Contenido = "Existe error, faltan operadores|" + Columna;
								return NodoTemp;
							}
							else
							{
								NodoTemp.Derecho = PilaArboles.Pop();
								NodoTemp.Izquierdo = PilaArboles.Pop();
								PilaArboles.Push(NodoTemp);
							}
						}
					}
					if (ListaNoUnarios.Contains(token))
						PilaTokens.Push(token);
				}
				else
				{
					Nodo Error = new Nodo();
					Error.Contenido = "Existe error, No es token reconocido|" + Columna;
					return Error;
				}
			}
			while (PilaTokens.Count() > 0)
			{
				Nodo NodoTemp = new Nodo();
				NodoTemp.Contenido = PilaTokens.Pop().ToString();

				if (NodoTemp.Contenido == "(")
				{ 
					NodoTemp.Contenido = "Existe error, faltan operandos|" + Columna;
					return NodoTemp;
				}
				else if (PilaArboles.Count() < 2)
				{ 
					NodoTemp.Contenido = "Existe error, faltan operandos|" + Columna;
					return NodoTemp;
				}
				else
				{
					NodoTemp.Derecho = PilaArboles.Pop();
					NodoTemp.Izquierdo = PilaArboles.Pop();
					PilaArboles.Push(NodoTemp);
				}
			}
			if (PilaArboles.Count() != 1)
			{
				Nodo Error = new Nodo();
				Error.Contenido = "Existe error, faltan operandos|" + Columna;
				return Error;
			}

			Nodo NodoRetorno = new Nodo();
			Nodo NodoDerecho = new Nodo();
			NodoDerecho.Contenido = "#";
			NodoRetorno.Contenido = ".";
			NodoRetorno.Izquierdo = PilaArboles.Pop();
			NodoRetorno.Derecho = NodoDerecho;
			return NodoRetorno;
		}

		private List<string> AnalizadorER(string ER)
		{
			List<string> Tokens = new List<string>();
			for (int i = 0; i < ER.Length; i++)
			{
				if (ER[i] == '/')
				{
					Tokens.Add(ER[i].ToString() + ER[i + 1].ToString());
					i++;
				}
				else if (ER[i] == '<')
				{
					string token = "";
					while (ER[i] != '>')
					{
						token += ER[i];
						i++;
					}
					Tokens.Add(token + ">");
				}
				else
					Tokens.Add(ER[i].ToString());
			}
			return Tokens;
		}
	}
}
