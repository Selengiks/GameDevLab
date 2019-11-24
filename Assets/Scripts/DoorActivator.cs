using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorActivator : MonoBehaviour
{
    [SerializeField]private Animator anim;
    [SerializeField] GameObject winText;  
    
    public void DoorOpen()
    {
            anim.SetTrigger("Activate");
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                winText.SetActive(true);
            }
            
               
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Interact") && SceneManager.GetActiveScene().buildIndex != 3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else if (Input.GetButton("Interact") && SceneManager.GetActiveScene().buildIndex == 3)
            SceneManager.LoadScene("MainMenu");

    }

}
