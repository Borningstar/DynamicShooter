namespace Assets.Scripts.Mounts
{
    using System;
    using Items;
    using Vexe.Runtime.Types;

    public class Mount : BetterBehaviour, IMount
    {
        public string MountName
        {
            get; set;
        }

        public IItem Mounted
        {
            get; set;
        }
    }
}