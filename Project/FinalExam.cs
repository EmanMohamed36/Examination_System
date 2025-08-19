using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class FinalExam:Exam
    {
        
        public FinalExam() {
            Console.WriteLine("Final Exam");
            McqQuestions = new List<MCQ_Question>();
            TOFQuestions = new List<TrueOrFalse_Question>();
            FullMark = 0;

        }
        public FinalExam(int _TimeOfExam ,int _NumberOfQuestions)
        { 
            TimeOfExam = _TimeOfExam;
            NumberOfQuestions = _NumberOfQuestions;
            McqQuestions = new List<MCQ_Question>();
            TOFQuestions = new List<TrueOrFalse_Question>();
            FullMark = 0;

        }

        public override string ToString()
        {
            string mcqString = McqQuestions != null && McqQuestions.Count > 0 ?
                string.Join("\n", McqQuestions) : "No MCQ Questions";
            string tofString = TOFQuestions != null && TOFQuestions.Count > 0 ?
                string.Join("\n", TOFQuestions) : "No True or False Questions";
            return $"TimeOfExam: {TimeOfExam}\nNumberOfQuestions: {NumberOfQuestions}\n\n\t\t\t\t\tMCQ Questions:\n{mcqString}\n\n\t\t\t\t\tTrue Or FalseQuestions:\n{tofString}\n\n";
        }
    }
}
