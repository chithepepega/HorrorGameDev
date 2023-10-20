using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    private CharacterController controller;
    private Vector3 player;

    private float speed;
    private float normalSpeed;
    private float sprintSpeed;

    private float gravity = -9.81f;
    private float jumpHeight = 2f;

    private bool crouch;
    private bool crouching;
    private float crouchTimer;

    void Start() {
        crouch = false;
        crouchTimer = 0f;
        crouching = false;

        normalSpeed = 5f;
        sprintSpeed = 8f;

        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        ReadInput();
    }

    private void FixedUpdate() {
        HandleMove();
        HandleCrouch();
        HandleGravity();
    }

    private void ReadInput() {
        if (controller.isGrounded) {
            player.x = Input.GetAxisRaw("Horizontal");
            player.z = Input.GetAxisRaw("Vertical");

            speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;
            
            if (Input.GetKeyDown(KeyCode.LeftControl)) {
                crouching = !crouching;
                crouchTimer = 0;
                crouch = true;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                player.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }
    }

    private void HandleMove() {
        controller.Move(transform.TransformDirection(new() { x = player.x, z = player.z }) * speed * Time.deltaTime);
    }

    private void HandleCrouch() {
        if (!crouch) return;

        crouchTimer += Time.deltaTime;

        float p = crouchTimer / 1;
        p *= p;

        if (crouching)
            controller.height = Mathf.Lerp(controller.height, 1, p);
        else
            controller.height = Mathf.Lerp(controller.height, 2, p);

        if (p > 1) {
            crouch = false;
            crouchTimer = 0f;
        }
    }

    private void HandleGravity() {
        if (controller.isGrounded && player.y < 0) {
            player.y = -2f;
        }

        player.y += gravity * Time.deltaTime;
        controller.Move(player * Time.deltaTime);
    }
}
