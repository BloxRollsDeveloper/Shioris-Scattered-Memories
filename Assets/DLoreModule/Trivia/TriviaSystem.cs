using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Class to define what a "trivia question" is
public class TriviaQuestion
{
    //What is the question?
    public string questionText;

    //What are the answer options? 
    public string textAnswerA;
    public string textAnswerB;
    public string textAnswerC;
    public string textAnswerD;

    //correct answer for this question?
    public string correctAnswer;


}
public class TriviaSystem : MonoBehaviour
{

    //the current round. This will correspond to the TriviaRounds[] array. 
    //Arrays count from 0, so currentround is 0 if it's the first question. 
    //in editor, it'll say Element 0, imagine it like 'Element currentRound'

    public int currentRound = -1; // initialize at -1


    //how many questions did the player get right so far? 

    public int playerScore;

    //how many questions does the player need to get right to win? 
    public int scoreToWinLevel;

    //the most recent answer from player (A, B, C, D)
    public string lastPlayerAnswer;

    public Text uiMainText; //for questions & speech
    //the answer text boxes
    public Text uiAnswerA;
    public Text uiAnswerB;
    public Text uiAnswerC;
    public Text uiAnswerD;

    //the Next Round button
    public Button nextRoundButton;
    //Good and bad audio clip refs
    public AudioClip buzzGood;
    public AudioClip buzzBad;

    //vfx refs, if we get to it
    public GameObject vfxleGood;
    public GameObject vfxBad;


    //HP 
    public int playerHP;
    //Declare serialized Class "TriviaRound". This defines what a TriviaQuestion contains
    [System.Serializable]
    public class TriviaRound
    {

        //What is the question?
        public string questionText;
        public string victoryText;
        //What are the answer options? 
        public string textA;
        public string textB;
        public string textC;
        public string textD;

        //correct answer for this question?
        public string correctAnswer;

        //the VA clip for the audio
        public AudioClip questionVAudio;

    }

    //The Array for trivia questions. 
    public TriviaRound[] triviaRounds;

    void Start()
    {
        //start first round
    }

    //get player answer from button
    public void playerAnsweredLetter(string playerAnswer)
    {
        lastPlayerAnswer = playerAnswer;

        //Get live game state
        //PersistentGameState gameState = FindFirstObjectByType<PersistentGameState>();

        //is the player correct?
        if (playerAnswer == triviaRounds[currentRound].correctAnswer)
        {
            //reset hp; 
            playerHP = 2;
            //give player a point


            //incredibly sloppy way to hide the ui buttons 
            uiAnswerA.transform.parent.parent.gameObject.SetActive(false);
            //load the victory text
            uiMainText.text = triviaRounds[currentRound].victoryText;

            //show the Next Round button
            nextRoundButton.gameObject.SetActive(true);

            playerScore++;


        }
        else
        {
            // if not, subtract hp from persistent game state. 
            playerHP--;

            //check if player just totally lost
            if (playerHP <= 0)
            {
                Debug.Log("fail");
                SceneManager.LoadScene("GameOver"); //rip
            }
            else
            {
                //or just let them ask again? 
            }

        }
    }

    public void LoadNextRound()
    {


        //Get live game state
        PersistentGameState gameState = FindFirstObjectByType<PersistentGameState>();
        //count up rounds 

        //reset Answer pointer
        lastPlayerAnswer = "";

        //if there are more questions...
        if (currentRound <= triviaRounds.Length - 1)
        {

            currentRound += 1;
            //populate UI with the correct text
            uiAnswerA.text = triviaRounds[currentRound].textA;
            uiAnswerB.text = triviaRounds[currentRound].textB;
            uiAnswerC.text = triviaRounds[currentRound].textC;
            uiAnswerD.text = triviaRounds[currentRound].textD;

            uiMainText.text = triviaRounds[currentRound].questionText;
        }
        else
        {
            //the worst thing I wrote so far. be better
            //replace EndingScene with whatever it needs to be. Best to put the string in a variable 
            //GameObject.FindAnyObjectByType<PersistentGameState>().GetComponent<PersistentGameState>().ChangeScene("EndingScene");

            Debug.Log("success");
            //SceneManager.LoadScene(); //rip
        }

    }
    void Update()
    {

    }
}
