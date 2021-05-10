using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A888781.Actividad03
{
    class PlanCuentas
    {
        List<PlanCuentas> plan = new List<PlanCuentas>();
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        string planCuentas = "";
        public void Chequear()
        {
            if (File.Exists(planCuentas))
            {
                var reader = new StreamReader(planCuentas);
                {
                    while (!reader.EndOfStream)
                    {
                        var barrita = reader.ReadLine();
                        var Plan = new PlanCuentas(barrita);
                        plan.Add(Plan);
                    }
                }
            }
        }
        public PlanCuentas()
        {
        }
        public PlanCuentas(string barrita)
        {
            var datos = barrita.Split('|');
            Codigo = int.Parse(datos[0]);
            Nombre = datos[1];
            Tipo = datos[2];
        }
        private bool Buscar(int Codigo)
        {
            bool bus = false;
            int pos = 0;
            while (pos < plan.Count && !bus)
            {
                if (plan[pos].Codigo == Codigo)
                {
                    bus = true;
                }
                else
                {
                    pos++;
                }
            }
            return bus;
        }
    }
}
