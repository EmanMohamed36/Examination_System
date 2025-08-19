using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal abstract class Question
    {
        public string HeaderOfTheQuestion { protected set; get; }
        public string BodyOfTheQuestion { protected set; get; }
        protected double mark;
        protected int numberOfChoices;

        protected int rightAnswerId;

       
        public int RightAnswerId
        { 
            set { rightAnswerId = value < 0 || value > numberOfChoices? 0:value; }
            get { return rightAnswerId; }
        }
        public double Mark
        { 
            get { return mark; }
            set { mark = value < 0 ? 0 : value; }
        }
        public int NumberOfChoices
        {
            get { return numberOfChoices; }
            set { numberOfChoices = value < 0 ? 0 : value; }
        }
    }
}
