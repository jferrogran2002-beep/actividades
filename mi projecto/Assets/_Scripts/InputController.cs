using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    InputAction moveInput;

    [HideInInspector] public Vector2 moveVector;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        moveInput = InputSystem.actions.FindAction("Move");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      GetInput();  
    }
    public void GetInput()
    {
        moveVector = moveInput.ReadValue<Vector2>();
    }
}
