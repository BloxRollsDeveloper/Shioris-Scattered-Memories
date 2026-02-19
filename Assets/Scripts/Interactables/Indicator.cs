using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public GameObject starIndicator;
    public GameObject triviaCanvas;
    public Button startTrivia;

    private void Start()
    {
        if (starIndicator != null)
        {
            starIndicator.SetActive(false);
        }

        if (startTrivia != null)
        {
            startTrivia.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            starIndicator.SetActive(true);
            startTrivia.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            starIndicator.SetActive(false);
            startTrivia.gameObject.SetActive(false);
            if (triviaCanvas.activeSelf)
            {
                triviaCanvas.SetActive(false);
            }
        }
    }
}
