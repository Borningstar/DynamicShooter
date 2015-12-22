namespace Assets.Scripts.Mounts
{
    using Items.Weapons;

    public sealed class WeaponMount : Mount
    {
        public IWeapon Mounted
        {
            get; set;
        }
    }
}