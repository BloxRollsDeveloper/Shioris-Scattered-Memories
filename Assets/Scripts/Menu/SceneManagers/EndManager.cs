using UnityEngine;
using UnityEngine.SceneManagement;
public class EndManager : MonoBehaviour
{
    
  public void ReturnGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

  
   public void QuitGame()
    {
        Application.Quit();
    }
}