using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateHandler : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject interactionInfo;

    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;
    public GameObject restartButton;

    public static GameStateHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            return;
        }

    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void PauseGame()
    {
        playerController.animator.SetBool("isWalking", false);
        StartCoroutine(PauseDelay());

    }

    public void ContinueGame()
    {
        playerController.enabled = true;
    }

    public void SetInteractionInfo(Vector3 targetPos)
    {
        interactionInfo.SetActive(true);
        interactionInfo.transform.position = targetPos;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
        gameOverText.text = "Life is Short. Don't be in Hurry...";
        StartCoroutine(RestartAppearDelay());
        Debug.Log("Game Over ");
    }

    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator RestartAppearDelay()
    {
        yield return new WaitForSeconds(3);
        restartButton.SetActive(true);
    }

    IEnumerator PauseDelay()
    {
        yield return new WaitForSeconds(0.5f);
        playerController.enabled = false;
    }
}
