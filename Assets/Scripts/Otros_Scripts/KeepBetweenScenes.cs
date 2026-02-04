using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepBetweenScenes : MonoBehaviour
{
    // Start is called before the first frame update

    /*
    public GameObject player;
    public GameObject gameManager;
    public GameObject canvas;
    public GameObject eventSystem;*/
    public GameObject keepThisObjects;
    public Scene thisSceneName;

    void Start()
    {
        /*ontDestroyOnLoad(player);
        DontDestroyOnLoad(gameManager);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(eventSystem);*/
        DontDestroyOnLoad(keepThisObjects);
    }

    // Update is called once per frame
    void Update()
    {
        if (thisSceneName.name == "Cinematic-2")
        {
            Debug.Log("DIIIOSSSS");
            keepThisObjects.SetActive(false);
        }
    }
}
