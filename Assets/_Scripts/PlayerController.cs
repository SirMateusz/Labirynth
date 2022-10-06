using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f, groundDistance = 0.5f, gravity = -9.81f, jumpHeight = 1.5f;
    Vector3 velocity;
    CharacterController characterController;
    public Transform groundCheck, materialCheck;
    public LayerMask groundMask;

    [SerializeField] bool isGrounded;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(velocity * Time.deltaTime);
        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;

        RaycastHit hit;

        if (Physics.Raycast(materialCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                case "Slow":
                    speed = 7f;
                    break;
                case "Fast":
                    speed = 20f;
                    break;
                default:
                    speed = 12f;
                    break;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "PickUp") hit.gameObject.GetComponent<Pickup>().PickedUp();
    }
    
}

