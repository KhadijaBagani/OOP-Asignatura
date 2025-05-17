# Control de Flujo

- [Condicionales](#condicionales)
  - [If](#if)
  - [Cadenas de Ifs](#cadenas-de-ifs)
  - [Switch](#switch)
    - [Sintaxis Switch](#sintaxis-switch)
    - [Pattern Matching](#pattern-matching)
- [Bucles](#bucles)
  - [Foreach](#foreach)
  - [For](#for)
  - [While](#while)
  - [Do While](#do-while)
- [Saltos](#saltos)




Las instrucciones de control de flujo nos permiten controlar que instrucciones se ejecutan y en qué orden. La universalmente conocida es el típico "if ... else ...", pero en C# hay mucho más.

## Condicionales

Son las **instrucciones** que deciden si algo se ejecuta o no en base a una condición. La más clásica es el **if**, pero también tenemos el **switch**.

### If

Presente en casi todos los lenguajes y bastante intuitiva. Dicho esto, el if en C# presenta ciertas particularidades:

- Los `()` de la condición **no son opcionales**.
- La condición acepta cualquier valor o cálculo que devuelva un **booleano**.
- Los `{}` sí que son opcionales, pero sin ellos el if solo cogerá la primera instrucción que le siga.
  - **Usad siempre los `{}`** (o casi siempre), por favor. Sobre todo si no teneis soltura programando. Os vais a ahorrar muchos dolores de cabeza.
- El interior del if cuenta como **su propio ámbito** (scope), por lo que las **variables locales** que declareis dentro **no se podrán usar fuera**.

Ejemplos:


```cs
if (condition)
   Console.WriteLine("Is true");
else
    Console.WriteLine("Is false");
```

```cs
/*Lo mismo que el anterior primer ejemplo pero con {}*/
if (condition){
    Console.WriteLine("Is true");
} else {
    Console.WriteLine("Is false");
}
```

```cs
/*Posibles condiciones*/
if (true) //Un valor a lo bruto
bool isTrue = false;
if (isTrue) //Variable
if (obj != null)  //Una operación booleana (comparación)
if (vehicle is Car car) //Comprobación de tipo
if (obj.BooleanMethod()) //Llamada a un método
```

```cs
/*Ámbito interno del IF*/
if (vehicle is Car coche) { //Coche se declara en el if
    //Existe dentro del if
    Console.WriteLine($"Coche: {coche.model}");
    //Pero termina cuando este acaba 
}
//Fuera da error
Console.WriteLine($"Coche: {coche.model}"); 
```

> [!Note]
> El uso que acabais de ver de el operador **`is`** es algo conocido como **Pattern Matching** (coincidencia de patrones) que permite comprobar si un objeto es de un tipo concreto (o compatible) y tratarlo como tal.
> 
> Se explica en mayor detalle en el apartado [Pattern Matching](#pattern-matching) de la instrucción **Switch**

### Cadenas de Ifs

Hay veces que no basta con una comprovación, que tenemos **más de dos opciones** que comprobar o veces en las que necesitamos al menos dos condiciones. Ahí es donde entra en juego la posibilidad de **encadenar ifs**.

```cs
if(value < 0){
    Console.WriteLine("Is Negative");
}else if(value > 0){
    Console.WriteLine("Is Positive"); 
}else{
    Console.WriteLine("Is Zero"); 
}
```
Realmente, esto es lo mismo que ↓

```cs
if(value < 0){
    Console.WriteLine("Is Negative");
}else{
    if(value > 0){
        Console.WriteLine("Is Positive"); 
    }else{
        Console.WriteLine("Is Zero"); 
    }
} 
```

Pero escrito de una forma mucho más elegante y legible. Además, al poner el if directamente después del else (sin `{}`) podemos mantener la misma indentación en todos los ifs. Esto nos simplifica aberraciones como:

```cs
if(condition){
    ...
}else{
    if(condition){
        ...
    }else{
        if(condition){
            ...
        }else{
            if(condition){
                ...
            }else{
                if(condition){
                    ...
                }else{
                    ...
                }
            }
        }
    }
} 
```

En una bonita cadena

```cs
if(condition){
    ...
}else if(condition){
    ...
}else if(condition){
    ...
}else if(condition){
    ...
}else if(condition){
    ...
}else{
    ...
}
    
```

### Switch

> [!Warning]
> **No confundir** el `switch` con una cadena de ifs.
>
> **En otros lenguajes son equivalentes, `en C# NO`**.

El objetivo de la instrucción `switch` es el mismo que el de una cadena de ifs que hace **múltiples comparaciones** sobre **un mismo valor**: asociar ciertas acciones a opción posible. Sin embargo, **no lo hacen de la misma forma**.

En lenguajes interpretados como JavaScript o Python el `switch`, si existe siquiera, es solo una sintaxis especial para una cadena de ifs. Pero en lenguajes compilados no suele ser así debido a que el compilador puede optimizar enormemente su funcionamiento, a veces incluso eliminando la necesidad de hacer comparaciones por completo.

Es muy complejo y no necesitais entender porqué ni como ocurre, simplemente recordad esto: si queda bien hacerlo con un `switch`, no lo hagas con `if`s.

#### Sintaxis Switch

La sintaxis del `switch` merece una sección a parte porque es sin duda una de las más complejas en casi todos los lenguajes de programación. Veamos un ejemplo "simple".

```cs
switch (num) {
    case 0: /*Qué hacer*/ break;
    case 1: /*Qué hacer*/ break;
    case 2: /*Qué hacer*/ break;
    case 3: /*Qué hacer*/ break;
    default: /*Qué hacer*/ break;
}
```

Vale, el `case` es muy claro, le estás diciendo "si el valor es este, haz lo siguiente" y el `default` es obviamente una especie de else, ¿pero y el `break`? ¿Porqué da **error** si no lo pongo pero no siempre?

En realidad es más simple de lo que parece: el break le dice cuando parar. Y si no lo pones, simplemente continua.

```cs
switch (num) {
    case 0: /*Se ejecuta si es 0*/   
    case 1: /*Se ejecuta si es 1 o 0 */ 
        break;
    default: /*Se ejecuta si no es ninguno de los anteriores*/ 
        break;
}
```

De esta forma puedes hacer que lo que se hace en case se aplique también a otro sin apenas escribir.

```cs
switch (num) {
    default: /*Se ejecuta siempre que no es 0 o 1*/ 
    case 0: /*Se ejecuta siempre que no sea 1*/ 
    case 1: /*Se ejecuta siempre*/ 
        break; //El único break obligatorio es el del final
}
```

Para la mayoría de condiciones resulta excesivo usar un `switch`, pero si tiene más de 3 opciones o se beneficia de reutilizar lo que se hace en alguna opción, seguramente sea mejor utilizar un switch.

También es muy recomendable si esperais que el número de opciones vaya a incrementar en el futuro.

#### Pattern Matching

Uno de esos casos es el **Pattern Matching** o Coincidencia de Patrones, ya que nos permite tratar de forma distinta a cada una de las subclases de un objeto y eso es algo que siempre está abierto a nuevas opciones. Veamos un ejemplo simple.

```cs
switch (v) {
    case Car coche:
        Console.WriteLine($"{coche.model} matrícula: {coche.plateNumber}");
        break;
    case Bike bici:
        Console.WriteLine($"Es una bici modelo {bici.model}");
        break;

    case ElectricScooter scooter:
        var carga = scooter.batteryLevel * 100;
        Console.WriteLine($"Patín al {carga}% de carga");
        break;

    default:
        Console.WriteLine($"No sé lo que es");
        break;
}
```

No solo es una forma elegante y legible de representar lo que hacemos con cada subclase, sino que además es muy fácil expandirlo en el futuro y/o escribir un default que te avise o produzca un error si se encuenta algo que no sabe gestionar.

El Pattern Matching es complejo pero muy potente, si quereis más información mirad estos recursos: 

- [Fundamentos Pattern Matching](https://www.campusmvp.es/recursos/post/lenguaje-csharp-coincidencia-de-modelos-parte-1-fundamentos.aspx)
- [Switch con expresiones](https://www.campusmvp.es/recursos/post/lenguaje-csharp-coincidencia-de-modelos-parte-2-uso-de-expresiones-en-el-switch.aspx)


## Bucles

> *Para cuando una sola vez no es suficiente.*

Ahora en serio. Sí, la idea de los bucles es tan simple como **"quiero volve a hacer esto"**, pero son estructuras sorprendentemente complejas, interesantes y hasta **potencialmente problemáticas**.

Además, su complejidad ni siquiera proviene de las instrucciones `break` (salir del bucle) o `continue` (salta al siguiente ciclo del bucle). La complejidad surge del cómo se decide exactamente si continuar en bucle y cómo.

Debido a esto, vamos a empezar por los bucles más intuitivos e ir bajando de nivel hasta los más simples (y problemáticos).

### Foreach

> [!warning]
> Esta parte será expandida en el futuro

### For

> [!warning]
> Esta parte será expandida en el futuro

### While

```cs
while(true){} //Diversión sin fin para todos 
// (te puede colgar el PC)
```
Como el ejemplo anterior ilustra, `while` (y su variante `do while`) es el tipo de bucle con mayor potencial destructivo.

El motivo es simple: no tiene ningún tipo de protección contra bucles infinitos. Simplemente acepta una condición y ejecuta el código continuamente hasta que esta sea false.



> [!warning]
> Esta parte será expandida en el futuro

### Do While

> [!warning]
> Esta parte será expandida en el futuro

## Saltos

> [!warning]
> Esta parte será expandida en el futuro