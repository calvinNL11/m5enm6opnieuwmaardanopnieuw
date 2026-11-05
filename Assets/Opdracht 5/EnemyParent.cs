using UnityEngine;

public class EnemyParent : MonoBehaviour
{

    public int health = 100;
    public int Speed = 5;

    private void Update()
    {
        Walk();
    }
    public void Walk()
    {
        if (health > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        TakeDamage(50);
    }
}