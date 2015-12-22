namespace Assets.Scripts.Items
{
    public interface IItem
    {
        string Type { get; set; }
        string Prefix { get; set; }
        string Suffix { get; set; }
    }
}