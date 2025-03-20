using UnityEngine;

public class LaunchCube : MonoBehaviour
{
    public float thrust = 5f;  // Speed of going up
    public float gravity = 2f; // Speed of going down
    public float groundHeight = 0.5f; // Adjust based on your cube's size

    private bool isGrounded;

    void Update()
    {
        // Check if the cube is touching the ground
        isGrounded = transform.position.y <= groundHeight;

        if (Input.GetButton("Jump"))
        {
            // Move the cube upwards
            transform.position += Vector3.up * thrust * Time.deltaTime;
        }
        else if (!isGrounded)
        {
            // Move the cube downwards like gravity, but stop at the ground
            transform.position += Vector3.down * gravity * Time.deltaTime;
        }
    }
}
