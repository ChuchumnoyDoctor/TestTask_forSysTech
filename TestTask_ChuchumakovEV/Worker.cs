using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_ChuchumakovEV
{
    public class Worker
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string DataPostupleniyaNaRabotu { get; set; }
        public GroupOfWorker FK_GroupOfWorker { get; set; }
        public double BazovayaStavkaZP { get; set; }
        public string Nachalnik { get; set; }
    }
}
