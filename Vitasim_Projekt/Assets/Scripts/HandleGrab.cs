using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleGrab : XRGrabInteractable
{
    public float Distance = 0.05f;
    public float Mass = 20.0f;
    public float EditMass { get { return Mass; } set { Mass = value; } }
    public Transform handler;
    Rigidbody rb;

    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //checks if hand/object is too far away from base point, releases if too far.
        if (Vector3.Distance(handler.position, transform.position) > Distance)
        {
            var interactor = GetComponent<XRBaseInteractor>();
            this.OnSelectExiting(interactor);
        }
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        //The reason for using base is to make sure the original OnSelectEntering is run, not too sure...
        base.OnSelectEntering(interactor);

        Rigidbody rbHandler = handler.GetComponent<Rigidbody>();
        rbHandler.mass = Mass;

        StoreInteractor(interactor);
        MatchAttachmentPoints(interactor);
    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        //this is done as not every object may have attachment points to grab onto.
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        base.OnSelectExiting(interactor);

        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        var rbHandler = handler.GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;
        rbHandler.mass = 1.0f;
    }
}
