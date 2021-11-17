using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    float startHealth = 5;
    public float currentHealth;
    public GameObject DeathEffect;
    public static Health healthinstance;
    [SerializeField] GameObject PostProcessingObject;
    private void Start()
    {
        healthinstance = this;
    }

    private void OnEnable()
    {
        currentHealth = startHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        ScoreManager.Scoreinstance.updateHealth(Mathf.Round(currentHealth));
        PostProcessingObject.SetActive(true);
        StartCoroutine(PostProcessingEffectStop());
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //gameObject.SetActive(false);
        Destroy(this.gameObject);
        //Instantiate(DeathEffect, this.transform);
        if (this.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    IEnumerator PostProcessingEffectStop()
    {
        yield return new WaitForSeconds(0.1f);
        PostProcessingObject.SetActive(false);
    }
}