using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab_C_sharp
{
    class Workshop
    {
        public int id;
        public int workplaces;
        public int MaxCapacity;
        public int MaxNumMaster;
        public int MaxNumWorker;
        public int NumMasterCurrent;
        public int NumWorkerCurrent;
        public const int DetailMaster = 100;
        public const int DetailWorker = 70;
        public const double CostOfDet = 10;
        public double CostDet;

        public Workshop(int id, int workPlaces, int MaxCapacity, int MaxNumMaster,int MaxNumWorker,int NumMasterCurrent,int NumWorkerCurrent,double CostDet)
        {
            this.id = id;
            workplaces = workPlaces;
            this.MaxCapacity = MaxCapacity;
            this.MaxNumMaster = MaxNumMaster;
            this.MaxNumWorker = MaxNumWorker;
            this.NumMasterCurrent = NumMasterCurrent;
            this.NumWorkerCurrent = NumWorkerCurrent;
            this.CostDet = CostDet;

        }

        public override string ToString()
        {
            return String.Format("Номер цеху:{0},Кількість робочих місць:{1},Максимальна кількість працівників що можуть працювати у цеху :{2}, Максимальна кількість майстрів що можуть працювати у цьому цеху:{3}, Максимальная кількість робітників які можуть працювати у цьому цеху:{4},Поточна кількість майстрів у цеху на даний час:{5}Поточна кількість робітників у цеху на даний час:{6},кількість деталей які може виробити майстер у цеху: {7},кількість деталей які може виробити робітник у цеху: {8}, собівартість однієї деталі що виробляється у цеху:{9},Поточна вартість однієї деталі що виробляється у цеху:{10}",
                this.id, this.workplaces, this.MaxCapacity, this.MaxNumMaster, this.MaxNumWorker, this.NumMasterCurrent, this.NumWorkerCurrent, DetailMaster,DetailWorker,CostOfDet,this.CostDet);
        }



    }
}
