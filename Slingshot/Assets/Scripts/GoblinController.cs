using UnityEngine;

public class GoblinController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a box hits an enemy at high speed
        if (collision.contacts[0].normal.y < -.5)
        {
            Destroy(gameObject);
        }
    }
}
