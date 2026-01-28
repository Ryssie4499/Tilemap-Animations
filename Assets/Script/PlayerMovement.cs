using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //velocità
    [SerializeField] float speed;
    private Vector3 movement;
    private float direction;
    private Animator anim;

    private void Start()
    {
        //a inizio gioco è girato in avanti (destra)
        direction = 1;

        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("IsAttacking");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Kill");
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //con l'input si muove
        float xMovement = Input.GetAxis("Horizontal");              //-1 a 1
        movement.x = xMovement * speed * Time.fixedDeltaTime;

        //se ci muoviamo verso sinistra, si gira a sinistra
        if (xMovement < 0)
            direction = -1;

        //se ci muoviamo verso destra, si gira a destra
        else if (xMovement > 0)
            direction = 1;

        //se non sono fermo, IsMoving è true e l'animazione di corsa parte
        if (xMovement != 0)
            anim.SetBool("IsMoving", true);

        //se sono fermo, IsMoving è false e l'animazione di corsa si ferma, passando all'idle
        else
            anim.SetBool("IsMoving", false);

        //la scala varia in base alla direzione
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);

        transform.Translate(movement);
    }
}
