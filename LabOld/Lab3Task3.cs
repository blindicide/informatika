using System;
class Lab3Task3 {
  static void Main1() {
        Random rnd = new Random();
        int linelen;
        int[][] matrix = new int[5][];
            matrix[0] = new int[5];
            matrix[1] = new int[3];
            matrix[2] = new int[8];
            matrix[3] = new int[4];
            matrix[4] = new int[6];
        for (int temp1 = 0; temp1 < 5; temp1++) {
            int[] temparr = matrix[temp1];
            linelen = temparr.Length;
            for (int temp2 = 0; temp2 < linelen; temp2++) {
                int ran = rnd.Next(-500, 500);
                matrix[temp1][temp2] = ran;
            }
        }
        // Вычислить сумму
        for (int temp1 = 0; temp1 < 5; temp1++) {
            int[] temparr = matrix[temp1];
            linelen = temparr.Length;
            int tempint = 0;
            for (int temp2 = 0; temp2 < linelen; temp2++) {
                tempint += matrix[temp1][temp2];
            }
            Console.Write("Сумма элементов строки ");
            Console.Write(Convert.ToString(temp1));
            Console.Write(": ");
            Console.Write(tempint);
            Console.WriteLine();
        }
        Console.WriteLine("Массив:");
        for (int temp1 = 0; temp1 < 5; temp1++) {
            int[] temparr = matrix[temp1];
            linelen = temparr.Length;
            for (int temp2 = 0; temp2 < linelen; temp2++) {
                int tempint = matrix[temp1][temp2];
                Console.Write(tempint);
                if (temp2 + 1 == linelen) {
                    Console.WriteLine();
                }
                else {
                    Console.Write("  ");
                }
            }
        }
    }
}