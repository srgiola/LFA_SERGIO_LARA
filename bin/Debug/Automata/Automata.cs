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
Dictionary<string, string> Hojas = new Dictionary<string, string>();
string UltimaHoja;
private void Inicializar()
{
ERROR = 54;
//------------------------ SETS ----------------------------------
Set S0 = new Set();
S0.ID = "LETRA";
S0.Rangos = new List<Rango>();
Rango R0 = new Rango();
R0.Inicio = 65;
R0.Fin = 70;
S0.Rangos.Add(R0);
Rango R1 = new Rango();
R1.Inicio = 97;
R1.Fin = 102;
S0.Rangos.Add(R1);
ListaSets.Add(S0);
Set S1 = new Set();
S1.ID = "DIGITO";
S1.Rangos = new List<Rango>();
Rango R2 = new Rango();
R2.Inicio = 48;
R2.Fin = 57;
S1.Rangos.Add(R2);
ListaSets.Add(S1);
//------------------------ TOKENS --------------------------------
Token T0 = new Token();
T0.ID = 1;
T0.ER = "DIGITO'+'DIGITO|DIGITO*|(LETRADIGITO)*";
ListaTokens.Add(T0);
Token T1 = new Token();
T1.ID = 2;
T1.ER = "DIGITO'-'DIGITO";
ListaTokens.Add(T1);
Token T2 = new Token();
T2.ID = 3;
T2.ER = "LETRA*{RESERVADAS()}";
ListaTokens.Add(T2);
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
EstadoInicial = "1, 4, 5, 7, 10, 11";
EAceptacion.Add("1, 4, 5, 7, 10, 11");EAceptacion.Add("2, 4, 8, 11");EAceptacion.Add("4, 11");EAceptacion.Add("11");EAceptacion.Add("6, 10, 11");EAceptacion.Add("5, 11");EAceptacion.Add("10, 11");Estado E0= new Estado();
E0.ID = "1, 4, 5, 7, 10, 11";
E0.Transiciones = new Dictionary<string, string>();
E0.TokenTransicion = new Dictionary<string, string>();
E0.Transiciones.Add("<DIGITO>", "2, 4, 8, 11");
E0.Transiciones.Add("<LETRA>", "6, 10, 11");
E0.TokenTransicion.Add("<DIGITO>", "1 1 2");
E0.TokenTransicion.Add("<LETRA>", "1 3");
E0.TokenTransicion.Add("#", "-1");
Estados.Add("1, 4, 5, 7, 10, 11", E0);
Estado E1= new Estado();
E1.ID = "2, 4, 8, 11";
E1.Transiciones = new Dictionary<string, string>();
E1.TokenTransicion = new Dictionary<string, string>();
E1.Transiciones.Add("<DIGITO>", "4, 11");
E1.Transiciones.Add("+", "3");
E1.Transiciones.Add("-", "9");
E1.TokenTransicion.Add("+", "1");
E1.TokenTransicion.Add("<DIGITO>", "1");
E1.TokenTransicion.Add("-", "2");
E1.TokenTransicion.Add("#", "-1");
Estados.Add("2, 4, 8, 11", E1);
Estado E2= new Estado();
E2.ID = "4, 11";
E2.Transiciones = new Dictionary<string, string>();
E2.TokenTransicion = new Dictionary<string, string>();
E2.Transiciones.Add("<DIGITO>", "4, 11");
E2.TokenTransicion.Add("<DIGITO>", "1");
E2.TokenTransicion.Add("#", "-1");
Estados.Add("4, 11", E2);
Estado E3= new Estado();
E3.ID = "3";
E3.Transiciones = new Dictionary<string, string>();
E3.TokenTransicion = new Dictionary<string, string>();
E3.Transiciones.Add("<DIGITO>", "11");
E3.TokenTransicion.Add("<DIGITO>", "1");
Estados.Add("3", E3);
Estado E4= new Estado();
E4.ID = "11";
E4.Transiciones = new Dictionary<string, string>();
E4.TokenTransicion = new Dictionary<string, string>();
E4.TokenTransicion.Add("#", "-1");
Estados.Add("11", E4);
Estado E5= new Estado();
E5.ID = "9";
E5.Transiciones = new Dictionary<string, string>();
E5.TokenTransicion = new Dictionary<string, string>();
E5.Transiciones.Add("<DIGITO>", "11");
E5.TokenTransicion.Add("<DIGITO>", "2");
Estados.Add("9", E5);
Estado E6= new Estado();
E6.ID = "6, 10, 11";
E6.Transiciones = new Dictionary<string, string>();
E6.TokenTransicion = new Dictionary<string, string>();
E6.Transiciones.Add("<DIGITO>", "5, 11");
E6.Transiciones.Add("<LETRA>", "10, 11");
E6.TokenTransicion.Add("<DIGITO>", "1");
E6.TokenTransicion.Add("<LETRA>", "3");
E6.TokenTransicion.Add("#", "-1");
Estados.Add("6, 10, 11", E6);
Estado E7= new Estado();
E7.ID = "5, 11";
E7.Transiciones = new Dictionary<string, string>();
E7.TokenTransicion = new Dictionary<string, string>();
E7.Transiciones.Add("<LETRA>", "6");
E7.TokenTransicion.Add("<LETRA>", "1");
E7.TokenTransicion.Add("#", "-1");
Estados.Add("5, 11", E7);
Estado E8= new Estado();
E8.ID = "6";
E8.Transiciones = new Dictionary<string, string>();
E8.TokenTransicion = new Dictionary<string, string>();
E8.Transiciones.Add("<DIGITO>", "5, 11");
E8.TokenTransicion.Add("<DIGITO>", "1");
Estados.Add("6", E8);
Estado E9= new Estado();
E9.ID = "10, 11";
E9.Transiciones = new Dictionary<string, string>();
E9.TokenTransicion = new Dictionary<string, string>();
E9.Transiciones.Add("<LETRA>", "10, 11");
E9.TokenTransicion.Add("<LETRA>", "3");
E9.TokenTransicion.Add("#", "-1");
Estados.Add("10, 11", E9);
//------------------------ HOJAS  --------------------------------
//Key Firts y Last  --> Value TokenID
Hojas.Add("1", "1");
Hojas.Add("2", "1");
Hojas.Add("3", "1");
Hojas.Add("4", "1");
Hojas.Add("5", "1");
Hojas.Add("6", "1");
Hojas.Add("7", "2");
Hojas.Add("8", "2");
Hojas.Add("9", "2");
Hojas.Add("10", "3");
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
string LTk = "";
Analizador(ref cadena2, EstadoInicial, cadena2[0].ToString(), ref Retorno, ref AB, false, "-1", LTk);
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
public bool Analizador (ref string A, string E, string Tk, ref List<string> L, ref string AB, bool W, string Token, string LTk)
{
Estado T;
if (E == null) { return false; }
bool B = Estados.TryGetValue(E, out T);
string ENuevo = "";
if (Tk.Length <= 0) { ENuevo = null; }
else
{
LTk = T.ID;
ENuevo = T.getTrancicion(Tk);
string A2 = A;
string AB2 = "";
bool Work = false;
try { A2 = A2.Substring(1, A2.Length - 1); } catch { }
if(A2.Length > 0) { Work = Analizador(ref A2, ENuevo, A2[0].ToString(), ref L, ref AB2, true, Token, LTk); }
else { Work = Analizador(ref A2, ENuevo, "", ref L, ref AB2, true, Token, LTk); }
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
if (A.Length > 0) { return Analizador(ref A, ENuevo, A[0].ToString(), ref L, ref AB, W, Token, LTk); }
else { return Analizador(ref A, ENuevo, "", ref L, ref AB, W, Token, LTk); }
}
else
{
if (EAceptacion.Contains(E) && E != EstadoInicial)
{
if (!W)
{
if (Token.Length > 2)
{
string[] Partes = Token.Split(' ');
List<string> Aux = new List<string>();
Aux.AddRange(Partes);
foreach (var item in T.TokenTransicion)
{
if (Aux.Contains(item.Value)) { Aux.Remove(item.Value); }
}
try{ Token = Aux[0]; }
catch {
Aux = new List<string>();
Token = "";
foreach (var item in Partes)
{ if (!Aux.Contains(item)) { Aux.Add(item); Token += item + " "; } }
}
L.Add(AB + " = " + Token);
}
else { L.Add(AB + " = " + Token); }
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
