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

Son los valores que "pasamos" a las funciones desde el exterior para su ejecución. Simplemente transfiere

### Opcionales

> [!warning]
> Esta parte será expandida en el futuro

### Modificadores

#### Params

#### Ref

#### Out

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
owner.Method(); //da error
```


### Tipos Avanzados

> [!warning]
> Esta parte será expandida en el futuro

#### Funciones Anónimas

#### Funciones Asíncronas
 

