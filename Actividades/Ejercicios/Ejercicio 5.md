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
2. Tenemos una lista de nombres que queremos mostrar por pantalla, pero queremos que se muestren solo los que empiezan por "A" y que no haya nombres duplicados.
   - **Pista:** Mirad los métodos que aporta Linq, hay uno que os ayudará mucho.
3. Tenemos una colección de elementos que son subclases de `Item`, pero no sabemos cual es cual y solo nos interesa obtener las pociones de curación `HealingPotion`. Filtrad para que la consulta devuelva todas las pociones que tenemos.
  - **Pista:** Mirad los métodos que aporta Linq, hay uno que os ayudará mucho.

## Agregación y elementos parciales

Hay veces que no queremos obtener absolutamente todo lo que hay en una colección o en el resultado de una consulta. Linq nos permite obtener solo parte de estos o agregarlos para obtener otros resultados:

1. Ya hemos visto cómo obtener las `HealingPotion`s de la colección, pero y si simplemente queremos contar cuantas hay sin gastar? Para saber si llevamos suficientes?
   - Descarta las que tienen 0 usos restantes
    - **Pista:** Mirad los métodos que aporta Linq, hay uno que os ayudará mucho.
2. Queremos implementar una acción de "Curado Rápido" que nos permita curarnos en combate sin seleccionar una poción concreta. Para ello necesitamos una consulta que nos devuelva la primera poción de la colección que tiene más de 0 usos restantes.
   - Ha de devolver null si no hay pociones que cumplan los requisitos
3. En el **subapartado 1** hemos contado cuantas pociones teníamos, pero eso realmente no nos dice el número de usos totales. En vez de un "COUNT" nos gustaría hacer "SUM" de los `remaining` de las pociones.
4. Ahora queremos saber cual es la poción con **más usos restantes** en toda la colección.
   - Ha de incluir a todas las subclases de `Potion`.
   - **Pista:** El método de Linq que teneis que usar empieza por **Max**