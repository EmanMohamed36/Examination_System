using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal static class HelperQuestion
    {


        public static TrueOrFalse_Question ReadInfoAndCreateObjectForTrueOrFalse_Question()
        {
            Console.WriteLine("True or False Question");

            Console.WriteLine("Please Enter Question Header");
            string Header = Helper.ReadString();


            Console.WriteLine("Please Enter Question Body");
            string Body = Helper.ReadString();

            Console.WriteLine("Please Enter Question Mark");
            double Mark = Helper.ReadDouble();

            Console.WriteLine("Please Enter Id of Correct Answer (1 for True, 2 for False) ");
            int CorrectAnswerId = Helper.ReadInt(1, 2);

            TrueOrFalse_Question q = new TrueOrFalse_Question(Header, Body, Mark, CorrectAnswerId);
            return q;
        }
        public static MCQ_Question ReadInfoAndCreateObjectForMCQ_Question()
        {
            Console.WriteLine("MCQ Question");

            Console.WriteLine("Please Enter Question Header");
            string Header = Helper.ReadString();


            Console.WriteLine("Please Enter Question Body");
            string Body = Helper.ReadString();

            Console.WriteLine("Please Enter Question Mark");
            double Mark = Helper.ReadDouble();


            Console.WriteLine("Please Enter Number Of Choices of Question");
            int NumberOfChoices = Helper.ReadInt(1, 7);

            Console.WriteLine("Choices of Question");


            // Dictionary<int, string> inputChoices = new Dictionary<int, string>();
            Answer[] inputChoices = new Answer[NumberOfChoices];
            for (int i = 0; i < NumberOfChoices; i++)
            {
                Console.WriteLine($"Please Enter Choice Number {i + 1}");
                string choice = Helper.ReadString();
                // inputChoices.Add(i, choice);

                inputChoices[i] = new Answer(i + 1, choice);

            }
            Console.WriteLine("Please Enter Id of Correct Answer: ");
            int CorrectAnswerId = Helper.ReadInt(1, NumberOfChoices);


            MCQ_Question q = new MCQ_Question(Header, Body, Mark, NumberOfChoices, inputChoices, CorrectAnswerId);
            return q;
        }


        public static string GetAnswerById(Answer[] answers, int id)
        {
            try
            {
                string result;

                if (answers is not null)
                {
                    Answer? answer = answers.FirstOrDefault(a => a.Id == id);
                    if (answer is not null)
                    {
                        result = answer.Text;
                    }
                    else
                    {
                        result = "ID is not found!!";
                    }

                }
                else
                {
                    result = "Not Choices Founded!!";
                }
                return result;


            }
            catch (FormatException e)
            {
                return e.Message;

            }

        }

    }
}
