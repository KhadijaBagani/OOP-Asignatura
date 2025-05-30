namespace VideoGame.Inventory.Correction {


    /// <summary>
    /// Clase base de Item
    /// </summary>
    public abstract class Item {
        public readonly string name;

        /// <summary>
        /// Price nullable y virtual para ser modificable
        /// </summary>
        public virtual int? Price {
            get;
            private set;
        }

        protected Item(string name, int? price = 0) {
            this.name = name;
            this.Price = price;
        }
    }

    /// <summary>
    /// Clase padre de los equipables
    /// </summary>
    public abstract class Equipable : Item {
        public Equipable(string name, int? price = 0) : base(name, price) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True si se ha equipado</returns>
        public virtual bool Equip(Player player) {
            return player !=null; //Por defecto siempre se puede equipar a un jugador
        }
    }

    /// <summary>
    /// Clase padre de todas las armas
    /// </summary>
    public abstract class Weapon : Equipable {
        public Weapon(string name, int? price = 0) : base(name, price) {
        }

    }


    /// <summary>
    /// Espada
    /// </summary>
    public class Sword : Item {
        public Sword(string name, int? price = 0) : base(name, price) {
        }
    }

    /// <summary>
    /// Clase padre de todas las armas de proyectiles
    /// </summary>
    public abstract class ProjectileWeapon : RangedWeapon, IAmmoWeapon {
        protected ProjectileWeapon(string name, int? price = 0) : base(name, price) {
        }

        /// <summary>
        /// Proyectiles restantes
        /// </summary>
        public abstract int Remaining {
            get;
        }
    }

    public class Bow : ProjectileWeapon {
        public Bow(string name, int? price = 0) : base(name, price) {
        }

        public override int Remaining {
            // TODO: Que devuelva el número de flechas en el inventario
            get => throw new NotImplementedException();
        } 

        
    }

    /// <summary>
    /// Pergamino con hechizos
    /// </summary>
    public class SpellScroll : RangedWeapon, ISpellCaster, ILimitedUse {
        protected readonly Spell _spell; //No puedes cambiar el hechizo
        public Spell Spell {
            get => _spell;
        }
        public int Remaining {
            get;
            protected set;
        }
        
        public SpellScroll(string name, Spell spell, int? price = 0) : base(name, price) {
            this._spell = spell;
        }
    }

    /// <summary>
    /// Clase padre de las pociones
    /// </summary>
    public abstract class Potion : Item, IPotion {

        public int Remaining {
            get;
            protected set;
        }

        public readonly int _size;


        public int Size => _size; // Getter de size para satisfacer la interfaz IPotion


        public Potion(string name, int size, int? price = 0) : base(name, price) {
            this.Remaining = size;
            this._size = size;
        }

        /// <summary>
        /// Usa la poción (efecto y disminuir remaining)
        /// </summary>
        /// <param name="player"></param>
        public void Use(Player player) {
            if (Remaining <= 0)
                return;
            Remaining--;
            this.UseEffect(player);
        }

        /// <summary>
        /// Ejecuta el efecto de usar la poción y nada más
        /// </summary>
        /// <param name="player"></param>
        protected abstract void UseEffect(Player player);
    }

    public class MagicWand : RangedWeapon, ISpellCaster, IAmmoWeapon {

        protected readonly Spell _spell;
        public Spell Spell {
            get => _spell;
        }

        public int Remaining {
            get;
            protected set;
        }
        public MagicWand(string name, Spell spell, int? price = 0) : base(name, price) {
            this._spell = spell;
        }
    }

    public abstract class RangedWeapon:Weapon {
        protected RangedWeapon(string name, int? price = 0) : base(name, price) {
        }

        public float MaxRange {
            get;
            protected set;
        }
    }

}