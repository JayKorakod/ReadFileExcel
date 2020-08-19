using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ExcelModel
    {
        public string MATERIAL_NO { get; set; }
        public string CATEGORY_CODE { get; set; }

        public override string ToString()
        {
            return "Matrrial_No: " + MATERIAL_NO + "      Catagory: " + CATEGORY_CODE;
        }
    }
}
