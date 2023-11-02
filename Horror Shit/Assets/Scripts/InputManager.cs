using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInput.OnFootActions onFoot;
    private PlayerInput playerInput;
    private PlayerMotor motor;
    private PlayerLook look;


    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
    }

    void FixedUpdate()
    {

    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
