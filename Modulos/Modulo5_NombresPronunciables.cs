using System;

namespace CleanCodeBanco
{
    // MODULO 5: NOMBRES PRONUNCIABLES Y BUSCABLES
    // PRONUNCIABLE: si no puedes decirlo en una reunion, no puedes discutirlo.
    // BUSCABLE: buscar "30" con Ctrl+F devuelve miles de resultados inutiles;
    // buscar "DIAS_DEL_PLAZO_FIJO" devuelve exactamente lo que buscas.
    public static class Modulo5_NombresPronunciables
    {
        public static void EjecutarDemo()
        {
            ImprimirTituloDelModulo();

            // ---------- CODIGO SUCIO ----------
            Console.WriteLine("[SUCIO] Nombres impronunciables y numeros magicos:");
            Console.WriteLine("  decimal sc   -> saldo? sueldo? suma? Nadie lo pronuncia ni lo busca.");
            Console.WriteLine("  string fct   -> fecha de... cuenta? cierre? credito?");
            Console.WriteLine("  interes = sc * 30 / 365 / 100;");
            Console.WriteLine("  Que significa 30? Y 365? Y 100? Busque '30' con Ctrl+F:");
            Console.WriteLine("  el editor encontrara fechas, montos y edades... todo menos esto.");

            decimal sc = 500m;
            decimal interesDelCodigoSucio = sc * 30 / 365 / 100;
            Console.WriteLine("  Resultado del calculo confuso: " + interesDelCodigoSucio);
            Console.WriteLine();

            // ---------- CODIGO LIMPIO ----------
            Console.WriteLine("[LIMPIO] Nombres completos + constantes con nombre:");

            decimal saldoDeLaCuenta = 500m;
            const int DIAS_DEL_PLAZO_FIJO = 30;
            const int DIAS_DEL_ANO_COMERCIAL = 365;
            const int FACTOR_PARA_CONVERTIR_PORCENTAJE = 100;
            const decimal TASA_ANUAL_PORCENTUAL_DEL_PLAZO = 5m;

            decimal interesEstimadoDelPlazoFijo =
                saldoDeLaCuenta
                * TASA_ANUAL_PORCENTUAL_DEL_PLAZO
                * DIAS_DEL_PLAZO_FIJO
                / DIAS_DEL_ANO_COMERCIAL
                / FACTOR_PARA_CONVERTIR_PORCENTAJE;

            Console.WriteLine("  saldoDeLaCuenta = 500");
            Console.WriteLine("  TASA_ANUAL_PORCENTUAL_DEL_PLAZO = 5");
            Console.WriteLine("  DIAS_DEL_PLAZO_FIJO = 30");
            Console.WriteLine("  interesEstimadoDelPlazoFijo = " + interesEstimadoDelPlazoFijo);
            Console.WriteLine();

            Console.WriteLine("CONCLUSION: ahora 'DIAS_DEL_PLAZO_FIJO' se pronuncia en una");
            Console.WriteLine("reunion y se encuentra con Ctrl+F en segundos. Cambiar el");
            Console.WriteLine("plazo a 60 dias significa tocar UNA sola linea del proyecto.");
        }

        private static void ImprimirTituloDelModulo()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" MODULO 5: NOMBRES PRONUNCIABLES Y BUSCABLES");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }

    // VERSION SUCIA: nombres comprimidos y numeros magicos repetidos.
    public class PlazoFijoSucio
    {
        public decimal CalcularInteres(decimal sc, int d)
        {
            // Tres numeros magicos: 30? 365? 100?
            return sc * 5 * d / 365 / 100;
        }
    }

    // VERSION LIMPIA: las constantes viven una sola vez.
    public class PlazoFijo
    {
        private const int DIAS_DEL_ANO_COMERCIAL = 365;
        private const int FACTOR_PARA_CONVERTIR_PORCENTAJE = 100;

        public decimal CalcularInteresDelPlazoFijo(decimal saldoDeLaCuenta, int diasDelPlazoFijo, decimal tasaAnualPorcentual)
        {
            decimal interesEstimado =
                saldoDeLaCuenta * tasaAnualPorcentual * diasDelPlazoFijo / DIAS_DEL_ANO_COMERCIAL / FACTOR_PARA_CONVERTIR_PORCENTAJE;
            return interesEstimado;
        }
    }
}
