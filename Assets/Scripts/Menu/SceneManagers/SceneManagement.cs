using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    
  public void StartGame()
    {
        SceneManager.LoadScene("LoreSceneLibrary");
    }

  
   public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
