using System;
using System.Reflection.Metadata.Ecma335;

public class General
{
    private static int[][] variants = new int[][]
    {
        new int[] {4, 6},    
        new int[] {6, 8},    
        new int[] {7, 9},    
        new int[] {4, 8},    
        new int[] {0, 3, 9}, 
        new int[] {},        
        new int[] {0, 1, 7},
        new int[] {2, 6},    
        new int[] {1, 3},    
        new int[] {2, 4}    
    };

    public static long CountPhoneNumbers(int n)
    {
        if (n == 1)
            return 8; 

        long[,] dinamicArray = new long[n + 1, 10];

        for (int digit = 0; digit <= 9; digit++)
        {
            dinamicArray[1, digit] = (digit == 5 || digit == 0 || digit == 8) ? 0 : 1;
        }
            
        for (int length = 2; length <= n; length++)
        {
            for (int digit = 0; digit <= 9; digit++)
            {
                foreach (int nextVariant in variants[digit])
                {
                    dinamicArray[length, digit] += dinamicArray[length - 1, nextVariant];
                }
            }
        }
        long totalNumbers = 0;
        for (int digit = 0; digit <= 9; digit++)
        {
           
                totalNumbers += dinamicArray[n, digit];
        }

        return totalNumbers;
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if(n > 50 || n < 1)
        {
            return;
        }
        long result = CountPhoneNumbers(n);
        Console.WriteLine(result);
    }
}
