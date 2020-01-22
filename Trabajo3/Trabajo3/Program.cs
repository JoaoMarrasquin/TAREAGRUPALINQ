using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo3
{
    class Program
    {
        static void Main(string[] args)
        {

            int opcion;
            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(){ID= 1, Nombre= "Juan"},
                new Cliente(){ID= 2, Nombre= "Dayana"},
                new Cliente(){ID= 3, Nombre= "Steven"},
                new Cliente(){ID= 4, Nombre= "Carlos"},
                new Cliente(){ID= 5, Nombre= "Andres"},
                new Cliente(){ID= 6, Nombre= "Emmanuel"},
                new Cliente(){ID= 7, Nombre= "Laura"},
                new Cliente(){ID= 8, Nombre= "Adiela"},
                new Cliente(){ID= 9, Nombre= "Daniel"},
                new Cliente(){ID= 10, Nombre= "Adonis"},
            };

            List<Factura> facturas = new List<Factura>()
            {
                new Factura(){Observacion= "Plato" ,Fecha= "11-02-2019",Total= 10000, IDcliente=1},
                new Factura(){Observacion= "Auto" ,Fecha= "02-20-2019",Total= 5000, IDcliente=2},
                new Factura(){Observacion= "Comida" ,Fecha= "10-05-2020",Total= 4000, IDcliente=3},
                new Factura(){Observacion= "Ropa" ,Fecha= "21-05-2018",Total= 11000, IDcliente=4},
                new Factura(){Observacion= "Ropa" ,Fecha= "14-01-2018",Total= 9000, IDcliente=5},
                new Factura(){Observacion= "Plato" ,Fecha= "15-12-2020",Total= 6000, IDcliente=6},
                new Factura(){Observacion= "Comida" ,Fecha= "12-12-2019",Total= 7000, IDcliente=7},
                new Factura(){Observacion= "Comida" ,Fecha= "14-06-2020",Total= 1000, IDcliente=8},
                new Factura(){Observacion= "Plato" ,Fecha= "12-10-2016",Total= 2000, IDcliente=9},
                new Factura(){Observacion= "Ropa" ,Fecha= "14-03-2017",Total= 8000, IDcliente=10},
            };
            do
            {
                Console.Clear();
                Console.WriteLine("----------MENU DE OPCIONES----------");
                Console.WriteLine("1.-LOS TRES CLIENTES CON MAYOR VENTA"+
                    "\n2.-LOS TRES CLIENTES CON MENOR VENTA" +
                    "\n3.-CLIENTES Y SUS RESPECTIVA VENTA" +
                    "\n4.-CLIENTE CON MAYOR VENTA DE TODOS" +
                    "\n5.-CLIENTE CON OBSERVACION PLATO" +
                    "\n6.-VENTAS EN EL AÑO 2019" +
                    "\n7.-VENTA MAS ANTIGUA" +
                    "\n8.-SALIR");
                Console.WriteLine("\n----------DIGITE UNA DE LAS OPCIONES----------\n");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nCLIENTE CON LAS 3 MAYORES VENTAS");
                        var mayorventa = from cliente in clientes
                                         join factura in facturas.Where(x => x.Total > 8000) on cliente.ID equals factura.IDcliente
                                         select new { Nombre = cliente.Nombre, Ventamayor = factura.Total };

                        mayorventa.ToList().ForEach(x =>
                        {
                            Console.WriteLine("Nombre= {0}    Venta {1}\n", x.Nombre, x.Ventamayor);
                        });
                        break;

                    case 2:
                        Console.WriteLine("\nCLIENTE CON LAS 3 MENORES VENTAS");

                        var menorventa = from cliente in clientes
                                         join factura in facturas.Where(x => x.Total <= 4000) on cliente.ID equals factura.IDcliente
                                         select new { Nombre = cliente.Nombre, Ventamenor = factura.Total };

                        menorventa.ToList().ForEach(x =>
                        {
                            Console.WriteLine("Nombre= {0}    Venta {1}\n", x.Nombre, x.Ventamenor);
                        });
                        break;
                    case 3:
                        Console.WriteLine("\nCLIENTES Y SUS RESPECTIVAS VENTAS");

                        var ventaporcliente = from cliente in clientes
                                              join factura in facturas on cliente.ID equals factura.IDcliente
                                              select new { Nombre = cliente.Nombre, Venta = factura.Total };

                        ventaporcliente.ToList().ForEach(x =>
                        {
                            Console.WriteLine("Nombre del cliente= {0}      Venta= {1}\n", x.Nombre, x.Venta);
                        });

                        break;
                    case 4:
                        Console.WriteLine("\nCLIENTE CON MAYOR VENTA");

                        var ventatotalmayor = from cliente in clientes

                                              join factura in facturas on cliente.ID equals factura.IDcliente
                                              where cliente.Nombre.ToUpper() == "Carlos".ToUpper()
                                              group cliente by factura.Total into resumen
                                              select new { ventas = resumen.Key, Nombre = (from res in resumen select res.Nombre.ToString()).Max() };

                        ventatotalmayor.ToList().ForEach(x =>
                        {
                            Console.WriteLine("Nombre= {0}    Venta= {1}\n", x.Nombre, x.ventas);
                        });
                        break;
                    case 5:
                        Console.WriteLine("\nCLIENTES CON OBSERVACION PLATO");

                        var observacionplato = from cliente in clientes
                                               join factura in facturas on cliente.ID equals factura.IDcliente
                                               where factura.Observacion == "Plato"
                                               select new { Nombre = cliente.Nombre, Observacion = factura.Observacion };

                        observacionplato.ToList().ForEach(x =>
                        {
                            Console.WriteLine("Nombre = {0}     Observacion = {1}\n", x.Nombre, x.Observacion);
                        });
                        break;
                    case 6:
                        Console.WriteLine("\nVENTAS DEL AÑO 2019");

                        var venta2019 = from cliente in clientes
                                        join factura in facturas on cliente.ID equals factura.IDcliente
                                        where factura.Fecha.Contains("2019")
                                        select new { Nombre = cliente.Nombre, Venta = factura.Total, Fecha = factura.Fecha };
                        venta2019.ToList().ForEach(x =>
                        {
                            Console.WriteLine("Nombre= {0}   Venta= {1}    Fecha= {2}\n", x.Nombre, x.Venta, x.Fecha);
                        });
                        break;
                    case 7:
                        Console.WriteLine("\nLA VENTA MÁS ANTIGUA");

                        var ventaantigua = from cliente in clientes
                                           join factura in facturas on cliente.ID equals factura.IDcliente
                                           where factura.Fecha.Contains("2016")
                                           select new { Nombre = cliente.Nombre, Venta = factura.Total, Fecha = factura.Fecha };
                        ventaantigua.ToList().ForEach(x =>
                        {
                            Console.WriteLine("Nombre= {0}   Venta= {1}     Fecha= {2}\n", x.Nombre, x.Venta, x.Fecha);
                        });
                        break;
                    case 8:
                        Console.WriteLine("\nFIN DE LOS EJERCICIOS\n");
                        break;
                    default:
                        Console.WriteLine("\nINGRESE UNA OPCION VALIDA\n");
                        break;
                }
                Console.ReadKey();
            } while (opcion !=8);
        }
    }
}
