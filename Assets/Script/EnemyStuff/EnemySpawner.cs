using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;  //prefab dell'enemy da spawnare
    [SerializeField] float rate;        //rate con il quale spawnano
    float timer;

    private void Update()
    {
        //finchè è in pausa non spawna nessuno e il timer sta "fermo"
        //if (GameManager.Instance.status == GameStatus.GamePaused) return;

        //quando vado in running comincio a far partire il timer
        timer += Time.deltaTime;

        //se il timer raggiunge il rate, spawno il prefab dell'enemy nella posizione dello spawner con la sua rotazione
        if(timer>=rate)
        {
            Instantiate(enemy, transform.position, transform.rotation);

            //resetto il timer
            timer = 0;
        }
    }
}
