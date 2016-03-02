using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }
            else if(!(a<b+c) || !(b<a+c) || !(c<a+b))
            {
                throw new ArgumentException("This is invalid triangle");
            }
            else
            {
                double p = (a + b + c) / 2;
                double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                return area;
            }
            
        }

        static string DigitToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "Invalid number!";
            }
        }

        static int FindMaxElementsInArray(params int[] elements)
        {
            int maxNumber = elements[0];
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("The array is empty!");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (maxNumber < elements[i])
                {
                    int tmp = maxNumber;
                    maxNumber = elements[i];
                    elements[i] = maxNumber;
                }
            }
            return maxNumber;
        }

        static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        static double CalcDistance(double x1, double y1, double x2, double y2, 
            out bool isHorizontal, out bool isVertical)
        {
            if (y1 == y2)
            {
                isHorizontal = true;

            }
            else
            {
                isHorizontal = false;
            }
            if (x1 == x2)
            {
                isVertical = true;
            }
            else
            {
                isVertical = false;
            }
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToString(5));
      
            Console.WriteLine(FindMaxElementsInArray(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            DateTime dateOfBirthOne =  new DateTime(1992, 3, 17 ) ;
            Student peter = new Student("Peter", "Ivanov", "From Sofia", dateOfBirthOne);

            DateTime dateOfBirthTwo =  new DateTime(1993, 11, 3) ;
            Student stella = new Student("Stella","Markova", "From Vidin", dateOfBirthTwo);
           
            Console.WriteLine("{0} older than {1} -> {2}",
            peter.FirstName, stella.FirstName, peter.IsCurrentOlderThan(stella));
        }
    }
}
