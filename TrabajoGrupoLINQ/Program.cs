using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoGrupoLINQ
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            int opcion = 0;
           
            //Creacion de los 50 números
            int[] numeros = new int[50]{  32 ,77,87,80,54,18,35,73,68,48,
                                          83,31,16,78,38,79,36,91,46,33,
                                          10,52,7,23,99,25,59,70,58,45,
                                          11,72,92,93,89,1,14,76,71,51,
                                          84,97,19,34,82,41,53,30 ,100 ,22,};
            

            do
            {
                Console.WriteLine("--------------------->MENU<----------------------------");
                Console.WriteLine("1) Mostrar por consola todos los números primos");
                Console.WriteLine("2) Mostrar por consola la suma de todos los elementos");
                Console.WriteLine("3) Generar una nueva lista con el cuadrado de los números");
                Console.WriteLine("4) Generar una nueva lista con los números que no son primos");
                Console.WriteLine("5) Obtener el promedio de todos los números mayores a 50");
                Console.WriteLine("6) Contar en la lista la cantidad de números pares e impares");
                Console.WriteLine("7) Mostrar por consola cada elemento y la cantidad de veces que se repite en la lista");
                Console.WriteLine("8) Mostrar en consola los elementos de forma descendente.");
                Console.WriteLine("9) Mostrar en consola los números únicos(no se repiten)");
                Console.WriteLine("10)Sumar todos los números únicos de la lista");
                Console.WriteLine("11)SALIR");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("A Elegido la Opcion 1:Mostrar números primos");
                        var Primo = from numero in numeros
                                    where (numero % 2) !=0
                                    select numero;

                        foreach (var item1 in Primo)
                        {
                            Console.WriteLine("|{0}| ", item1);
                        }

                        break;
                    case 2:
                        var Suma = from Nume in numeros
                                   select Nume;
                        Console.WriteLine("La Suma Total es   {0}", Suma.Sum());
                        break;
                    case 3:
                        Console.WriteLine("Lista de Cuadrados");
                        var Cuadrados = from Nume in numeros

                                        select Nume;
                        foreach (var item in Cuadrados)
                        {

                            Console.WriteLine(item * item);
                        }
                        break;
                    case 4:
                        var NoPrimo = from numero in numeros
                                    where (numero % 2) == 0
                                    select numero;

                        foreach (var item1 in NoPrimo)
                        {
                            Console.WriteLine("|{0}| ", item1);
                        }
                        break;
                    case 5:
                        var Promedio50 = from Nume in numeros     
                                        where Nume > 50
                                        select Nume;
                        Console.WriteLine("El promedio es {0}", Promedio50.Average());
                        break;
                    case 6:
                        int par = 0;
                        int impar = 0;

                        var consulta6 = from Nume in numeros
                                        group Nume by (Nume % 2) == 0 ? par++ : impar++;

                        
                        foreach (var item in consulta6)
                        {}
                        Console.WriteLine(" pares  {0} " + " impares {1}", par, impar);
                        break;
                    case 7:
                        foreach (var registro in
                numeros.Select((v) => new { Valor = v }) 
                .GroupBy(x => x.Valor) 
                                       
                .Select(x => new {
                    Valor = x.Key, 
                    Cantidad = x.Count(), 
                }))
                        {
                            Console.WriteLine(string.Format("Valor: '{0}'\tCant. Repetidas: {1}\t", registro.Valor, registro.Cantidad));
                        }
                        break;
                    case 8:
                        
                        var Descendente = from Nume in numeros
                                           
                                        orderby Nume descending
                                        select Nume;
                       
                        foreach (var item in Descendente)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 9:
                        foreach (var registro in
  numeros.Select((v) => new { Valor = v }) 
  .GroupBy(x => x.Valor) 
  .Select(x => new {
      Valor = x.Key,

   }))
                        {
                            Console.WriteLine(string.Format("UNICO: '{0}\t", registro.Valor));
                        }
                        break;
                    case 10:
                        int suma = 0;
                        foreach (var registro in numeros.Select((v) => new { Valor = v, Valor2 = 0 }).GroupBy(x => x.Valor).Select(x => new{     Valor = x.Key}))
                        {
                           
                            suma = registro.Valor + suma;
                        }
                        Console.WriteLine("La suma es: "+suma);




                        break;


                }

            } while (opcion != 11);





























            Console.ReadKey();
        }
    }
}
