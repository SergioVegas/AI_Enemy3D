using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(MoveBehavior))]
public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public event Action<bool> OnAiming;

    protected MoveBehavior _mb;
    private InputSystem_Actions _actions;
    public int HP = 10;
    protected float speedWalk = 10f;
 
    protected float actualSpeed;
    private float xVelocity;
    private float zVelocity;


    private void Awake()
    {
        _mb = GetComponent<MoveBehavior>();
        _actions = new InputSystem_Actions();
        _actions.Player.SetCallbacks(this);
        actualSpeed = speedWalk;
    }

    void Update()
    {
        _mb.ExecuteMovement(new Vector3(xVelocity, 0, zVelocity), actualSpeed);
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;
        Debug.Log("Player HP: " + HP);
        if (HP <= 0)
        {
            Debug.Log("Player Dead!");
            // Puedes añadir lógica de muerte aquí (ej: recargar escena)
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        xVelocity = input.x;
        zVelocity = input.y;
    }

    public void OnEnable()
    {
        _actions.Enable();
    }

    public void OnDisable()
    {
        _actions.Disable();
    }
}
