using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
}