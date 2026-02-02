using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode AttackKey = KeyCode.F;
    public KeyCode KillKey = KeyCode.K;
    public KeyCode PauseKey = KeyCode.Escape;

    private void Update()
    {
        if (Input.GetKeyDown(AttackKey))
        {
            PlayerMovement.Instance.Attack();
            PlayerAttack.Instance.HitItem();
        }

        if (Input.GetKeyDown(KillKey))
        {
            PlayerMovement.Instance.Die();
        }

        //se non clicco il tasto esc skippo, se lo clicco...
        if (!Input.GetKeyDown(PauseKey)) return;
        PlayerMovement.Instance.PauseMenu();
    }
}
