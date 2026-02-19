using UnityEngine;
using UnityEngine.SceneManagement;
public class GuraSceneManager : MonoBehaviour
{
    
  public void CorrectAnswer()
    {
        SceneManager.LoadScene("MumeiWorld");
    }

  
   public void WrongAnswer()
    {
       SceneManager.LoadScene("GameOver");
    }
}
