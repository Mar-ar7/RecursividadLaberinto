using System;

public class LaberintoSolver
{
    public static bool HayCamino(int[][] laberinto, int filaInicial, int columnaInicial, int filaFinal, int columnaFinal)
    {
        if (filaInicial < 0 || filaInicial >= laberinto.Length || columnaInicial < 0 || columnaInicial >= laberinto[0].Length)
        {
            Console.WriteLine($"Posición ({filaInicial}, {columnaInicial}) está fuera de los límites.");
            return false;
        }

        if (laberinto[filaInicial][columnaInicial] == 1)
        {
            Console.WriteLine($"Posición ({filaInicial}, {columnaInicial}) es una pared.");
            return false;
        }
        if (laberinto[filaInicial][columnaInicial] == 2)
        {
            Console.WriteLine($"Posición ({filaInicial}, {columnaInicial}) ya fue visitada.");
            return false;
        }

        if (filaInicial == filaFinal && columnaInicial == columnaFinal)
        {
            Console.WriteLine($"¡Salida encontrada en la posición ({filaInicial}, {columnaInicial})!");
            ImprimirLaberinto(laberinto);
            return true;
        }

        laberinto[filaInicial][columnaInicial] = 2;
        Console.WriteLine($"Visitando posición ({filaInicial}, {columnaInicial}).");

        ImprimirLaberinto(laberinto);

        if (HayCamino(laberinto, filaInicial - 1, columnaInicial, filaFinal, columnaFinal))
        {
            return true;
        }
        if (HayCamino(laberinto, filaInicial + 1, columnaInicial, filaFinal, columnaFinal))
        {
            return true;
        }
        if (HayCamino(laberinto, filaInicial, columnaInicial - 1, filaFinal, columnaFinal))
        {
            return true;
        }
        if (HayCamino(laberinto, filaInicial, columnaInicial + 1, filaFinal, columnaFinal))
        {
            return true;
        }

        laberinto[filaInicial][columnaInicial] = 0;
        Console.WriteLine($"Retrocediendo desde la posición ({filaInicial}, {columnaInicial}).");

        ImprimirLaberinto(laberinto);

        return false;
    }

    public static void ImprimirLaberinto(int[][] laberinto)
    {
        for (int i = 0; i < laberinto.Length; i++)
        {
            for (int j = 0; j < laberinto[i].Length; j++)
            {
                if (laberinto[i][j] == 2)
                {
                    Console.Write("* "); 
                }
                else
                {
                    Console.Write(laberinto[i][j] + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int[][] laberinto1 = new int[][]
        {
            new int[] { 0, 1, 0, 0, 0 },
            new int[] { 0, 1, 1, 1, 0 },
            new int[] { 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 0, 1, 1 },
            new int[] { 0, 0, 0, 0, 0 }
        };

        Console.WriteLine("Laberinto 1:");
        Console.WriteLine(HayCamino(laberinto1, 0, 0, 4, 4) ? "Camino encontrado" : "No hay camino");

        int[][] laberinto2 = new int[][]
        {
            new int[] { 0, 0, 1, 1, 1, 0, 0, 0 },
            new int[] { 1, 0, 1, 0, 0, 0, 1, 1 },
            new int[] { 1, 0, 0, 0, 1, 1, 0, 1 },
            new int[] { 0, 1, 1, 1, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1, 1, 1, 1, 0 },
            new int[] { 1, 1, 0, 0, 0, 0, 1, 0 },
            new int[] { 0, 1, 1, 1, 0, 1, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 1, 1, 0 }
        };

        Console.WriteLine("Laberinto 2:");
        Console.WriteLine(HayCamino(laberinto2, 0, 0, 7, 4) ? "Camino encontrado" : "No hay camino");

        int[][] laberinto3 = new int[][]
        {
            new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 },
            new int[] { 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
            new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
            new int[] { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 },
            new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        Console.WriteLine("Laberinto 3:");
        Console.WriteLine(HayCamino(laberinto3, 0, 0, 9, 9) ? "Camino encontrado" : "No hay camino");
    }
}
