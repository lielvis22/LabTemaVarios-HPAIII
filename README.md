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
| 2 | Generación de cadenas `INSERT`/`UPDATE` y consultas parametrizadas | Escenario 1 | `PruebaFunciones/` |
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
 ┣ 📂 PruebaFunciones
 ┃ ┣ 📜 Program.cs
 ┃ ┗ 📜 PruebaFunciones.csproj
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
dotnet restore PruebaFunciones
dotnet restore Factorial
dotnet restore Frecuencias
```

**3. Ejecutar cada ejercicio**

```bash
# Problema 2: Generación de cadenas INSERT/UPDATE
dotnet run --project PruebaFunciones

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

### Generación dinámica de cadenas INSERT y UPDATE

El programa (proyecto `PruebaFunciones`, con *top-level statements*) construye las sentencias SQL mediante **manipulación de cadenas** (`string.Join`, interpolación y un `List<string>`) a partir de las claves de un `Dictionary<string, object>`. Así, las mismas funciones sirven para cualquier tabla y cualquier conjunto de columnas.

```csharp
using System;
using System.Collections.Generic;

// Diccionario con los datos del inventario que deseamos procesar
Dictionary<string, object> datosInventario = new Dictionary<string, object>
{
    { "Nombre", "Laptop HP Envy" },
    { "Precio", 850.99m },
    { "Cantidad", 15 }
};

// 1. Generar sentencia INSERT llamando a la función
string sqlInsert = GenerarInsert("productos", datosInventario);
Console.WriteLine("--- SENTENCIA INSERT GENERADA ---");
Console.WriteLine(sqlInsert);
Console.WriteLine();

// 2. Generar sentencia UPDATE llamando a la función (actualizando id = 1)
string sqlUpdate = GenerarUpdate("productos", datosInventario, "id = 1");
Console.WriteLine("--- SENTENCIA UPDATE GENERADA ---");
Console.WriteLine(sqlUpdate);

/// <summary>
/// Función para construir dinámicamente una consulta INSERT usando parámetros SQL.
/// </summary>
static string GenerarInsert(string tabla, Dictionary<string, object> datos)
{
    // Unimos las llaves del diccionario para obtener el nombre de las columnas (ej: "Nombre, Precio, Cantidad")
    var columns = string.Join(", ", datos.Keys);

    // Creamos los marcadores de posición agregando el prefijo '@' a cada llave (ej: "@Nombre, @Precio, @Cantidad")
    var placeholders = "@" + string.Join(", @", datos.Keys);

    // Retornamos la cadena SQL formateada
    return $"INSERT INTO {tabla} ({columns}) VALUES ({placeholders});";
}

/// <summary>
/// Función para construir dinámicamente una consulta UPDATE usando la cláusula SET con parámetros SQL.
/// </summary>
static string GenerarUpdate(string tabla, Dictionary<string, object> datos, string condicionWhere)
{
    var setParts = new List<string>();

    // Recorremos las claves del diccionario para construir la asignación "Columna = @Columna"
    foreach (var key in datos.Keys)
    {
        setParts.Add($"{key} = @{key}");
    }

    // Unimos todas las asignaciones con comas (ej: "Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad")
    string setClause = string.Join(", ", setParts);

    // Retornamos la cadena SQL formateada
    return $"UPDATE {tabla} SET {setClause} WHERE {condicionWhere};";
}
```

**Salida:**

```
--- SENTENCIA INSERT GENERADA ---
INSERT INTO productos (Nombre, Precio, Cantidad) VALUES (@Nombre, @Precio, @Cantidad);

--- SENTENCIA UPDATE GENERADA ---
UPDATE productos SET Nombre = @Nombre, Precio = @Precio, Cantidad = @Cantidad WHERE id = 1;
```

| Función | Técnica de cadenas | Resultado |
|---|---|---|
| `GenerarInsert` | `string.Join` sobre las claves para las columnas y para los marcadores `@` | `INSERT ... VALUES (@Nombre, @Precio, @Cantidad)` |
| `GenerarUpdate` | `foreach` + `List<string>` para armar `Columna = @Columna`, unido con `string.Join` | `UPDATE ... SET Nombre = @Nombre, ...` |

### ¿Por qué marcadores `@` y no los valores directamente?

Las funciones **no pegan los valores** (`"Laptop HP Envy"`, `850.99`, `15`) dentro del texto SQL; solo colocan marcadores como `@Nombre`. Los valores se envían después, por separado, como parámetros:

```csharp
using var cmd = new MySqlCommand(sqlInsert, conexion);
foreach (var kvp in datosInventario)
    cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
cmd.ExecuteNonQuery();
```

Si en cambio se concatenaran los valores del usuario:

```csharp
// ❌ INSEGURO
string sql = "INSERT INTO productos (Nombre, Precio, Cantidad) VALUES ('" + nombre + "', " + precio + ", " + cantidad + ")";
```

un nombre como `x', 0, 0); DROP TABLE productos; --` produciría:

```sql
INSERT INTO productos (Nombre, Precio, Cantidad) VALUES ('x', 0, 0); DROP TABLE productos; --', 850.99, 15)
```

y el motor **eliminaría la tabla**. Con los marcadores `@`, ese mismo texto se guarda literalmente como el nombre del producto y nunca se ejecuta como código.


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

**Consulta 1**
<img width="1063" height="380" alt="image" src="https://github.com/user-attachments/assets/3aff694e-89cb-48e5-9456-929e4118115f" />

**Consulta 2**
<img width="1046" height="353" alt="image" src="https://github.com/user-attachments/assets/f02134e0-e5a0-49b0-8cc1-abf92b4fb33b" />

**Consulta 3**
<img width="1057" height="367" alt="image" src="https://github.com/user-attachments/assets/57392a5a-164f-4e13-9b8e-5b7a912ae7ec" />



**Problema 2: Cadenas INSERT/UPDATE y consultas parametrizadas**

<img width="1492" height="456" alt="image" src="https://github.com/user-attachments/assets/8826e8ae-1820-4b38-a467-7eeeb594c75e" />

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
