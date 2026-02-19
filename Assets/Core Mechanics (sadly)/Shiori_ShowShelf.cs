using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shiori_ShowShelf : MonoBehaviour
{

    public GameObject shelfBig;
    public GameObject Player;
    public GameObject uiPointer;
    public GameObject bookButtons;

    InputAction inputUse;

    void Start()
    {
        inputUse = InputSystem.actions.FindAction("OnInteract");

        shelfBig.SetActive(false);
        bookButtons.SetActive(false);
    }

    void Update()
    {

        //show or hide pointer helper when near shelf in default view

        if (Player.transform.localPosition.x >= -6.5f && Player.transform.localPosition.x <= -3.5)
        {
            if (!uiPointer.activeSelf) { uiPointer.SetActive(true); }

        }
        else
        {
            if (uiPointer.activeSelf) { uiPointer.SetActive(false); }
        }




    }

    // input events (lmao I had to learn this in a day eeep ~Lore) 
    public void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact btn press");

        if (Player.transform.localPosition.x >= -6.5f && Player.transform.localPosition.x <= -3.5)
        {
            if (shelfBig.activeSelf == false) { shelfBig.SetActive(true); }

            if (!bookButtons.activeSelf) { bookButtons.SetActive(true); }
            Debug.Log("local gamestate bigShelfDisplayed T");
        }
        else
        {
            if (shelfBig.activeSelf == true)
            {
                shelfBig.SetActive(false);
                if (bookButtons.activeSelf) { bookButtons.SetActive(false); }


                Debug.Log("local gamestate bigShelfDisplayed F");
            }
        }

    }
}