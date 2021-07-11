using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    public float force = 10.0f;
    bool stomped = false;
    // Start is called before the first frame updates
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D palyerRb = other.GetComponent<Rigidbody2D>();
            palyerRb.AddForce(transform.up * force, ForceMode2D.Impulse);
            stomped = true;
            CapsuleCollider2D coll = transform.parent.gameObject.GetComponent<CapsuleCollider2D>();
            coll.enabled = false;
        }
    }

    //When the gameObject is stomped and exits the screen, its destroyed
    private void OnBecameInvisible()
    {
        if (stomped)
            Destroy(transform.parent.gameObject);
    }
}
