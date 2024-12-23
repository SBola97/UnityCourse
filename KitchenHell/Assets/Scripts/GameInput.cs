using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    private PlayerInputActions playerInputActions;
    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(InputAction.CallbackContext context)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(InputAction.CallbackContext context){
        OnInteractAction?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized(){
        
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        //Prevents from moving faster on diagonal
        inputVector = inputVector.normalized;

/*         if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Pressing the W button");
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Pressing the A button");
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Pressing the S button");
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Pressing the D button");
            inputVector.x = +1;
        } */
        //Debug.Log(inputVector);
        return inputVector;
    }
}
