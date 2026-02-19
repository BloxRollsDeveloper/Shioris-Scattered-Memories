using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentGameState : MonoBehaviour
{
    //Start player with 2 "HP". 0 hp is game over
    public int playerHP = 2;

    //Bools to check if a level is complete
    public bool[] levels;
    //count finished levels
    int finishedLevelsCount;

    //VN data per scene
    VNHandler vnSceneHandler;

    //Trivia handler per scene
    TriviaSystem triviaSceneHandler;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        finishedLevelsCount = 0;
    }

    void Update()
    {
        //reset count of inished levels
        finishedLevelsCount = 0;
        //we need 3 completed levels to win, 
        if (levels[0])
        {
            finishedLevelsCount++;
        }
        if (levels[1])
        {
            finishedLevelsCount++;
        }
        if (levels[2])
        {
            finishedLevelsCount++;
        }

        //if player has 3 completed levels, they win 
        if (finishedLevelsCount == 3)
        {
            ChangeScene("EndingScene");
        }

        //rip
        if (playerHP<0)
        { GameOver(); }


    }

    //other objects can call GameOver() , to send player to Game Over scene
    public void GameOver()
    {
        ChangeScene("GameOver");
    }


    //call from any script in any scene to change scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
        

    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
