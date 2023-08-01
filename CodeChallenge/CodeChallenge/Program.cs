// See https://aka.ms/new-console-template for more information
using CodeChallenge.Classes;

Console.WriteLine("Hello, World!");
//MathAndNumbers.CheckPrimeNumbers();
//MathAndNumbers.TwoPosivetOutOfThree();
//MathAndNumbers.TransposeMatrix();

string P = "abc";
string Q = "bcd";
var minDistinct = CodilityChallenge.PiCodeGM(P, Q);
Console.WriteLine("Pi Code restul of P = '{0}' and Q = '{1}: {2}.'", P, Q, minDistinct);
Console.WriteLine("");

P = "axxz";
Q = "yzwy";
minDistinct = CodilityChallenge.PiCodeGM(P, Q);
Console.WriteLine("Pi Code restul of P = '{0}' and Q = '{1}: {2}.'", P, Q, minDistinct);
Console.WriteLine("");

P = "bacad";
Q = "abada";
minDistinct = CodilityChallenge.PiCodeGM(P, Q);
Console.WriteLine("Pi Code restul of P = '{0}' and Q = '{1}: {2}.'", P, Q, minDistinct);
Console.WriteLine("");

P = "amz";
Q = "amz";
minDistinct = CodilityChallenge.PiCodeGM(P, Q);
Console.WriteLine("Pi Code restul of P = '{0}' and Q = '{1}: {2}.'", P, Q, minDistinct);
Console.WriteLine("");

//var gap = Iterations.BinaryGap(5);

//string P = "abc";
//string Q = "def";

//var total = CodilityChallenge.PiCodeGM(P, Q);

Console.ReadKey();