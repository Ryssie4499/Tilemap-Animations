using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float tileSize;    //Grandezza della tile da spostare
    [SerializeField] float viewZone = 1;//il range di visibilità dal player al bordo della camera
    [SerializeField] Transform player;  //posizione del player

    private Transform[] tiles; //array di tiles da spostare
    private int leftIndex, rightIndex;  //indici di posizione delle tiles

    private void Start()
    {
        //settaggio iniziale degli indici

        //faccio in modo che le tiles a cui fa riferimento lo script, siano i figli dello script, indipendentemente da quanti sono
        tiles = new Transform[transform.childCount];
        for(int i= 0; i< transform.childCount; i++)
        {
            tiles[i] = transform.GetChild(i);
        }

        //assegno i valori iniziali degli indici
        leftIndex = 0;
        rightIndex = tiles.Length-1;
    }
    private void Update()
    {
        //movimento tiles

        //se la posizione del player è all'interno della viewZone, la tile di sinistra si sposta a destra
        while(player.position.x > (tiles[rightIndex].transform.position.x - viewZone))
        {
            SwitchRight();
        }

        //se la posizione del player è all'interno della viewZone, la tile di destra si sposta a sinistra
        while(player.position.x < (tiles[leftIndex].transform.position.x + viewZone))
        {
            SwitchLeft();
        }
    }

    //spostiamo la tile precedente e la facciamo diventare successiva (da sinistra verso destra)
    void SwitchRight()
    {
        //se è una sola tile, non possiamo spostarla
        if (tiles.Length < 2) return;

        //sposto la tile da sinistra a destra della sua stessa misura sommata a quella della tile che al momento sta a destra
        tiles[leftIndex].position = Vector3.right * (tiles[rightIndex].position.x + tileSize);

        //aggiorno gli indici
        rightIndex = leftIndex;
        leftIndex++;

        //controllo che l'indice non sfori la size dell'array
        if (leftIndex == tiles.Length)
        {
            leftIndex = 0;
        }
    }

    //spostiamo la tile successiva e la facciamo diventare precedente (da destra verso sinistra)
    void SwitchLeft()
    {
        // se è una sola tile, non possiamo spostarla
        if (tiles.Length < 2) return;

        // sposto la tile da destra a sinistra
        tiles[rightIndex].position = Vector3.right * (tiles[leftIndex].position.x - tileSize);

        // aggiorno gli indici
        leftIndex = rightIndex;
        rightIndex--;

        // controllo che l'indice non vada sotto zero
        if (rightIndex < 0)
        {
            rightIndex = tiles.Length - 1;
        }
    }
}
