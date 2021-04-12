using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour
{
    //speed of animation
    public float speed = 5.0f;
    public XRController controller = null;

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
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //this is a simply solution and may not be good for actual systems
        //store input
        CheckGrip();
        CheckPointer();

        //smooth input values
        SmoothFinger(gripFingers);
        SmoothFinger(pointFingers);

        //apply smoothed values
        AnimateFinger(gripFingers);
        AnimateFinger(pointFingers);
    }

    private void CheckGrip()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            //checks the grip button value and then changes specific fingers (list) values to grip value
            SetFingerTargets(gripFingers, gripValue);
        }
    }

    private void CheckPointer()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointerValue))
        {
            //same as checkgrip, just for trigger values (point)
            SetFingerTargets(pointFingers, pointerValue);
        }
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
        foreach(Finger finger in fingers)
        {
            AnimateFinger(finger.type.ToString(), finger.current);
        }
    }

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }
}