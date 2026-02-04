using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
    GamePaused,
    GameRunning
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public static GameManager Instance;
    public GameStatus status;
    public int points;
    public static event Action OnPointsAdded;

    private void OnEnable()
    {
        Bush.OnItemDestroyed += GetPoints;
        EnemyMovement.OnEnemyKilled += GetPoints;
    }


    private void OnDisable()
    {
        Bush.OnItemDestroyed -= GetPoints;
        EnemyMovement.OnEnemyKilled -= GetPoints;
    }
    private void GetPoints(int maxHealth)
    {
        points += maxHealth;
        OnPointsAdded?.Invoke();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        status = GameStatus.GamePaused;
    }

    private void Update()
    {
        if (status == GameStatus.GamePaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        status = GameStatus.GameRunning;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        status = GameStatus.GamePaused;
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        status = GameStatus.GameRunning;
    }
}
//ReloadScene --> reloadate la scena corrente