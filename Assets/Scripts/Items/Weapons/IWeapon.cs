namespace Assets.Scripts.Items.Weapons
{
    using Reactors;
    using UnityEngine;

    public interface IWeapon
    {
        GameObject Ammo { get; set; }
        WeaponModifier WeaponModifier { get; set; } 
        float FireRate { get; }

        void ConnectReactor(Reactor reactor);
        bool Fire();
        void LoadAmmo(GameObject ammo);
        void LoadModifier(WeaponModifier weaponModifier);
    }
}