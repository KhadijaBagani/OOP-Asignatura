# Clases

- [Clases](#clases)
  - [Clase vs Instancia/Objeto](#clase-vs-instanciaobjeto)
  - [Partes de una Clase](#partes-de-una-clase)
    - [Campos](#campos)
    - [Métodos](#métodos)
  - [This](#this)
    - [Usos](#usos)
  - [Constructores](#constructores)
    - [Usos de los Constructores](#usos-de-los-constructores)



## Clase vs Instancia/Objeto

Una clase **NO ES** un objeto. Una clase es la idea o plantilla de un objeto. Es en lo que nos basamos para crear objetos.

Cada objeto creado a partir de una clase (usando `new`) es lo que llamamos una "instancia" de esa clase. Cada instancia es independiente y separada, pero comparten una estructura y funcionalidades, son el misto "tipo" de objeto.

Ese "tipo de objeto" es lo que realmente es la clase. No un objeto concreto, sino una categoría o patrón.

```cs
clase Ejemplo{ //No es un objeto

}
new Ejemplo(); //Crea un objeto (instancia de Ejemplo)
```

## Partes de una Clase

Tal y como podéis ver en la teoría, las clases y los objetos surgieron para permitirnos tener elementos en el código que **ejecutan acciones** a la vez que **almacenan datos**.

Las acciones de una clase se llaman **métodos** y los datos se llaman **campos**. Podríamos decir que los campos son como las columnas de una tabla en SQL, mientras que los métodos son como Stored Procedures asociados a una tabla en concreto.

### Campos

Los campos se declaran de la siguiente forma:

```cs
clase Ejemplo{ 
    private int campo; //Campo privado de tipo entero
}
```

Al ser parte de una clase, solo se pueden declarar **dentro de la clase**. ¡No confundir con una **variable local**!

Los campos además se pueden "inicializar", lo que quiere decir que cada vez que se cree una **instancia** de esa clase, empezará con esos valores.

```cs
class Ejemplo{
    public int edad=12;
    public DateTime fecha = new DateTime();
}
...
new Ejemplo(); //Se crea con edad 12 y un Datetime por defecto
```

### Métodos

Son **funciones** propias de la clase. Se declaran así:

```cs
clase Ejemplo{ 
    // Siguen la siguiente estructura:
    // public/private tipoRetorno nombre(parámetros)

    public void HazAlgo() //Método público sin parámetros que no devuelve ningún resultado (void es "nada")
    { 
        /*lo que hace*/
    }

    //Los parámetros siguen este patrón:
    //Tipo1 nombre1, Tipo2 nombre2...
    public void MiraEsto(object cosa) //Igual que el método anterior pero recibe el parámetro "cosa"
    { 
        /*lo que hace*/
    }

    public bool IsTodoBien() //Método público sin parámetros que devuelve un valor booleano
    { 
        /*lo que hace*/

        //El método siempre ha de devolver un resultado del tipo especificado (bool en este caso)
        return /*resultado*/; 
    }
}
```

Los métodos tienen dos formas de comunicarse con el "exterior" (con la parte del código en la que se les llama): los **parametros** y el **valor de retorno**. 
 
 - Parámetros: permiten introducir valores en el método desde el exterior. Se usan principalmente como **inputs**.
   - Un método puede tener tantos parámetros como sea necesario.
 - Valor de Retorno: permite a la función "devolver" un resultado cuando esta termina. Solo puede devolver **un único valor** y se utiliza exclusivamente como **output**.

Ejemplo de método:

```cs
public class Sumador{
    public int Sumar(int a, int b){
        //Al ser parámetros, podemos usar a y b dentro de la función
        Console.WriteLine(a) //Muestra el valor de a en la consola
        Console.WriteLine(b) //Muestra el valor de b
        return a+b; //"retorna" la suma de ambos como resultado
    }
}

```

Ejemplo de uso:

```cs
//Primero instanciar la clase
Sumador sum = new Sumador();

//Ahora podemos usarla
sum.Sumar(1,2); //Podemos no usar el valor de retorno
int valor = sum.Sumar(3,2); //Podemos guardarlo
Console.WriteLine(sum.Sumar(5,5)); //O usarlo directamente

//Tenemos que indicar todos los parámetros obligatorios
//Hacer esto da error:
sum.Sumar();
sum.Sumar(1);

```

## This

`this` es una keyword que solo tiene significado dentro de una clase o método.

This significa **"el objeto que esté ejecutando esto"**. Es un poco como escribir "tonto el que lo lea", "el que lo lea" no es una persona concreta, es `this`.

```cs
//Tonto el que lo ejecute
new Tonto(this);
```

### Usos

"Jaja, muy graciosa, pero de qué nos sirve." Pues para evitar ambigüedades y para referirnos directamente al objeto actual.

> [!warning]
> Esta parte será expandida en el futuro

## Constructores

Son métodos especiales que se usan para instanciar clases. Necesitan la keyword `new` para ser invocados.

```cs
class Example{

  //Constructor simple (no recibe nada y no hace nada)
  public Example(){

  }
}

...

new Example(); //Llama al constructor que hemos declarado
```

Cada clase puede tener tantos constructores como quiera mientras no entren en **conflicto**.

```cs

class Example{

  //Los dos constructores tienen los mismos tipos de parámetros
  //No puede distinguirlos
  public Example(int num){

  }

  public Example(int valor){

  }
}
...

new Example(1); //No sabe qué constructor usar

```

### Usos de los Constructores

Nos permiten especificar los datos que necesita un objeto para poder ser creado y hacer que ocurra algo concreto cuando lo creamos.

Por ejemplo: cada vez que instanciemos la siguiente clase se escribirá "Hola a todos!" en la consola.

```cs
class Saludador{

  //Constructor simple (no recibe nada y no hace nada)
  public Saludador(){
    Console.Write("Hola a todos!"); 
  }
}
```

El siguiente hace lo mismo pero exige que le especifiques un saludo concreto para poder crearlo.

```cs
class Saludador{

  //Constructor simple (no recibe nada y no hace nada)
  public Saludador(string saludo){
    Console.Write(saludo+" a todos!"); 
  }
}

...

new Saludador(); //Dará error porque no se especifica saludo
new Saludador("Hola"); //Mostrará "Hola a todos"
new Saludador(""); //También funciona y mostrará " a todos"
new Saludador(null); //Lo mismo con null
```

Dicho esto, el uso típico es para inicializar valores

```cs
class Coordenada{
  public int x;
  public int y;
  
  public Coordenada(int x, int y){
    //Asigna los parámetros recibidos a los campos
    this.x = x;
    this.y = y;
  }
}

...

var position = new Coordenadas(10,25);
Console.Write(position.y); //El valor de "y" es 25

```