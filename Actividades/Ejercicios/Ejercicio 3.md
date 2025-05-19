# Ejercicio 3: Estructuras

Vamos a partir del entrenamiento de **Data Structures** para intentar hacer una **cola**: una estructura dónde el primer elemento que entra es el primero que sale.


# Parte 1: Clases

1. Cread la clase `QueueNode` que usaremos para almacenar valores en la cola.
2. Cread la clase `MyQueue` con los siguientes capacidades:

   - Añadir valores
   - Extraer valores (y eliminarlos en el proceso)
   - Contar la longitud de la cola
   - Pista: para hacer una cola no basta con tener el nodo `head`, necesitas también el `tail` (el nodo final)

3. Aseguraos que `MyQueue` implementa la interfaz `IPoppable` creada en el **entrenamiento**


# Parte 2: Funcionalidades

1. Implementa el método `PushRange` que añade múltiples valores a la vez.
   - `PushRange` recibe los múltiples valores como un **ICollection**
   - Podeis comprobar que funciona intentando usar una `List` como parámetro.
2. Implementa el método `Contains` para comprobar si la cola contiene un valor concreto.
   - `Contains` recibe un parámetro de tipo T
   - No devuelve el valor encontrado ni su posición, solo si existe.
   - Para **comparar** valores de **tipo genérico** usad `Object.Equals(value1, value2)`

3. Implementa el método `IndexOf`, que encuentra el **primer** índice con el valor especificado.
   -   Recibe un parámetro de tipo T
   -   Devuelve la posición del elemento en la cola contando desde el inicio
   - Para **comparar** valores de **tipo genérico** usad `Object.Equals(value1, value2)`
  