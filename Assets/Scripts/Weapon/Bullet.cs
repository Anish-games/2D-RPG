using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    public GameObject damageEffect;
    public int damage;
    void Start()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyableObj destroy = collision.GetComponent<DestroyableObj>();

        if (destroy != null)
        {
            destroy.takeDamage(damage);
        }
        
        Instantiate(damageEffect , transform.position , transform.rotation);

        Destroy(gameObject);
    }
}
