# 🏦 CleanCodeBanco — Tarea Semana 2: Clean Code, Principios y Nombramientos

Proyecto de consola en **C# (.NET 8.0)** que demuestra **5 principios de nombramiento** de *Clean Code* (Robert C. Martin). Cada principio tiene una versión **SUCIA** (principio roto) y una versión **LIMPIA** (principio aplicado), dentro de un dominio bancario: cuentas, retiros, intereses y transferencias.

> **Asignatura:** Clean Code · **Tarea:** Semana 2 · **Lenguaje:** C# · **Duración del video:** 8 min 10 s

---

## ▶️ Cómo ejecutar

```bash
cd CleanCodeBanco
dotnet run
```

**Requisitos:** SDK de .NET 8.0 (probado con `dotnet run` en Visual Studio Code y terminal).

Al ejecutar aparece un menú: elija **1–5** para ver cada principio, **6** para ejecutar todos los demos en secuencia, **0** para salir.

---

## 🗺️ Tabla de mapeo: módulo → principio → dónde mirar

| # | Principio (tema de la tarea) | Clase SUCIA | Clase LIMPIA | Error demostrado |
|:-:|------------------------------|-------------|--------------|------------------|
| **1** | Código zombie (código muerto) | `CuentaBancariaSucia` | `CuentaBancariaLimpia` | 4 zombies: bloque comentado, variable sin usar (CS0219), `if (false)`, código inalcanzable tras `return` (CS0162) |
| **2** | Código autodocumentado | `ValidadorDeRetirosSucio` | `ValidadorDeRetiros` | Método `P(s, r, l)` que depende de comentarios vs. `ElRetiroEsValido(saldoDisponible, montoSolicitado, limitePorOperacion)` |
| **3** | Nombres que revelan intención | `InteresSucio` | `CalculadoraDeInteres` | `CI(c, d, t)` — letras sin significado vs. `CalcularInteresGenerado(capital, diasDelPlazo, tasaInteresAnualPorcentual)` |
| **4** | Evitar desinformación + distinciones con sentido | `GestorDeCuentasSucio` | `GestorDeCuentas` | `cuentasArray` miente (es una `List`), `cuentaInfo/Data/2` diferencia vacía, `ObtenerCuentasMorosas()` devuelve todas vs. `cuentaOrigen` / `cuentaDestino` (distinción por rol) |
| **5** | Nombres pronunciables y buscables | `PlazoFijoSucio` | `PlazoFijo` | `sc`, `fct` impronunciables y números mágicos `30/365/100` vs. constantes `DIAS_DEL_PLAZO_FIJO`, `DIAS_DEL_ANO_COMERCIAL` |

---

---

## ✅ Checklist final de la entrega

- [ ] Ejecutar `dotnet run` y probar las **seis opciones** del menú sin errores
- [ ] Grabar el video siguiendo el guion (duración entre **5 y 10 minutos**)
- [ ] Reproducir el video completo: audio audible y código legible en pantalla
- [ ] Subir a YouTube con visibilidad **«Oculta»** (no en listado)
- [ ] Abrir el enlace en **ventana de incógnito** para confirmar que se ve
- [ ] Copiar el enlace de YouTube en el documento de entrega (no enlaces de nube)
- [ ] Adjuntar el código fuente completo, **sin las carpetas `bin` ni `obj`**
- [ ] Confirmar que este README incluye la **tabla de mapeo** módulo → principio

---

## 📁 Estructura del proyecto

```
CleanCodeBanco/
├── CleanCodeBanco.csproj            ← configuración del proyecto .NET 8.0
├── Program.cs                       ← menú interactivo de demos
├── README.md                        ← este archivo
└── Modulos/
    ├── Modulo1_CodigoZombie.cs             → código zombie
    ├── Modulo2_CodigoAutodocumentado.cs    → código autodocumentado
    ├── Modulo3_NombresConIntencion.cs      → nombres con intención
    ├── Modulo4_EvitarDesinformacion.cs     → evitar desinformación
    └── Modulo5_NombresPronunciables.cs     → pronunciables y buscables
```

Cada archivo de módulo contiene: el método `EjecutarDemo()` (imprime la comparación en pantalla), la clase **SUCIA** (con comentarios que marcan cada error) y la clase **LIMPIA** (con los nombres corregidos).

> 💡 **Consejo final:** cuando el docente interrumpa con preguntas, la respuesta más fuerte siempre está en el propio proyecto: **muestra el archivo, señala el nombre, ejecuta la demo**. Defender código es eso: no recitar teoría, sino demostrar con el proyecto abierto que cada decisión tiene una razón.
```