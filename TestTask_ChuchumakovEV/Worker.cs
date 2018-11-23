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
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime DataPostupleniyaNaRabotu { get; set; }
        public double BazovayaStavka { get; set; }
        public GroupOfWorker GetGroupOfWorker { get; set; }
    }
}
