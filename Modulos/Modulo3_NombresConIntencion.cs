using System;

namespace CleanCodeBanco
{
    // MODULO 3: USAR NOMBRES QUE REVELEN SUS INTENCIONES
    // Un nombre debe responder: POR QUE existe? QUE hace? COMO se usa?
    public static class Modulo3_NombresConIntencion
    {
        public static void EjecutarDemo()
        {
            ImprimirTituloDelModulo();

            // ---------- CODIGO SUCIO ----------
            Console.WriteLine("[SUCIO] InteresSucio.CI(c, d, t)");
            Console.WriteLine("  c? d? t? Nadie sabe que significan esas letras.");
            Console.WriteLine("  Para usarlo hay que abrir el codigo y adivinar.");

            var interesSucio = new InteresSucio();
            decimal resultadoDelCodigoSucio = interesSucio.CI(1000m, 30, 5m);
            Console.WriteLine("  CI(1000, 30, 5) devuelve: " + resultadoDelCodigoSucio);
            Console.WriteLine("  Es 1000 el capital? Es 5 una tasa? Un factor? Nadie lo sabe.");
            Console.WriteLine();

            // ---------- CODIGO LIMPIO ----------
            Console.WriteLine("[LIMPIO] CalculadoraDeInteres.CalcularInteresGenerado(...)");
            Console.WriteLine("  Cada nombre declara su intencion, ademas se usan");
            Console.WriteLine("  argumentos nombrados para que la llamada se lea sola.");

            const decimal CAPITAL_DEL_DEPOSITO = 1000m;
            const int DIAS_QUE_DURA_EL_PLAZO = 30;
            const decimal TASA_DE_INTERES_ANUAL_PORCENTUAL = 5m;

            var calculadoraDeInteres = new CalculadoraDeInteres();
            decimal interesGanado = calculadoraDeInteres.CalcularInteresGenerado(
                capital: CAPITAL_DEL_DEPOSITO,
                diasDelPlazo: DIAS_QUE_DURA_EL_PLAZO,
                tasaInteresAnualPorcentual: TASA_DE_INTERES_ANUAL_PORCENTUAL);

            Console.WriteLine("  Interes ganado por el plazo fijo: " + interesGanado);
            Console.WriteLine();

            Console.WriteLine("CONCLUSION: con nombres con intencion, la llamada al metodo");
            Console.WriteLine("se lee como una frase: 'calcule el interes generado por un");
            Console.WriteLine("capital de 1000 durante 30 dias al 5% anual'.");
        }

        private static void ImprimirTituloDelModulo()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" MODULO 3: NOMBRES QUE REVELAN INTENCIONES");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }

    // VERSION SUCIA: nombres de una letra.
    public class InteresSucio
    {
        public decimal CI(decimal c, int d, decimal t)
        {
            return c * t * d / 365 / 100;
        }
    }

    // VERSION LIMPIA: cada parametro dice por que existe.
    public class CalculadoraDeInteres
    {
        public decimal CalcularInteresGenerado(decimal capital, int diasDelPlazo, decimal tasaInteresAnualPorcentual)
        {
            decimal interesGenerado = capital * tasaInteresAnualPorcentual * diasDelPlazo / 365 / 100;
            return interesGenerado;
        }
    }
}
