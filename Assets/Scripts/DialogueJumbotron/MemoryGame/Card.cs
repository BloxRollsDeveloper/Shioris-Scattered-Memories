using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public Image outline;
    public string groupName => transform.parent.name;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        PairsManager.Instance.CardPicked(this);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        print("I am dragging it!");
        PairsManager.Instance.Dragging();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PairsManager.Instance.NotHoveringOverCard(this);
    }

    public void Highlight(bool highlight)
    {
        outline.color = highlight ? Color.green : Color.red;
    }
}
