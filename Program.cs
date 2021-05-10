using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A888781.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            Diario diario = new Diario();
            diario.IngresarNuevo();
            Console.ReadLine();
        }
    }
}
