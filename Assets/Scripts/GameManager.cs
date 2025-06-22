using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Panel and UI Elements")]
    public GameObject gameOverPanel;
    public GameObject youLoseText;
    public GameObject youWinText;
    public Button restartButton;
    public Button exitButton;

    private void Awake()
    {
        Instance = this;

        // Ensure everything starts hidden
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (youLoseText != null) youLoseText.SetActive(false);
        if (youWinText != null) youWinText.SetActive(false);
    }

    private void Start()
    {
        // Optional: hook up button actions in case they're not set via Inspector
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitToMainMenu);
    }

    public void ShowLoseScreen()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (youLoseText != null) youLoseText.SetActive(true);
        if (youWinText != null) youWinText.SetActive(false);
    }

    public void ShowWinScreen()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (youLoseText != null) youLoseText.SetActive(false);
        if (youWinText != null) youWinText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("Main"); // Ensure this scene is added to Build Settings
    }
}
