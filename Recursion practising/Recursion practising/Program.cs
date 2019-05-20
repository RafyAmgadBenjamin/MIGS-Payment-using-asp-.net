using System;

namespace Recursion_practising
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SumNaturalNo(10));
            // DisplayNoDigits(1234);
            //     Console.WriteLine(CountDigitNum(123456));  
            // PrintEvenAndOddNumber(1, 20);
            // Console.WriteLine(IsPrime(13, 13)); 

            //string word = "RADAR";
            //Console.WriteLine(IsPalindrom(word, 0, word.Length-1));

            //  int facatorialNo = 5;
            // Console.WriteLine(GetFactorial(facatorialNo));

            Console.WriteLine(CalFibonatici(9));
        }
        /// <summary>
        /// problem 3
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        static int SumNaturalNo(int no)
        {
            if (no == 1)
                return 1;
            return SumNaturalNo(no - 1) + no;
        }
        /// <summary>
        /// problem 4
        /// </summary>
        /// <param name="n"></param>
        static void DisplayNoDigits(int n)
        {
            if (n == 0)
                return;
            DisplayNoDigits(n / 10);

            Console.WriteLine(n % 10);

        }
        /// <summary>
        /// problem 5
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int CountDigitNum(int n)
        {
            if (n == 0)
                return 0;
            return CountDigitNum(n / 10) + 1;
        }
        /// <summary>
        /// problem 6
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        static void PrintEvenAndOddNumber(int start,int end)
        {
            if (start > end)
                return;
            if (start % 2 == 0) {
                Console.WriteLine("All even numbers :");
                Console.Write(start + " ");
            }
            else
            {
                Console.WriteLine("All Odd numbers :");
                Console.Write(start + " ");
            }

            PrintEvenAndOddNumber(start = start+1,end);
        }
        /// <summary>
        /// problem 7
        /// </summary>
        /// <param name="n"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        static bool IsPrime(int n, int val)
        {

            if (n == 1)
                return true;
            return IsPrime(n = n - 1, val) && (val%n!=0 || val==n || n==1);
        }
        /// <summary>
        /// problem 8
        /// </summary>
        /// <param name="word"></param>
        /// <param name="st"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static bool IsPalindrom(string word,int st,int end)
        {
            if (st == end || end<=st)
                return true;
            else
            {
                if (word[st] != word[end])
                    return false;
                else
                   return IsPalindrom(word, st =st+1, end=end-1);
            }
        }
        /// <summary>
        /// problem 9
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int GetFactorial(int n)
        {
            if (n == 1 ||n == 0)
                return 1;

            return n * GetFactorial(n = n - 1) ;
        }
        /// <summary>
        /// problem 10
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int CalFibonatici(int n) {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            return CalFibonatici(n - 1) + CalFibonatici(n - 2);
        }
    }
}
