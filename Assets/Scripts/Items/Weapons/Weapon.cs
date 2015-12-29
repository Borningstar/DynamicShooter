namespace Assets.Scripts.Items.Weapons
{
    using Reactors;
    using Projectiles;
    using UnityEngine;
    using Modifiers;

    public class Weapon : Item, IWeapon
    {
        public GameObject Ammo { get; set; }
        public IModifier Modifier { get; set; }
        public float FireRate { get; protected set; }

        protected float cost;
        protected float nextFire;
        protected IReactor reactor;

        protected virtual void Start()
        {
            if (Ammo != null)
            {
                LoadAmmo(Ammo);

                if (Modifier != null)
                {
                    LoadModifier(Modifier);
                }
            }
        }

        public virtual void LoadAmmo(GameObject ammo)
        {
            Ammo = ammo;
            cost = Ammo.GetComponent<Projectile>().Cost;
        }

        public virtual void LoadModifier(IModifier modifier)
        {
            Modifier = modifier;
            FireRate *= Modifier.FireRateMod;
            cost *= Modifier.CostMod;
        }

        public void ConnectReactor(IReactor reactor)
        {
            this.reactor = reactor;
        }

        public virtual bool Fire()
        {
            if (reactor != null && Ammo != null)
            {
                if (Time.time > nextFire)
                {
                    if (reactor.Drain(cost))
                    {
                        nextFire = Time.time + FireRate;

                        LaunchProjectile();

                        return true;
                    }
                }
            }
            return false;
        }

        protected virtual void LaunchProjectile()
        {
            GameObject tempProjectile = Instantiate(Ammo, this.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f)) as GameObject;

            ApplyModifiers(tempProjectile);
        }

        protected virtual void ApplyModifiers(GameObject projectile)
        {
            if (Modifier != null)
            {
                projectile.GetComponent<Projectile>().Damage *= Modifier.DamageMod;
                var oldScale = projectile.transform.localScale;
                projectile.transform.localScale = Vector3.Scale(Modifier.SizeMod, oldScale);
                projectile.GetComponent<Projectile>().Speed *= Modifier.SpeedMod;
            }
        }
    }
}