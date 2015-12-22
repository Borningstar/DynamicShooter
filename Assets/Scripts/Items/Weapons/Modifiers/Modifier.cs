namespace Assets.Scripts.Items.Weapons.Modifiers
{
    using UnityEngine;
    using Vexe.Runtime.Types;

    public class Modifier : BetterScriptableObject, IModifier
    {
        public float DamageMod { get; protected set; }
        public float SpeedMod { get; protected set; }
        public Vector3 SizeMod { get; protected set; }
        public float CostMod { get; protected set; }
        public float FireRateMod { get; protected set; }
    }
}