namespace Assets.Scripts.Items
{
    public interface IItem
    {
        string Type { get; }
        string Prefix { get; }
        string Suffix { get; }
    }
}