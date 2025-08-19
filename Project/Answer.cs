using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02
{
    internal class Answer
    {
        private int id;
        public string? Text { protected set; get; }

        public int Id
        { 
            get { return id; }
            set { id = value < 0? 0:value; }
        }
        public Answer(int _Id , string _Text)
        { 
            Id = _Id;
            Text = _Text;
        }

        public override string ToString()
        {
            return $"Id: {id} , Text: {Text}";
        }
    }
}
