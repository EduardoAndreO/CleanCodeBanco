using System;
using System.Text;

namespace CleanCodeBanco
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ImprimirEncabezadoInicial();

            bool elUsuarioQuiereSeguir = true;

            while (elUsuarioQuiereSeguir)
            {
                MostrarMenu();
                string opcionElegida = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (opcionElegida)
                {
                    case "1":
                        Modulo1_CodigoZombie.EjecutarDemo();
                        break;
                    case "2":
                        Modulo2_CodigoAutodocumentado.EjecutarDemo();
                        break;
                    case "3":
                        Modulo3_NombresConIntencion.EjecutarDemo();
                        break;
                    case "4":
                        Modulo4_EvitarDesinformacion.EjecutarDemo();
                        break;
                    case "5":
                        Modulo5_NombresPronunciables.EjecutarDemo();
                        break;
                    case "6":
                        EjecutarTodosLosDemos();
                        break;
                    case "0":
                        elUsuarioQuiereSeguir = false;
                        Console.WriteLine("Gracias por ver la demo. Fin del programa.");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida. Escriba un numero del 0 al 6.");
                        break;
                }

                if (elUsuarioQuiereSeguir)
                {
                    PausarHastaPresionarEnter();
                }
            }
        }

        private static void ImprimirEncabezadoInicial()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("  CLEAN CODE EN UN BANCO - PRINCIPIOS Y NOMBRES");
            Console.WriteLine("  Tarea Semana 2 - Codigo sucio vs. codigo limpio");
            Console.WriteLine("==================================================");
        }

        private static void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("------------------- MENU -------------------------");
            Console.WriteLine(" 1. Codigo zombie (codigo muerto)");
            Console.WriteLine(" 2. Codigo autodocumentado");
            Console.WriteLine(" 3. Nombres que revelan sus intenciones");
            Console.WriteLine(" 4. Evitar desinformacion y distinciones con sentido");
            Console.WriteLine(" 5. Nombres pronunciables y buscables");
            Console.WriteLine(" 6. Ejecutar TODOS los demos en secuencia");
            Console.WriteLine(" 0. Salir");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Elija una opcion: ");
        }

        private static void EjecutarTodosLosDemos()
        {
            Modulo1_CodigoZombie.EjecutarDemo();
            Console.WriteLine();
            Modulo2_CodigoAutodocumentado.EjecutarDemo();
            Console.WriteLine();
            Modulo3_NombresConIntencion.EjecutarDemo();
            Console.WriteLine();
            Modulo4_EvitarDesinformacion.EjecutarDemo();
            Console.WriteLine();
            Modulo5_NombresPronunciables.EjecutarDemo();
        }

        private static void PausarHastaPresionarEnter()
        {
            Console.WriteLine();
            Console.Write("Presione ENTER para volver al menu...");
            Console.ReadLine();
        }
    }
}
