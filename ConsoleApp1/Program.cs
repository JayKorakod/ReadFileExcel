using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetExcelbyclosedXML();
        }

        public static void GetExcelbyclosedXML()
        {
            string fileName = "C:\\Users\\HP\\Desktop\\Book1.xlsx"; /// path ต้องตรงกับ file
            var workbook = new XLWorkbook(fileName);
            var ws1 = workbook.Worksheet(1);



            List<ExcelModel> list = new List<ExcelModel>();
            ExcelModel model = new ExcelModel();
            var rows = ws1.RowsUsed();



            foreach (var row in rows)
            {

                if (row.RowNumber() != 1)
                {
                    model = new ExcelModel();
                    model.MATERIAL_NO = row.Cell(1).Value.ToString();
                    model.CATEGORY_CODE = row.Cell(2).Value.ToString();



                    list.Add(model);
                }
            }
            Console.WriteLine("ListModel");
            using (Entities1 db = new Entities1())   
            {
                //Console.WriteLine(e);
                foreach (ExcelModel e in list)
                {
                    if (db.MAS_MATERIAL_MASTER.Any(x => x.MATERIAL_NO == e.MATERIAL_NO))
                    {
                        var temp = db.MAS_MATERIAL_MASTER.First(x => x.MATERIAL_NO == e.MATERIAL_NO);
                        temp.CATEGORY_CODE = e.CATEGORY_CODE;
                        Console.WriteLine("MATERIAL_NO " + e.MATERIAL_NO + " " + " CATEGORY_CODE " +e.CATEGORY_CODE +" Update");
                        
                    }
                }
                //db.SaveChanges(); 
            }
        }
    }
}