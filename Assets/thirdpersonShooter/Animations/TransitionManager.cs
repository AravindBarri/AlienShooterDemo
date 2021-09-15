using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Animator transition;
    public bool gameStart = false;
    //public static TransitionManager transitionInstance;
    public float transitionTime = 1f;
    private void Start()
    {
        //transitionInstance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            LoadNextLevel();        
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        gameStart = false;
    }
}
