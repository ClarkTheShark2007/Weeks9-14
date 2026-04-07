using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

public class LocalMultiplayerManager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;

    public CinemachineImpulseSource impulseSource;

    public void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player);

        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSprites[player.playerIndex];

        LocalMultiplayerController controller = player.GetComponent<LocalMultiplayerController>();
        controller.manager = this;
    }

    public void PlayerAttacking(PlayerInput attackingPlayer)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if(attackingPlayer == players[i]) continue;

            if (Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position) < 0.5f)
            {
                Debug.Log("Player " + attackingPlayer.playerIndex + " hit player " + players[i].playerIndex);
                impulseSource.GenerateImpulse();

                ParticleSystem bloodparticles = players[i].GetComponent<ParticleSystem>();
                bloodparticles.Emit(10);
            }
        }
    }
}
