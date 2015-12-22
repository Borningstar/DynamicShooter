namespace Assets.Scripts.Items.Weapons.Modifiers
{
    using UnityEngine;

    public interface IModifier
    {
        float DamageMod { get; }
        float SpeedMod { get; }
        Vector3 SizeMod { get; }
        float CostMod { get; }
        float FireRateMod { get; }
    }
}