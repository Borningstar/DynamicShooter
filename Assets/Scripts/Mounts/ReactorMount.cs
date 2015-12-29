namespace Assets.Scripts.Mounts
{
    using Assets.Scripts.Items.Reactors;

    public sealed class ReactorMount : Mount
    {
        public IReactor Mounted
        {
            get; set;
        }
    }
}