using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int startHealth = 5;
    public int currentHealth;
    public GameObject DeathEffect;
    public static EnemyHealth Enemyhealthinstance;
    private void Start()
    {
        Enemyhealthinstance = this;
    }

    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        //ScoreManager.Scoreinstance.updateHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //gameObject.SetActive(false);
        Destroy(this.gameObject);
        Instantiate(DeathEffect, this.transform);
        if (this.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}