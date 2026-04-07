using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerController : MonoBehaviour
{
    public LocalMultiplayerManager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5f;
    public TrailRenderer trailRenderer;
    public ParticleSystem ps;
    //public TrailRenderer

    Coroutine theDashingCoroutine;
    // Update is called once per frame
    private void Start()
    {
        Sprite spriteRenderer = GetComponent<Sprite>();
        ps.textureSheetAnimation.SetSprite(0, spriteRenderer);
    }

    void Update()
    {
        transform.position += (Vector3) movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + ": Attack!");
            manager.PlayerAttacking(playerInput);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed == true)
        {
            if(theDashingCoroutine != null) 
            {
                StopCoroutine(Dash());
            }

            theDashingCoroutine = StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        trailRenderer.emitting = true;
        speed = 10f;
        yield return new WaitForSeconds(1f);
        trailRenderer.emitting = false;
        speed = 5f;
    }

}
