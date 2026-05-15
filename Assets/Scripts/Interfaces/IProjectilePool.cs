public interface IProjectilePool
{
    Projectile Get();
    void Return(Projectile projectile);
}
