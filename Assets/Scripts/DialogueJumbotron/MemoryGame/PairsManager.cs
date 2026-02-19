using UnityEngine;

public class PairsManager : MonoBehaviour
{
    public static PairsManager Instance;
    [SerializeField] private LineRenderer draggingLine;
    private Card _draggingCard;
    private InputBehaviourSystem _input;
    
    public Camera cam;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _input = GetComponent<InputBehaviourSystem>();
    }

    private void Update()
    {
        transform.position = cam.ScreenToWorldPoint(_input.MousePosition);
    }

    public void CardPicked(Card card)
    {
        _draggingCard = card;
        _draggingCard.Highlight(true);
        
        Vector2 cardPos = card.transform.position;
        draggingLine.SetPosition(0, cardPos);
        draggingLine.SetPosition(1, cardPos);

        if (!draggingLine.enabled)
        {
            draggingLine.enabled = true;
        }
    }

    public void Dragging()
    {
        Vector2 pos = cam.ScreenToWorldPoint(_input.MousePosition);
        draggingLine.SetPosition(1, pos);
    }

    public void NotHoveringOverCard(Card card)
    {
        if (draggingLine.enabled)
        {
            draggingLine.enabled = false;
        }

        _draggingCard = null;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
