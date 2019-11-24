using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private CharacterController2D controller;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spikes" || collision.gameObject.tag == "EnemyAttack")
            controller.Death();
            
    }

}
