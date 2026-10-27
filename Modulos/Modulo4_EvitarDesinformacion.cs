using System;
using System.Collections.Generic;

namespace CleanCodeBanco
{
    // MODULO 4: EVITAR LA DESINFORMACION Y HACER DISTINCIONES CON SENTIDO
    // A) DESINFORMAR: llamar 'cuentasArray' a una List<string>.
    // B) DISTINGUIR SIN SENTIDO: cuentaInfo, cuentaData, cuenta2.
    public static class Modulo4_EvitarDesinformacion
    {
        public static void EjecutarDemo()
        {
            ImprimirTituloDelModulo();

            // ---------- CODIGO SUCIO ----------
            Console.WriteLine("[SUCIO] Tres desinformaciones clasicas (ver archivo):");
            Console.WriteLine("  1) 'List<string> cuentasArray' -> no es un Array, es una List");
            Console.WriteLine("  2) cuentaInfo / cuentaData / cuenta2 -> tres nombres,");
            Console.WriteLine("     cero diferencia con sentido");
            Console.WriteLine("  3) ObtenerCuentasMorosas() devuelve TODAS las cuentas: el");
            Console.WriteLine("     nombre miente sobre lo que hace");
            Console.WriteLine();

            var gestorSucio = new GestorDeCuentasSucio();
            List<string> supuestasCuentasMorosas = gestorSucio.ObtenerCuentasMorosas();
            Console.WriteLine("  ObtenerCuentasMorosas() devolvio: "
                + string.Join(", ", supuestasCuentasMorosas));
            Console.WriteLine("  El programador que confie en ese nombre tomara");
            Console.WriteLine("  decisiones equivocadas. Eso es desinformar.");
            Console.WriteLine();

            // ---------- CODIGO LIMPIO ----------
            Console.WriteLine("[LIMPIO] Nombres veraces + distinciones por rol:");
            var gestorLimpio = new GestorDeCuentas();

            List<string> cuentasVerdaderamenteMorosas = gestorLimpio.ObtenerCuentasMorosas();
            Console.WriteLine("  ObtenerCuentasMorosas() devuelve SOLO morosas: "
                + (cuentasVerdaderamenteMorosas.Count == 0 ? "(ninguna, lista vacia honesta)" : string.Join(", ", cuentasVerdaderamenteMorosas)));

            // Distincion CON sentido: cada nombre describe su rol en la historia.
            string cuentaOrigen = "CTA-001";
            string cuentaDestino = "CTA-002";
            decimal montoATransferir = 250m;

            bool laTransferenciaFueRegistrada = gestorLimpio.RegistrarTransferencia(
                cuentaOrigen, cuentaDestino, montoATransferir);

            Console.WriteLine("  Transferencia " + cuentaOrigen + " -> " + cuentaDestino
                + " por " + montoATransferir + ": registrada = " + laTransferenciaFueRegistrada);
            Console.WriteLine();

            Console.WriteLine("CONCLUSION: un nombre que miente es peor que un nombre feo.");
            Console.WriteLine("Y solo se distingue entre nombres cuando la diferencia");
            Console.WriteLine("tiene un significado real (origen/destino), no por estetica.");
        }

        private static void ImprimirTituloDelModulo()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine(" MODULO 4: EVITAR DESINFORMACION Y");
            Console.WriteLine("           DISTINCIONES CON SENTIDO");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }

    // VERSION SUCIA: nombres que mienten y distinciones vacias.
    public class GestorDeCuentasSucio
    {
        // DESINFORMACION: se llama "Array" pero es una List<string>.
        private List<string> cuentasArray = new List<string>();

        public GestorDeCuentasSucio()
        {
            cuentasArray.Add("CTA-001");
            cuentasArray.Add("CTA-002");
            cuentasArray.Add("CTA-003");
        }

        // DISTINCIONES SIN SENTIDO: las tres variables guardan lo mismo.
        public void DemostrarDistincionesSinSentido()
        {
            string cuentaInfo = "CTA-001";
            string cuentaData = "CTA-002";
            string cuenta2 = "CTA-003";
            Console.WriteLine(cuentaInfo + cuentaData + cuenta2);
        }

        // DESINFORMACION: el nombre promete 'morosas' pero devuelve TODAS.
        public List<string> ObtenerCuentasMorosas()
        {
            return cuentasArray; // MIENTE: incluye cuentas al dia
        }
    }

    // VERSION LIMPIA: nombres veraces y distinciones con significado.
    public class GestorDeCuentas
    {
        private List<string> cuentasRegistradas = new List<string>();

        public GestorDeCuentas()
        {
            cuentasRegistradas.Add("CTA-001"); // cuenta al dia
            cuentasRegistradas.Add("CTA-002"); // cuenta al dia
            cuentasRegistradas.Add("CTA-003"); // cuenta morosa
        }

        public List<string> ObtenerTodasLasCuentas()
        {
            return cuentasRegistradas;
        }

        // Ahora el nombre CUMPLE lo que promete: solo las morosas.
        public List<string> ObtenerCuentasMorosas()
        {
            const string NUMERO_DE_CUENTA_MOROSA = "CTA-003";
            List<string> cuentasMorosas = new List<string>();

            foreach (string cuenta in cuentasRegistradas)
            {
                bool laCuentaEsMorosa = cuenta == NUMERO_DE_CUENTA_MOROSA;
                if (laCuentaEsMorosa)
                {
                    cuentasMorosas.Add(cuenta);
                }
            }

            return cuentasMorosas;
        }

        // Distincion CON sentido: origen y destino tienen roles distintos.
        public bool RegistrarTransferencia(string cuentaOrigen, string cuentaDestino, decimal montoATransferir)
        {
            bool elMontoEsPositivo = montoATransferir > 0;
            bool lasCuentasSonDistintas = cuentaOrigen != cuentaDestino;

            return elMontoEsPositivo && lasCuentasSonDistintas;
        }
    }
}
