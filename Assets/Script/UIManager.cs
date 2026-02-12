using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text points;
    [SerializeField] GameObject inGameUI;
    [SerializeField] Image playerHealthBar;
    [SerializeField] TMP_Text timerTXT;
    [SerializeField] Button enhancePlayerBTN;
    string minutesTXT;
    string secondsTXT;
    float timer;
    float minutes;
    float seconds;

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

        playerHealthBar.fillAmount = (float)PlayerMovement.Instance.currentHealth / (float)PlayerMovement.Instance.maxHealth;



        timer += Time.deltaTime;

        //converto i secondi in minuti (ogni 60 un minuto arrotondato per difetto)
        minutes = Mathf.Floor(timer / 60);

        //restituisco il resto di timer / 60 arrotondandolo all'intero più vicino
        seconds = Mathf.FloorToInt(timer % 60);


        #region
        ////se i minuti sono ad una sola cifra hanno uno zero davanti
        //if(minutes < 10)
        //    minutesTXT = "0" + minutes.ToString();
        //else
        //    minutesTXT = minutes.ToString();

        //if (seconds < 10)
        //    secondsTXT = "0" + seconds.ToString();
        //else
        //    secondsTXT = seconds.ToString();

        ////compongo il text di 3 stringe: "minuti, secondi, intervallati da :"
        //timerTXT.text = minutesTXT + ":" + secondsTXT;
        #endregion


        //prendo una stringa modello e i valori tra parentesi graffe sono dei segnaposto per gli elementi che inserisco dopo
        //lo 0 sta per "primo elemento dopo la stringa"
        //l'1 sta per "secondo elemento dopo la stringa"
        //:00 è il formato numerico a due cifre (01 - 12)
        timerTXT.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (GameManager.Instance.points < 10)
            enhancePlayerBTN.interactable = false;
        else
            enhancePlayerBTN.interactable = true;

    }

    public void EnhancePlayerAttack()
    {
        PlayerAttack.Instance.damagePerHit += 1;
        GameManager.Instance.points -= 10;
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        points.text = GameManager.Instance.points.ToString();
    }
}
//01:00