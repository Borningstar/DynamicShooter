namespace Assets.Scripts.Enemy.Weapons
{
    using UnityEngine;

    public interface IEnemyWeapon
    {
        GameObject Ammo { get; }
        float FireRate { get; }
        float Delay { get; }
        float Variance { get; }
    }
}