<div align="center">

# 🧪 Laboratorio: Temas Varios (Repaso del CRUD)

**Inyección SQL · Consultas Parametrizadas · Métodos Sobrecargados · Recursividad · Frecuencias**

**Universidad Tecnológica de Panamá**
Facultad de Ingeniería en Sistemas Computacionales · Campus Víctor Levi Sasso
Herramientas de la Programación Aplicada III (.NET)

| | |
|---|---|
| **Estudiante** | Elvis Li |
| **Cédula** | 8-1028-139 |
| **Grupo** | 1IL133 |
| **Instructora** | Ing. Irina Fong |
| **Módulo** | IV – Acceso a Base de Datos: Aplicaciones en Capas |
| **Fecha de entrega** | 05 de octubre de 2026 |

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-14-239120?logo=csharp&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?logo=mysql&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?logo=visualstudio&logoColor=white)

</div>

---

## 📑 Tabla de contenido

1. [Descripción](#-descripción)
2. [Problemas resueltos](#-problemas-resueltos)
3. [Tecnologías y versiones](#-tecnologías-y-versiones)
4. [Estructura del proyecto](#-estructura-del-proyecto)
5. [Guía de instalación (onboarding)](#-guía-de-instalación-onboarding)
6. [Escenario 1: Seguridad en el CRUD y consultas parametrizadas](#-escenario-1-seguridad-en-el-crud-y-consultas-parametrizadas)
7. [Escenario 2: Métodos sobrecargados y recursividad](#-escenario-2-métodos-sobrecargados-y-recursividad)
8. [Escenario 3: Análisis de frecuencias](#-escenario-3-análisis-de-frecuencias)
9. [Conclusiones](#-conclusiones)
10. [Referencias](#-referencias)
11. [Autor](#-autor)

---

## 📌 Descripción

Repositorio con los ejercicios del laboratorio de repaso, organizados en tres escenarios técnicos:

- **Escenario 1:** construcción dinámica de sentencias `INSERT` y `UPDATE` mediante manipulación de cadenas, demostración de **inyección SQL** sobre la base de datos `productosdb` y su mitigación con **consultas parametrizadas**.
- **Escenario 2:** clase `SobreCarga` con el método `Cuadrado` sobrecargado para `int` y `double`, y cálculo del **factorial (n!)** del 0 al 10 de forma recursiva.
- **Escenario 3:** simulación de **6000 tiros de un dado** que contabiliza la frecuencia con la que sale cada cara.

**Objetivo:** reforzar las buenas prácticas de seguridad en el acceso a datos y los fundamentos de programación orientada a objetos y algoritmos en C#.

**Arquitectura:** cada ejercicio es una aplicación de consola .NET independiente, en su propia carpeta, para poder ejecutarlo y probarlo por separado.

---

## 📋 Problemas resueltos

| N.º | Problema | Escenario | Carpeta |
|---|---|---|---|
| 1 | Consultas SQL (3) | Escenario 1 | `SQL/` |
| 2 | Generación de cadenas `INSERT`/`UPDATE` y consultas parametrizadas | Escenario 1 | `SQL/` |
| 3 | Métodos sobrecargados | Escenario 2 | `SobreCarga/` |
| 4 | Recursividad: factorial (n!) | Escenario 2 | `Factorial/` |
| 5 | Análisis de frecuencias | Escenario 3 | `Frecuencias/` |

---

## 🛠 Tecnologías y versiones

| Tecnología | Versión |
|---|---|
| .NET SDK | `10.0` |
| C# | `14` |
| IDE | Visual Studio 2022 / Visual Studio Code |
| Base de datos | MySQL 8.0 (`productosdb`) |
| Sistema operativo | Windows 11 |

> Verifica tu versión con: `dotnet --version`
>
> El ejercicio de sobrecarga se ejecuta como **aplicación de un solo archivo** (`dotnet run SobreCarga.cs`), función disponible desde **.NET 10**.

---

## 📂 Estructura del proyecto

```
📦 LabTemaVarios-HPAIII
 ┣ 📂 Factorial
 ┃ ┣ 📜 Program.cs
 ┃ ┗ 📜 Factorial.csproj
 ┣ 📂 SobreCarga
 ┃ ┗ 📜 SobreCarga.cs
 ┣ 📂 Frecuencias
 ┃ ┣ 📜 Program.cs
 ┃ ┗ 📜 Frecuencias.csproj
 ┣ 📂 SQL
 ┃ ┗ 📜 consultas.sql
 ┣ 📂 img
 ┃ ┣ 🖼 problema1.png
 ┃ ┗ 🖼 problema2.png
 ┗ 📜 README.md
```

---

## 🚀 Guía de instalación (onboarding)

### Requisitos previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Git](https://git-scm.com/)
- [MySQL 8.0](https://dev.mysql.com/downloads/) (solo para el Escenario 1)
- Visual Studio 2022 o Visual Studio Code con la extensión C# Dev Kit

### Pasos

**1. Clonar el repositorio**

```bash
git clone https://github.com/lielvis22/LabTemaVarios-HPAIII.git
cd LabTemaVarios-HPAIII
```

**2. Restaurar dependencias**

```bash
dotnet restore Factorial
dotnet restore Frecuencias
```

**3. Ejecutar cada ejercicio**

```bash
# Problema 3: Métodos sobrecargados (archivo único)
cd SobreCarga
dotnet run SobreCarga.cs
cd ..

# Problema 4: Factorial recursivo
dotnet run --project Factorial

# Problema 5: Frecuencias
dotnet run --project Frecuencias
```

**Alternativa con Visual Studio:** abrir el `.csproj` (o `.sln`/`.slnx`) del ejercicio y presionar `Ctrl + F5`.

---

## 🔐 Escenario 1: Seguridad en el CRUD y consultas parametrizadas

### Construcción de sentencias por concatenación (inseguro)

```csharp
public static string ArmarInsert(string nombre, decimal precio)
{
    return "INSERT INTO productos (nombre, precio) VALUES ('" + nombre + "', " + precio + ")";
}

public static string ArmarUpdate(int id, string nombre)
{
    return $"UPDATE productos SET nombre = '{nombre}' WHERE id = {id}";
}
```

### Demostración de inyección SQL

Si el usuario escribe como nombre:

```
x', 0); DROP TABLE productos; --
```

La sentencia generada queda así:

```sql
INSERT INTO productos (nombre, precio) VALUES ('x', 0); DROP TABLE productos; --', 12)
```

El motor ejecutaría el `INSERT` y luego **eliminaría la tabla**, porque el texto ingresado se interpreta como código SQL.

### Mitigación: consultas parametrizadas

```csharp
using var cmd = new MySqlCommand(
    "INSERT INTO productos (nombre, precio) VALUES (@nombre, @precio)", conexion);
cmd.Parameters.AddWithValue("@nombre", nombre);
cmd.Parameters.AddWithValue("@precio", precio);
cmd.ExecuteNonQuery();
```

Con parámetros, el valor se envía **como dato y no como código**, por lo que la entrada maliciosa se guarda literalmente como texto y no se ejecuta.

### Consultas SQL

```sql
USE productosdb;

-- 1. Inyección para forzar la devolución de todos los datos (bypass lógico)
SELECT * FROM productos WHERE nombre = '' OR '1'='1';

-- 2. Inyección basada en tiempo (pausa la respuesta 1 segundo por cada fila evaluada)
SELECT * FROM productos WHERE id = 14 - SLEEP(1);

-- 3. Inyección mediante comentario (anula las condiciones posteriores de la consulta)
SELECT * FROM productos WHERE nombre = 'Yuca'; -- ' AND precio = '12';
```

| Consulta | Técnica | Efecto |
|---|---|---|
| 1 | Bypass lógico | `'1'='1'` siempre es verdadero, así que devuelve **todos** los productos. |
| 2 | Basada en tiempo | `SLEEP()` retrasa la respuesta; el atacante deduce información por el tiempo de espera. |
| 3 | Comentario | `--` convierte en comentario la condición de `precio`, que nunca se evalúa. |

### 📸 Evidencia

**Problema 1: Consultas SQL**

Consulta 1
<img width="440" height="171" alt="image" src="https://github.com/user-attachments/assets/44b1d7e6-f9c8-4d09-b244-cf77b1ce5262" />

Consulta 2
<img width="432" height="142" alt="image" src="https://github.com/user-attachments/assets/b7d881c0-6c29-4339-83f2-47abf552c82f" />

Consulta 3
<img width="398" height="102" alt="image" src="https://github.com/user-attachments/assets/56afbbbf-bbb7-41a2-b211-a52d67ab3a41" />

**Problema 2: Cadenas INSERT/UPDATE y consultas parametrizadas**

![Problema 2 - Inyección SQL y consultas parametrizadas](img/problema2.png)

---

## 🧩 Escenario 2: Métodos sobrecargados y recursividad

### Métodos sobrecargados

La clase `SobreCarga` define dos métodos con el mismo nombre, `Cuadrado`, pero con distinto tipo de parámetro. El compilador elige cuál ejecutar según el tipo del argumento:

```csharp
// Ejecutar con: dotnet run SobreCarga.cs
using System;
using SobreCargaMetodos;

SobreCarga varSobreCarga = new SobreCarga();
varSobreCarga.ProbarMetodosSobreCargados();
varSobreCarga.Cuadrado(8);
Console.WriteLine("El cuadrado de {0}", varSobreCarga.Cuadrado(9));

namespace SobreCargaMetodos
{
    public class SobreCarga
    {
        /// Prueba los métodos Cuadrado sobrecargados
        public void ProbarMetodosSobreCargados()
        {
            Console.WriteLine("El cuadrado del integer 7 es {0}", Cuadrado(7));
            Console.WriteLine("El Cuadrado del double 7.5 es {0}", Cuadrado(7.5));
        }

        public int Cuadrado(int valorInt)
        {
            Console.WriteLine("Se llamó a Cuadrado con argumento int:{0}", valorInt);
            return valorInt * valorInt;
        }

        public double Cuadrado(double valorDouble)
        {
            Console.WriteLine("Se llamó a Cuadrado con argumento double:{0}", valorDouble);
            return valorDouble * valorDouble;
        }
    }
}
```

| Llamada | Método elegido | Resultado |
|---|---|---|
| `Cuadrado(7)` | `Cuadrado(int)` | 49 |
| `Cuadrado(7.5)` | `Cuadrado(double)` | 56.25 |
| `Cuadrado(8)` | `Cuadrado(int)` | 64 |
| `Cuadrado(9)` | `Cuadrado(int)` | 81 |

### Factorial recursivo

```csharp
namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cálculo del factorial del 0 al 10
            for (long contador = 0; contador <= 10; contador++)
            {
                Console.WriteLine("{0}! ={1}", contador, Factorial(contador));
            }
        }

        // Declaración recursiva del método Factorial
        public static long Factorial(long numero)
        {
            // Caso base
            if (numero <= 1)
                return 1;
            // Paso de recursividad
            else return numero * Factorial(numero - 1);
        }
    }
}
```

El **caso base** (`numero <= 1`) detiene la recursión: cada llamada reduce `numero` en 1 hasta llegar a 1 (o 0), y ahí la función deja de llamarse a sí misma, evitando un `StackOverflowException`. Como la condición es `<= 1`, también cubre `0! = 1` y los números negativos.

**Salida:**

```
0! =1
1! =1
2! =2
3! =6
4! =24
5! =120
6! =720
7! =5040
8! =40320
9! =362880
10! =3628800
```

> **Nota:** el tipo `long` soporta hasta `20!`. Para valores mayores se puede usar `System.Numerics.BigInteger`.

### 📸 Evidencia

**Problema 3: Métodos sobrecargados**

<img width="640" height="180" alt="Problema 3 - Métodos sobrecargados" src="https://github.com/user-attachments/assets/69fd9d4d-77c6-4b7d-88c6-f577d323bed4" />

**Problema 4: Factorial recursivo**

<img width="667" height="297" alt="Problema 4 - Factorial recursivo" src="https://github.com/user-attachments/assets/d2674263-e0c7-4b4a-b748-6653d6dc9de7" />

---

## 📊 Escenario 3: Análisis de frecuencias

El programa simula **6000 tiros de un dado** con `Random.Next(1, 7)` y usa un `switch` para incrementar el contador de la cara que salió:

```csharp
Random numerosAleatorios = new Random();

int frecuencia1 = 0;
int frecuencia2 = 0;
int frecuencia3 = 0;
int frecuencia4 = 0;
int frecuencia5 = 0;
int frecuencia6 = 0;

int cara; // Almacena el último valor que se tiró

for (int tiro = 1; tiro <= 6000; tiro++)
{
    // Números del 1 al 6
    cara = numerosAleatorios.Next(1, 7);

    // Determina el valor del tiro e incrementa el contador apropiado
    switch (cara)
    {
        case 1: frecuencia1++; break;
        case 2: frecuencia2++; break;
        case 3: frecuencia3++; break;
        case 4: frecuencia4++; break;
        case 5: frecuencia5++; break;
        case 6: frecuencia6++; break;
        default:
            Console.WriteLine("hubo un error de entrada");
            break;
    }
}

Console.WriteLine("Cara \t Frecuencia");
Console.WriteLine("1\t{0}\n2\t{1}\n3\t{2}\n4\t{3}\n5\t{4}\n6\t{5}",
    frecuencia1, frecuencia2, frecuencia3, frecuencia4, frecuencia5, frecuencia6);
```

**Ejemplo de salida** (los valores cambian en cada ejecución porque los tiros son aleatorios):

```
Cara     Frecuencia
1        1003
2        987
3        1012
4        996
5        1020
6        982
```

Como el dado es justo, cada cara tiende a salir cerca de **1000 veces** (6000 ÷ 6). La suma de las seis frecuencias siempre es 6000.

### 📸 Evidencia

**Problema 5: Análisis de frecuencias**

<img width="683" height="175" alt="Problema 5 - Frecuencias" src="https://github.com/user-attachments/assets/be9bffd0-2057-466a-882e-23f3626ee763" />

---

## ✅ Conclusiones

- **Inyección SQL:** concatenar la entrada del usuario directamente en una sentencia SQL permite alterar la lógica de la consulta, como se vio con el bypass `'1'='1'`, el retardo con `SLEEP()` y los comentarios `--`. Las consultas parametrizadas eliminan este riesgo porque el motor trata los valores como datos y nunca como código.
- **Sobrecarga de métodos:** permite usar un mismo nombre (`Cuadrado`) para operaciones equivalentes sobre distintos tipos de datos. El compilador escoge la versión correcta según el tipo del argumento, lo que hace el código más legible y fácil de usar.
- **Recursividad:** el factorial se resuelve reduciendo el problema en cada llamada hasta llegar al caso base. Sin un caso base bien definido la función se llamaría indefinidamente y provocaría un desbordamiento de pila.
- **Frecuencias:** los contadores permiten resumir grandes volúmenes de datos (6000 tiros) en una tabla corta. Los resultados muestran que, con suficientes repeticiones, cada cara se acerca a la probabilidad teórica de 1/6.

---

## 📚 Referencias

- [Novedades de .NET 10 – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/core/whats-new/dotnet-10/overview)
- [Inyección SQL – OWASP](https://owasp.org/www-community/attacks/SQL_Injection)
- [Sobrecarga de métodos en C# – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/csharp/methods#method-overloading)
- [Clase Random – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/api/system.random)
- [Instrucción switch – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement)

---

## 👤 Autor

| | |
|---|---|
| **Nombre** | Elvis Li |
| **Cédula** | 8-1028-139 |
| **Correo institucional** | elvis.li@utp.ac.pa |
| **GitHub** | [@lielvis22](https://github.com/lielvis22) |
| **Institución** | Universidad Tecnológica de Panamá |
| **Carrera** | Licenciatura en Ingeniería en Sistemas Computacionales |

---

<div align="center">

**Universidad Tecnológica de Panamá** · Facultad de Ingeniería en Sistemas Computacionales
Herramientas de la Programación Aplicada III (.NET) · Grupo 1IL133
Entregado el 05/10/2026 por Elvis Li

</div>
