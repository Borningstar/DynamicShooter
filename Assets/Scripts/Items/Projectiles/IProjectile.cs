namespace Assets.Scripts.Items.Projectiles
{
    public interface IProjectile
    {
        float Cost { get; set; }
        float Speed { get; set;  }
        float Damage { get; set; }
    }
}