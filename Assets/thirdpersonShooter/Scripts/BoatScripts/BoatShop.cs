using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatShop : MonoBehaviour
{
    [SerializeField] GameObject boatPrefab;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerMovement player = other.GetComponent<PlayerMovement>();
                if (player != null)
                {
                    if(ScoreManager.Scoreinstance.score > 20)
                    {
                        boatPrefab.SetActive(true);
                        ScoreManager.Scoreinstance.score -= 20;
                    }
                    else
                    {
                        Debug.Log("find more enemies and increase your score to buy a boat");
                    }
                    
                }
            }
        }
    }
}
