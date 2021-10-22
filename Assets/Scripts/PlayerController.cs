using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]  //  Shows variable in Unity Editor despite it being private
    private float speed = 10f; //  Speed of the player

    private PlayerMove move;  //  Create reference to PlayerMove called move

    void Start() //  Method that is runs when the code is run
    {
        move = GetComponent<PlayerMove>(); //  Create a GameObject with component PlayerMove

    }

    void Update() //  Method that is run once on every frame update
    {
        float xMovement = Input.GetAxisRaw("Horizontal");  //  Take the input from the player for left/ right
        float zMovement = Input.GetAxisRaw("Vertical");  //  Take the input from the player for forwards/ backwards

        Vector3 moveHorizontal = transform.right * xMovement;  //  Create 3D vector for left/ right movement equal to the
        // vector transform.right (the vector (1, 0, 0)) multiplied by the amount of movement input by that player (between -1 and 1)
        Vector3 moveVertical = transform.forward * zMovement;  //  Create 3D vector for forward/ backward movement equal to the
        //  vector transform.forward (0, 0, 1) mulptiplied by the users forward input

        Vector3 velocityCont = (moveHorizontal + moveVertical).normalized * speed; //  Add the x and z vectors and normalize it to
        // make the vectors magnitude equal to 1 so that the player does not move faster when walking diagonally and multiply by speed

        move.Move(velocityCont); //  The 3D vector for the movement of the player is passed into the method in PlayerMove that moves the player
    }
}