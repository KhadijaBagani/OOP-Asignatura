# Encapsulación

- [Encapsulación](#encapsulación)
  - [¿Qué es?](#qué-es)
  - [¿De qué nos sirve?](#de-qué-nos-sirve)
  - [Encapsulación básica](#encapsulación-básica)
  - [Propiedades (get/set)](#propiedades-getset)
    - [Propiedades simples](#propiedades-simples)
    - [Propiedades avanzadas](#propiedades-avanzadas)

## ¿Qué es?

Es el mecanismo por el cual **aislamos** los campos de un **objeto** del mundo exterior.

Esto nos permite hacer que los objetos sean **"[cajas negras](https://es.wikipedia.org/wiki/Caja_negra_(sistemas))"**, es decir, sistemas en los que podemos ignorar completamente su funcionamiento interno y preocuparnos solo de cómo interactuamos con este.

## ¿De qué nos sirve?

Nos sirve para limitar problemas y simplificar el desarrollo de sistemas complejos ya que separa el programa en módulos independientes que solo pueden interactuar entre ellos de formas muy concretas y predefinidas.

También ayuda a hacer que el código sea modular y fácil de testear.

## Encapsulación básica

La forma más simple de encapsular un campo es hacerlo privado y añadir métodos a la clase para extraer y modificar su valor.

```cs
class Encapsulator{
    private int value; //Campo a encapsular

    //Método para modificarlo
    public void setValue(int value){
        this.value = value;
    }

    //Método para recuperarlo
    public int getValue(){
        return this.value;
    }
}
```

De esta forma podemos asegurarnos de que el campo en cuestión solo se usa de la forma que queremos. Por ejemplo: podemos limitar su rango de valores.

```cs
    //Método para modificarlo
    public void setValue(int value){
        //Impide introducir valores menores a 1
        if(value>1){
            this.value = value;
        }else{
            this.value =1;
        }
    }

    //Método para recuperarlo
    public int getValue(){
        //Impide devolver valores menores a 1
        if(this.value>1){
            return this.value;
        }else{
            return 1;
        }  
    }
```

De esta forma podemos **garantizar** que, independientemente de cómo se use la clase, siempre se devolverá un valor válido.


## Propiedades (get/set)

### Propiedades simples

Las propiedades son una especie de híbrido entre **método** y **campo** que se usa para la encapsulación.

Veamos un ejemplo:

```cs
class Encapsulator{
    public int propValue { //Propiedad
        get;
        set;
    }
}
```

En realidad, esto es lo mismo que el primer ejemplo de [encapsulación básica](#encapsulación-básica) que hemos visto pero escrito de forma más elegante. Es una forma rápida de declarar un campo privado con un método para extraer el valor (get) y otro para modificarlo (set).

En el fondo, la mayor diferencia es que las propiedades se usan como si fueran campos, no hacen falta paréntesis.

```cs
var val1 = obj.propValue;
//Es internamente lo mismo que
var val2 = obj.getValue();
```

### Propiedades avanzadas

> [!warning]
> Esta parte será expandida en el futuro