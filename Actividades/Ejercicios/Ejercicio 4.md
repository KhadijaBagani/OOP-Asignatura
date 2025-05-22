# Ejercicio 4: Arrays

## Trabajar con Arrays

Queremos ver la diferencia que supone trabajar con arrays comparado con otros tipos de colecciones. Para lograrlo vamos a intentar implementar funcionalidades que ya hemos trabajado pero con arrays.

1. **Reverse**: vamos a implementar un método **estático** (ver [teoría](../../Teoría/Conceptos/Funciones.md#métodos-estáticos)) llamado `Reverse` para "dar la vuelta" a los valores de un array.
   - No podeis usar el `Reverse` que os da ya C#, obviamente.
   - **No ha de devolver un valor** ni crear un nuevo array, lo ha de **modificar** "en el sitio".

2. **Pop:**  que haga "pop" sobre un array.
   - Ha modificar el array **no devolver uno nuevo**.
   - El orden de los valores ha de cambiar igual que cambiaba en la cola y el stack.

3. Intentad optimizar los métodos anteriores para que hagan el mínimo de operaciones necesario.
   - Depurad para ver lo que hace y si hay pasos que podeis saltar u omitir
   - Si no sabeis optimizar, explicad en comentarios lo que crees que se puede mejorar


## Recorrer Colecciones

Ya hemos visto cómo recorrer los elementos de un array o una lista, pero hasta ahora los hemos recorrido todos y en orden, vamos a probar con formas más raras de recorrer colecciones.

```cs
//Usad este array como base para comprobar que funciona
string[] letters = "abcdefghijklmnñopqrtuvwxyz"
                .Select(c => c.ToString())
                .ToArray();
```

1. **Recorrer Pares:** queremos hacer que un bucle `foreach` solo recorra los valores pares (el segundo, el cuarto, el sexto...)
   -  Haced que muestre los valores recorridos con `Console.WriteLine`
   -  Intentad que el proceso sea lo más simple posible
   -  **No vale usar un for normal**

2. **Recorrer Desde Fuera:** ahora queremos hacer un `for` que recorra los valores desde "fuera" hacia "adentro". Es decir, que muestre "a", luego "z", luego "b", "y"...
   - Ha de poder funcionar con colecciones de cualquier tamaño


## Generar Colecciones

Y ya puestos, vamos a generar unas pocas colecciones:

1. Queremos un método `FibonacciArray` que acepte `size` y genere un array de ese tamaño con la sucesión de fibonacci.
2. Añade una sobrecarga al método anterior 
3. Queremos un método `PowersOfTwo` que acepte un valor `limit` y devuelva un array con todas las potencias de 2 **menores** que ese límite.


## EXTRA: Control de Errores

Añadid control de errores a todos los métodos.
   - Intentad devolver `null` o algún valor por defecto en vez de lanzar una excepción
   - Considerad todos los inputs posibles, no solo los "razonables"
