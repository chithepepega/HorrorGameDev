using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    private CharacterController controller;
    private Vector3 player;

    private float speed = 5;
    private bool sprinting;

    private float gravity = -18.81f;
    private float jumpHeight = 2f;
    private bool isGrounded;

    private bool crouch;
    private bool crouching = false;
    private bool lerpCrouch = false;
    private float crouchTimer;

    void Start() {
        crouch = false;
        crouchTimer = 0f;
        crouching = false;

        controller = GetComponent<CharacterController>();
    }

    private void Update() 
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                crouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        player.y += gravity * Time.deltaTime;
        if (isGrounded && player.y < 0)
            player.y = -2f;
        controller.Move(player * Time.deltaTime);
  
    }
   
    public void Sprint() {
        sprinting = !sprinting;
        if (sprinting)
            speed = 8;
        else
            speed = 5;
    }

    public void HandleCrouch() {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Jump() {
        if(isGrounded)
        {
            player.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
