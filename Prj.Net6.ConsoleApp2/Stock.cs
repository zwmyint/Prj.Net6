using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.ConsoleApp2
{
    public class Stock
    {
        public string Sku { get; set; }
        public string ModelName { get; set; }
        public string Category { get; set; }
        public int Qty { get; set; }
    }

    public class Sales
    {
        public string Sku { get; set; }
        public int SaleRecord { get; set; }
    }


}
