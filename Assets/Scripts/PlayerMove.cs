using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    public CharacterController controller;
    public Vector3 velocity = Vector3.zero;  //  Create a 3D vector with magnitude and direction 0

    private Rigidbody playerRigidbody;

    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

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
            velocity.y = -2f;
        }

        float xMovement = Input.GetAxisRaw("Horizontal");  //  Take the input from the player for left/ right
        float zMovement = Input.GetAxisRaw("Vertical");  //  Take the input from the player for forwards/ backwards

        Vector3 moveHorizontal = transform.right * xMovement;  //  Create 3D vector for left/ right movement equal to the
        // vector transform.right (the vector (1, 0, 0)) multiplied by the amount of movement input by that player (between -1 and 1)
        Vector3 moveVertical = transform.forward * zMovement;  //  Create 3D vector for forward/ backward movement equal to the
        //  vector transform.forward (0, 0, 1) mulptiplied by the users forward input

        Vector3 velocityCont = (moveHorizontal + moveVertical).normalized * speed; //  Add the x and z vectors and normalize it to
        // make the vectors magnitude equal to 1 so that the player does not move faster when walking diagonally and multiply by speed

        controller.Move(velocityCont * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.fixedDeltaTime);
        
    }
}