using System.Collections;
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

    [Header("Texto de tempo")]
    public Text txtTempo;   

    [Header("Velocidade global")]
    public float globalSpeed = 1f;
    private Coroutine speedRoutine;

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

        UpdateTimeUI();
    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            UpdateTimeUI();
            Win();
            return;
        }

        UpdateTimeUI();
    }

    void UpdateTimeUI()
    {
        if (txtTempo == null) return;

        int seconds = Mathf.CeilToInt(currentTime);
        int m = seconds / 60;
        int s = seconds % 60;
        txtTempo.text = $"{m:00}:{s:00}";
    }

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

    public void GameOver()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;
        if (losePanel != null)
            losePanel.SetActive(true);
    }

    public void Win()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;
        if (winPanel != null)
            winPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void BoostGlobalSpeed(float multiplier, float duration)
    {
        if (speedRoutine != null)
            StopCoroutine(speedRoutine);

        speedRoutine = StartCoroutine(BoostRoutine(multiplier, duration));
    }

    private IEnumerator BoostRoutine(float multiplier, float duration)
    {
        globalSpeed = multiplier;
        yield return new WaitForSeconds(duration);
        globalSpeed = 1f;
        speedRoutine = null;
    }
}