using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DamagePlayer : MonoBehaviour
{
    public PlayerHealth playerHealth;
   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage();
            Debug.Log("Player has entered the collider");
        }
    }
}
