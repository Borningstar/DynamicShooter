﻿namespace Assets.Scripts.Items.Projectiles
{
    public interface IProjectile
    {
        float Cost { get; }
        float Speed { get; set;  }
        float Damage { get; set; }
    }
}