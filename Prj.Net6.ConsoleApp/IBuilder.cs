using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.ConsoleApp
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
