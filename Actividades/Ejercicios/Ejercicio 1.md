# Ejercicio 1: Concesionario

Estamos trabajando en un software interno que gestiona un concesionario y nos hemos encontrado la siguiente clase:

```cs
/// <summary>
/// Clase que define las características de los coches
/// </summary>
public class Car{
    /// <summary>
    /// Número de matrícula (4 números y 3 letras), null si no ha sido matriculado
    /// </summary>
    public string? plateNumber;

    /// <summary>
    /// Color/patrón con el que ha sido pintado
    /// </summary>
    public string paint;

    /// <summary>
    /// Modelo de vehículo
    /// </summary>
    public string model;

    /// <summary>
    /// Número de kilómetros que tiene el vehículo
    /// </summary>
    public float kmTraveled;

    public Car(string model, string paint, string? plateNum = null, float km=0){
        this.model = model;
        this.paint = paint;
        this.plateNumber = plateNum;
        this.kmTraveled = km;
    }
}

```

La clase como tal **no está mal**, pero no cumple los principios de **OOP**, especialmente el de **Encapsulación**. A lo largo de este ejercicio intentaremos remediarlo y entender qué nos aporta OOP en esta situación.

## Primero de todo

> [!warning]
> Copiad esta clase en un **módulo nuevo** (preguntad si no sabeis hacerlo) que tenga el namespace **Concesionario**.
>

## 1. Nada de Transformers

Es un poco absurdo que podamos modificar el modelo del vehículo después de crearlo. No tiene ningún sentido a no ser que los coches sean capaces de transformarse.

Cómo asumimos que no estamos en una peli de Michael Bay, nos gustaría hacer que el modelo **no sea modificable** una vez creado el Coche.


## 2. La madre que te matriculó

No sabemos si es por un empleado manazas o un error del programa, pero nos hemos encontrado que muchos vehículos acaban con matrículas inválidas.

Para solucionarlo, hemos creado el siguiente **método** (cópialo en la clase **Car**):

```cs
/// <summary>
/// Asigna la matrícula al vehículo y garantiza que no se asigna una matrícula no válida
/// </summary>
/// <param name="plateNumber">Número de matrícula (4 números y 3 letras mayúsculas)</param>
public void Matricular(string plateNumber){
    if(plateNumber == null || plateNumber.Length == 0)
        throw new Exception("Matrícula no especificada");
    if(plateNumber.Length!=7)
        throw new Exception("Longitud de matrícula inválida");
    
    this.plateNumber = plateNumber;
}
```

El problema es que este método no impide al resto del programa seguir asignando directamente la matrícula y saltarse las protecciones. 

> Encapsula **plateNumber** para garantizar que siempre se hacen las comprobaciones antes de asignar la matrícula.

### BONUS: Patrón Matrícula

> [!warning]
> Solo para los que vais avanzados

Añadid otra comprobación a **Matricular** que garantice que el texto introducido tiene **4 números** y **3 letras**.

```cs
//Error que tiene que lanzar
throw new Exception("Formato de matrícula inválido");
```

Aquí teneis recursos que podeis usar:

- [IsDigit()](https://how.dev/answers/what-is-charisnumber-in-c-sharp)
- [IsLetter()](https://www.geeksforgeeks.org/c-sharp-char-isletter-method/)
- [RegEx](https://www.aluracursos.com/blog/regex-en-c-sharp-como-utilizar-expresiones-regulares)

## 3. Cuentakilometros

Queremos encapsular también el contador de los kilometros viajados (**kmTraveled**), pero de una forma específica

- Queremos que se pueda poner un valor inicial en el contructor
- Pero que a partir de ese momento solo se pueda incrementar

De esta forma impedimos que se pueda accidentalmente resetear el valor.

### Bonus: Extra encapsulado

Realmente, si lo pensamos, no hay necesidad de permitir a la clase **Car** modificar el valor del cuentakilomentros. En vez de encapsular el valor directamente dentro de Car, podríamos crear otra clase que se responsabilice exclusivamente de que el cuentakilometros funcione como es debido:

```cs
public class KMCount{
    public float count;
}

```

**Reemplaza** el funcionamiento del cuentakilomentros original con esta clase y encapsulala para permitir **solo incrementos** y nada más. Evita también que se pueda **reemplazar** el Cuentakilometros por uno nuevo.