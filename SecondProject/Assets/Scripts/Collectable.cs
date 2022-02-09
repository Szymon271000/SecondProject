using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.AddCoin();
                Destroy(this.gameObject);
            }
            
        }
    }
    //OntriggerEnter
    //give the player a coin
    //destroy this object
}
