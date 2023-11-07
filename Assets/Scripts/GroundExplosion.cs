using UnityEngine;

public class GroundExplosion : MonoBehaviour
{
    public int damage;
    public float damageRadius;

    private void OnEnable() => Explode();

    public void Damage(Damageable damageable) => damageable.Damage(damage);
    
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRadius);

        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Damageable damageable))
            {
                Damage(damageable);
            }
        }
    }
}
