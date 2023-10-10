using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    private CharacterController controller;
    private Vector3 player;
    private float speed;
    private float normalSpeed;
    private float sprintSpeed;
    private float gravity = -9.81f;
    private float jumpHeight = 2f;

    void Start() {
        normalSpeed = 5f;
        sprintSpeed = 8f;
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        ReadInput();
    }

    private void FixedUpdate() {
        ProcessMove();
    }

    private void ReadInput() {
        if (controller.isGrounded) {
            player.x = Input.GetAxisRaw("Horizontal");
            player.z = Input.GetAxisRaw("Vertical");

            speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : normalSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
                player.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    private void ProcessMove() {
        controller.Move(transform.TransformDirection(new() { x = player.x, z = player.z }) * speed * Time.deltaTime);

        if (controller.isGrounded && player.y < 0)
            player.y = -2f;

        player.y += gravity * Time.deltaTime;
        controller.Move(player * Time.deltaTime);
    }

    public void Crouch() {

    }

    public void Sprint() {

    }

    public void Jump() {

    }
}
