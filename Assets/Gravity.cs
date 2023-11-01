using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravity = -9.81f; // change this for faster falling
    public float groundDistance = 0.4f; // maximal distance between ground and your character for gravity to reset
    public bool isGrounded;
    public CharacterController Controller;
    public Transform GroundCheck;
    public LayerMask groundMask; // make sure to set any objects that should act as things you want your gravity to reset on to this layer
    public Vector3 velocity;

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask); // Make a sphere to check if you are grounded

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // set velocity.y to -2f if vel.y is less than 0 because 0 is sometimes buggy
        }

        velocity.y += gravity * Time.deltaTime;

        Controller.Move(velocity * Time.deltaTime);
    }
}
