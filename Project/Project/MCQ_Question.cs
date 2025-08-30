using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class MCQ_Question : Question
    {
        // protected Dictionary<int, string> Choices = new Dictionary<int, string> { };
        public Answer[] answers { protected set; get; }
        public MCQ_Question()
        {
            Console.WriteLine("MCQ Question");
            answers = new Answer[numberOfChoices];

        }
        public string printAnswers()
        {
            string ansString = answers != null && answers.Length > 0 ?
                string.Join("\n", answers.Select(a => $"Choice {a.Id}: {a.Text}")) : "Choices is Empty";
            return ansString;
        }
        public MCQ_Question(string _HeaderOfTheQuestion, string _BodyOfTheQuestion, double _Mark, int _numberOfChoices, /*Dictionary<int, string> _Choices*/ Answer[] _answers, int _RightAnswerId)
        {
            HeaderOfTheQuestion = _HeaderOfTheQuestion;
            BodyOfTheQuestion = _BodyOfTheQuestion;
            Mark = _Mark;
            NumberOfChoices = _numberOfChoices;
            // Choices = _Choices;
            RightAnswerId = _RightAnswerId;
            answers = _answers;


        }


        public override string ToString()
        {
            string ansString = printAnswers();
            string correctAnswer = HelperQuestion.GetAnswerById(answers, rightAnswerId);
            return $"HeaderOfTheQuestion: {HeaderOfTheQuestion}\nBodyOfTheQuestion: {BodyOfTheQuestion}\nMark: {Mark}\nNumberOfChoices: {numberOfChoices}\nChoices:\n{ansString}\nCorrect Answer: {correctAnswer}";
        }

    }
}
