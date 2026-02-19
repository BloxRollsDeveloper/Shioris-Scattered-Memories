using UnityEngine;
using UnityEngine.UI;

public class StartGuraPuzzle : MonoBehaviour
{
    [SerializeField] private PuzzleWindow window;
    [SerializeField] private Button startButton;

    private void Awake()
    {
        if (window == null)
        {
            Debug.LogError("PuzzleWindow not assigned");
            return;
        }

        if (startButton == null)
        {
            Debug.LogError("StartButton not assigned");
            return;
        }

        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener(window.ShowWindow);
    }
}