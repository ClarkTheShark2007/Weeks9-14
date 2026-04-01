using UnityEngine;

public class Wall : MonoBehaviour
{
    //References
    public Transform playerPosition;
    public Player playerInput;

    //Varibles
    float pushDistance = 0.25f;

    public void stopMovement() //Pushes the play away from the wall and makes the movement set by on the OnMove to 0.
    {
        Vector2 newPos = playerPosition.position;
        if (playerInput.movement.y > 0) //Top Wall
        {
            newPos += new Vector2(0, pushDistance * -1);
            playerInput.movement.y = 0f;
            playerInput.slipperyMovement.y = 0f;

        }
        else if (playerInput.movement.y < 0) //Bottom Wall
        {
            newPos += new Vector2(0, pushDistance);
            playerInput.movement.y = 0f;
            playerInput.slipperyMovement.y = 0f;
        }

        if(playerInput.movement.x > 0) //Left Wall
        {
            newPos += new Vector2(pushDistance * -1, 0);
            playerInput.movement.x = 0f;
            playerInput.slipperyMovement.x = 0f;
        } 
        else if (playerInput.movement.x < 0) //Right Wall
        {
            newPos += new Vector2(pushDistance, 0);
            playerInput.movement.x = 0f;
            playerInput.slipperyMovement.x = 0f;

        }

        playerPosition.position = newPos;


    }
}
