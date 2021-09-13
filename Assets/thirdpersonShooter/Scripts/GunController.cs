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
    public GameObject gunflash;
    public GameObject hitmarker;
    public GameObject temp;

    [SerializeField]
    int TotalEnemies = 4;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
                gunflash.SetActive(true);
                Invoke("StopGunFlash", 0.3f);
            }


        }

    }

    private void StopGunFlash()
    {
        gunflash.SetActive(false);
    }

    private void FireGun()
    {
        Ray ray = new Ray(firePoint.position, firePoint.right);
        Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue, 2f);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.collider.gameObject.name);
            temp = Instantiate(hitmarker, hit.point, Quaternion.identity);
            temp.SetActive(true);
            print(temp.name);
            Invoke("deleteHitMarker", 0.5f);
            var enemyhealth = hit.collider.gameObject.GetComponent<EnemyHealth>();
            if (enemyhealth != null)
            {
                print("Take Damage");
                enemyhealth.TakeDamage(damage);
            }
            if(hit.collider.gameObject.tag == "Enemy")
            {
                TotalEnemies--;
                EnemyMovement movobj = hit.collider.gameObject.GetComponent<EnemyMovement>();
                if(movobj != null)
                {
                    movobj.HitEffect();
                }
                
                //EnemyMovement.enemyInstance.HitEffect();
            }
        }
    }
    private void deleteHitMarker()
    {
        Destroy(temp.gameObject);
    }
}