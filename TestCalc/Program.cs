using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcEngine;

namespace TestCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcEngine.CalcEngine ce = new CalcEngine.CalcEngine();
            bool nextFormula = true;
            while (nextFormula)
            {
                Console.Write("Введите формулу > ");
                string s = Console.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    var v = ce.Evaluate(s);
                    Console.WriteLine($"Результат = {v}");
                    Console.Write("Еще формула? Дд/Нн > ");
                    string k = Console.ReadLine();
                    switch (k.ToUpper())
                    {
                        case "Д":
                        case "Да":
                            Console.Clear();
                            break;
                        default:
                            nextFormula = false;
                            break;
                    }
                }
            }
        }
    }
}
