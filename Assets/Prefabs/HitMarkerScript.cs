using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkerScript : MonoBehaviour
{
    public static HitMarkerScript hitmarkerInstance;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("InActiveMarker", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
       

    public void InActiveMarker()
    {
        Destroy(this.gameObject);
    }
}
