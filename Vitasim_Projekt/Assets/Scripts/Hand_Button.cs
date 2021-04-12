using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand_Button : XRBaseInteractable
{
    /*
     * NOTICE: this script is created for the buttons on the drill model in our project.
     * This may not function in any other projects that are structured differently, nor may it work on different models in same project.
     * 
     * You can copy most of the functionality and rewrite the code to function with correct axis' for new models.
     */

    //max and min movement for button (is z, as the button move back and forth on the z axis compared to base model)
    private float zMin = 0.0f;
    private float zMax = 0.0f;

    public float zInRange = 0.03f;

    private XRBaseInteractor hoverInteractor = null;
    private float previousHandHeight = 0.0f;

    public UnityEvent OnPress = null;
    private bool previousPress = false;

    protected override void Awake()
    {
        base.Awake();

        //Adds listeners to the event OnHoverEnter (which properly refers to touching a model)
        onHoverEntered.AddListener(StartPress);
        onHoverExited.AddListener(EndPress);
    }

    private void OnDestroy()
    {
        //Here the listeners are removed, to avoid unneeded interactions when its no longer neeeded
        onHoverEntered.RemoveListener(StartPress);
        onHoverExited.RemoveListener(EndPress);
    }

    //In the press methos the parameter indicate which controller (hands) thats interacting.
    private void StartPress(XRBaseInteractor interactor)
    {
        hoverInteractor = interactor;
        previousHandHeight = GetLocalZPostion(hoverInteractor.transform.position);
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        hoverInteractor = null;
        previousHandHeight = 0.0f;

        previousPress = false;
        SetZPosition(zMax);
    }

    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        //method that controls how far we can press the button before it activates etc.
        Collider collider = GetComponent<Collider>();

        //LocalPosition is used (though unneeded) to ensure the position is taken for the models position and not the global position
        zMin = transform.localPosition.z - (collider.bounds.size.z * 0.5f); //here the button activates when the button is pushed 30% of its height in.
        zMax = transform.localPosition.z;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        //This method focus is to make the interactable part of the button press
        if (hoverInteractor)
        {
            //moves button based on handposition
            float newHandHeight = GetLocalZPostion(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandHeight;
            previousHandHeight = newHandHeight;

            float newPosition = transform.localPosition.z - handDifference;
            SetZPosition(newPosition);

            CheckPress();
        }
    }

    private float GetLocalZPostion(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);

        return localPosition.z;
    }

    private void SetZPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;

        newPosition.z = Mathf.Clamp(position, zMin, zMax);

        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        //checks if the button is pressed down AND thats its not the same as the previous press
        if (inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
        }

        previousPress = inPosition;
    }

    private bool InPosition()
    {
        //as controllers move unsteadily, this method is used to allow ranges of collision to get more smooth interaction
        float inRange = Mathf.Clamp(transform.localPosition.z, zMin, zMin + zInRange);

        return transform.localPosition.z == inRange;
    }
}
