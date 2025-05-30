namespace VideoGame.Inventory.Correction {


    /*Usad un placeholder para estas clases*/
    public class Player {

    }

    public abstract class Spell {

    }


    public class Armor : Equipable {

        public readonly float dmgReduction;

        public Armor(string name, float dmgReduction) : base(name) {
            if (dmgReduction > 1 || dmgReduction < 0)
                throw new Exception("dmgReduction percentage is out of bounds");
            this.dmgReduction = dmgReduction;
        }

        public virtual int ReduceDMG(int baseDamage) {
            var ret = (int)(baseDamage * (1 - dmgReduction));
            Console.WriteLine($"Damage reduced from {baseDamage} to {ret}");
            return ret;
        }
    }

    /// <summary>
    /// Interfaz de las pociones
    /// </summary>
    public interface IPotion : ILimitedUse {

        /// <summary>
        /// Tamaño de la poción
        /// </summary>
        public int Size {
            get;
        }
            

    }

    public class HealingPotion : Potion {
        public HealingPotion(int size, int? price = 0) : base("Healing Potion " + size, size, price) {

        }



        protected override void UseEffect(Player player) {
            Console.WriteLine("Healing");
        }


    }

    public class ManaPotion : Potion {
        public ManaPotion(int size, int? price = 0) : base("Healing Potion " + size, size, price) {

        }

        protected override void UseEffect(Player player) {
            Console.WriteLine("Recharging");
        }

    }

    public class StaminaPotion : Potion {
        public StaminaPotion(int size, int? price = 0) : base("Healing Potion " + size, size, price) {

        }

    
        protected override void UseEffect(Player player){
            Console.WriteLine("Recovering");
        }

    }
    
    public class RestoreAll:Potion{
        public RestoreAll(int size, int? price=0):base("Healing Potion "+size,size,price){
            
        }

        protected override void UseEffect(Player player) {
            Console.WriteLine("Healing");
            Console.WriteLine("Recharging");
            Console.WriteLine("Recovering");
        }

    }
}