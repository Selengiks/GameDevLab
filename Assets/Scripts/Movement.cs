using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]CharacterController2D controller;

    float move = 0f;
    bool crouch;
    bool jump;
    bool attack;

    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        crouch = Input.GetButton("Crouch");
        if(Input.GetButton("Fire1"))
            attack = true;
        if(Input.GetButtonDown("Jump"))
            jump = true;
        
    }

    private void FixedUpdate()
    {
        controller.Move(move, crouch, ref jump);
        controller.Attack(ref attack);
    }
    
}
