using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab_C_sharp
{
    class Master:Person
    {
        public int Sertif;
        public const double Salary = 40000;
        public Master(string FirstName,string SecondName,string name, string Id, int NW, int sert)
        {
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.name = name;
            this.Id = Id;
            this.NumberWorkshop = NW;
            Sertif = sert;
        }
        public override string ToString()
        {
            return String.Format("Призвіще:{0},Ім'я:{1},По-батькові: {2},ID: {3},Номер цеху: {4},Кількість сертифікатів проходження курсів підвіщення кваліфікації:{5}",
                this.SecondName, this.FirstName, this.name, this.Id, this.NumberWorkshop, Sertif);
        }

    }
}
