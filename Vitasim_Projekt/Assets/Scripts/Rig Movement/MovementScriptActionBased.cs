using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class MovementScriptActionBased : MonoBehaviour
{
    //This script has the function of switching between teleport mode and continuous movement mode
    // It also adds the functionality to teleport, so when you aren't aiming to teleport, the controllers are in direct interact mode

    public GameObject directControllerGameObject;
    public GameObject rayControllerGameObject;

    public InputActionReference movementSwitchKey;
    public InputActionReference teleportActivationReference;

    [Space]
    public UnityEvent onSwitchTeleport;
    public UnityEvent onSwitchContinuous;
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    private bool teleport = false;

    private void Start()
    {
        movementSwitchKey.action.performed += MovementSwitch;
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancelled;
    }

    private void MovementSwitch(InputAction.CallbackContext obj)
    {
        if (teleport)
        {
            DeactivateTeleport();
            onSwitchContinuous.Invoke();
        }
        else
        {
            onSwitchTeleport.Invoke();
        }        
        teleport = !teleport;
    }

    private void TeleportModeActivate(InputAction.CallbackContext obj)
    {
        if (teleport)
        {
            onTeleportActivate.Invoke();
        }        
    }

    private void TeleportModeCancelled(InputAction.CallbackContext obj)
    {
        if (teleport)
        {
            // adds delay to activation of cancelation
            Invoke("DeactivateTeleport", .1f);
        }        
    }

    void DeactivateTeleport()
    {
        onTeleportCancel.Invoke();
    }
}
