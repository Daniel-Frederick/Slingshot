using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellController : MonoBehaviour
{
    private Vector3 initPosition;
    new CircleCollider2D collider;
    int speed = 50;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        initPosition = transform.position;
    }

    private void Update()
    {
        // TODO: I did this wrong
        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > -10 || transform.position.x < 10)
        {
            Debug.Log("did it wrong");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnMouseUp()
    {
        // Need to fix the collider variable

        //Vector2 directionToInitPos = initPosition - transform.position;
        //collider.AddForce(directionToInitPos * speed);
        //collider.gracityScale = 1;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

}
