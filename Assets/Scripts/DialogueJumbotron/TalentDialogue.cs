using UnityEngine;
using TMPro;

public class TalentDialogue : MonoBehaviour
{
    [Header("Text Stuffs")]
    public TextMeshProUGUI textPrompt;
    
    
    public bool hasTalkedTo = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTalkedTo)
        {
            textPrompt.gameObject.SetActive(true);
        }
    }
}
