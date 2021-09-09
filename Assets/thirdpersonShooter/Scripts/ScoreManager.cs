using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int health = 5;
    public Text ScoreUI;
    public Text HealthUI;
    public static ScoreManager Scoreinstance;
    private void Start()
    {
        Scoreinstance = this;
    }
    public void updateHealth(float value)
    {
        HealthUI.text = "Health: " + value;
    }
    public void CoinScore()
    {
        score++;
        ScoreUI.text = "Score: " + score;
    }
    public void BottleScore()
    {
        health =  5;
        Health.healthinstance.currentHealth = health;
        HealthUI.text = "Health: " + health;
    }
    public void EnemyKillScore()
    {
        score+=5;
        ScoreUI.text = "Score: " + score;
    }
}