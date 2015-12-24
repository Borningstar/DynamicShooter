namespace Assets.Scripts.Enemy.Ships
{
    using System.Collections.Generic;
    using UnityEngine;

    public interface IEnemyShip
    {
        float Speed { get; }
        float Health { get; }
        List<GameObject> Weapons { get; }

        bool DealDamage(float damage);
    }
}