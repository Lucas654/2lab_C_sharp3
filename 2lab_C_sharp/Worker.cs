using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab_C_sharp
{
    class Worker:Person
    {
        public const double Salary = 15000;
        public string Education;

        public Worker(string FirstName,string SecondName,string name, string Id, int NW, string Ed)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.name = name;
            this.Id = Id;
            this.NumberWorkshop = NW;
            Education = Ed;
        }
        public override string ToString()
        {
            return String.Format("Призвіще:{0},Ім'я:{1},По-батькові: {2},ID: {3},Номер цеху: {4},Наявність освіти:{5}",
                this.SecondName, this.FirstName, this.name, this.Id, this.NumberWorkshop, this.Education);
        }
    }
}
