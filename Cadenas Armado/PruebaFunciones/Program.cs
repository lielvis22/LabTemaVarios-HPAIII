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