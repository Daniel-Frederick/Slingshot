using UnityEngine;

public class Boomerang : Spell
{
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float curveHeight = 2f;

    protected override void Update()
    {
        base.Update();

        if (isLaunched && Input.GetMouseButtonDown(0))
        {
            // cast initPosition to Vector2 so types match
            Vector2 start2D = (Vector2)initPosition;
            Vector2 toStart = (start2D - rb.position).normalized;

            // compute how “deep” the dip should be
            float dist = Vector2.Distance(start2D, rb.position);
            float curve  = Mathf.Sin(dist / maxDistance * Mathf.PI) * curveHeight;

            // build your curved direction and re‑normalize
            Vector2 curvedDir = new Vector2(toStart.x, toStart.y - curve).normalized;

            // apply it
            rb.linearVelocity = curvedDir * speed;
        }
    }
}
