using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    [SerializeField] private GameObject[] smthToActivate;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButton("Interact") && collision == collision.GetComponent<BoxCollider2D>())
        {
            GetComponent<Animator>().SetTrigger("Activate");
            foreach (GameObject el in smthToActivate)
                el.SetActive(!el.activeSelf);

            Destroy(GetComponent<BoxCollider2D>());
            Destroy(this);

        }

    }
   
}
