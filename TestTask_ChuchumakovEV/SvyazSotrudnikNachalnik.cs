using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_ChuchumakovEV
{
    class SvyazSotrudnikNachalnik
    {
        public int Id { get; set; }
        public int Fk_IdSotrudnik { get; set; }
        public int Fk_IdNachalnik { get; set; }
    }
}
