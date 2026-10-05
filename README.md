<div align="center">

# 🧪 Laboratorio de Temas Varios: Repaso del CRUD

**Inyección SQL · Consultas Parametrizadas · Métodos Sobrecargados · Recursividad · Frecuencias**

**Universidad Tecnológica de Panamá**
Facultad de Ingeniería en Sistemas Computacionales · Campus Víctor Levi Sasso
Herramientas de la Programación Aplicada III (.NET)

| | |
|---|---|
| **Estudiante** | `[Tu nombre completo]` |
| **Cédula** | `[0-000-0000]` |
| **Grupo** | 1IL133 |
| **Instructora** | Ing. Irina Fong |
| **Módulo** | IV – Acceso a Base de Datos: Aplicaciones en Capas |
| **Fecha de entrega** | `[dd de mes de 2026]` |

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?logo=visualstudio&logoColor=white)

</div>

---

## 📑 Tabla de contenido

1. [Descripción](#-descripción)
2. [Tecnologías y versiones](#-tecnologías-y-versiones)
3. [Estructura del proyecto](#-estructura-del-proyecto)
4. [Guía de instalación (onboarding)](#-guía-de-instalación-onboarding)
5. [Escenario 1: Seguridad en el CRUD y consultas parametrizadas](#-escenario-1-seguridad-en-el-crud-y-consultas-parametrizadas)
6. [Escenario 2: Métodos sobrecargados y recursividad](#-escenario-2-métodos-sobrecargados-y-recursividad)
7. [Escenario 3: Análisis de frecuencias](#-escenario-3-análisis-de-frecuencias)
8. [Conclusiones](#-conclusiones)

---

## 📌 Descripción

Solución de consola en C# organizada en tres escenarios técnicos:

- **Escenario 1:** construcción dinámica de sentencias `INSERT` y `UPDATE` mediante manipulación de cadenas, demostración de una **inyección SQL** y su mitigación con **consultas parametrizadas**.
- **Escenario 2:** clase con **métodos sobrecargados** y cálculo del **factorial (n!)** de forma recursiva con control del caso base.
- **Escenario 3:** algoritmo que recorre un conjunto de números y **contabiliza la frecuencia** de cada elemento.

---

## 🛠 Tecnologías y versiones

| Tecnología | Versión |
|---|---|
| .NET SDK | `8.0.x` |
| C# | `12` |
| IDE | Visual Studio 2022 `[17.x]` / VS Code |
| Base de datos | `[SQL Server 2022 / LocalDB / ninguna, solo simulación]` |
| Paquetes NuGet | `[Microsoft.Data.SqlClient 5.x, si aplica]` |
| Sistema operativo | `[Windows 11]` |

> Verifica tu versión con: `dotnet --version`

---

## 📂 Estructura del proyecto

```
📦 LabTemasVarios
 ┣ 📂 LabTemasVarios
 ┃ ┣ 📂 Escenario1_CRUD
 ┃ ┃ ┗ 📜 GeneradorSql.cs
 ┃ ┣ 📂 Escenario2_Sobrecarga
 ┃ ┃ ┣ 📜 Calculadora.cs
 ┃ ┃ ┗ 📜 Recursividad.cs
 ┃ ┣ 📂 Escenario3_Frecuencias
 ┃ ┃ ┗ 📜 Frecuencias.cs
 ┃ ┣ 📜 Program.cs
 ┃ ┗ 📜 LabTemasVarios.csproj
 ┣ 📂 img
 ┃ ┣ 🖼 escenario1.png
 ┃ ┣ 🖼 escenario2.png
 ┃ ┗ 🖼 escenario3.png
 ┣ 📜 LabTemasVarios.sln
 ┗ 📜 README.md
```

---

## 🚀 Guía de instalación (onboarding)

### Requisitos previos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Git](https://git-scm.com/)
- Visual Studio 2022 o Visual Studio Code con la extensión C# Dev Kit

### Pasos

**1. Clonar el repositorio**

```bash
git clone https://github.com/[tu-usuario]/[nombre-repo].git
cd [nombre-repo]
```

**2. Restaurar dependencias**

```bash
dotnet restore
```

**3. Compilar**

```bash
dotnet build
```

**4. Ejecutar**

```bash
dotnet run --project LabTemasVarios
```

**Alternativa con Visual Studio:** abrir `LabTemasVarios.sln` (o `.slnx`), presionar `F5` o `Ctrl + F5`.

---

## 🔐 Escenario 1: Seguridad en el CRUD y consultas parametrizadas

### Construcción de sentencias por concatenación (inseguro)

```csharp
public static string ArmarInsert(string nombre, string correo)
{
    return "INSERT INTO Usuarios (Nombre, Correo) VALUES ('" + nombre + "', '" + correo + "')";
}

public static string ArmarUpdate(int id, string nombre)
{
    return $"UPDATE Usuarios SET Nombre = '{nombre}' WHERE Id = {id}";
}
```

### Demostración de inyección SQL

Si el usuario escribe como nombre:

```
x'); DROP TABLE Usuarios; --
```

La sentencia generada queda así:

```sql
INSERT INTO Usuarios (Nombre, Correo) VALUES ('x'); DROP TABLE Usuarios; --', 'a@a.com')
```

El motor ejecutaría el `INSERT` y luego **eliminaría la tabla**, porque el texto ingresado se interpreta como código SQL.

### Mitigación: consultas parametrizadas

```csharp
using var cmd = new SqlCommand(
    "INSERT INTO Usuarios (Nombre, Correo) VALUES (@nombre, @correo)", conexion);
cmd.Parameters.AddWithValue("@nombre", nombre);
cmd.Parameters.AddWithValue("@correo", correo);
cmd.ExecuteNonQuery();
```

Con parámetros, el valor se envía **como dato y no como código**, por lo que la entrada maliciosa se guarda literalmente como texto y no se ejecuta.

### Consultas SQL

```sql
-- 1. Consulta de todos los registros
SELECT * FROM Usuarios;

-- 2. [Tu consulta 2]

-- 3. [Tu consulta 3]
```

### 📸 Evidencia

![Escenario 1 - Consola](img/escenario1.png)

---

## 🧩 Escenario 2: Métodos sobrecargados y recursividad

### Métodos sobrecargados

Mismo nombre, distinta firma (cantidad o tipo de parámetros):

```csharp
public class Calculadora
{
    public int Sumar(int a, int b) => a + b;
    public int Sumar(int a, int b, int c) => a + b + c;
    public double Sumar(double a, double b) => a + b;
    public int Sumar(params int[] numeros) => numeros.Sum();
}
```

### Factorial recursivo

```csharp
public static long Factorial(int n)
{
    if (n < 0) throw new ArgumentException("No existe factorial de números negativos.");
    if (n <= 1) return 1;            // Caso base: detiene la recursión
    return n * Factorial(n - 1);     // Llamada recursiva
}
```

El **caso base** (`n <= 1`) garantiza que la función deje de llamarse a sí misma, evitando un `StackOverflowException`. Se valida además la entrada negativa, que de otro modo nunca alcanzaría el caso base.

> **Nota:** `long` soporta hasta `20!`. Para valores mayores se puede usar `System.Numerics.BigInteger`.

### 📸 Evidencia

![Escenario 2 - Consola](img/escenario2.png)

---

## 📊 Escenario 3: Análisis de frecuencias

```csharp
int[] numeros = { 4, 7, 2, 4, 9, 7, 4, 2, 1 };
var frecuencias = new Dictionary<int, int>();

foreach (int n in numeros)
{
    if (frecuencias.ContainsKey(n))
        frecuencias[n]++;
    else
        frecuencias[n] = 1;
}

Console.WriteLine("Número | Frecuencia");
foreach (var par in frecuencias.OrderBy(p => p.Key))
    Console.WriteLine($"{par.Key,6} | {par.Value}");
```

**Salida esperada:**

```
Número | Frecuencia
     1 | 1
     2 | 2
     4 | 3
     7 | 2
     9 | 1
```

Se usa un `Dictionary<int, int>` porque permite contar en un solo recorrido del arreglo (complejidad **O(n)**).

### 📸 Evidencia

![Escenario 3 - Consola](img/escenario3.png)

---

## ✅ Conclusiones

- `[Conclusión sobre la inyección SQL y la importancia de parametrizar]`
- `[Conclusión sobre la sobrecarga de métodos]`
- `[Conclusión sobre la recursividad y el caso base]`
- `[Conclusión sobre el conteo de frecuencias]`

---

<div align="center">

**Universidad Tecnológica de Panamá** · Facultad de Ingeniería en Sistemas Computacionales
Herramientas de la Programación Aplicada III (.NET) · Grupo 1IL133
Entregado el `[dd/mm/2026]` por `[Tu nombre]`

</div>
