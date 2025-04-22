using UnityEngine;

public class RedirectSpell : Spell
{
    private uint clickCount = 0;
    protected override void Update() {
        base.Update();

        if (isLaunched && Input.GetMouseButtonDown(0) && clickCount == 0) {
            clickCount++;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = ((Vector2)mouseWorldPosition - rb.position).normalized;
            float currentSpeed = rb.linearVelocity.magnitude;
            rb.linearVelocity = direction * currentSpeed;
        }
    }
}
