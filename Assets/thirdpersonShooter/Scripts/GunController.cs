using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{
    [Range(0, 2)]
    [SerializeField] float fireRate = 1f;
    [SerializeField]
    [Range(1, 10)]
    int damage = 1;
    [SerializeField] float timer;
    [SerializeField] Transform firePoint;
    public ParticleSystem particleSyste;
    //public GameObject bulletPrefab;
    //[SerializeField] float bulletSpeed;
    // AudioSource audioSource;
    // public AudioClip audioClip;
    [SerializeField]
    int TotalEnemies = 4;

    // Start is called before the first frame update
    void Start()
    {
       // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                //Instantiate(particleSyste, particlePoint.position, Quaternion.identity);
                //BulletSpawn();
              //  audioSource.clip = audioClip;
               // audioSource.Play();
                timer = 0f;
                FireGun();
                particleSyste.Play();
            }
        }
        if(TotalEnemies == 0)
        {
            HelicopterSpawn.helicinstance.finishedGame = true;
        }
    }

    /*public void BulletSpawn()
    {
        GameObject temp = Instantiate(bulletPrefab);
        temp.transform.position = firePoint.transform.position;
        temp.GetComponent<Rigidbody>().AddForce(Vector3.forward*bulletSpeed);
    }*/
    private void FireGun()
    {

        //particleSyste.transform.position = particlePoint.position;
        //particleSyste.Play();

        //Debug.DrawRay(firePoint.position, firePoint.forward*50f, Color.red,2f);
        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        //Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Ray ray = new Ray(firePoint.position, firePoint.right);
        Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue, 2f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.collider.gameObject.tag);
            var enemyhealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
            if (enemyhealth != null)
            {
                print("Take Damage");
                enemyhealth.TakeDamage(damage);
            }
            if(hit.collider.gameObject.tag == "Enemy")
            {
                TotalEnemies--;
                ScoreManager.Scoreinstance.EnemyKillScore();
            }
        }
    }
}