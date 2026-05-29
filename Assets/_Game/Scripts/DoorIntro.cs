using System.Collections;
using UnityEngine;

public class DoorIntro : MonoBehaviour
{
    public Transform startWalkTarget;
    public float walkSpeed = 2.5f;
    public float startDelay = 0.3f;

    private Rigidbody2D rb;
    private PlayerController playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();

        StartCoroutine(PlayIntro());
    }

    private IEnumerator PlayIntro()
    {
        if (playerController != null)
        {
            playerController.enabled = false;
        }

        yield return new WaitForSeconds(startDelay);

        if (startWalkTarget != null && rb != null)
        {
            while (Mathf.Abs(transform.position.x - startWalkTarget.position.x) > 0.05f)
            {
                float direction = Mathf.Sign(startWalkTarget.position.x - transform.position.x);

                rb.linearVelocity = new Vector2(direction * walkSpeed, rb.linearVelocity.y);

                transform.localScale = new Vector3(
                    direction * Mathf.Abs(transform.localScale.x),
                    transform.localScale.y,
                    transform.localScale.z
                );

                yield return null;
            }
        }

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }

        if (playerController != null)
        {
            playerController.enabled = true;
        }
    }
}