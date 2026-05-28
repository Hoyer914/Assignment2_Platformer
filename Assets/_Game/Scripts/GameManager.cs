using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalCoins;
    public int collectedCoins;

    public TMP_Text coinText;
    public TMP_Text messageText;

    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        collectedCoins = 0;
        UpdateCoinText();

        if (messageText != null)
        {
            messageText.text = "";
        }
    }

    public void CollectCoin()
    {
        if (gameEnded)
        {
            return;
        }

        collectedCoins++;
        UpdateCoinText();
    }

    public bool HasCollectedAllCoins()
    {
        return collectedCoins >= totalCoins;
    }
    public bool IsGameEnded()
    {
        return gameEnded;
    }

    public void ShowNeedCoinsMessage()
    {
        if (messageText != null)
        {
            messageText.text = "Collect all coins first!";
        }
    }

    public void WinLevel()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;

        if (messageText != null)
        {
            messageText.text = "You Win!";
        }

        StartCoroutine(RestartAfterDelay());
    }

    public void LoseLevel()
    {
        if (gameEnded)
        {
            return;
        }

        gameEnded = true;

        if (messageText != null)
        {
            messageText.text = "You Lose!";
        }

        StartCoroutine(RestartAfterDelay());
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + collectedCoins + " / " + totalCoins;
        }
    }

    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}