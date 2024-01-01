using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInput.OnFootActions onFoot;
    private PlayerInput playerInput;
    private PlayerMotor motor;
    private PlayerLook look;
    private FlashLight flashLight;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        flashLight = GetComponent<FlashLight>();
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Crouch.performed += ctx => motor.HandleCrouch();
        onFoot.FlashLight.performed += ctx => flashLight.FlashLightArm();
    }

    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
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
