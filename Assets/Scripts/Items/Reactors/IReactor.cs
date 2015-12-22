namespace Assets.Scripts.Items.Reactors
{
    public interface IReactor
    {
        float MaximumCapacity { get; }
        float RechargeRate { get; }
        float RechargeAmount { get; }
        float CurrentCharge { get; }

        bool Drain(float amount);
        string ToString();
    }
}