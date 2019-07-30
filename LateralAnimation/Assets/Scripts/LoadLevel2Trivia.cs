using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel2Trivia : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 1f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Persistent2");
    }
}
