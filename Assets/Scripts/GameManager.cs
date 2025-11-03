using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Tempo total de jogo (segundos)")]
    public float gameDuration = 120f;

    [Header("HUD (imagens de vida e escudo)")]
    public Image[] heartImages;
    public Image[] shieldImages;

    [Header("Painéis de fim de jogo")]
    public GameObject winPanel;
    public GameObject losePanel;

    private float currentTime;
    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = gameDuration;

        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);

        PlayerHealth ph = FindFirstObjectByType<PlayerHealth>();
        if (ph != null)
            UpdateHUD(ph);
    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            Win();
        }
    }

    // ===== HUD =====
    public void UpdateHUD()
    {
        PlayerHealth ph = FindFirstObjectByType<PlayerHealth>();
        if (ph != null)
            UpdateHUD(ph);
    }

    public void UpdateHUD(PlayerHealth player)
    {
        if (heartImages != null && heartImages.Length > 0)
        {
            for (int i = 0; i < heartImages.Length; i++)
                heartImages[i].enabled = i < player.currentHealth;
        }

        if (shieldImages != null && shieldImages.Length > 0)
        {
            for (int i = 0; i < shieldImages.Length; i++)
                shieldImages[i].enabled = i < player.currentShields;
        }
    }

    // ===== DERROTA =====
    public void GameOver()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;
        if (losePanel != null)
            losePanel.SetActive(true);
    }

    // ===== VITÓRIA =====
    public void Win()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;
        if (winPanel != null)
            winPanel.SetActive(true);
    }

    // ===== REINICIAR =====
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
