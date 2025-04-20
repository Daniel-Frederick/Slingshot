using UnityEngine;

public class GoblinController : MonoBehaviour
{
    // private float velocityThreshold = .8;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a box hits an enemy at high speed
        if (collision.gameObject.CompareTag("Box") && collision.contacts[0].normal.y < -.5)
        {
            Destroy(gameObject);
        }

        // Goblin fall damage
        if (collision.gameObject.CompareTag("Road") && collision.relativeVelocity.y > .8) {
            Destroy(gameObject);
        }
    }
}
