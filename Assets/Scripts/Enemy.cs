using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Collider2D player;
    [SerializeField] BoxCollider2D disableEyes;
    private Animator anim;
    private Rigidbody2D player_rb;
    private Collider2D enemy;
    private Rigidbody2D enemy_rb;
    private int distance;
    private bool faceRight = true;
    Vector3 velo = new Vector3();
    private bool[] animState = new bool[5] { false, false, false, false, false };
    //0 - Run, 1 - Attack, 2 - Stay, 3 - Walk, 4 = Idle;
    //Run = PlayerSpoted, Stay = Wait, Walk = PlayerLeft, Idle = StopMove
    private void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<CapsuleCollider2D>();
        enemy_rb = GetComponent<Rigidbody2D>();
        player_rb = player.gameObject.GetComponent<Rigidbody2D>();
        velo.x = -3;
    }

    private void FixedUpdate()
    {
        anim.SetBool("PlayerSpoted", animState[0]);
        if (faceRight || animState[2])
            animState[0] = false;
        anim.SetBool("Attack", animState[1]);
        animState[1] = false;
        anim.SetBool("Wait", animState[2]);
        if (faceRight)
            animState[2] = false;
        anim.SetBool("PlayerLeft", animState[3]);
        if (animState[4])
            animState[3] = false;
        anim.SetBool("StopMove", animState[4]);
        if (!faceRight)
            animState[4] = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Player")
       {
            if (faceRight)
            {
                Flip();
                enemy_rb.velocity = velo;
                animState[0] = true;
            }
            else
            {
                animState[1] = true;
            }
       }
       else if(collision.tag == "PatrolRange" && !faceRight)
       {
            enemy_rb.velocity = Vector3.zero;
            animState[2] = true;
            Invoke("Wait", 3f);
       }
       else if(collision.tag == "PatrolRange" && faceRight)
       {
            enemy_rb.velocity = Vector3.zero;
            animState[4] = true;
            disableEyes.enabled = true;
       }

        if (collision.tag == "PlayerAttack" && collision.IsTouching(enemy))
        {
            Death();
            Debug.Log("Smert\'");
        }

        

    }

    private void Flip()
    {

        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Wait()
    {
        disableEyes.enabled = false;
        Flip();
        enemy_rb.velocity = velo * -0.7f;
        animState[3] = true;
    }

    private void Death()
    {
        anim.SetTrigger("Die");
        enemy_rb.velocity = Vector3.zero;
        //Destroy(enemy);
        Destroy(disableEyes);
        Destroy(this);
    }
}
