using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;  //prefab dell'enemy da spawnare
    [SerializeField] float rate;        //rate con il quale spawnano
    float timer;
    int counter;
    [SerializeField] float minRate;
    [SerializeField] int countBeforeChangeRate;
    [SerializeField] float changedRate;
    private void Update()
    {
        //finchè è in pausa non spawna nessuno e il timer sta "fermo"
        //if (GameManager.Instance.status == GameStatus.GamePaused) return;

        //quando vado in running comincio a far partire il timer
        timer += Time.deltaTime;

        //se il timer raggiunge il rate, spawno il prefab dell'enemy nella posizione dello spawner con la sua rotazione
        if(timer>=rate)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation, transform);
            counter++;

            //se counter è un multiplo di countBeforeChangeRate e non è 0, e il rateo è maggiore del minimo, cambio rateo
            if (counter % countBeforeChangeRate == 0 && counter != 0 && rate >= minRate)
                rate -= changedRate;

            //resetto il timer
            timer = 0;
        }
    }
}
