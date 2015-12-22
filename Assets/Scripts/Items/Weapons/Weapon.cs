namespace Assets.Scripts.Items.Weapons
{
    using Reactors;
    using Projectiles;
    using UnityEngine;

    public class Weapon : Item, IWeapon
    {
        public GameObject Ammo { get; set; }
        public WeaponModifier WeaponModifier { get; set; }
        public float FireRate { get; protected set; }

        protected float cost;
        protected float nextFire;
        protected Reactor reactor;

        protected virtual void Start()
        {
            if (Ammo != null)
            {
                LoadAmmo(Ammo);

                if (WeaponModifier != null)
                {
                    LoadModifier(WeaponModifier);
                }
            }
        }

        public virtual void LoadAmmo(GameObject ammo)
        {
            Ammo = ammo;
            cost = Ammo.GetComponent<Projectile>().Cost;
        }

        public virtual void LoadModifier(WeaponModifier weaponModifier)
        {
            WeaponModifier = weaponModifier;
            FireRate *= WeaponModifier.fireRateMod;
            cost *= WeaponModifier.costMod;
        }

        public void ConnectReactor(Reactor reactor)
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
            if (WeaponModifier != null)
            {
                projectile.GetComponent<Projectile>().Damage *= WeaponModifier.damageMod;
                var oldScale = projectile.transform.localScale;
                projectile.transform.localScale = Vector3.Scale(WeaponModifier.sizeMod, oldScale);
                projectile.GetComponent<Projectile>().Speed *= WeaponModifier.speedMod;
            }
        }
    }
}