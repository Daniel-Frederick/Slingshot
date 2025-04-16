using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : Spell
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Road"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
