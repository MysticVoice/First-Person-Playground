using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public ScriptableBoolEvent jumpEvent;
    public ScriptableBoolEvent shootEvent;
    public ScriptableVector2Event lookEvent;
    public ScriptableVector2Event moveEvent;

    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerControlls playerControls;
    
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else _instance = this;
        playerControls = new PlayerControlls();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (playerControls.Player.Jump.triggered) jumpEvent.trigger(playerControls.Player.Jump.ReadValue<float>() > 0);
        if (playerControls.Player.Shoot.triggered) shootEvent.trigger(playerControls.Player.Shoot.ReadValue<float>() > 0);
        if (playerControls.Player.Look.triggered) lookEvent.trigger(playerControls.Player.Look.ReadValue<Vector2>());
        if (playerControls.Player.Movement.triggered) moveEvent.trigger(playerControls.Player.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
