using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal abstract class Exam
    {
        protected int timeOfExam;
        protected int numberOfQuestions;
        public List<MCQ_Question> McqQuestions = new List<MCQ_Question>();
        public List<TrueOrFalse_Question> TOFQuestions = new List<TrueOrFalse_Question>();
        protected double fullMark;

        public double FullMark
        {
            set { fullMark = value < 0 ? 0 : value; }
            get { return fullMark; }
        }
        public int TimeOfExam
        {
            set { timeOfExam = value < 0 ? 0 : value; }
            get { return timeOfExam; }
        }
        public int NumberOfQuestions
        {
            get { return numberOfQuestions; }
            set { numberOfQuestions = value < 0 ? 0 : value; }
        }
    }
}
