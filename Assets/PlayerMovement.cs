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
    public InputActionProperty joystick2;
    private const float stepSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = gameObject.transform.position;
        var inputValue = joystick2.action.ReadValue<Vector2>();
       if(inputValue.x > 0.5f)
        {
            pos.x += stepSize;
            Debug.Log("right");
        }
       else if(inputValue.x < -0.5f)
        {
            pos.x -= stepSize;
            Debug.Log("left");
        }
       else if (inputValue.y > 0.5f)
        {
            pos.z += stepSize;
            Debug.Log("up");
        }
       else if (inputValue.y < -0.5f)
        {
            pos.z -= stepSize;
            Debug.Log("down");
        }
        gameObject.transform.position = pos;

    }
}
