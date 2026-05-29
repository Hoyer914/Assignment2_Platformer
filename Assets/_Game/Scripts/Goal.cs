using UnityEngine;

public class Goal : MonoBehaviour
{
    public float centerTolerance = 0.25f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        float distanceToDoorCenter = Mathf.Abs(collision.transform.position.x - transform.position.x);

        if (distanceToDoorCenter > centerTolerance)
        {
            return;
        }

        if (GameManager.Instance.HasCollectedAllCoins())
        {
            GameManager.Instance.WinLevel();
        }
        else
        {
            GameManager.Instance.ShowNeedCoinsMessage();
        }
    }
}