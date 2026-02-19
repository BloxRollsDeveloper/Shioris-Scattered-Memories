using UnityEngine;
using UnityEngine.InputSystem;

public class InputBehaviourSystem : MonoBehaviour
{
    private HoloJam _inputSystem;

    public float Horizontal;
    public bool Interact;
    public Vector2 MousePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _inputSystem = new HoloJam();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = _inputSystem.Player.Move.ReadValue<Vector2>().x;
        Interact = _inputSystem.Player.Interact.WasPressedThisFrame();
        MousePosition = _inputSystem.Player.Look.ReadValue<Vector2>();
    }

	private void OnEnable()
	{
        _inputSystem.Enable();
	}

	private void OnDisable()
	{
		_inputSystem.Disable();
	}
}
