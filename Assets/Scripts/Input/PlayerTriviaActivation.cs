using UnityEngine;

public class PlayerTriviaActivation : MonoBehaviour
{
    private InputBehaviourSystem _input;
    
    public GameObject talentTrivia;
    public bool isTriviaActive;

    private void Start()
    {
        _input = GetComponent<InputBehaviourSystem>();
        isTriviaActive = false;
    }

    /* this script is a bunch of fucko lines that pisses me off.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trivia") && !isTriviaActive)
        {
            print("penaur");
            if (_input.Interact)
            {
                talentTrivia.SetActive(true);
                isTriviaActive = true;
            }
        }
    }*/
}
