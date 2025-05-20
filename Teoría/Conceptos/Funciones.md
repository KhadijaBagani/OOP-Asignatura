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

## Tipos

### Métodos


> [!warning]
> Esta parte será expandida en el futuro
 

### Métodos Estáticos


### Funciones Anónimas


### Otros

> [!warning]
> Esta parte será expandida en el futuro
 

