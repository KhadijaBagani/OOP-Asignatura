namespace VideoGame.Inventory.Correction {

    /// <summary>
    /// Interfaz de los items que lanzan spells
    /// </summary>
    public interface ISpellCaster {
        /// <summary>
        /// Spell concreto que lanza
        /// </summary>
        public Spell Spell { get; }
    }


    public interface ILimitedUse {
        /// <summary>
        /// Permite saber los usos restantes que tienen pero no modificarlos
        /// </summary>
        public int Remaining {
            get;
        }
    }

    /// <summary>
    /// Interfaz de los items que usan munición
    /// </summary>
    public interface IAmmoWeapon : ILimitedUse {
        // TODO: Añadir forma de obtener tipo de munición
    }

}