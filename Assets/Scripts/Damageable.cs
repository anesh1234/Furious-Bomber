using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;

    Player playerObject;

    public void Damage(int damage)
    {
        currentHealth -= damage;
        playerObject.AddPoints(damage * 10);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

}
