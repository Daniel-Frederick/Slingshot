using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : Spell
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Road"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            // Continue to the next Spell
        }
    }
}
