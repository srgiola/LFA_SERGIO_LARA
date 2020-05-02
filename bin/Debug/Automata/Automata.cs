using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Automata
{
class Automata
{
List<Set> ListaSets = new List<Set>();
List<Token> ListaTokens = new List<Token>();
List<Action> ListaActions = new List<Action>();
List<string> ST = new List<string>();
Dictionary<string, Estado> Estados = new Dictionary<string, Estado>();
string EstadoInicial;
List<string> EAceptacion = new List<string>();
int ERROR;
private void Inicializar()
{
ERROR = 54;
//------------------------ SETS ----------------------------------
Set S0 = new Set();
S0.ID = "LETRA";
S0.Rangos = new List<Rango>();
Rango R0 = new Rango();
R0.Inicio = 65;
R0.Fin = 90;
S0.Rangos.Add(R0);
Rango R1 = new Rango();
R1.Inicio = 97;
R1.Fin = 122;
S0.Rangos.Add(R1);
Rango R2 = new Rango();
R2.Inicio = 95;
R2.Fin = 95;
S0.Rangos.Add(R2);
ListaSets.Add(S0);
Set S1 = new Set();
S1.ID = "DIGITO";
S1.Rangos = new List<Rango>();
Rango R3 = new Rango();
R3.Inicio = 48;
R3.Fin = 57;
S1.Rangos.Add(R3);
ListaSets.Add(S1);
Set S2 = new Set();
S2.ID = "CHARSET";
S2.Rangos = new List<Rango>();
Rango R4 = new Rango();
R4.Inicio = 32;
R4.Fin = 254;
S2.Rangos.Add(R4);
ListaSets.Add(S2);
//------------------------ TOKENS --------------------------------
Token T0 = new Token();
T0.ID = 2;
T0.ER = "'\"'CHARSET'\"'|'''CHARSET'''";
ListaTokens.Add(T0);
Token T1 = new Token();
T1.ID = 5;
T1.ER = "'<''>'";
ListaTokens.Add(T1);
Token T2 = new Token();
T2.ID = 6;
T2.ER = "'<'";
ListaTokens.Add(T2);
Token T3 = new Token();
T3.ID = 7;
T3.ER = "'>'";
ListaTokens.Add(T3);
Token T4 = new Token();
T4.ID = 8;
T4.ER = "'>''='";
ListaTokens.Add(T4);
Token T5 = new Token();
T5.ID = 9;
T5.ER = "'<''='";
ListaTokens.Add(T5);
Token T6 = new Token();
T6.ID = 13;
T6.ER = "'*'";
ListaTokens.Add(T6);
Token T7 = new Token();
T7.ID = 40;
T7.ER = "'(''*'";
ListaTokens.Add(T7);
Token T8 = new Token();
T8.ID = 41;
T8.ER = "'*'')'";
ListaTokens.Add(T8);
Token T9 = new Token();
T9.ID = 42;
T9.ER = "';'";
ListaTokens.Add(T9);
Token T10 = new Token();
T10.ID = 43;
T10.ER = "'.'";
ListaTokens.Add(T10);
Token T11 = new Token();
T11.ID = 50;
T11.ER = "'.''.'";
ListaTokens.Add(T11);
Token T12 = new Token();
T12.ID = 51;
T12.ER = "':'";
ListaTokens.Add(T12);
Token T13 = new Token();
T13.ID = 53;
T13.ER = "':''='";
ListaTokens.Add(T13);
Token T14 = new Token();
T14.ID = 3;
T14.ER = "LETRA(LETRA|DIGITO)*{RESERVADAS()}";
ListaTokens.Add(T14);
//------------------------ ACTIONS --------------------------------
Action A0 = new Action();
A0.ID = "RESERVADAS()";
A0.Actions = new Dictionary<string, int>();
A0.Actions.Add("PROGRAM", 18);
A0.Actions.Add("INCLUDE", 19);
A0.Actions.Add("CONST", 20);
A0.Actions.Add("TYPE", 21);
A0.Actions.Add("VAR", 22);
A0.Actions.Add("RECORD", 23);
A0.Actions.Add("ARRAY", 24);
A0.Actions.Add("OF", 25);
A0.Actions.Add("PROCEDURE", 26);
A0.Actions.Add("FUNCTION", 27);
A0.Actions.Add("IF", 28);
A0.Actions.Add("THEN", 29);
A0.Actions.Add("ELSE", 30);
A0.Actions.Add("FOR", 31);
A0.Actions.Add("TO", 32);
A0.Actions.Add("WHILE", 33);
A0.Actions.Add("DO", 34);
A0.Actions.Add("EXIT", 35);
A0.Actions.Add("END", 36);
A0.Actions.Add("CASE", 37);
A0.Actions.Add("BREAK", 38);
A0.Actions.Add("DOWNTO", 39);
ListaActions.Add(A0);
//------------------------ ESTADOS --------------------------------
EstadoInicial = "1, 4, 7, 9, 10, 11, 13, 15, 16, 18, 20, 21, 22, 24, 25, 27";
EAceptacion.Add("30");EAceptacion.Add("8, 14, 30");EAceptacion.Add("12, 30");EAceptacion.Add("19, 30");EAceptacion.Add("23, 30");EAceptacion.Add("26, 30");EAceptacion.Add("28, 29, 30");Estado E0= new Estado();
E0.ID = "1, 4, 7, 9, 10, 11, 13, 15, 16, 18, 20, 21, 22, 24, 25, 27";
E0.Transiciones = new Dictionary<string, string>();
E0.TokenTransicion = new Dictionary<string, string>();
E0.Transiciones.Add("\"", "2");
E0.Transiciones.Add("'", "5");
E0.Transiciones.Add("<", "8, 14, 30");
E0.Transiciones.Add(">", "12, 30");
E0.Transiciones.Add("*", "19, 30");
E0.Transiciones.Add("(", "17");
E0.Transiciones.Add(";", "30");
E0.Transiciones.Add(".", "23, 30");
E0.Transiciones.Add(":", "26, 30");
E0.Transiciones.Add("<LETRA>", "28, 29, 30");
E0.TokenTransicion.Add("\"", "2");
E0.TokenTransicion.Add("'", "2");
E0.TokenTransicion.Add("<", "5 6 9");
E0.TokenTransicion.Add(">", "7 8");
E0.TokenTransicion.Add("*", "13 41");
E0.TokenTransicion.Add("(", "40");
E0.TokenTransicion.Add(";", "42");
E0.TokenTransicion.Add(".", "43 50");
E0.TokenTransicion.Add(":", "51 53");
E0.TokenTransicion.Add("<LETRA>", "3");
Estados.Add("1, 4, 7, 9, 10, 11, 13, 15, 16, 18, 20, 21, 22, 24, 25, 27", E0);
Estado E1= new Estado();
E1.ID = "2";
E1.Transiciones = new Dictionary<string, string>();
E1.TokenTransicion = new Dictionary<string, string>();
E1.Transiciones.Add("<CHARSET>", "3");
E1.TokenTransicion.Add("<CHARSET>", "2");
Estados.Add("2", E1);
Estado E2= new Estado();
E2.ID = "3";
E2.Transiciones = new Dictionary<string, string>();
E2.TokenTransicion = new Dictionary<string, string>();
E2.Transiciones.Add("\"", "30");
E2.TokenTransicion.Add("\"", "2");
Estados.Add("3", E2);
Estado E3= new Estado();
E3.ID = "30";
E3.Transiciones = new Dictionary<string, string>();
E3.TokenTransicion = new Dictionary<string, string>();
E3.TokenTransicion.Add("#", "-1");
Estados.Add("30", E3);
Estado E4= new Estado();
E4.ID = "5";
E4.Transiciones = new Dictionary<string, string>();
E4.TokenTransicion = new Dictionary<string, string>();
E4.Transiciones.Add("<CHARSET>", "6");
E4.TokenTransicion.Add("<CHARSET>", "2");
Estados.Add("5", E4);
Estado E5= new Estado();
E5.ID = "6";
E5.Transiciones = new Dictionary<string, string>();
E5.TokenTransicion = new Dictionary<string, string>();
E5.Transiciones.Add("'", "30");
E5.TokenTransicion.Add("'", "2");
Estados.Add("6", E5);
Estado E6= new Estado();
E6.ID = "8, 14, 30";
E6.Transiciones = new Dictionary<string, string>();
E6.TokenTransicion = new Dictionary<string, string>();
E6.Transiciones.Add(">", "30");
E6.Transiciones.Add("=", "30");
E6.TokenTransicion.Add(">", "5");
E6.TokenTransicion.Add("=", "9");
E6.TokenTransicion.Add("#", "-1");
Estados.Add("8, 14, 30", E6);
Estado E7= new Estado();
E7.ID = "12, 30";
E7.Transiciones = new Dictionary<string, string>();
E7.TokenTransicion = new Dictionary<string, string>();
E7.Transiciones.Add("=", "30");
E7.TokenTransicion.Add("=", "8");
E7.TokenTransicion.Add("#", "-1");
Estados.Add("12, 30", E7);
Estado E8= new Estado();
E8.ID = "19, 30";
E8.Transiciones = new Dictionary<string, string>();
E8.TokenTransicion = new Dictionary<string, string>();
E8.Transiciones.Add(")", "30");
E8.TokenTransicion.Add(")", "41");
E8.TokenTransicion.Add("#", "-1");
Estados.Add("19, 30", E8);
Estado E9= new Estado();
E9.ID = "17";
E9.Transiciones = new Dictionary<string, string>();
E9.TokenTransicion = new Dictionary<string, string>();
E9.Transiciones.Add("*", "30");
E9.TokenTransicion.Add("*", "40");
Estados.Add("17", E9);
Estado E10= new Estado();
E10.ID = "23, 30";
E10.Transiciones = new Dictionary<string, string>();
E10.TokenTransicion = new Dictionary<string, string>();
E10.Transiciones.Add(".", "30");
E10.TokenTransicion.Add(".", "50");
E10.TokenTransicion.Add("#", "-1");
Estados.Add("23, 30", E10);
Estado E11= new Estado();
E11.ID = "26, 30";
E11.Transiciones = new Dictionary<string, string>();
E11.TokenTransicion = new Dictionary<string, string>();
E11.Transiciones.Add("=", "30");
E11.TokenTransicion.Add("=", "53");
E11.TokenTransicion.Add("#", "-1");
Estados.Add("26, 30", E11);
Estado E12= new Estado();
E12.ID = "28, 29, 30";
E12.Transiciones = new Dictionary<string, string>();
E12.TokenTransicion = new Dictionary<string, string>();
E12.Transiciones.Add("<LETRA>", "28, 29, 30");
E12.Transiciones.Add("<DIGITO>", "28, 29, 30");
E12.TokenTransicion.Add("<LETRA>", "3");
E12.TokenTransicion.Add("<DIGITO>", "3");
E12.TokenTransicion.Add("#", "-1");
Estados.Add("28, 29, 30", E12);
}
public List<string> Analizar(string cadena)
{
string cadena2 = "";
Inicializar();
List<string> Retorno = new List<string>();
string[] A = cadena.Split(' ');
foreach (var item in A)
{
List<string> R = AnalizarActions(item);
if (R.Count > 0) { Retorno.AddRange(R); }
else { cadena2 += item + " "; }
}
if (cadena2.Length > 0) { cadena2 = cadena2.Substring(0, cadena2.Length - 1); } 
while (cadena2.Length > 0)
{
string AB = "";
Analizador(ref cadena2, EstadoInicial, cadena2[0].ToString(), ref Retorno, ref AB, false, "-1");
}
return Retorno;
}
public List<string> AnalizarActions (string A)
{
A = A.ToUpper();
List<string> Retorno = new List<string>();
foreach (var item in ListaActions)
{
int R = 0;
bool B = item.Actions.TryGetValue(A, out R);
if (B)
{ Retorno.Add((A + " = " + R)); }
}
return Retorno;
}
public bool Analizador (ref string A, string E, string Tk, ref List<string> L, ref string AB, bool W, string Token)
{
Estado T;
if (E == null) { return false; }
bool B = Estados.TryGetValue(E, out T);
string ENuevo = "";
if (Tk.Length <= 0) { ENuevo = null; }
else
{
ENuevo = T.getTrancicion(Tk);
string A2 = A;
string AB2 = "";
bool Work = false;
try { A2 = A2.Substring(1, A2.Length - 1); } catch { }
if(A2.Length > 0) { Work = Analizador(ref A2, ENuevo, A2[0].ToString(), ref L, ref AB2, true, Token); }
else { Work = Analizador(ref A2, ENuevo, "", ref L, ref AB2, true, Token); }
if (ENuevo == null || !Work)
{
foreach (var item in ListaSets)
{
if (item.Pertenece(Tk[0]) && Tk.Length == 1)
{
Tk = "<" + item.ID + ">";
ENuevo = T.getTrancicion(Tk);
break;
}
}
}
}
if (ENuevo != null)
{
Token = T.getTokenTransicion(Tk);
try { AB += A.Substring(0, 1); A = A.Substring(1, A.Length - 1); } catch { }
if (A.Length > 0) { return Analizador(ref A, ENuevo, A[0].ToString(), ref L, ref AB, W, Token); }
else { return Analizador(ref A, ENuevo, "", ref L, ref AB, W, Token); }
}
else
{
if (EAceptacion.Contains(E))
{
if (!W)
{
L.Add(AB + "=" + Token);
AB = "";
}
return true;
}
else
{
if(A.Length > 0) { AB += A.Substring(0, 1); A = A.Substring(1, A.Length - 1); }
if (!W)
{
if(AB == " ") { L.Add(AB); }
else { L.Add(AB + " = ERROR " + ERROR); }
AB = "";
}
return false;
}
}
}
}
class Action
{
public string ID {get; set;}
public Dictionary<string, int> Actions {get; set;}
}
class Rango
{
public int Inicio {get; set;}
public int Fin {get; set;}
}
class Set
{
public string ID {get; set;}
public List<Rango> Rangos {get; set;}
public bool Pertenece (char A)
{
foreach (var item in Rangos)
{
if(A >= item.Inicio && A <= item.Fin)
{ return true; }
}
return false;
}
}
class Token
{
public int ID {get; set;}
public string ER {get; set;}
}
class Estado
{
public string ID {get; set;}
public Dictionary<string, string> Transiciones {get; set;}
public Dictionary<string, string> TokenTransicion {get; set;}
public string getTrancicion (string A)
{
string R = "";
bool B = Transiciones.TryGetValue(A, out R);
if(B){ return R; }
else
{ return null; }
}
public string getTokenTransicion (string A)
{
string R = "";
bool B = TokenTransicion.TryGetValue(A, out R);
if(B){ return R; }
else
{ return null; }
}
}
}
