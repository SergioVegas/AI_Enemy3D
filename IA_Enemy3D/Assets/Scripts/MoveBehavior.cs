using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveBehavior : MonoBehaviour
{
    private CharacterController _controller;
    public float rotateSpeed = 720f; // Aumentada para una rotación más fluida hacia la dirección de movimiento

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void ExecuteMovement(Vector3 direction, float speed)
    {
        // Move in the direction of the axes (X for horizontal, Z for vertical)
        if (direction.magnitude >= 0.1f)
        {
            // Move the controller
            _controller.Move(direction * speed * Time.deltaTime);

            // Rotate the character to face the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
