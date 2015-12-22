namespace Assets.Scripts.Items.Shields
{
    using Reactors;

    public interface IShield
    {
        float MaximumShield { get; }
        float RechargeAmount { get; }
        float RechageDelay { get; }
        float RechargeRate { get; }
        float RechargeCost { get; }
        float CurrentShield { get; }

        float DealDamage(float damage);
        string ToString();
        void ConnectReactor(Reactor reactor);
    }
}
