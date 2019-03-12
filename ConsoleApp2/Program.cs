using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.NewLine + "Goal: Print Prime Numbers from 5 to 25");
            int a = 5, b = 25;
            printPrimeNumbers(a, b);

            Console.WriteLine(Environment.NewLine + "Goal: Calculate Series till 5");
            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine(Environment.NewLine + "The sum of the series is: " + r1);

            Console.WriteLine(Environment.NewLine + "Goal: Print Triangle of 5 lines");
            int n4 = 5;
            printTriangle(n4);

            Console.WriteLine(Environment.NewLine + "Goal: Print array frequency");
            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            //self reflection:
            //Able to outut results but limited error catching and not the most efficient methodology for the code.
            //Have never written c# prior, trying to adjust from SQL to an object oriented way of thinking. Hints were very helpful in terms of determining a better way to implement.
            Console.ReadKey();
        }

        /*
        * x – starting range, integer (int)
        * y – ending range, integer (int)
        * 
        * summary      : This method prints all the prime numbers between x and y
        * For example 5, 25 will print all the prime numbers between 5 and 25 i.e. 
        * 5, 7, 11, 13, 17, 19, 23
        * Tip: Write a method isPrime() to compute if a number is prime or not.
        *
        * returns      : N/A
        * return type  : void
        *
        */
        public static void printPrimeNumbers(int x, int y)
        {
            try
            {

                for (int i = x; i <= y; i++)
                {
                    if (isPrime(i))
                    {
                        Console.Write(" " + i);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        //helper function for printPrimeNumbers to determine if one number is prime.
        public static bool isPrime(int num)
        {
            for (int a = 2; a <= num; a++)
            {
                if (num != a && num % a == 0)
                {
                    //Console.WriteLine("Prime Number is false");
                    return false;
                }
            }
            //Console.WriteLine("Prime Number is true");
            return true;
        }

        ////////////////////////////////////////////////////////////////
        /*
        * para    n – number of terms of the series, integer (int)
        * 
        * summary        : This method computes the series 1/2 – 2!/3 + 3!/4 – 4!/5 --- n     
        *                   * where ! means factorial, i.e., 4! = 4*3*2*1 = 24. Round off the results to 
        *                   three decimal places. 
        * Hint: Odd terms are all positive whereas even terms are all negative.
        * Tip: Write a method to compute factorial of n, call it whenever required.
        *
        * returns        : result
        * return type    : double
        */
        public static double getSeriesResult(int n)
        {
            try
            {
                double result = 0;
                for (int i = 1; i <= n; i++)
                {
                    result = result + ((Math.Pow((-1), (i + 1)) * (factorialResult(i))) / (1 + i));
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
                return 0;
            }
        }

        //helper function for getSeriesResult
        public static double factorialResult(int num)
        {
            double result = 1;
            for (int i = 1; i <= num; i++)
            {
                result = i * result;
            }
            return result;
        }

        /////////////////////////////////////////////////////////////////
        /*
        * n – number of lines for the pattern, integer (int)
        * 
        * summary      : This method prints a triangle using *
        * For example n = 5 will display the output as: 

            *
           ***
          *****
         *******
        *********

        *
        * returns      : N/A
        * return type  : void
        * 
        * //fifth odd number is nine.
        * Determine odd number assigned to the line
        */
        public static void printTriangle(int n)
        {
            try
            {
                int charsInTriangle = oddResult(n);
                for (int i = 1; i <= n; i++)
                {
                    int emptyChars = ((charsInTriangle - oddResult(i)) / 2);
                    int starChars = oddResult(i);
                    string triangleLine = "";
                    for (int sC = 1; sC <= starChars; sC++)
                    {
                        triangleLine = triangleLine + "*";
                    }
                    string triangleLine1 = triangleLine.PadRight(oddResult(i) + emptyChars);
                    Console.Write(Environment.NewLine + triangleLine1.PadLeft(charsInTriangle));
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }

        }

        //helper function for printTriangle
        public static int oddResult(int num)
        {
            int result = -1;
            for (int i = 1; i <= num; i++)
            {
                result = result + 2;
            }
            return result;
        }

        /////////////////////////////////////////////////////////
        /*
        * a – array of elements, integer (int)
        * 
        * summary      : This method computes the frequency of each element in the array
        * For example a = {1,2,3,2,2,1,3,2} will display the output as: 

        Number	Frequency
        1	2
        2	4
        3	2

        * returns      : N/A
        * return type  : void
        */
        
        public static void computeFrequency(int[] a)
        {
            try
            {
                int arraylen = a.Length;
                int[,] uniqueValues = new int[arraylen, 2];
                int arrayEnd = 0;
                for (int i = 0; i < arraylen; i++)
                {
                    int testInt = a[i];
                    //Console.WriteLine(testInt);
                    //if the value already exists in my unique array then increment
                    for (int n = 0; n < arraylen; n++)
                    {
                        if ((uniqueValues[n, 0] == testInt))
                        {
                            uniqueValues[n, 1] = uniqueValues[n, 1] + 1;
                            break;
                        }
                    }
                    //if the value does not exist then create the value in an "empty" array slot.
                    for (int t = 0; t < arraylen; t++)
                    {
                        int element = (uniqueValues[t, 0]);
                        if (element == 0)
                        {
                            uniqueValues[t, 0] = testInt;
                            uniqueValues[t, 1] = 1;
                            break;
                        }
                        else if (element == testInt)
                        {
                            break;
                        }
                    }
                }

                for (int b = 0; b < arraylen; b++)
                {
                    arrayEnd = arrayEnd + 1;
                    int element = (uniqueValues[b, 0]);
                    if (element == 0)
                    {
                        break;
                    }
                }

                Console.WriteLine(Environment.NewLine + "Number/Frequency");
                for (int i = 0; i < arrayEnd-1; i++)
                {
                    for (int j = 0; j < uniqueValues.GetLength(1); j++)
                    {
                        Console.Write(uniqueValues[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }


    }
}

