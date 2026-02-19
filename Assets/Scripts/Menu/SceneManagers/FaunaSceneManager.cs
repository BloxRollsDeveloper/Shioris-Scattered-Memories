using UnityEngine;
using UnityEngine.SceneManagement;
public class FaunaSceneManager : MonoBehaviour
{
    
  public void CorrectAnswer()
    {
        SceneManager.LoadScene("CreditsScene");
    }

  
   public void WrongAnswer()
    {
       SceneManager.LoadScene("FaunaWorld");
    }
}
