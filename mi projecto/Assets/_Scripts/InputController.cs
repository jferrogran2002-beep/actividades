using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    InputAction moveInput;
    [HideInInspector] public InputAction drinkInput;
    private PlayerInteraction playerInteraction;

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
        drinkInput = InputSystem.actions.FindAction("Interact");
        playerInteraction = GetComponent<PlayerInteraction>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        //drinkInput.started += Drink;
    }
    private void OnDisable()
    {
        //drinkInput.started -= Drink;
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
    public void Drink(InputAction.CallbackContext context)
    {
        if(Inventory.Instance.hasPotion)
        {
            playerInteraction.UsePotion();
            Debug.Log("Tomaste la poción " + Inventory.Instance.pickedUpPotion.potionName);
            Inventory.Instance.pickedUpPotion = null;
            Inventory.Instance.hasPotion = false;
            HUDManager.Instance.ResetPotionName();
        }
        else
        {
            Debug.Log("No hay pociones");
        }
    }
}
