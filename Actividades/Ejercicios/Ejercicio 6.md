# Ejercicio 6: Eventos

Queremos simplificar nuestro juego usando lambdas. Ya hemos visto el engorro que era hacer subclases para cada tipo de item. Así que hemos decidido cambiarlos por "eventos" (funciones que se ejecutan cuando ocurre algo concreto) empezando por las pociones.

## MasterPotion

1. Vamos a crear una clase llamada `MasterPotion` que es una copia de `Potion` pero con ligeras modificaciones:
   - Tiene un campo de tipo **delegado** llamado UseEffect() que se llama cuando el jugador la usa.
   - Por defecto UseEffect debería tener una función que lance un mensaje de error diciendo que no hay "UseEffect" asignado.
   - Todas las funcionalidades básicas de Potion deben preservarse.
2. Tenemos así un sistema que nos permite hacer cualquier poción, sin embargo, no tenemos formas de crear las pociones concretas que teníamos ante (HealingPotion, ManaPotion...). Crea métodos estáticos para poder emularlas sin necesidad de subclases.
   - Recuerda permitir seleccionar el tamaño.


## Pool de Recompensas

Queremos poder configurar recompensas para dar al jugador cuando hace ciertas cosas (completar una misión, abrir un cofre, matar a un enemigo) pero no queremos que esta sea exactamente la misma. Nos gustaría crear un sistema que nos permita definir recompensas aleatorias para nuestro juego.

1. Define la clase `Reward`. Ha de cumplir las siguientes características:
   - Ha de almacenar el conjunto de items que se pueden recibir como recompensa junto con la probabilidad de que te toque cada uno.
   - Almacena ambos como quieras, simplemente garantiza que sea eficiente.
   - El conjunto no ha de ser modificable después de ser creado
   - Reward ha de tener un método `GetReward` que te permita obtener la recompensa que te ha tocado. Y otro llamado `GetChances` que te permite ver acceder a los items y sus probabilidades pero no modificarlos. ***Déjalos vacíos de momento*** (pon un `throw new NotImplementedException();`)

2. Implementa `GetChances`


> [!warning]
> Esta parte será expandida en el futuro
