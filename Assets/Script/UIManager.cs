using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text points;
    [SerializeField] GameObject inGameUI;

    private void OnEnable()
    {
        GameManager.OnPointsAdded += UpdateCounter;
    }
    private void OnDisable()
    {
        GameManager.OnPointsAdded -= UpdateCounter;
    }
    private void Update()
    {
        if (GameManager.Instance.status == GameStatus.GameRunning)
            inGameUI.SetActive(true);
        else
            inGameUI.SetActive(false);
    }

    public void UpdateCounter()
    {
        points.text = GameManager.Instance.points.ToString();
    }
}