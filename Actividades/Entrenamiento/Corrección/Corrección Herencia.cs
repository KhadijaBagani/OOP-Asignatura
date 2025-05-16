

namespace Concesionario{

    /// <summary>
    /// Clase abstracta de vehículo
    /// </summary>
    public abstract class Vehicle{
        public readonly string model;
        
        public Vehicle(string model){
            this.model = model;
        }

        /// <summary>
        /// Indica si el vehículo tiene el combustible necesario para continuar
        /// </summary>
        public virtual bool HasFuel => false;

        public abstract void Drive();
    }

    partial class Car{

        public override void Drive(){
            Console.WriteLine("Conduciendo Coche");
        }

    }

    /// <summary>
    /// Patinete eléctrico
    /// </summary>
    class ElectricScooter : Vehicle {

        /// <summary>
        /// Porcentaje de batería entre 0 y 1
        /// </summary>
        public decimal batteryLevel;

        public override bool HasFuel => batteryLevel>0;

        public ElectricScooter(string model) : base(model) {

        }

        public override void Drive(){
            Console.WriteLine("Conduciendo Coche");
        }
    }

    /// <summary>
    /// Bici
    /// </summary>
    class Bike : Vehicle {
        public new string model ="Error";

        public string vehicleModel => base.model;
        
        public override bool HasFuel => true;
        public Bike(string model) : base(model) {

        }

        public override void Drive(){
            Console.WriteLine("Conduciendo Coche");
        }
    }
    /// <summary>
    /// Sirve como nexo del módulo
    /// </summary>
    public class Module{

        /// <summary>
        /// Punto de entrada para ejecutar el módulo
        /// </summary>
        public static void Execute(){
            
            /*
                funcionalidades del módulo
            */
            var testCar = new Car("Opel","Blanco");
            testCar.kmTraveled.Increase(100.0f);
            List<Vehicle> miLista = new List<Vehicle>();

            
            miLista.Add(testCar);
            miLista.Add(new ElectricScooter("Xiaomi"));
            miLista.Add(new Bike("BMX"));

        

            Bike bici = new Bike("Mountain Bike");
            Vehicle copia = bici;
            Console.WriteLine(bici.model);
            Console.WriteLine(bici.vehicleModel); 
            Console.WriteLine(copia.model);

        }

    }
}