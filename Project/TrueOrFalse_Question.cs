using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class TrueOrFalse_Question:Question
    {
        public TrueOrFalse_Question()
        {
            Console.WriteLine("True Or False Question");
        }
        public TrueOrFalse_Question(string _HeaderOfTheQuestion, string _BodyOfTheQuestion, double _Mark,int _RightAnswerId)
        {
            HeaderOfTheQuestion = _HeaderOfTheQuestion;
            BodyOfTheQuestion = _BodyOfTheQuestion;
            Mark = _Mark;
            RightAnswerId = _RightAnswerId;
        }

        public override string ToString()
        {
            string result = rightAnswerId == 1 ? "True" : "False";
            return $"HeaderOfTheQuestion: {HeaderOfTheQuestion}\nBodyOfTheQuestion: {BodyOfTheQuestion}\nMark: {Mark}\nCorrectAnswer: {result}";
        }
    }
}
