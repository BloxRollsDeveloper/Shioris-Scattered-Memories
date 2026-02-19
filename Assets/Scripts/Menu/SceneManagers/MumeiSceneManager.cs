using UnityEngine;
using UnityEngine.SceneManagement;
public class MumeiSceneManager : MonoBehaviour
{
    
  public void CorrectAnswer()
    {
        SceneManager.LoadScene("FaunaWorld");
    }

  
   public void WrongAnswer()
    {
       SceneManager.LoadScene("MumeiWorld");
    }
}
