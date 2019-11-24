using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press_F : MonoBehaviour
{
    [SerializeField] GameObject useText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            useText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        useText.SetActive(false);
    }

    private void OnDestroy()
    {
        if(useText != null)
            useText.SetActive(false);
    }

}
