using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPack : MonoBehaviour
{
   public GameObject HealthP;
    public void OnCollisionEnter(Collision collision)
     {
      	string HealthPack = collision.gameObject.tag;
       	if (HealthPack == "player")
       	{
            Debug.Log ("HPcollision");
            HealthP.SetActive (false);
       	}
        
     }

}
