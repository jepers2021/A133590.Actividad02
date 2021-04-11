using System;
using System.Collections.Generic;

namespace A133590.Actividad02
{
    class Program
    {
        static int validarEntero(string ingreso, string mensajeError)
        {
            int numero;
            bool exito = Int32.TryParse(ingreso, out numero);

            while(!exito || numero <= 0)
            {
                Console.WriteLine(mensajeError);
                Console.Write("Ingrese un número nuevamente: ");
                exito = Int32.TryParse(ingreso, out numero);
            }

            return numero;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 02");

            Dictionary<int, int> operadores = new Dictionary<int, int>();
            Queue<int> ordenes = new Queue<int>();

            Dictionary<int, int> operadoresYordenes = new Dictionary<int, int>();

            while(true)
            {
                Console.WriteLine("1) Dar de alta cierta cantidad de operadores.");
                Console.WriteLine("2) Ingresar nuevas ordenes de trabajo.");
                Console.WriteLine("3) Asignar ordenes de trabajo a operadores.");
                Console.WriteLine("4) Salir");
                Console.Write("Ingrese una opcion: ");
                int opcion;
                bool exito = Int32.TryParse(Console.ReadLine(), out opcion);
                while(!exito || opcion < 1 || opcion > 4)
                {
                    Console.Write("Opción incorrecta, ingrese una opción válida: ");
                    exito = Int32.TryParse(Console.ReadLine(), out opcion);
                }

                switch(opcion)
                {
                    case 1:
                        {
                            Console.Write("Ingrese el número de operadores que desea dar de alta: ");
                            int numOperadores = validarEntero(Console.ReadLine(), "Número de operadores inválido");
                            for(int i = 0; i < numOperadores; i++)
                            {
                                Console.Write("Ingrese el número del operador: ");
                                int operador;
                                exito = Int32.TryParse(Console.ReadLine(), out operador);
                                while(!exito || operador <= 0)
                                {
                                    Console.Write("Ingreso inválido, ingrese otro número de operador: ");
                                    exito = Int32.TryParse(Console.ReadLine(), out operador);
                                }
                                if(operadores.ContainsKey(operador))
                                {
                                    Console.WriteLine("Número de operador ya existente. Intente nuevamente");
                                    i--;
                                }

                                operadores.Add(operador,0);
                            }
                            if(numOperadores == 1)
                            {
                                Console.WriteLine("Operador registrado exitosamente.");
                            }else
                            {
                                Console.WriteLine($"Se registraron exitosamente {numOperadores} operadores.");
                            }
                            
                        }
                        break;

                    case 2:
                        {
                            Console.Write("Ingrese el número de ordenes que desea ingresar: ");
                            int numOrdenes = validarEntero(Console.ReadLine(), "Número de ordenes inválido");
                            for (int i = 0; i < numOrdenes; i++)
                            {
                                Console.Write("Ingrese el número de orden: ");
                                int orden;
                                exito = Int32.TryParse(Console.ReadLine(), out orden);
                                while (!exito || orden <= 0)
                                {
                                    Console.Write("Ingreso inválido, ingrese otro número de orden: ");
                                    exito = Int32.TryParse(Console.ReadLine(), out orden);
                                }
                                if (ordenes.Contains(orden))
                                {
                                    Console.WriteLine("Número de orden ya existente. Intente nuevamente");
                                    i--;
                                }

                                ordenes.Enqueue(orden);
                            }
                            if (numOrdenes == 1)
                            {
                                Console.WriteLine("Orden ingresada exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine($"Se registraron exitosamente {numOrdenes} ordenes.");
                            }

                        }
                        break;

                    case 3:
                        {
                            Console.Write("Ingrese el número del operador: ");
                            int operador;
                            exito = Int32.TryParse(Console.ReadLine(), out operador);
                            while(!exito || operador <= 0)
                            {
                                Console.Write("Número de operador inválido, ingrese un número de operador válido: ");
                                exito = Int32.TryParse(Console.ReadLine(), out operador);
                            }
                            if(!operadores.ContainsKey(operador))
                            {
                                Console.WriteLine($"El operador {operador} no existe.");
                                continue;
                            }

                            if (operadoresYordenes.ContainsKey(operador))
                            {
                                Console.WriteLine($"Orden {operadoresYordenes[operador]} finalizada.");
                                operadores[operador]++;
                            }

                            if (ordenes.Count == 0)
                            {
                                Console.WriteLine($"Operador {operador} existe pero no hay ordenes disponibles.");
                                operadoresYordenes.Remove(operador);
                                continue;
                            }

                            operadoresYordenes[operador] = ordenes.Dequeue();

                            Console.WriteLine($"Orden {operadoresYordenes[operador]} asignada a {operador}.");


                        }
                        break;

                    case 4:
                        {
                            
                            foreach(int operador in operadores.Keys)
                            {
                                
                                Console.WriteLine($"Operador: {operador}, Ordenes: {operadores[operador]}.");
                            }

                            Console.WriteLine("Ordenes pendientes: ");
                            while(ordenes.Count > 0)
                            {
                                Console.WriteLine(ordenes.Dequeue());
                            }
                            foreach(int operador in operadoresYordenes.Keys)
                            {
                                Console.WriteLine(operadoresYordenes[operador]);
                            }
                        }

                        Console.WriteLine("Presione cualquier tecla para continuar..");
                        Console.ReadKey();
                        return;
                }
            }
        }
    }
}
