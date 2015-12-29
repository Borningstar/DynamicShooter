namespace Assets.Scripts.Items.Weapons
{
    using Modifiers;
    using Reactors;
    using UnityEngine;

    public interface IWeapon
    {
        GameObject Ammo { get; set; }
        IModifier Modifier { get; set; } 
        float FireRate { get; }

        void ConnectReactor(IReactor reactor);
        bool Fire();
        void LoadAmmo(GameObject ammo);
        void LoadModifier(IModifier modifier);
    }
}