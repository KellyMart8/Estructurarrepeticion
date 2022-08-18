int[] valores;
valores = new int[9] {3, 6, 7, 8, 9, 0, 4, 3, 2};
string[] paises = new string[3] { "Nicaragua", "el Salvador", "Venezuela " };

int total = 0;


foreach(int i in valores)
{
    total += i;
    Console.Write("{0}", i);
}
Console.WriteLine("Total: " + total);

int[,] numeros = new int[2, 2] { { 5, 2 }, { 8, 6 } };
numeros[2, 1] = 10;

    foreach (int i in numeros)
{
    Console.WriteLine("{0}", i);
}
    Console.WriteLine(valores.Length);

int[][] matriz = new int[valores.Length][];