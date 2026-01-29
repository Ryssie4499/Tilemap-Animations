using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
    GamePaused,
    GameRunning
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStatus status;


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
}
//ReloadScene --> reloadate la scena corrente