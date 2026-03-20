using UnityEngine;
using UnityEngine.InputSystem;

public class Particles : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            particle.Emit(10000);
        }
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            particle.Play();
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            particle.Stop();
        }
    }
}
