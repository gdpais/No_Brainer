using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    public float force = 10.0f;
    bool stomped = false;
    public AudioClip deathSound;
    // Start is called before the first frame updates
    private void OnTriggerEnter2D(Collider2D other)
    {
        //CapsuleCollider2D coll = transform.parent.gameObject.GetComponent<CapsuleCollider2D>();
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D palyerRb = other.GetComponent<Rigidbody2D>();
            palyerRb.AddForce(transform.up * force, ForceMode2D.Impulse);
            Die();
        }

        if (other.gameObject.CompareTag("waves"))
        {
            Die();
        }

        /*if (other.gameObject.CompareTag("boxMovable"))
        {
            stomped = true;
            coll.enabled = false;
        }*/
    }

    private void Die()
    {
        stomped = true;
        CapsuleCollider2D coll = transform.parent.gameObject.GetComponent<CapsuleCollider2D>();
        coll.enabled = false;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    //When the gameObject is stomped and exits the screen, its destroyed
    private void OnBecameInvisible()
    {
        if (stomped)
            Destroy(transform.parent.gameObject);
    }
}
