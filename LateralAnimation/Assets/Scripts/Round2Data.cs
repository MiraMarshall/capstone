using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Round2Data : MonoBehaviour
{
    public RoundData[] allRoundData;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("Menu Trivia 2");
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
