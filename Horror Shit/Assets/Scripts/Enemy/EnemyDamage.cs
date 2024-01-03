using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject colliderObject; 
   
    public void EnableDamageCollider()
    {
        colliderObject.SetActive(true);
    }
    public void DisableDamageCollider()
    {
        colliderObject.SetActive(false);
    }
}
