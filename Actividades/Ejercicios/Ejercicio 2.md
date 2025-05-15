# Ejercicio 2: Inventario

Vamos a crear un sistema de inventario rudimentario para un juego de rol o fantasía.

**USAD EN NAMESPACE `VideoGame.Inventory` para el módulo de este ejercicio**

## Parte 1: Clases

Vamos a empezar creando las clases principales que vamos a necesitar:

1. Crea una clase **Item** simplemente para englobar todos los tipos de objeto que podemos poner en el inventario.
    - De momento, lo único que tendrán en común todos **Items** es que han de tener un nombre.
    - Deberíamos evitar que ese nombre se modifique una vez creado el Item.

2. Crea la subclase **Armor** para que podamos definir armaduras para el personaje.
   - Han se ser creadas con un nombre y un valor de **dmgReduction** (reducción de daño).
   - **dmgReduction** es un valor de 0 a 1 que indica el porcentaje de daño que reduce la armadura.

3. Crea la subclase **HealingPotion**, que nos va a servir para que el personaje se pueda curar.
   - Las pociones han de ser creadas con un tamaño que define el número máximo de usos que tienen.
   - Queremos que se pueda saber tanto el tamaño de la poción como el número de usos restantes.
   - Queremos que todas las pociones de curación se llamen simplemente "Healing Potion".

4. Implementa el método **Use** en las pociones para que podamos usarlas.
   - A falta de personaje, el método simplemente ha de decir **Healing** en vez de curar.
   - Recordad limitar el número de usos. (No dar error si se sobrepasa)

5. Repasad la encapsulación de todas las clases hasta el momento.
   - Aseguraos de que no dejais nada más "expuesto" de lo que es necesario.

6. Implementad el método **ReduceDMG** de las armaduras
   - **Recibe** el valor de daño base y **Devuelve** el daño restante tras la reducción (ambos enteros).
   - El cálculo del daño restante es: `daño * (100% - reducción)`.
   - Además, el método ha de mostrar el siguiente mensaje por la consola: `Damage reduced from <base> to <reducido>`.