using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace fuckdwennis
{
    internal class Program
    {
        public static int sum(int tall1, int tall2)
        {
            int totalsum = tall1 + tall2;
            return totalsum;
        }

        static void Main(string[] args)
        {
            opgv14();
            Console.ReadLine();
            
        }

        static void opgv8(int tallå)
        {
            string[] tall = { "1", "2", "3", "435", "51345" };
            for (int i = 0; i < tall.Length; i++)
            {

                if (tall[i].Length > tallå)
                {
                    Console.WriteLine(tall[i]);
                }
                Console.WriteLine();


            }
        }

        static void opgv9()
        {
            int[] tall = {12, 42, 3, 23, 2 };
            
            for (int i = 0; i < tall.Length; i++) 
            {

                Console.WriteLine(tall[i]);
            }
            Array.Sort(tall);
            Console.WriteLine();

            for (int i = 0; i < tall.Length; i++)
            {

                Console.WriteLine(tall[i]);
            }
            Console.WriteLine();
            for (int i = tall.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(tall[i]);
            }

        }
        static void opgv10()
        {
            //spør arthur om løsningen som inneholder 2 for loops//
            String[] tall = { "*", "**", "***", "****", "*****"};

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < tall.Length; j++)

                {
                    Console.WriteLine(tall[j]);

                }
                Array.Reverse(tall);
            }


        }
        static void opgv12()
        {
            int[] tall = { 1, 9, 33, 44 };

            int tempoen = tall[0];

            int tempotwo = tall[1];

            tall[1] = tempoen;

            tall[0] = tempotwo;

            foreach(int i in tall)
                Console.WriteLine(i);   
        }




        static void opgv13()
        {


            int[] arr = { 23, 55, 34, 53, 78 };
        }

        static void opgv14()
        {






        }
    
    
    
    
    
    
    
    
    
    
    
    }
}
  

