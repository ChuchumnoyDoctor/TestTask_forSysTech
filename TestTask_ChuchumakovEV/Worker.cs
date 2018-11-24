using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_ChuchumakovEV
{
    class Worker
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime DataPostupleniyaNaRabotu { get; set; }
        public GroupOfWorker FK_GroupOfWorker { get; set; }
        public double BazovayaStavkaZP { get; set; }
        
    }
}
