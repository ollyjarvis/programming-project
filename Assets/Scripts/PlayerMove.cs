using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.3f; // Float for the speed of the player, private so that it cannot be changed by that player
    // Serialized so that it appears in the Unity editor to make it easier to edit during testing
    [SerializeField]
    private float sprintSpeed = 3f;

    public CharacterController controller; // Character controller called controller, used to apply the movement to the player
    public Vector3 velocity = Vector3.zero;  //  Create a 3D vector with magnitude and direction 0

    public float gravity = -9.81f; // Value of gravity, used when player jumps to make them fall back to the ground

    [SerializeField]
    public float jumpHeight = 1.3f; // Arbitrary number used in the gravity calcuations as a scalar to increase or decrease height of jumps

    public Transform groundCheck; // Empty object that sits at the players feet which is used as the position for the ground check
    public float groundDistance = 0.4f; // The radius of the sphere that checks if the player is on the ground
    public LayerMask groundMask; // The tag that the check sphere checks against, tag for items that are the ground

    bool isGrounded; // Boolean that will store True when the player is in the ground and False when it is not

    void Start()  //  Method that is run once when the code is run
    {

    }

    void Update()  //  Method that runs constantly but is not frame-rate dependant so will not cause
    // the player to move at different speeds depending on the clients frame-rate
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // When the player is near the floor the downwards velocity is set to a small value
            // to stop the player from falling faster each time they jump
        }

        float xMovement = Input.GetAxisRaw("Horizontal");  //  Take the input from the player for left/ right
        float zMovement = Input.GetAxisRaw("Vertical");  //  Take the input from the player for forwards/ backwards

        Vector3 moveHorizontal = transform.right * xMovement;  //  Create 3D vector for left/ right movement equal to the
        // vector transform.right (the vector (1, 0, 0)) multiplied by the amount of movement input by that player (between -1 and 1)
        Vector3 moveVertical = transform.forward * zMovement;  //  Create 3D vector for forward/ backward movement equal to the
        //  vector transform.forward (0, 0, 1) mulptiplied by the users forward input

        Vector3 velocityNorm = (controller.velocity + moveHorizontal + moveVertical).normalized; //  Add the x and z vectors and normalize it to
        // make the vectors magnitude equal to 1 so that the player does not move faster when walking diagonally and multiply by speed

        if(Input.GetButton("Shift"))
        {
            controller.Move(velocityNorm * speed * Time.deltaTime); // If the player is holding shift the player will sprint
        }
        else
        {
            controller.Move(velocityNorm * sprintSpeed * Time.deltaTime); // Uses move function to move the character controller at the speed set
            // Uses Time.deltaTime to make the movement frame independant else players with more powerful machines would move faster
        }

        if(Input.GetButtonDown("Jump") && isGrounded) // If the player presses jump and the player is on the floor
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Increases the y velocity using SUVAT equations
        }

        velocity.y += gravity * Time.deltaTime; // velocity is constantly decresed to make the player always fall when they are not on the floor

        controller.Move(velocity * Time.fixedDeltaTime); // velocity is applied to the character controller
        
    }
}