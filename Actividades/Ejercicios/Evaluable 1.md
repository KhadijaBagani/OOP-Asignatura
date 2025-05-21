# Clases y Subclases

En el **ejercicio 2** ya experimentamos con tipos de Items en un juego, pero ahora vamos a implementar un **sistema de inventario** de verdad.

> Vamos a utilizar el namespace `VideoGame.Inventory` para este ejercicio y algunas de las clases del **ejercicio 2**.

```cs
/*Usad un placeholder para estas clases*/
public class Player{

}

public abstract class Spell{
   
}
```


## Parte 1: Items (2,5 Puntos)

Queremos expandir el sistema de items con diversas funcionalidades: 

1. Queremos que **todos los items** tengan un precio de venta (en nº de monedas de oro) para poder comerciar. (null si no se puede vender). **(0,5 Puntos)** 
2. Queremos crear los siguientes tipos de items **(No Hace falta implementarlos)**: **(1 Punto)**
   - *(Recordad poner comentarios de documentación)*
   - **Sword**
     - Arma cuerpo a cuerpo
   - **Bow**
     - Arma a distancia que requiere flechas
   - **SpellScroll**
     - Lanza un hechizo concreto
     - Arma a distancia
     - Un solo uso (se destruye)
   - **MagicWand**
     - Arma a distancia para magos
     - Lanza un hechizo concreto
     - Usos ilimitados pero gasta magia

3. Queremos que todos los items (Incluso los creados en el **ejercicio 2**) se clasifiquen en las siguientes categorías y subcategorías (mantened los nombres): **(1 Punto)**
   - **Equipable**:
     - Incluye  **Weapons** y **Armors**
     - Tienen el método `Equip`
       - Recibe un parámetro `Player`
       - Devuelve si se ha podido equipar
   - **Weapon**:
     - Incluye todo lo que se considera un arma
   - **LimitedUse**:
     - Engloba todos los items que se gastan tras cierta cantidad de usos
     - Tienen la propiedad `remaining` que indica los usos restantes.
   - **SpellCaster**
     - Engloba todos los items que lanzan hechizos
     - Tienen la propiedad `spell` que indica el spell que lanzan al ser usados
   - **RangedWeapon**
     - Engloba todos los objetos que se usan a distancia
     - Tienen la propiedad `maxRange` que devuelve su distancia límite.
   - **AmmoWeapon**
     - Engloba a las armas que necesitan munición.
     - Tienen la propiedad `remaining` que indica la munición restante.



## Parte 2: Pociones (1,5 Puntos)

Queremos mejorar el sistema de pociones para permitir más efectos.

1. Reconfigura `HealingPotion` para que pueda haber más tipos de pociones.
   - Las pociones han de ser subclases de `Potion` **(0,5 Puntos)**

2. Vamos a añadir las siguientes pociones: **(1 Punto)**
   - `StaminaPotion`
     - Al usarla escribe "Recovering"
   - `ManaPotion`
     - Al usarla escribe "Recharging"
   - `RestoreAll`
     - Hace lo que las otras 3 pociones combinadas

