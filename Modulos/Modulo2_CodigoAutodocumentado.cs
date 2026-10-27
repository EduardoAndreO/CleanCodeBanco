using System;

namespace CleanCodeBanco
{
    // MODULO 2: CODIGO AUTODOCUMENTADO
    // Los propios nombres explican QUE hace, sin leer comentarios.
    public static class Modulo2_CodigoAutodocumentado
    {
        public static void EjecutarDemo()
        {
            ImprimirTituloDelModulo();

            // ---------- CODIGO SUCIO ----------
            Console.WriteLine("[SUCIO] ValidadorDeRetirosSucio.P(...)");
            Console.WriteLine("  El metodo se llama 'P'. Los parametros son s, r y l.");
            Console.WriteLine("  Sin los comentarios seria imposible saber que hace.");

            var validadorSucio = new ValidadorDeRetirosSucio();
            bool esRetiroPosibleSegunCodigoSucio =
                validadorSucio.P(s: 500m, r: 200m, l: 300m);

            Console.WriteLine("  P(500, 200, 300) devuelve: " + esRetiroPosibleSegunCodigoSucio);
            Console.WriteLine("  ... pero quien lee 'P' no sabe si es de PERMITIR o de PESIMO.");
            Console.WriteLine();

            // ---------- CODIGO LIMPIO ----------
            Console.WriteLine("[LIMPIO] ValidadorDeRetiros.ElRetiroEsValido(...)");
            Console.WriteLine("  El nombre del metodo y de los parametros explican todo.");
            Console.WriteLine("  Se entiende SIN leer ningun comentario.");

            var validadorLimpio = new ValidadorDeRetiros();
            bool esRetiroValidoSegunCodigoLimpio =
                validadorLimpio.ElRetiroEsValido(
                    saldoDisponible: 500m,
                    montoSolicitado: 200m,
                    limitePorOperacion: 300m);

            Console.WriteLine("  ElRetiroEsValido(500, 200, 300) devuelve: " + esRetiroValidoSegunCodigoLimpio);
            Console.WriteLine();

            Console.WriteLine("CONCLUSION: el comentario describia un problema que los");
            Console.WriteLine("buenos nombres resuelven solos. Comentario que sobra,");
            Console.WriteLine("nombre que falta.");
        }

        private static void ImprimirTituloDelModulo()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" MODULO 2: CODIGO AUTODOCUMENTADO");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }

    // VERSION SUCIA: necesita los comentarios para poder entenderse.
    public class ValidadorDeRetirosSucio
    {
        // s = saldo de la cuenta
        // r = monto que el cliente quiere retirar
        // l = limite maximo permitido por operacion
        public bool P(decimal s, decimal r, decimal l)
        {
            if (r > l)
            {
                return false; // se pasa del limite
            }

            if (r > s)
            {
                return false; // no hay saldo suficiente
            }

            if (r <= 0)
            {
                return false; // monto invalido
            }

            return true; // todo bien
        }
    }

    // VERSION LIMPIA: los nombres dicen TODO.
    public class ValidadorDeRetiros
    {
        public bool ElRetiroEsValido(decimal saldoDisponible, decimal montoSolicitado, decimal limitePorOperacion)
        {
            bool elMontoExcedeElLimitePorOperacion = montoSolicitado > limitePorOperacion;
            bool elMontoExcedeElSaldoDisponible = montoSolicitado > saldoDisponible;
            bool elMontoNoEsPositivo = montoSolicitado <= 0;

            bool elRetiroEsValido =
                !elMontoExcedeElLimitePorOperacion &&
                !elMontoExcedeElSaldoDisponible &&
                !elMontoNoEsPositivo;

            return elRetiroEsValido;
        }
    }
}
