using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab_C_sharp
{
    class zavod: IComparable<zavod>
    {
        public List<Workshop> workshops = new List<Workshop>();
        public Dictionary<string,Person> people = new Dictionary<string,Person>();
        public string nameZavod { get; set; }
        public int numOfWorkshops { get { return workshops.Count; } set { } }
        public int numOfMasters { 
            get { int i = 0; 
                foreach (var person in people) 
                {
                    string a = person.Value.GetType().ToString();
                    
                    string[] b = a.Split('.');
                    if (b[1]== "Master") 
                        i++; 
                }
                return i; 
            }
            set { }
        }
        public int numOfemployees {
            get
            {
                int i = 0;
                foreach (var person in people)
                {
                    string a = person.Value.GetType().ToString();

                    string[] b = a.Split('.');
                    if (b[1] == "Worker")
                        i++;
                }
                return i;
            }
            set { }
        }
        public double salaryEmpl { get; set; }
        public double salaryMaster { get; set; }
        public double incomeMaster { get; set; }
        public double incomeEmpl{ get; set; }
        public int FD;
       

        public zavod(string nameZavod, int numOfWorkshop,int numOfMasters, int numOfemployees, double salaryEmpl, double salaryMaster, double incomeMaster, double incomeEmpl)
        {

            this.nameZavod = nameZavod;
            this.salaryEmpl = salaryEmpl;
            this.salaryMaster = salaryMaster;
            this.incomeMaster = incomeMaster;
            this.incomeEmpl = incomeEmpl;

        }
        public zavod(zavod obj)
        {
            nameZavod = obj.nameZavod;
            numOfWorkshops = obj.numOfWorkshops;
            numOfMasters = obj.numOfMasters;
            numOfemployees = obj.numOfemployees;
            salaryEmpl = obj.salaryEmpl;
            salaryMaster = obj.salaryMaster;
            incomeMaster = obj.incomeMaster;
            incomeEmpl = obj.incomeEmpl;
        }

        public bool HireEmpl(Person person)
        {
            if (!people.ContainsKey(person.Id))
            {
                people.Add(person.Id, person);
                return true;
            }
            else
                return false;
        }
        public bool HireMaster(Person person)
        {
            if (!people.ContainsKey(person.Id))
            {
                people.Add(person.Id, person);
                return true;
            }
            else
                return false;
        }
        public bool Fire(string k)
        {
            if (people.ContainsKey(k))
            {
                people.Remove(k);
                return true;
            }
            else
                return false;
        }
       
        public void Write()
        {

        }


        public int CompareTo(zavod obj)
        {
            if (this.numOfWorkshops > obj.numOfWorkshops && this.numOfemployees>obj.numOfemployees && this.numOfMasters>obj.numOfMasters)
                return 1;
            if (this.numOfWorkshops < obj.numOfWorkshops && this.numOfemployees < obj.numOfemployees && this.numOfMasters < obj.numOfMasters)
                return -1;
            else
                return 0;
        }

        

        public override string ToString()
        {
            return String.Format("Назва заводу:{0},Кількість цехів: {1},Кількість майстрів: {2},Кількість працівників: {3},ЗП працівників: {4},ЗП майстрів: {5},Прибуток з майстра:{6},Прибуток з працівника: {7}",
                this.nameZavod, this.numOfWorkshops,this.numOfMasters, this.numOfemployees,this.salaryEmpl,this.salaryMaster,this.incomeMaster,this.incomeEmpl);
        }

        









    }
   
}
