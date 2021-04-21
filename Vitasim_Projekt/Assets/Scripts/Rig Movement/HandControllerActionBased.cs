using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HandControllerActionBased : MonoBehaviour
{
    ////SerializeField allows unity to see the variable in inspector, while it keeps the variable private for the class
    //[SerializeField] InputActionReference controllerActionGrip;
    //[SerializeField] InputActionReference controllerActionTrigger;

    //private Animator handAnimator;

    //private readonly List<Finger> gripFingers = new List<Finger>()
    //{
    //    new Finger(FingerType.Middle),
    //    new Finger(FingerType.Ring),
    //    new Finger(FingerType.Pinky)
    //};

    ////finger(s) for trigger
    //private readonly List<Finger> triggerFingers = new List<Finger>()
    //{
    //    new Finger(FingerType.Index),
    //    new Finger(FingerType.Thumb)
    //};

    //private void Awake()
    //{
    //    controllerActionGrip.action.performed += GripPress;
    //    controllerActionTrigger.action.performed += TriggerPress;

    //    controllerActionGrip.action.canceled += GripPress;
    //    controllerActionTrigger.action.canceled += TriggerPress;


    //    handAnimator = GetComponent<Animator>();
    //}

    //private void GripPress(InputAction.CallbackContext obj)
    //{
    //    foreach (Finger finger in gripFingers)
    //    {
    //        handAnimator.SetFloat(finger.type.ToString(), obj.ReadValue<float>());
    //    }
    //}

    //private void TriggerPress(InputAction.CallbackContext obj)
    //{
    //    foreach (Finger finger in triggerFingers)
    //    {
    //        handAnimator.SetFloat(finger.type.ToString(), obj.ReadValue<float>());
    //    }
    //}

    //speed of animation
    public float speed = 5.0f;
    [SerializeField] InputActionReference controllerActionGrip;
    [SerializeField] InputActionReference controllerActionTrigger;

    private Animator animator = null;

    //finger groups
    //fingers for grip button
    private readonly List<Finger> gripFingers = new List<Finger>()
    {
        new Finger(FingerType.Middle),
        new Finger(FingerType.Ring),
        new Finger(FingerType.Pinky)
    };

    //finger(s) for trigger
    private readonly List<Finger> pointFingers = new List<Finger>()
    {
        new Finger(FingerType.Index),
        new Finger(FingerType.Thumb)
    };

    private void Awake()
    {
        controllerActionGrip.action.performed += CheckGrip;
        controllerActionTrigger.action.performed += CheckTrigger;

        controllerActionGrip.action.canceled += CheckGrip;
        controllerActionTrigger.action.canceled += CheckTrigger;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //smooth input values
        SmoothFinger(gripFingers);
        SmoothFinger(pointFingers);

        //apply smoothed values
        AnimateFinger(gripFingers);
        AnimateFinger(pointFingers);
    }

    private void CheckGrip(InputAction.CallbackContext obj)
    {
        SetFingerTargets(gripFingers, obj.ReadValue<float>());
    }

    private void CheckTrigger(InputAction.CallbackContext obj)
    {
        SetFingerTargets(pointFingers, obj.ReadValue<float>());
    }

    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        //sets target values for each finger
        foreach (Finger finger in fingers)
        {
            finger.target = value;
        }
    }

    private void SmoothFinger(List<Finger> fingers)
    {
        //smooths movement to target location/position
        foreach (Finger finger in fingers)
        {
            //unscaledDeltaTime is used for better smoothness, when taking pausing and fps into account
            float time = speed * Time.unscaledDeltaTime;

            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
        }
    }

    private void AnimateFinger(List<Finger> fingers)
    {
        //animates each fingers taking into account which finger is animated (pinky, index etc)
        foreach (Finger finger in fingers)
        {
            AnimateFinger(finger.type.ToString(), finger.current);
        }
    }

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }
}
