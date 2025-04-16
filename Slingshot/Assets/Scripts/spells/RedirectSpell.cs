using UnityEngine;

public class RedirectSpell : Spell
{
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goblin")) {
            Destroy(collision.gameObject);
        }
    }

    protected override void Update() {
        base.Update();

        if (isLaunched && Input.GetMouseButtonDown(0)) {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = ((Vector2)mouseWorldPosition - rb.position).normalized;
            float currentSpeed = rb.linearVelocity.magnitude;
            rb.linearVelocity = direction * currentSpeed;
        }
    }
}
