using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exam02
{
    internal class Subject
    {
        protected int id;
        public string Name { protected set;  get; }

        public List<Exam> finalExamsList { get; set; }
        public List<Exam> practicalExamsList { get; set; }
        public Subject(int _Id, string _Name)
        {
            Id = _Id;
            Name = _Name;
            finalExamsList = new List<Exam>();
            practicalExamsList = new List<Exam>();
        }
        public int Id
        {
            set { id = value < 0 ? 0 : value; }
            get { return id; }
        }
        public override string ToString()
        {
            
            return $"Id: {Id}  Name: {Name}";
        }
    }
}
