using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;


// player life - quick restart
// intro when player gets past the first level

public class TriviaController : MonoBehaviour
{


    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

  

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private AnswerData answerData;
   

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    private bool isCorrect;
    private string wrongAnswer = "WRONG!!!";
    //private bool rightOrWrong;

    // Use this for initialization
    void Start()
    {
        
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;

        //AnswerButtonClicked(false);

    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
        
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }


    //public void changeColor()
    //{

    //    var colors = GetComponent<Button>().colors;
    //    colors.normalColor = Color.red;
    //    GetComponent<Button>().colors = colors;



    //}
    public void AnswerButtonClicked(bool isCorrect)
    {
        Debug.Log("ANSWERBUTTONCLICKED*****************");
        

        if (isCorrect)
        {
            print("CORRECT!!");

            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        

        } else
        {
            print(wrongAnswer);
        

        }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        } else
        {
            EndRound();
        }

    }


    //public void DisplayRightOrWrong(bool rightOrWrong)
    //{
    //    Debug.Log("Right or Wrong");
    //    GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
    //    AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();

    //    if (rightOrWrong)
    //    {
    //        answerData.answerText = "CORRECT!";

    //    } else
    //    {
    //        answerData.answerText = "WRONG";
    //    }

    //}


    public void EndRound()
    {
        isRoundActive = false;

        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RedoTrivia()
    {
        SceneManager.LoadScene("Persistent");
    }

    public void RedoTrivia2()
    {
        SceneManager.LoadScene("Trivia 2");
    }


    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }

        }
    }
}
