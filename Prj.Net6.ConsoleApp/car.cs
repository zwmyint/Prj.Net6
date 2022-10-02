using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.ConsoleApp
{
    public class Car
    {
        public Wheel WheelType;
        public string ModelNo;
        public string Company;
    }
    public class Wheel
    {
        public string Material;
    }
    public class AlloyWheel : Wheel
    {
        public string FrictionLevel;
    }
    public class ChromeWheel : Wheel
    {
        public bool HasChromePlating;
    }
}
