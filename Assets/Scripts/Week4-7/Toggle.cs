using UnityEngine;

public class Toggle : MonoBehaviour
{
    public void ToggleShape()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        //if(gameObject.activeInHierarchy == true)
        //{
        //  gameObject.SetActive(false);
        //} else
        //{
        //    gameObject.SetActive(true);
        //}
    }
}
