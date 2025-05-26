# Ejercicio 5: Linq

## Selects

1. Partiendo de una colección de `int`s, obtén una colección que contenga esos mismos números en forma de `string`.
2. Partiendo de esa misma colección de `int`s, haz que cada número se convierta en un número de repeticiones de la letra **"A"**
   - [1, 3, 4] => ["A", "AAA", "AAAA"]
   - **Pista:** Mirad los métodos que aporta Linq, hay uno que os ayudará mucho.
3. Tenemos una lista de nombres que queremos mostrar por pantalla, pero por desgracia `null` se muestra como un espacio vacío. Haz un select que sustituya cada `null` por **"Sin nombre"**.


## Filtrado

Hay veces que no queremos trabajar sobre todos los valores de una colección, los métodos de "filtrado" como `Where`.

1. Partiendo del **Apartado 2 de Selects**: No tiene sentido que haya repeticiones negativas. Mejora la operación para que "filtre" los inputs negativos.

> [!warning]
> Esta parte será expandida en el futuro