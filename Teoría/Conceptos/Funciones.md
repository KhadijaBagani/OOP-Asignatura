# Funciones

Las funciones son conjuntos de "expresiones" (≃ acciones) que se pueden "llamar" (ejecutar).

Las funciones constan de las siguientes partes:

- Nombre *(opcional si es anónima)*
- Tipo de retorno
- Parámetros *(opcionales)*
- Implementación *(opcional si es abstracta)*

```cs

ReturnType Name(ParamType parameter){
    //Implementation
}

```

## Overload

> [!warning]
> No confundir con `override` esto no tiene nada que ver con métodos virtuales.

Oveload o (sobrecarga) es como llamamos a tener varias funciones **con el mismo nombre** en la misma clase. Esto está permitido solo cuando las funciones **pueden ser distinguidas** según el número o tipo de parámetros.

Es decir: **han de tener parámetros distintos**;

```cs
int Example(int a, int b){}

int Example(float a, float b){} //No da error

float Example(float a, float b){} //Da error aunque sea distinta

float Example(float a){} //No da error. Solo 1 param 
```

## Parámetros

Son los valores que "pasamos" a las funciones desde el exterior para su ejecución. Son aparentemente muy simples pero tienen una complejidad oculta en el cómo se transfieren los valores.

La mayoría de **valores primitivos** se pasan "por copia", es decir, se crea una copia idéntica del valor de manera que modificarlo no altera el valor que fué enviado.

Imaginemos este método

```cs
public void PrintStr(string str) {
    str += " añadido";
    Console.WriteLine(str);
}
```

Al llamarlo así podemos ver que la variable texto no ha sido modificada por la función. Porque se ha "pasado una copia" a la función, que es lo que realmente se modifica.

```cs
string text = "Inicial";
PrintStr(text); //Escribe "Inicial añadido"
Console.WriteLine(text); //Escribe "Inicial"
```

Sin embargo, si hicieramos algo parecido con una clase, veríamos que la variable original se ve afectada. Eso se debe a que las clases se pasan "por referencia" por lo que la clase que hay dentro del método es la misma que hay fuera.

### Opcionales

Muchas veces nos gustaría poder definir los parámetros de forma que podamos usarlos si los necesitamos pero también ignorarlos si no. Podríamos hacerlo con sobrecargas, pero sería muy engorroso y volumioso.

```cs
public void Optional() {
    this.Optional("Default"); //llama a la otra con un valor por defecto
}
public void Optional(string str) {
    //...
}
```

En vez de eso, lo mejor es definir **parámetros opcionales** con valores por defecto.

```cs
public void Optional(string str="Default") {
    //...
}
```

De esta forma si no se introduce el parámetro la función se puede seguir ejecutando sin problemas.


### Modificadores

Además, podemos añadir ciertos modificadores a los parámetros para que se comporten de formas especiales:

#### Params

Params nos permite hacer que una función acepte una cantidad arbitraria de parámetros del mismo tipo y que simplemente los procese como una secuencia:

```cs
class MyList{
    //Parametro de tipo array de ints
    public void Add(params int[] ListNumbers)
    {

    }
}
```

```cs
var list = new MyList();
//Add acepta cualquier cantidad de ints
list.Add(1);
list.Add();
list.Add(1,2,3,4,5);
//También acepta un array de ints
list.Add(new int[]{ 1, 2, 3, 4 });
//Pero solo uno
list.Add(new int[]{1, 2}, new int[]{3, 4}); //Error
```

#### Ref

Fuerza a que el parámetro se pase por referencia, aunque normalmente sea un tipo que se pasa por copia.

#### Out

Similar a `ref` pero hace que el parámetro se use como un "output" extra de la función aparte del return. Sirve para devolver más valores cuando lo necesitamos.

#### Otros modificadores

> [!warning]
> Esta parte será expandida en el futuro

## Tipos de Funciones

### Métodos

Son el tipo de función más común. Se declaran **dentro de una clase** y solo pueden ser llamadas **desde una instancia** de la misma.

```cs
class Owner{

    public void Method(){
        // this es la instancia que llama al método
    }
}
```

```cs
//Incorrecto
Owner.Method(); //Da error
//Correcto
var owner = new Owner();
owner.Method();
```
 

### Métodos Estáticos

En cambio, los métodos estáticos son globales a la clase. Pueden ser llamados desde una instancia pero no tienen acceso a `this`.


```cs
class Owner{

    public static void Global(){
        // this no existe
    }
}
```

```cs
//Correcto
Owner.Global();
//Incorrecto
var owner = new Owner();
owner.Global(); //da error
```


### Tipos Avanzados

> [!warning]
> Esta parte será expandida en el futuro

<!-- #### Funciones Anónimas

#### Funciones Asíncronas -->
 

