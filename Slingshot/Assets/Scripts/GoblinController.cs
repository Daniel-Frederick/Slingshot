using UnityEngine;

public class GoblinController : MonoBehaviour
{
    private float velocityThreshold = .8f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a box hits an enemy at high speed
        if (collision.gameObject.CompareTag("Box") && collision.relativeVelocity.y < velocityThreshold-1)
        {
            Destroy(gameObject);
        }

        // Goblin fall damage
        if (collision.gameObject.CompareTag("Road") && collision.relativeVelocity.y > velocityThreshold) {
            Destroy(gameObject);
        }
    }
}
