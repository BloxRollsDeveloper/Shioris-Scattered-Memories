using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LoreBookSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    //start position of book 
    Vector2 bookStartPos;
    Vector2 slidePos;

    public string BookLevelName;
    //it's magic. If you understand how this works, you are now a Unity C# developer.  

    private void Start()
    {
        bookStartPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
        slidePos = new Vector2(transform.localPosition.x - 3, transform.localPosition.y - 3);

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject );
        if (eventData.pointerCurrentRaycast.gameObject == this.gameObject)
        {

            transform.localPosition = slidePos;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (eventData.pointerCurrentRaycast.gameObject == this.gameObject)
        {
            transform.localPosition = bookStartPos;
        }
    }

    public void GoToBookLevel()
    {
        PersistentGameState gameState = FindFirstObjectByType<PersistentGameState>();
        gameState.ChangeScene(BookLevelName);
    }
}

