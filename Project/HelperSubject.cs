    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    namespace Exam02
    {
        internal static class HelperSubject
        {
            public static List<Subject> subjectsList;
            static HelperSubject()
            {
                subjectsList = new List<Subject>();
            }
            public static void createSubject()
            {
                Console.WriteLine("Please Enter Subject Id");
                int Id = ReadIdSubject(0, 100000);
                Console.WriteLine("Please Enter Subject Name: ");
                string name = Helper.ReadString();

                Subject s = new Subject(Id, name);
                subjectsList.Add(s);
                CreateExamForSpecificSubject(Id);
               

            }
            public static void GetAllSubjects()
            {

                if (subjectsList is not null && subjectsList.Count > 0)
                {
                    int count = 1;
                    foreach (Subject s in subjectsList)
                    {

                        Console.WriteLine($"Subject {count}: ");
                        Console.WriteLine(s);
                        Console.WriteLine("-------------------------");
                        count++;
                    }

                }
                else
                {
                    Console.WriteLine("No Subject Founded!!");

                }
                Helper.Delay();

            }

            public static bool FoundId(int id)
            {

                try
                {
                    bool found = false;
                    if (subjectsList is not null && subjectsList.Count > 0)
                    {
                        Subject? s = subjectsList.Find(a => a.Id == id);
                        if (s != null)
                        {
                            found = true;

                        }

                    }
             
                        return found;
                }
                catch {
                    throw new Exception();
                }
            }

            public static int ReadIdSubject(int start, int end)
            {
                int number;
                bool isInt = true;
                bool foundId = true;
                do
                {
                    if (!isInt || !foundId)
                        Console.WriteLine($"Please Enter Valid Input choose from {start} to {end}");

                    isInt = int.TryParse(Console.ReadLine(), out number);
                    if (number < start || number > end)
                        isInt = false;
                    foundId = FoundId(number);
                    if (foundId)
                        Console.WriteLine("This Id Was Taken please Enter another one!!");

                }
                while (!isInt || foundId);
                return number;
            }
            public static void CreateExamForSpecificSubject(int id)
            {
                bool found = FoundId(id);
                if (found)
                {
                    Subject? s = subjectsList.Find(a => a.Id == id);
                    int choice = 1;
                    int count = 0;
                    do
                    {
                        Console.Clear();
                        if (count < 1)
                            Console.WriteLine($"Do You wan't to Create Exam For {s.Name} ?(Choose 1 for Yes or 2 for No)");
                        else
                            Console.WriteLine($"Do You wan't to Create Another Exam For {s.Name} ?(Choose 1 for Yes or 2 for No)");
                        choice = Helper.ReadInt(1, 2);
                        if (choice == 1)
                        {
                            var (exam, n) = HelperExam.CreateExam();
                            if (n == 1 && exam is not null)
                            {
                                s.practicalExamsList.Add(exam);
                            }
                            else if (exam is not null)
                            {
                                s.finalExamsList.Add(exam);
                            }


                        }
                        else
                        {
                            Helper.MainWindow();
                        }
                        count++;

                    } while (choice == 1);

                }
                else
                {
                    Console.WriteLine("Subject Id doesn't found");
                }

            }
            public static void TakePracticalExamForSpecificSubject(int id)
            {
                bool found = FoundId(id);
                if (found)
                {

                    Subject? s = subjectsList.Find(a => a.Id == id);
                    int numberOfExam = s.practicalExamsList.Count;
                    if (numberOfExam > 0)
                    {
                        Console.WriteLine($"{numberOfExam} Exams Available in {s.Name}");

                        Console.WriteLine($"Choose from {1} to {numberOfExam} to take one of them:");
                        int ExamNumber = Helper.ReadInt(1, numberOfExam);
                        Exam exam = s.practicalExamsList[ExamNumber - 1];

                        Console.Clear();

                        HelperExam.TakeExam(exam);


                    }
                    else
                    {
                        Console.WriteLine($"Can't found Exams in Subject: {s.Name}");

                        Helper.Delay();
                    }

                }
                else
                {
                    Console.WriteLine($"Can't found Subject with Id: {id}");

                    Helper.Delay();
                }
            }

            public static void TakeFinalExamForSpecificSubject(int id)
            {
                bool found = FoundId(id);
                if (found)
                {
                    Subject? s = subjectsList.Find(a => a.Id == id);
                    int numberOfExams = s.finalExamsList.Count;
                    if (numberOfExams > 0)
                    {
                        Console.WriteLine($"{numberOfExams} Exams Available in {s.Name}");

                        Console.WriteLine($"Choose from {1} to {numberOfExams} to take one of them:");
                        int ExamNumber = Helper.ReadInt(1, numberOfExams);
                        Exam exam = s.finalExamsList[ExamNumber - 1];

                        Console.Clear();

                        HelperExam.TakeExam(exam);


                    }
                    else
                    {
                        Console.WriteLine($"Can't found Exams in Subject: {s.Name}");
                        Helper.Delay();
                    }
                }
                else
                {
                    Console.WriteLine($"Can't found Subject with Id: {id}");
                    Helper.Delay();
                }
            }

        
        }
    }
