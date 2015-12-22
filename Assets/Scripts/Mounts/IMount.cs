namespace Assets.Scripts.Mounts
{
    using Assets.Scripts.Items;

    public interface IMount
    {
        string MountName { get; set; }
        IItem Mounted { get; set; }
    }
}