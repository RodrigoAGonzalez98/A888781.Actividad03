using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A888781.Actividad03
{
    class Diario
    { }
    namespace A873263.Actividad03
    {
        class Diario
        {
            public int NroAsiento { get; set; }
            public DateTime Fecha { get; set; }
            public int CodigoCuenta { get; set; }
            public decimal Debe { get; set; }
            public decimal Haber { get; set; }
            public string Linea { get; }

            const string diario = "Diario.txt";
            public Diario()
            { }
            public Diario(int Nro, DateTime Fecha, int CodigoCuenta, decimal Debe, decimal Haber)
            {
                NroAsiento = Nro;
                this.Fecha = Fecha;
                this.CodigoCuenta = CodigoCuenta;
                this.Debe = Debe;
                this.Haber = Haber;
            }
            public Diario(string barra)
            {
                var datos = barra.Split('|');
                NroAsiento = int.Parse(datos[0]);
                Fecha = DateTime.Parse(datos[1]);
                CodigoCuenta = int.Parse(datos[2]);
                Debe = decimal.Parse(datos[3]);
                Haber = decimal.Parse(datos[4]);
            }
            public string ObtenerLineaDatos() => $"{NroAsiento};{Fecha};{CodigoCuenta};{Debe};{Haber}";
            /*public Diario IngresarNuevo()
            {
                
            }*/
            internal Diario IngresarNuevo()
            {
                var diario = new Diario();
                Console.WriteLine("Nuevo asiento");

                diario.NroAsiento = Ingresarasiento();
                diario.Fecha = IngresarFecha("Ingrese la fecha");
                diario.CodigoCuenta = IngresarCuenta();
                diario.Debe = Ingresardebe();
                diario.Haber = Ingresarhaber();

                return diario;

            }
            public void Mostrar()
            {
                Console.WriteLine();
                Console.WriteLine($"Número asiento {NroAsiento}");
                Console.WriteLine($"{Fecha:dd/mm/yyyy}");
                Console.WriteLine($"{CodigoCuenta}");
                Console.WriteLine(Debe);
                Console.WriteLine(Haber);
                Console.WriteLine();
            }
            private static int Ingresarasiento(bool obligatorio = true)
            {
                var titulo = "Ingrese el Número de asiento";
                if (!obligatorio)
                {
                    titulo += " o presione Enter para continuar";
                }

                do
                {
                    Console.WriteLine(titulo);
                    var ingreso = Console.ReadLine();
                    if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                    {
                        return 0;
                    }

                    if (!int.TryParse(ingreso, out var NroAsiento))
                    {
                        Console.WriteLine("No ha ingresado un número válido.");
                        continue;
                    }

                    if (NroAsiento < 1)
                    {
                        Console.WriteLine("Debe ser un número mayor a 1.");
                        continue;
                    }
                    if (Diario.Existe(NroAsiento))
                    {
                        Console.WriteLine("El número indicado ya existe.");
                        continue;
                    }

                    return NroAsiento;

                } while (true);
            }

            private static bool Existe(int nroAsiento)
            {
                throw new NotImplementedException();
            }

            private static void Add(Diario elDiario)
            {
                throw new NotImplementedException();
            }
            /*
            public Diario(string linea)
            {
                
            }
            */
            private static DateTime IngresarFecha(string titulo, bool obligatorio = true)
            {
                do
                {
                    if (!obligatorio)
                    {
                        titulo += " o presione [Enter para continuar]";
                    }

                    Console.WriteLine(titulo);

                    var ingreso = Console.ReadLine();

                    if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                    {
                        return DateTime.MinValue;
                    }

                    if (!DateTime.TryParse(ingreso, out DateTime fechaNacimiento))
                    {
                        Console.WriteLine("No es una fecha válida");
                        continue;
                    }
                    if (fechaNacimiento > DateTime.Now)
                    {
                        Console.WriteLine("La fecha debe ser menor a la actual");
                        continue;
                    }
                    return fechaNacimiento;

                } while (true);
            }
            private static int IngresarCuenta(bool obligatorio = true)
            {
                var titulo = "Ingrese el código de cuenta (Entero de 2 cifras)";
                if (!obligatorio)
                {
                    titulo += " o presione [Enter] para continuar";
                }

                do
                {
                    Console.WriteLine(titulo);
                    var ingreso = Console.ReadLine();
                    if (!obligatorio && string.IsNullOrWhiteSpace(ingreso))
                    {
                        return 0;
                    }

                    if (!int.TryParse(ingreso, out var CodigoCuenta))
                    {
                        Console.WriteLine("No ha ingresado un código válido");
                        continue;
                    }

                    if (CodigoCuenta < 11 || CodigoCuenta > 34)
                    {
                        Console.WriteLine("No figura en el archivo");
                        continue;
                    }
                    if (Diario.Existe(CodigoCuenta))
                    {
                        Console.WriteLine("El código indicado ya existe.");
                        continue;
                    }

                    return CodigoCuenta;

                } while (true);

            }
            private static decimal Ingresardebe(bool obligatorio = true)
            {
                decimal debe = 0;
                Console.WriteLine("Ingrese D-para saldo deudor-");
                var tecla = Console.ReadKey(intercept: true);
                if (tecla.Key == ConsoleKey.D)
                {
                    Console.WriteLine("Debe");
                    var eleccion = Console.ReadLine();
                    if (!decimal.TryParse(eleccion, out debe))
                    {
                        Console.WriteLine("El importe debe ser númerico.");
                        continue;
                    }
                    else if (debe < 0)
                    {
                        Console.WriteLine("El importe debe ser mayor o igual a cero.");
                        continue;
                    }
                }
            }
            private static decimal Ingresarhaber(bool obligatorio = true)
            {
                decimal haber = 0;
                Console.WriteLine("Ingrese H-para saldo acreedor-");
                var tecla = Console.ReadKey(intercept: true);
                if (tecla.Key == ConsoleKey.D)
                {
                    Console.WriteLine("Debe");
                    var eleccion = Console.ReadLine();
                    if (!decimal.TryParse(eleccion, out haber))
                    {
                        Console.WriteLine("El importe debe ser númerico.");
                        continue;
                    }
                    else if (haber < 0)
                    {
                        Console.WriteLine("El importe debe ser mayor o igual a cero.");
                        continue;
                    }
                }



            }
        }

    }
}

