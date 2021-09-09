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
                particleSyste.Play();
            }
            
        }
        
    }
    private void FireGun()
    {
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
                
                EnemyMovement.enemyInstance.HitEffect();
            }
        }
    }
}