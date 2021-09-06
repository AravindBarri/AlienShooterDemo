using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicopterSpawn : MonoBehaviour
{
    public bool finishedGame;
    Rigidbody helicopterRigidbody;
    // Start is called before the first frame update
    public static HelicopterSpawn helicinstance; 

    void Start()
    {
        helicopterRigidbody = this.GetComponent<Rigidbody>();
        helicinstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (finishedGame)
        {
            this.gameObject.SetActive(true);
            helicopterRigidbody.velocity = new Vector3(0, -2, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }

}
