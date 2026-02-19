using UnityEngine;
using UnityEngine.SceneManagement;
public class OverManager : MonoBehaviour
{
    
  public void MainMenuGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

  
   public void ReturnGame()
    {
        SceneManager.LoadScene("LoreSceneLibrary");
    }
}