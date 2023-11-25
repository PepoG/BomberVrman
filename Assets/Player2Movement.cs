using UnityEngine;
using UnityEngine.InputSystem;


public class Player2Movement : MonoBehaviour
{

    public InputAction joystick;
    public InputActionProperty moveLeft;
    public InputActionProperty moveRight;
    public InputActionProperty moveDown;
    public InputActionProperty moveUp;
    private const float stepSize = 5f;

    void FixedUpdate()
    {
        var c = GetComponent<CharacterController>();

        if (moveLeft.action.IsPressed())
        {
            c.Move(new Vector3(-stepSize * Time.deltaTime, 0, 0));
        }
        if (moveRight.action.IsPressed())
        {
            c.Move(new Vector3(stepSize * Time.deltaTime, 0, 0));
        }
        else if (moveUp.action.IsPressed())
        {
            c.Move(new Vector3(0, 0, stepSize * Time.deltaTime));        }
        else if (moveDown.action.IsPressed())
        {
            c.Move(new Vector3(0, 0, -stepSize * Time.deltaTime));
        }
    }
}
