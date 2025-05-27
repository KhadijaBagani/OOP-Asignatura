# Ejercicio 6: Eventos

Queremos simplificar nuestro juego usando lambdas. Ya hemos visto el engorro que era hacer subclases para cada tipo de item. Así que hemos decidido cambiarlos por "eventos" (funciones que se ejecutan cuando ocurre algo concreto) empezando por las pociones.

## MasterPotion

1. Vamos a crear una clase llamada `MasterPotion` que es una copia de `Potion` pero con ligeras modificaciones:
   - Tiene un campo de tipo **delegado** llamado UseEffect() que se llama cuando el jugador la usa.
   - Por defecto UseEffect debería tener una función que lance un mensaje de error diciendo que no hay "UseEffect" asignado.
   - Todas las funcionalidades básicas de Potion deben preservarse.
2. Tenemos así un sistema que nos permite hacer cualquier poción, sin embargo, no tenemos formas de crear las pociones concretas que teníamos ante (HealingPotion, ManaPotion...). Crea métodos estáticos para poder emularlas sin necesidad de subclases.
   - Recuerda permitir seleccionar el tamaño.




> [!warning]
> Esta parte será expandida en el futuro
