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
  - [Break](#break)
  - [Continue](#continue)
  - [Goto](#goto)

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

En realidad es más simple de lo que parece: el break le dice cuando acaba el case y, para evitar que te lo dejes, te avisará si no lo pones salvo en las siguientes excepciones

```cs
switch (num) {
    case 0: //No hace falta si no pones código
    case 1: // Se ejecuta si es 0 o 1
        break;
    case 2:
        return; //También vale salir del método
    case 3:
        goto case 2; //O saltar a otro case
    default: 
        throw new Exception("Oops"); //O dar un error
}
```

De esta forma puedes hacer que lo que se hace en case se aplique también a otro sin apenas escribir.

```cs
switch (num) {
    case 0: /*Se ejecuta siempre que no sea 1 o 2*/
        Console.WriteLine("0");
        goto case 1;
    case 2:
    case 1: /*Se ejecuta siempre*/
        Console.WriteLine("1");
        break;
    default: /*Se ejecuta siempre que no es 0, 1 o 2*/ 
        Console.WriteLine("default");
        goto case 0;
    
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

`foreach` es el bucle más intuitivo porque parte de la idea **repetir** una serie de **acciones** sobre un **conjunto de valores**.

```cs
foreach (var element in collection) {
    //Hacer algo con el elemento                
}
```

En realidad su funcionamiento interno es algo más complejo, ya que en realidad lo que hace es en cada bucle pedirle a la colección que le pase el siguiente elemento hasta que que haya terminado, pero esto no es relevante a no ser que queramos hacer que una de nuestras clases sea **"iterable"**. Pero eso lo veremos más adelante.

### For

El bucle `for` tiene una sintaxis que asusta un poco, pero es casi tan simple como `foreach`. Veamos un ejemplo:

```cs
//Contar del 0 al 9
for(int i=0; i<10; i++) {
    Console.WriteLine(i);
}
```

A diferencia del `foreach`, el bucle for se basa en una condición para decidir si parar o no, pero no resulta inmediatamente obvio porque esta está definida en tres partes separadas por `;`

La estructura en realidad es sencilla:

```cs
for(/*Valor de inicio*/;/*condición*/;/*valor siguiente*/){
    /*Acciones a repetir*/
}
```

1. Asigna el **valor inicial** para el bucle.
2. Comprueba que se cumple la **condición**.
   1. Se detiene en bucle si no.
3. Ejecuta las **acciones** del bucle.
4. Calcula el **valor siguiente**.
5. Vuelve al paso 2

El `for` de ejemplo anterior básicamente dice: empieza desde el 0 (`int i=0`) y continua sumando 1 (`i++`) mientras el valor siga siendo menor a 10 (`i<10`).

De hecho, no está limitado a solo una variable:

```cs
for(int i=0, j=5; i<10 && j<20; j++, i+=2) {
    Console.WriteLine($"{i}{j}");
}
```

Se puede hacer bastante más con un bucle for, pero este es su uso más frecuente.

### While

```cs
while(true){} //Diversión sin fin para todos 
// (te puede colgar el PC)
```

Como el ejemplo anterior ilustra, `while` (y su variante `do while`) es el tipo de bucle con mayor potencial destructivo.

El motivo es simple: no tiene ningún tipo de protección contra bucles infinitos. Simplemente acepta una condición y ejecuta el código continuamente hasta que esta sea `false`.

**No useis nunca `while`** si teneis alternativa. De hecho, a veces puede ser mejor usar un bucle **for** aunque no esteis iterando. Imaginemos por ejemplo un bucle que sirve para reintentar la conexión si no se consigue a la primera:

```cs
bool isConnected = TryToConnect();

while(!isConnected){
    isConnected = TryToConnect();
}
```

Si por algún motivo `TryToConnect` no puede tener éxito (no hay internet, está mal programada, etc.) el programa simplemente se quedará en bucle para siempre y ni siquiera dará error.

Por eso es mejor poner un límite a los bucles, aunque sea una cantidad absurda de número de intentos.

```cs
/* 100 intentos */
bool isConnected = TryToConnect();
for (int i=100; !isConnected && i>0; i--) {
     isConnected = TryToConnect();           
}
//Si aun así no conecta, lanzar un error
if(!isConnected)
    throw new Exception("Connection failed");
```

La única excepción aceptable es si tienes la absoluta certeza de que es matemáticamente imposible que el bucle no termine en un tiempo razonable.

### Do While

`do while` es una variante del bucle while y casi que una reliquia del pasado. No todos los lenguajes lo tienen y ni siquiera ofrece ninguna funcionalidad única, solo una forma mejor de escribir lo mismo.

```cs
bool isConnected;
do{
    isConnected = TryToConnect();
}while(!isConnected)
```

A primera vista parece un while que tiene la condición **después de la ejecución**. Y lo es, pero en cuanto piensas un poco te das cuenta que eso es lo mismo que duplicar el contenido de un while y ponerlo delante.

```cs
bool isConnected;
//Primer "loop"
isConnected = TryToConnect();
while(!isConnected){
    //Loops sucesivos
    isConnected = TryToConnect();
}
```

No es que `do while` sea inutil, pero no ofrece demasiados beneficios por encima de un `while` y menos aún para justificar usarlo en vez de un `for`.

No os compliqueis la vida, **usad otro tipo de bucle**.

## Saltos

### Break

Tiene distinto significado según dónde se use. Mirar [bucles](#bucles) y [switch](#switch) para más detalles.

### Continue

Salta a la siguiente iteración del bucle

```cs
foreach (Vehicle v in lista) {
    if(v is Car)
        continue; //Saltarse ese vehículo
    Console.WriteLine($"{v} no es un coche");
}

```

### Goto

Permite **saltar** a cualquier otra instrucción del **método actual**. Se recomienda evitar usarla a toda costa salvo en dos casos:

- Para **salir de dos bucles** a la vez (break solo sale de uno)
- Para saltar entre cases en un `switch` (ver [Sintaxis del Switch](#sintaxis-switch)).

```cs
/*Bucle*/
bool compartenValor = false;
foreach(var a in lista1){
    foreach(var b in lista1){
        if(a==b){
            compartenValor = true;
            goto Salida; //Salta a la etiqueta salida
        }
    }
}

Salida: //Etiqueta
```
