using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float leftX = 7f;
    public float rightX = 10f;

    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        if (transform.position.x >= rightX)
        {
            direction = -1;
        }
        else if (transform.position.x <= leftX)
        {
            direction = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.LoseLevel();
        }
    }
}