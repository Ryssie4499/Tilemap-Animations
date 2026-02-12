using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GameMode : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] List<EnemySpawner> spawners;
    bool spawnerEnabled = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        //se gli spawner sono abilitati
        if (spawnerEnabled)
        {
            //vado a disabilitarli tutti
            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].enabled = false;
            }

            //distruggo tutti i nemici
            foreach (EnemyMovement enemy in FindObjectsByType<EnemyMovement>(sortMode: FindObjectsSortMode.None))
            {
                Destroy(enemy.gameObject);
            }

            //disattiviamo la booleana per resettare tutto
            spawnerEnabled = false;
        }
        //se gli spawner sono disabilitati
        else
        {
            //li riabilito tutti
            for (int i = 0; i < spawners.Count; i++)
            {
                spawners[i].enabled = true;
            }

            //attiviamo la booleana per resettare tutto
            spawnerEnabled = true;
        }
    }
}
