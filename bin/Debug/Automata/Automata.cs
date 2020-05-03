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
T0.ID = 1;
T0.ER = "DIGITODIGITO*";
ListaTokens.Add(T0);
Token T1 = new Token();
T1.ID = 2;
T1.ER = "'\"'CHARSET'\"'|'''CHARSET'''";
ListaTokens.Add(T1);
Token T2 = new Token();
T2.ID = 4;
T2.ER = "'='";
ListaTokens.Add(T2);
Token T3 = new Token();
T3.ID = 5;
T3.ER = "'<''>'";
ListaTokens.Add(T3);
Token T4 = new Token();
T4.ID = 6;
T4.ER = "'<'";
ListaTokens.Add(T4);
Token T5 = new Token();
T5.ID = 7;
T5.ER = "'>'";
ListaTokens.Add(T5);
Token T6 = new Token();
T6.ID = 8;
T6.ER = "'>''='";
ListaTokens.Add(T6);
Token T7 = new Token();
T7.ID = 9;
T7.ER = "'<''='";
ListaTokens.Add(T7);
Token T8 = new Token();
T8.ID = 10;
T8.ER = "'+'";
ListaTokens.Add(T8);
Token T9 = new Token();
T9.ID = 11;
T9.ER = "'-'";
ListaTokens.Add(T9);
Token T10 = new Token();
T10.ID = 12;
T10.ER = "'O''R'";
ListaTokens.Add(T10);
Token T11 = new Token();
T11.ID = 13;
T11.ER = "'*'";
ListaTokens.Add(T11);
Token T12 = new Token();
T12.ID = 14;
T12.ER = "'A''N''D'";
ListaTokens.Add(T12);
Token T13 = new Token();
T13.ID = 15;
T13.ER = "'M''O''D'";
ListaTokens.Add(T13);
Token T14 = new Token();
T14.ID = 16;
T14.ER = "'D''I''V'";
ListaTokens.Add(T14);
Token T15 = new Token();
T15.ID = 17;
T15.ER = "'N''O''T'";
ListaTokens.Add(T15);
Token T16 = new Token();
T16.ID = 40;
T16.ER = "'(''*'";
ListaTokens.Add(T16);
Token T17 = new Token();
T17.ID = 41;
T17.ER = "'*'')'";
ListaTokens.Add(T17);
Token T18 = new Token();
T18.ID = 42;
T18.ER = "';'";
ListaTokens.Add(T18);
Token T19 = new Token();
T19.ID = 43;
T19.ER = "'.'";
ListaTokens.Add(T19);
Token T20 = new Token();
T20.ID = 44;
T20.ER = "'{'";
ListaTokens.Add(T20);
Token T21 = new Token();
T21.ID = 45;
T21.ER = "'}'";
ListaTokens.Add(T21);
Token T22 = new Token();
T22.ID = 46;
T22.ER = "'('";
ListaTokens.Add(T22);
Token T23 = new Token();
T23.ID = 47;
T23.ER = "')'";
ListaTokens.Add(T23);
Token T24 = new Token();
T24.ID = 48;
T24.ER = "'['";
ListaTokens.Add(T24);
Token T25 = new Token();
T25.ID = 49;
T25.ER = "']'";
ListaTokens.Add(T25);
Token T26 = new Token();
T26.ID = 50;
T26.ER = "'.''.'";
ListaTokens.Add(T26);
Token T27 = new Token();
T27.ID = 51;
T27.ER = "':'";
ListaTokens.Add(T27);
Token T28 = new Token();
T28.ID = 52;
T28.ER = "','";
ListaTokens.Add(T28);
Token T29 = new Token();
T29.ID = 53;
T29.ER = "':''='";
ListaTokens.Add(T29);
Token T30 = new Token();
T30.ID = 3;
T30.ER = "LETRA(LETRA|DIGITO)*{RESERVADAS()}";
ListaTokens.Add(T30);
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
EstadoInicial = "1, 3, 6, 9, 10, 12, 13, 14, 16, 18, 19, 20, 22, 23, 26, 29, 32, 35, 37, 39, 40, 41, 42, 43, 44, 45, 46, 47, 49, 50, 51, 53";
EAceptacion.Add("2, 56");EAceptacion.Add("56");EAceptacion.Add("11, 17, 56");EAceptacion.Add("15, 56");EAceptacion.Add("38, 56");EAceptacion.Add("36, 56");EAceptacion.Add("48, 56");EAceptacion.Add("52, 56");EAceptacion.Add("54, 55, 56");Estado E0= new Estado();
E0.ID = "1, 3, 6, 9, 10, 12, 13, 14, 16, 18, 19, 20, 22, 23, 26, 29, 32, 35, 37, 39, 40, 41, 42, 43, 44, 45, 46, 47, 49, 50, 51, 53";
E0.Transiciones = new Dictionary<string, string>();
E0.TokenTransicion = new Dictionary<string, string>();
E0.Transiciones.Add("<DIGITO>", "2, 56");
E0.Transiciones.Add("\"", "4");
E0.Transiciones.Add("'", "7");
E0.Transiciones.Add("=", "56");
E0.Transiciones.Add("<", "11, 17, 56");
E0.Transiciones.Add(">", "15, 56");
E0.Transiciones.Add("+", "56");
E0.Transiciones.Add("-", "56");
E0.Transiciones.Add("O", "21");
E0.Transiciones.Add("*", "38, 56");
E0.Transiciones.Add("A", "24");
E0.Transiciones.Add("N", "33");
E0.Transiciones.Add("D", "30");
E0.Transiciones.Add("M", "27");
E0.Transiciones.Add("(", "36, 56");
E0.Transiciones.Add(")", "56");
E0.Transiciones.Add(";", "56");
E0.Transiciones.Add(".", "48, 56");
E0.Transiciones.Add("{", "56");
E0.Transiciones.Add("}", "56");
E0.Transiciones.Add("[", "56");
E0.Transiciones.Add("]", "56");
E0.Transiciones.Add(":", "52, 56");
E0.Transiciones.Add(",", "56");
E0.Transiciones.Add("<LETRA>", "54, 55, 56");
E0.TokenTransicion.Add("<DIGITO>", "1");
E0.TokenTransicion.Add("\"", "2");
E0.TokenTransicion.Add("'", "2");
E0.TokenTransicion.Add("=", "4");
E0.TokenTransicion.Add("<", "5 6 9");
E0.TokenTransicion.Add(">", "7 8");
E0.TokenTransicion.Add("+", "10");
E0.TokenTransicion.Add("-", "11");
E0.TokenTransicion.Add("O", "12");
E0.TokenTransicion.Add("*", "13 41");
E0.TokenTransicion.Add("A", "14");
E0.TokenTransicion.Add("M", "15");
E0.TokenTransicion.Add("D", "16");
E0.TokenTransicion.Add("N", "17");
E0.TokenTransicion.Add("(", "40 46");
E0.TokenTransicion.Add(";", "42");
E0.TokenTransicion.Add(".", "43 50");
E0.TokenTransicion.Add("{", "44");
E0.TokenTransicion.Add("}", "45");
E0.TokenTransicion.Add(")", "47");
E0.TokenTransicion.Add("[", "48");
E0.TokenTransicion.Add("]", "49");
E0.TokenTransicion.Add(":", "51 53");
E0.TokenTransicion.Add(",", "52");
E0.TokenTransicion.Add("<LETRA>", "3");
Estados.Add("1, 3, 6, 9, 10, 12, 13, 14, 16, 18, 19, 20, 22, 23, 26, 29, 32, 35, 37, 39, 40, 41, 42, 43, 44, 45, 46, 47, 49, 50, 51, 53", E0);
Estado E1= new Estado();
E1.ID = "2, 56";
E1.Transiciones = new Dictionary<string, string>();
E1.TokenTransicion = new Dictionary<string, string>();
E1.Transiciones.Add("<DIGITO>", "2, 56");
E1.TokenTransicion.Add("<DIGITO>", "1");
E1.TokenTransicion.Add("#", "-1");
Estados.Add("2, 56", E1);
Estado E2= new Estado();
E2.ID = "4";
E2.Transiciones = new Dictionary<string, string>();
E2.TokenTransicion = new Dictionary<string, string>();
E2.Transiciones.Add("<CHARSET>", "5");
E2.TokenTransicion.Add("<CHARSET>", "2");
Estados.Add("4", E2);
Estado E3= new Estado();
E3.ID = "5";
E3.Transiciones = new Dictionary<string, string>();
E3.TokenTransicion = new Dictionary<string, string>();
E3.Transiciones.Add("\"", "56");
E3.TokenTransicion.Add("\"", "2");
Estados.Add("5", E3);
Estado E4= new Estado();
E4.ID = "56";
E4.Transiciones = new Dictionary<string, string>();
E4.TokenTransicion = new Dictionary<string, string>();
E4.TokenTransicion.Add("#", "-1");
Estados.Add("56", E4);
Estado E5= new Estado();
E5.ID = "7";
E5.Transiciones = new Dictionary<string, string>();
E5.TokenTransicion = new Dictionary<string, string>();
E5.Transiciones.Add("<CHARSET>", "8");
E5.TokenTransicion.Add("<CHARSET>", "2");
Estados.Add("7", E5);
Estado E6= new Estado();
E6.ID = "8";
E6.Transiciones = new Dictionary<string, string>();
E6.TokenTransicion = new Dictionary<string, string>();
E6.Transiciones.Add("'", "56");
E6.TokenTransicion.Add("'", "2");
Estados.Add("8", E6);
Estado E7= new Estado();
E7.ID = "11, 17, 56";
E7.Transiciones = new Dictionary<string, string>();
E7.TokenTransicion = new Dictionary<string, string>();
E7.Transiciones.Add("=", "56");
E7.Transiciones.Add(">", "56");
E7.TokenTransicion.Add(">", "5");
E7.TokenTransicion.Add("=", "9");
E7.TokenTransicion.Add("#", "-1");
Estados.Add("11, 17, 56", E7);
Estado E8= new Estado();
E8.ID = "15, 56";
E8.Transiciones = new Dictionary<string, string>();
E8.TokenTransicion = new Dictionary<string, string>();
E8.Transiciones.Add("=", "56");
E8.TokenTransicion.Add("=", "8");
E8.TokenTransicion.Add("#", "-1");
Estados.Add("15, 56", E8);
Estado E9= new Estado();
E9.ID = "21";
E9.Transiciones = new Dictionary<string, string>();
E9.TokenTransicion = new Dictionary<string, string>();
E9.Transiciones.Add("R", "56");
E9.TokenTransicion.Add("R", "12");
Estados.Add("21", E9);
Estado E10= new Estado();
E10.ID = "38, 56";
E10.Transiciones = new Dictionary<string, string>();
E10.TokenTransicion = new Dictionary<string, string>();
E10.Transiciones.Add(")", "56");
E10.TokenTransicion.Add(")", "41");
E10.TokenTransicion.Add("#", "-1");
Estados.Add("38, 56", E10);
Estado E11= new Estado();
E11.ID = "24";
E11.Transiciones = new Dictionary<string, string>();
E11.TokenTransicion = new Dictionary<string, string>();
E11.Transiciones.Add("N", "25");
E11.TokenTransicion.Add("N", "14");
Estados.Add("24", E11);
Estado E12= new Estado();
E12.ID = "25";
E12.Transiciones = new Dictionary<string, string>();
E12.TokenTransicion = new Dictionary<string, string>();
E12.Transiciones.Add("D", "56");
E12.TokenTransicion.Add("D", "14");
Estados.Add("25", E12);
Estado E13= new Estado();
E13.ID = "33";
E13.Transiciones = new Dictionary<string, string>();
E13.TokenTransicion = new Dictionary<string, string>();
E13.Transiciones.Add("O", "34");
E13.TokenTransicion.Add("O", "17");
Estados.Add("33", E13);
Estado E14= new Estado();
E14.ID = "34";
E14.Transiciones = new Dictionary<string, string>();
E14.TokenTransicion = new Dictionary<string, string>();
E14.Transiciones.Add("T", "56");
E14.TokenTransicion.Add("T", "17");
Estados.Add("34", E14);
Estado E15= new Estado();
E15.ID = "30";
E15.Transiciones = new Dictionary<string, string>();
E15.TokenTransicion = new Dictionary<string, string>();
E15.Transiciones.Add("I", "31");
E15.TokenTransicion.Add("I", "16");
Estados.Add("30", E15);
Estado E16= new Estado();
E16.ID = "31";
E16.Transiciones = new Dictionary<string, string>();
E16.TokenTransicion = new Dictionary<string, string>();
E16.Transiciones.Add("V", "56");
E16.TokenTransicion.Add("V", "16");
Estados.Add("31", E16);
Estado E17= new Estado();
E17.ID = "27";
E17.Transiciones = new Dictionary<string, string>();
E17.TokenTransicion = new Dictionary<string, string>();
E17.Transiciones.Add("O", "28");
E17.TokenTransicion.Add("O", "15");
Estados.Add("27", E17);
Estado E18= new Estado();
E18.ID = "28";
E18.Transiciones = new Dictionary<string, string>();
E18.TokenTransicion = new Dictionary<string, string>();
E18.Transiciones.Add("D", "56");
E18.TokenTransicion.Add("D", "15");
Estados.Add("28", E18);
Estado E19= new Estado();
E19.ID = "36, 56";
E19.Transiciones = new Dictionary<string, string>();
E19.TokenTransicion = new Dictionary<string, string>();
E19.Transiciones.Add("*", "56");
E19.TokenTransicion.Add("*", "40");
E19.TokenTransicion.Add("#", "-1");
Estados.Add("36, 56", E19);
Estado E20= new Estado();
E20.ID = "48, 56";
E20.Transiciones = new Dictionary<string, string>();
E20.TokenTransicion = new Dictionary<string, string>();
E20.Transiciones.Add(".", "56");
E20.TokenTransicion.Add(".", "50");
E20.TokenTransicion.Add("#", "-1");
Estados.Add("48, 56", E20);
Estado E21= new Estado();
E21.ID = "52, 56";
E21.Transiciones = new Dictionary<string, string>();
E21.TokenTransicion = new Dictionary<string, string>();
E21.Transiciones.Add("=", "56");
E21.TokenTransicion.Add("=", "53");
E21.TokenTransicion.Add("#", "-1");
Estados.Add("52, 56", E21);
Estado E22= new Estado();
E22.ID = "54, 55, 56";
E22.Transiciones = new Dictionary<string, string>();
E22.TokenTransicion = new Dictionary<string, string>();
E22.Transiciones.Add("<DIGITO>", "54, 55, 56");
E22.Transiciones.Add("<LETRA>", "54, 55, 56");
E22.TokenTransicion.Add("<LETRA>", "3");
E22.TokenTransicion.Add("<DIGITO>", "3");
E22.TokenTransicion.Add("#", "-1");
Estados.Add("54, 55, 56", E22);
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
if (Token.Length > 2)
{
string[] Partes = Token.Split(' ');
List<string> Aux = new List<string>();
Aux.AddRange(Partes);
foreach (var item in T.TokenTransicion)
{
if (Aux.Contains(item.Value)) { Aux.Remove(item.Value); }
}
Token = Aux[0];
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
