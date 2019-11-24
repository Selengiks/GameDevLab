using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    [SerializeField]private int[] leveltreasures;
    [SerializeField]public static int treasures = 0;
    [SerializeField]private TextMeshProUGUI treasureCount;

    [SerializeField]DoorActivator door;
    [SerializeField] GameObject doorCollider;



    private void Start()
    {
        treasureCount.text = leveltreasures[0] + " / " + leveltreasures[1];  
    }
    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Treasure" && collision.IsTouching(GetComponent<CapsuleCollider2D>()))
        {
            treasures++;
            treasureCount.text = ++leveltreasures[0] + " / " + leveltreasures[1];
            Destroy (collision.gameObject);

        }
        if(leveltreasures[0] == leveltreasures[1])
            {
                doorCollider.SetActive(true);
                door.DoorOpen();              
            } 
    }
}
