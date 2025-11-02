using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Tempo total de jogo (segundos)")]
    public float gameDuration = 120f;

    [Header("HUD (imagens de vida e escudo)")]
    public Image[] heartImages;   // arrasta Heart1, Heart2, Heart3
    public Image[] shieldImages;  // arrasta Shield1, Shield2, Shield3

    [Header("Painéis de fim de jogo")]
    public GameObject winPanel;   // painel de vitória
    public GameObject losePanel;  // painel de derrota

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

        // se o player já existir na cena, já atualiza HUD
        PlayerHealth ph = FindObjectOfType<PlayerHealth>();
        if (ph != null)
            UpdateHUD(ph);
    }

    void Update()
    {
        if (gameEnded) return;

        // contador regressivo
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            Win();
        }
    }

    // ====== HUD ======

    // versão sem parâmetro (pra manter compatibilidade com seu PlayerHealth atual)
    public void UpdateHUD()
    {
        PlayerHealth ph = FindObjectOfType<PlayerHealth>();
        if (ph != null)
            UpdateHUD(ph);
    }

    // versão com parâmetro (melhor)
    public void UpdateHUD(PlayerHealth player)
    {
        // vidas
        if (heartImages != null && heartImages.Length > 0)
        {
            for (int i = 0; i < heartImages.Length; i++)
            {
                heartImages[i].enabled = i < player.currentHealth;
            }
        }

        // escudos
        if (shieldImages != null && shieldImages.Length > 0)
        {
            for (int i = 0; i < shieldImages.Length; i++)
            {
                shieldImages[i].enabled = i < player.currentShields;
            }
        }
    }

    // ====== DERROTA ======
    public void GameOver()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;

        if (losePanel != null)
            losePanel.SetActive(true);

        Debug.Log("💀 GAME OVER");
    }

    // ====== VITÓRIA ======
    public void Win()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;

        if (winPanel != null)
            winPanel.SetActive(true);

        Debug.Log("🏆 VITÓRIA");
    }

    // ====== REINICIAR ======
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
