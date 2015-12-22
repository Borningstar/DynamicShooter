namespace Assets.Scripts.Items
{
    using Vexe.Runtime.Types;

    public class Item : BetterBehaviour, IItem
    {
        public string Type { get; protected set; }
        public string Prefix { get; protected set; }
        public string Suffix { get; protected set; }
    }
}