using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    public Text answerText;

    private AnswerData answerData;
    private TriviaController triviaController;


    // Use this for initialization
    void Start () 
    {
        triviaController = FindObjectOfType<TriviaController> ();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
        
        
    }


    public void HandleClick()
    {

        Debug.Log("ANSWER BUTTON!!!!**************");

        
        triviaController.AnswerButtonClicked(answerData.isCorrect);
        //if (triviaController.AnswerButtonClicked(answerData.isCorrect = true))
        //{
        //    answerText.text = "CORRECT";
        //}

       
    }

    //public void RightWrongHandleClick()
    //{

    //   if 

    //    //triviaController.DisplayRightOrWrong(answerData.answerText);
    //    //if (triviaController.AnswerButtonClicked(answerData.isCorrect = true))
    //    //{
    //    //    answerText.text = "CORRECT";
    //    //}


    //}


}