namespace Assets.Scripts.Mounts
{
    using Assets.Scripts.Items.Shields;

    public class ShieldMount : Mount
    {
        public IShield Mounted
        {
            get; set;
        }
    }
}