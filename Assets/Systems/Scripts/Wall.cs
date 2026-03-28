using UnityEngine;

public class Wall : MonoBehaviour
{
    public Transform playerPosition;
    public Player playerInput;
    float pushDistance = 0.25f;
    public void stopMovement()
    {
        Vector2 newPos = playerPosition.position;
        if (playerInput.movement.y > 0)
        {
            newPos += new Vector2(0, pushDistance * -1);
            playerInput.movement.y = 0f;
        }
        else if (playerInput.movement.y < 0)
        {
            newPos += new Vector2(0, pushDistance);
            playerInput.movement.y = 0f;
        }

        if(playerInput.movement.x > 0)
        {
            newPos += new Vector2(pushDistance * -1, 0);
            playerInput.movement.x = 0f;
        } 
        else if (playerInput.movement.x < 0)
        {
            newPos += new Vector2(pushDistance, 0);
            playerInput.movement.x = 0f;
        }

        playerPosition.position = newPos;


    }
}
