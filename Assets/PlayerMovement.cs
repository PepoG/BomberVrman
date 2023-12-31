using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class PlayerMovement : MonoBehaviour
{
   
    public InputAction joystick;
    public InputActionProperty joystick2left;
    public InputActionProperty joystick2right;
    private const float stepSize = 4f;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    void Update()
    {
        var c = GetComponent<CharacterController>();
        var inputValue = joystick2left.action.ReadValue<Vector2>();

       if(inputValue.x > 0.5f)
        {
            c.Move(new Vector3(stepSize * Time.deltaTime, 0, 0));
            //Debug.Log("right");
        } else if(inputValue.x < -0.5f)
        {
            c.Move(new Vector3(-stepSize * Time.deltaTime, 0, 0));
            //Debug.Log("left");
        }
       
        if (inputValue.y > 0.5f)
        {
            c.Move(new Vector3(0, 0, stepSize * Time.deltaTime));
            //Debug.Log("up");
        }
       else if (inputValue.y < -0.5f)
        {
            c.Move(new Vector3(0, 0, -stepSize * Time.deltaTime));
            //Debug.Log("down");
        }

        inputValue = joystick2right.action.ReadValue<Vector2>();

        if (inputValue.x > 0.5f)
        {
            c.Move(new Vector3(stepSize * Time.deltaTime, 0, 0));
            //Debug.Log("right");
        }
        else if (inputValue.x < -0.5f)
        {
            c.Move(new Vector3(-stepSize * Time.deltaTime, 0, 0));
            //Debug.Log("left");
        }

        if (inputValue.y > 0.5f)
        {
            c.Move(new Vector3(0, 0, stepSize * Time.deltaTime));
            //Debug.Log("up");
        }
        else if (inputValue.y < -0.5f)
        {
            c.Move(new Vector3(0, 0, -stepSize * Time.deltaTime));
            //Debug.Log("down");
        }
    }
}
