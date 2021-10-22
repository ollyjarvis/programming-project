using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;  //  Create a 3D vector with magnitude and direction 0

    private Rigidbody playerRigidbody;

    void Start()  //  Method that is run once when the code is run
    {
        playerRigidbody = GetComponent<Rigidbody>();  // rigidbody variable gets the Rigidbody component
    }

    public void Move(Vector3 velocityCont)  // Public method that takes the velocity vector from 
    //  PlayerController as a parameter
    {
        velocity = velocityCont;  // Stores the velocity from PlayerController in a variable in PlayerMove
    }
    void FixedUpdate()  //  Method that runs constantly but is not frame-rate dependant so will not cause
    // the player to move at different speeds depending on the clients frame-rate
    {
        MovePlayer();  //  The method that moves the player is called repeatedly at a fixed rate
    }

    void MovePlayer()  //  Method that moves the player object
    {
        if (velocity != Vector3.zero)  //  If the velocity vector has some magnitude
        {
            playerRigidbody.MovePosition(playerRigidbody.position + velocity * Time.fixedDeltaTime);  //  Takes in the
            //  current rigidbody vector and adds the new amount to move multiplied by time to stop the movement
            //  from being affected by the frame-rate of the client and moves the player to the new position

        }
    }
}