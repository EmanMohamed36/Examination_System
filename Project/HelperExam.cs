using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal static class HelperExam
    {

        enum TrueOrFalse
        { 
            True = 1,
            False = 2
        }
        public static PracticalExam CreateObjectForPracticalExams(int time, int numberOfQ)
        {

            
            
            PracticalExam p = new PracticalExam(time, numberOfQ);
            return p!;
            
            
        }
        public static FinalExam CreateObjectForFinalExams(int time, int numberOfQ)
        {

            FinalExam f = new FinalExam(time, numberOfQ);
            return f!;

        }

        public static (int time, int NumberOfQuestion) ReadInfoForExams(int choice)
        {
            string title = choice == 1 ?"Practical Exam:" : "Final Exam: ";
            Console.WriteLine($"{title}");
            
            Console.WriteLine("Please Enter the Time For Exam From (30 min to 180 min)");
            int time = Helper.ReadInt(30, 180);
            Console.WriteLine("Please Enter the Number of questions");
            int NumberOfQuestion = Helper.ReadInt(1, 100);
            return (time, NumberOfQuestion);

        }
        public static void GetAllFinalExams(int id)
        {
            try
            {
                if (HelperSubject.subjectsList is not null && HelperSubject.subjectsList.Count > 0)
                {
                    Subject? s = HelperSubject.subjectsList.Find(s => s.Id == id);

                    if (s != null && s.finalExamsList.Count > 0)
                    {
                        int count = 1;
                        foreach (FinalExam f in s.finalExamsList)
                        {
                            Console.WriteLine($"Exam {count}");
                            Console.WriteLine(f);

                            Console.WriteLine("-------------------------------------");
                            count++;
                        }
                        Helper.Delay();

                    }
                    else
                    {
                        Console.WriteLine($"Can't find Exam for subject with ID: {id} !!");
                        Helper.Delay();

                    }


                }
                else
                { 
                    
                }
                

            }
            catch(FormatException e)
             {
                Console.WriteLine(e.Message);
            }

        }

        public static void GetAllPracticalExams(int id)
        {
            try
            {
                if (HelperSubject.subjectsList is not null && HelperSubject.subjectsList.Count > 0)
                {
                    Subject? s = HelperSubject.subjectsList.Find(s => s.Id == id);
                    if (s != null && s.practicalExamsList.Count > 0)
                    {
                        int count = 1;
                        foreach (PracticalExam p in s.practicalExamsList)
                        {
                            Console.WriteLine($"Exam {count}");
                            Console.WriteLine(p);

                            Console.WriteLine("-------------------------------------");
                            count++;
                        }
                        Helper.Delay();

                    }
                    else
                    {
                        Console.WriteLine($"Can't find Exam for subject with ID: {id} !!");
                        Helper.Delay();

                    }

                }
               
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public static (Exam exam ,int Echoice) CreateExam()
        {
            Console.WriteLine("Please Enter the type of Exam (1 for Practical | 2 for Final)");
            int Echoise = Helper.ReadInt(1, 2);
            var EInfo = ReadInfoForExams(Echoise);
            
            Exam exam = (Echoise == 1 ? CreateObjectForPracticalExams(EInfo.time, EInfo.NumberOfQuestion)
                : CreateObjectForFinalExams(EInfo.time, EInfo.NumberOfQuestion))!;

            if (exam is null)
                throw new InvalidOperationException("Exam creation failed unexpectedly!");

            Console.Clear();

            for (int i = 1; i <= EInfo.NumberOfQuestion; i++)
            {
                Console.WriteLine($"Please Enter Type of Question{i} (1 For MCQ | 2 for True or False)");

                int  Qchoise = Helper.ReadInt(1, 2);

                if (Qchoise == 1)
                {
                    MCQ_Question q = HelperQuestion.ReadInfoAndCreateObjectForMCQ_Question();
                    
                    exam.McqQuestions.Add(q);
                    exam.FullMark +=  q.Mark; 

                }
                else
                {
                    TrueOrFalse_Question q = HelperQuestion.ReadInfoAndCreateObjectForTrueOrFalse_Question();
                    exam.TOFQuestions.Add(q);
                    exam.FullMark +=  q.Mark;
                }
                Console.Clear();

            }
                   Console.WriteLine("                             Exam:\n");
            if (exam is not null) Console.WriteLine(exam);
            Console.WriteLine("\nPress any key to Continue...");
            Console.ReadKey();
            return (exam , Echoise);
            //return (exam , Echoise);

        }
        public static void ShowExamImediatelyTaken(Exam exam , double score ,int[] MCQ , int[]TOF , DateTime start , DateTime end)
        {
            if (exam is not null)
            {
                
                Console.WriteLine($"Your Grade is {score} from {exam.FullMark}\t\t\t\t\t\t\t\t Time Spend: {end - start}");
                
                int countMcq = 0;
                foreach (MCQ_Question q in exam.McqQuestions)
                {
                    Console.WriteLine($" Question {countMcq + 1}: ");
                    Console.WriteLine(q.HeaderOfTheQuestion);
                    Console.WriteLine(q.BodyOfTheQuestion);
                    Console.WriteLine(q.printAnswers());
                    Console.WriteLine($"Your Answer: {HelperQuestion.GetAnswerById(q.answers,MCQ[countMcq])}");
                    Console.WriteLine($"Correct Answer: {HelperQuestion.GetAnswerById(q.answers,q.RightAnswerId)}");

                    countMcq++;
                }
                Console.WriteLine("\t\t\t\t\t\t\t\tTrue or False Questions:");
                int countTOF = 0;
                foreach (TrueOrFalse_Question q in exam.TOFQuestions)
                {
                    Console.WriteLine($" Question {countTOF + 1}: ");
                    Console.WriteLine(q.HeaderOfTheQuestion);
                    Console.WriteLine(q.BodyOfTheQuestion);
                    string userAnswer = TOF[countTOF] == 1 ? "True" : "False";
                    string correctAnswer = q.RightAnswerId == 1 ? "True" : "False";
                    Console.WriteLine($"Your Answer: {userAnswer}");
                    Console.WriteLine($"Correct Answer: {correctAnswer}");
                    countTOF++;
                }
                Helper.Delay();
            }
        }
        public static void TakeExam(Exam exam)
        {
            double scoreUser = 0;
            if (exam is not null)
            {
                DateTime startDate= DateTime.Now; 
                Console.WriteLine($"TimeOfExam: {exam.TimeOfExam} \t\t\t\t\t\t\t\t\t NumberOfQuestions: {exam.NumberOfQuestions}");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t\t\t\tMCQ Questions:");
                int[] MCQ = new int[exam.McqQuestions.Count];
                if (exam.McqQuestions.Count > 0)
                {
                    int countMcq = 0;
                    foreach (MCQ_Question q in exam.McqQuestions)
                    {

                        Console.WriteLine($" Question {countMcq + 1}\t\t\t\t\t\t\t\t Mark: {q.Mark}");
                        Console.WriteLine(q.HeaderOfTheQuestion);
                        Console.WriteLine(q.BodyOfTheQuestion);
                        Console.WriteLine(q.printAnswers());
                        Console.WriteLine($"Please Choose Id of Answer: ");
                        int userAnswerId = Helper.ReadInt(1, q.answers.Length);
                        if (q.RightAnswerId == userAnswerId) scoreUser += q.Mark;
                        MCQ[countMcq] = userAnswerId;
                        countMcq++;
                    }

                }
                else
                { 
                    
                    Console.WriteLine("Not Found MCQ Questions!!");
                    //Helper.Delay();
                }
                Console.WriteLine("\t\t\t\t\t\t\t\tTrue or False Questions:");
                int[] TOF = new int[exam.TOFQuestions.Count];
                if (exam.TOFQuestions.Count > 0)
                {
                    int countTOF = 0;
                    foreach (TrueOrFalse_Question q in exam.TOFQuestions)
                    {
                        Console.WriteLine($" Question {countTOF + 1}\t\t\t\t\t\t\t\t Mark: {q.Mark}");
                        Console.WriteLine(q.HeaderOfTheQuestion);
                        Console.WriteLine(q.BodyOfTheQuestion);
                        Console.WriteLine($"Please Choose Id of Answer: (1 for true | 2 for false)");
                        int userAnswerId = Helper.ReadInt(1, 2);

                        if (q.RightAnswerId == userAnswerId) scoreUser += q.Mark;
                        TOF[countTOF] = userAnswerId;
                        countTOF++;
                    }

                }
                else
                {
                    Console.WriteLine("Not Found MCQ Questions!!");

                }
                DateTime endDate = DateTime.Now;
                Console.Clear();
                ShowExamImediatelyTaken(exam, scoreUser, MCQ, TOF, startDate, endDate);
            }
        }

    }
}
