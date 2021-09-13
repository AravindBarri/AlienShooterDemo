using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool gameIsPaused;

    private void Awake()
    {
        if (instance == null)
        {
            instance = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }
}
