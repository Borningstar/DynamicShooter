namespace Assets.Scripts.Items
{
    using Vexe.Runtime.Types;

    public class Item : BetterBehaviour, IItem
    {
        protected string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        protected string prefix;
        public string Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        protected string suffix;
        public string Suffix
        {
            get { return suffix; }
            set { suffix = value;}
        }
    }
}