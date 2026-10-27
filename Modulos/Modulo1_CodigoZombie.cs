using System;

namespace CleanCodeBanco
{
    // MODULO 1: CODIGO ZOMBIE (CODIGO MUERTO)
    // Codigo que ya no se ejecuta pero sigue enterrado en el archivo.
    // La solucion real es BORRARLO: Git guarda todo por nosotros.
    public static class Modulo1_CodigoZombie
    {
        public static void EjecutarDemo()
        {
            ImprimirTituloDelModulo();

            // ---------- CODIGO SUCIO ----------
            Console.WriteLine("[SUCIO] CuentaBancariaSucia.CalcularInteresSimpleSucio");
            Console.WriteLine("  Dentro de ese metodo viven 4 zombies (ver archivo):");
            Console.WriteLine("  1) Bloque enorme comentado de una 'logica vieja'");
            Console.WriteLine("  2) Variable 'esClientePreferente' que nunca se usa");
            Console.WriteLine("  3) Un 'if (false)' que nunca puede ejecutarse");
            Console.WriteLine("  4) Lineas inalcanzables despues del return");
            Console.WriteLine();

            var cuentaSucia = new CuentaBancariaSucia();
            decimal interesCalculadoPorCodigoSucio =
                cuentaSucia.CalcularInteresSimpleSucio(
                    capital: 10000m,
                    diasDelPlazo: 30,
                    tasaAnualPorcentual: 5m);

            Console.WriteLine("  Resultado (aun funciona, pero cuesta leerlo): "
                + interesCalculadoPorCodigoSucio);
            Console.WriteLine();

            // ---------- CODIGO LIMPIO ----------
            Console.WriteLine("[LIMPIO] CuentaBancariaLimpia.CalcularInteresSimple");
            Console.WriteLine("  El mismo calculo, sin un solo zombie.");
            Console.WriteLine("  La 'logica vieja' vive en Git, no en el codigo.");

            var cuentaLimpia = new CuentaBancariaLimpia();
            decimal interesCalculadoPorCodigoLimpio =
                cuentaLimpia.CalcularInteresSimple(
                    capital: 10000m,
                    diasDelPlazo: 30,
                    tasaAnualPorcentual: 5m);

            Console.WriteLine("  Resultado: " + interesCalculadoPorCodigoLimpio);
            Console.WriteLine();

            Console.WriteLine("CONCLUSION: mismo resultado, pero el limpio se lee");
            Console.WriteLine("en 5 segundos y no deja dudas ni warnings al compilar.");
        }

        private static void ImprimirTituloDelModulo()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" MODULO 1: CODIGO ZOMBIE (CODIGO MUERTO)");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }

    // VERSION SUCIA: contiene los 4 tipos de codigo zombie.
    // Al compilar aparecera el warning CS0162 "unreachable code":
    // el propio compilador ya esta avisando que aqui hay cadaveres.
    public class CuentaBancariaSucia
    {
        public decimal CalcularInteresSimpleSucio(decimal capital, int diasDelPlazo, decimal tasaAnualPorcentual)
        {
            // ZOMBIE 1: bloque comentado de una "mejora" que nunca se aprobo.
            // decimal interesConBonus = capital * tasaAnualPorcentual / 100;
            // Console.WriteLine("Calculando interes con bonus...");
            // if (capital > 10000)
            // {
            //     interesConBonus = interesConBonus * 1.05m;
            // }
            // return interesConBonus;

            // ZOMBIE 2: variable declarada y nunca usada (warning CS0219).
            bool esClientePreferente = true;

            // ZOMBIE 3: condicion imposible. Parece codigo vivo, jamas lo hara.
            if (false)
            {
                esClientePreferente = false;
                Console.WriteLine("Este bloque nunca se ejecuta");
            }

            // Linea VIVA: el unico calculo que realmente importa.
            decimal interesGenerado = capital * tasaAnualPorcentual * diasDelPlazo / 365 / 100;
            return interesGenerado;

            // ZOMBIE 4: lineas INALCANZABLES despues del return (warning CS0162).
            Console.WriteLine("Fin del calculo");
            return 0;
        }
    }

    // VERSION LIMPIA: una sola ruta de ejecucion, cero cadaveres.
    public class CuentaBancariaLimpia
    {
        public decimal CalcularInteresSimple(decimal capital, int diasDelPlazo, decimal tasaAnualPorcentual)
        {
            decimal interesGenerado = capital * tasaAnualPorcentual * diasDelPlazo / 365 / 100;
            return interesGenerado;
        }
    }
}
