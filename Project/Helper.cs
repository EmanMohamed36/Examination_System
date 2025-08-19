using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal static class Helper
    {
       
        public static int ReadInt(int start , int end)
        {
            int number ;
            bool isInt = true;
            do
            {
                if(!isInt)
                    Console.WriteLine($"Please Enter Valid Input choose from {start} to {end}");
                isInt = int.TryParse(Console.ReadLine(), out number);
                if (number < start || number > end)
                     isInt = false;
            
            }
            while (!isInt);
            return number ;
        }
        public static string ReadString()
        {
            string input = "Eman";
            do
            {
                if(string.IsNullOrEmpty(input)) Console.WriteLine("Input Can't be Null or Empty");
                input = Console.ReadLine();

            } while (string.IsNullOrEmpty(input));
            return input ;
        }
        public static double ReadDouble()
        {
            double number;
            bool isDouble = true;
            do
            {
                if (!isDouble)
                    Console.WriteLine($"Please Enter Valid Input ");
                isDouble = double.TryParse(Console.ReadLine(), out number);
                
            }
            while (!isDouble);
            return number;
        }


        public static void MainWindow()
        {
            int choice = 1;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose Number From The List: ");
                Console.WriteLine(" 1) Create  Subject");
                Console.WriteLine(" 2) Get All Subjects");
                Console.WriteLine(" 3) Get All Practical Exams For Specific Subject");
                Console.WriteLine(" 4) Get All Final Exams For Specific Subject");
                Console.WriteLine(" 5) Create  Exam For Specific Subject");
                Console.WriteLine(" 6) Take Final Exam For Specific Subject");
                Console.WriteLine(" 7) Take Practical Exam For Specific Subject");

                Console.WriteLine(" 0) Exit");

                choice = ReadInt(0, 7);

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        HelperSubject.createSubject();
                        break;

                    case 2:
                        Console.Clear();
                        HelperSubject.GetAllSubjects();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter Id of Subject You want: ");
                        int id = ReadInt(0, 100000);
                        HelperExam.GetAllPracticalExams(id);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter Id of Subject You want: ");
                        int idF = ReadInt(0, 100000);
                        HelperExam.GetAllFinalExams(idF);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter Id of Subject You want: ");
                        int S_id = ReadInt(0, 100000);
                        HelperSubject.CreateExamForSpecificSubject(S_id);
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Enter Id of Subject You want: ");
                        int E_id = ReadInt(0, 100000);
                        HelperSubject.TakeFinalExamForSpecificSubject(E_id);
                        Console.WriteLine(E_id);

                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Enter Id of Subject You want: ");
                        int F_id = ReadInt(0, 100000);
                        HelperSubject.TakePracticalExamForSpecificSubject(F_id);
                        break;

                    case 0:
                        Console.WriteLine("GoodBye !!");
                        break;
                }


            } while (choice != 0);



        }

        public static void Delay()
        {
            Console.WriteLine("Press Any key to Continue");
            Console.ReadKey();

        }


    }

}

