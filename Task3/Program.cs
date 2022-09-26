using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    
    public static class Program
    {
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            if (tailLength <= 0 || tailLength == null)
                throw new ArgumentOutOfRangeException("Invalid tailLength value.");// Валидация значения tailLength

            var len = enumerable.Count(); //Количество элементов в коллекции 

            if (tailLength >= len)
                tailLength = len;
            int current = 1; //Номер текущего элемента в переборе

            foreach (T item in enumerable)
            {
                yield return (item, len - current >= tailLength ? null : len - current);
                current++;
            }
        }

        static void Main(string[] args)
        {
            var mas = new int[] { 1, 2, 3, 4 , 10, 128, 12, 30}.EnumerateFromTail(5);
            foreach (var ma in mas)
                Console.WriteLine(ma);

            var mas1 = new string[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun"}.EnumerateFromTail(3);
            foreach (var ma in mas1)
                Console.WriteLine(ma);

            var mas4 = new int[] { 1, 2, 3}.EnumerateFromTail(1);
            foreach (var ma in mas4)
                Console.WriteLine(ma);
        }
    }
}
