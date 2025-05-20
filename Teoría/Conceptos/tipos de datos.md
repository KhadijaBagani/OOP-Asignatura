# Tipos de Datos

Hay muchos **tipos** en C# y .NET como para mencionarlos todos. En su lugar, nos centraremos en las distintas formas de clasificarlos y lo que estas categorias nos dicen de los distintos tipos.

- [Primitivo o no Primitivo](#primitivo-o-no-primitivo)
  - [Tipos Primitivos](#tipos-primitivos)
  - [Tipos no Primitivos](#tipos-no-primitivos)
- [Valor o Referencia](#valor-o-referencia)
- [Valores Múltiples](#valores-múltiples)
  - [Colecciones](#colecciones)
  - [Arrays](#arrays)
    - [Diferencias](#diferencias)
  - [Tuplas](#tuplas)

## Primitivo o no Primitivo

Es una forma de separar los valores según si son elementos fundamentales de C# o no.

### Tipos Primitivos

Son todos los tipos fundamentales de C#. [Aquí](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types) podeis verlos todos, pero algúnos de los primitivos más típicos son `int`, `string` o `bool`

### Tipos no Primitivos

**Ninguna clase es primitiva**, al igual que ningún otro tipo de estructura de valores compuestos.

`object` es primitivo y todas las clases "heredan" de `object` pero `object` no es una clase de verdad.


## Valor o Referencia

No todos los tipos se almacenan igual. Cómo ya habeis visto, las clases se almacenan "por referencia", es decir, que un campo de tipo clase no almacena el contenido de una instancia, sino una referencia a ella.

Esto es importante para entender cómo trabajamos con distintos tipos. Por ejemplo: no es lo mismo comparar si dos ints tienen el mismo valor, que comparar si dos clases lo tienen.

```cs
int a=1, b=1;

Console.WriteLine(a == b); //True
```

```cs
var c = new ValueNode<int>(1);
var d = new ValueNode<int>(1);

Console.WriteLine(c == d); //false
Console.WriteLine(c.value == d.value); //true
```


## Valores Múltiples

Además de valores individuales, tenemos valores que son en realidad conjuntos de múltiples valores:
 
### Colecciones

Las colecciones son objetos que contienen valores en una estructura concreta y que nos proporcionan distintos métodos para manipularlos fácilmente.

.Net proporciona multitud de colecciones en el namespace `System.Collections.Generic`. Las más utilizadas son:

- List
- Stack
- Queue
- Dictionary
- HashSet
- PriorityList



### Arrays

A pesar de ser muy compatibles con las colecciones y hasta de ser posible usarlos casi como si fueran colecciones, los arrays no son colecciones, **no son ni objetos**.

Son secuencias de valores de tamaño fijo almacenadas directamente en memoria. Más información sobre qué son exactamente los arrays [aquí](https://www.inesem.es/revistadigital/informatica-y-tics/arrays/).

```cs
string[] diasSemana = new string[7];
int[,] matriz_3x4 = new int[3,4];
int[][] arrayDeArrays = new int[3][];

```
> [!warning]
> Esta parte será expandida en el futuro
> ACCEDER A VALORES CONCRETOS


También se pueden inicializar directamente

```cs
/*Formas de inicializar*/
//Collection syntax
int[] arr1 = { 1, 2, 3 };
//Array syntax
int[] arr2 = [1, 2, 3];
//Multidimensional syntax
int[,] arr3 = { { 1, 2, }, {3, 4}};
```

> [!warning]
> Esta parte será expandida en el futuro

#### Diferencias

> [!warning]
> Esta parte será expandida en el futuro


### Tuplas

Son una forma muy directa de almacenar varios valores en un mismo campo/variable. Al igual que los arrays, son muy fundamentales, de hecho, no son ni objetos, solo valores que se almacenan en grupo.

Su gran diferencia con los arrays es que tienen un tamaño completamente predeterminado y que pueden mezclar elementos de varios tipos sin problemas.

```cs
(int, int) coordenadas = (5, 2);
```

> [!warning]
> Esta parte será expandida en el futuro