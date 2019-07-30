using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    private Scene scene;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //if (scene.name == "Persistent")
        //{
            SceneManager.LoadScene("MenuScreen");

        //} else
        ////else (scene.name == "Persistent2");
        //{
        //    SceneManager.LoadScene("Menu Trivia 2");
        //}

        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
