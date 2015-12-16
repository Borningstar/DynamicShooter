namespace Assets.Scripts.Components
{
    interface IComponent
    {
        string Type { get; set; }
        string Prefix { get; set; }
        string Suffix { get; set; }
    }
}
