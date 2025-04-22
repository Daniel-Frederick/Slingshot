using UnityEngine;

public class Boomerang : Spell
{
    private uint clickCount = 0;
    protected override void Update()
    {
        base.Update();

        if (isLaunched && Input.GetMouseButton(0) && clickCount == 0)
        {
            clickCount++;
            Vector2 toStart = ((Vector2)initPosition - rb.position).normalized;
            Vector2 perp = new Vector2(-toStart.y, toStart.x);
            Vector2 curvedDir = (toStart + perp * 0.5f).normalized;
            rb.linearVelocity = curvedDir * rb.linearVelocity.magnitude;
        }
    }
}
