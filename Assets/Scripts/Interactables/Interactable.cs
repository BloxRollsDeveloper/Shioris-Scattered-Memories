using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableTrigger : MonoBehaviour
{
    public bool isInteractable = true;
    private bool playerInRange = false;

    // Called when another collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the object is the player
        {
            playerInRange = true;
            Debug.Log("Player entered range. Press 'E' to interact.");
        }
    }

    // Called when the other collider leaves the trigger zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range.");
        }
    }

    // Update is called once per frame
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && playerInRange && isInteractable)
        {
            Debug.Log("Interaction successful!");
            PerformInteraction();
        }
    }

    void PerformInteraction()
    {
        // Placeholder for interaction logic
        Debug.Log("Performing interaction...");
    }
}
