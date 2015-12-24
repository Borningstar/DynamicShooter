namespace Assets.Scripts.Items.Hulls
{
    public interface IHull
    {
        float MaximumHull { get; }

        void Repair(float amount);
        bool DealDamage(float damage);
        string ToString();
    }
}
