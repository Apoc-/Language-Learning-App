using System;
using System.Collections.Generic;

namespace LeitnerSystem
{
    public static class Helpers
    {
        private static Random rng = new Random();  

        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
        
        public static void Repeat(int repeatCount, Action action)
        {
            for (int i = 0; i < repeatCount; i++) action();
        }
    }
    
}