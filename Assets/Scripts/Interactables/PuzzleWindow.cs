using UnityEngine;

public class PuzzleWindow : MonoBehaviour
{
    private void Awake()
    {
        HideWindow();
    }

   public void ShowWindow()
    {
        gameObject.SetActive(true);
    }

    public void HideWindow()
    {
        gameObject.SetActive(false);
    }
}
