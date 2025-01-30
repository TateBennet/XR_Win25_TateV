using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;
using System;

[RequireComponent(typeof(XRGrabInteractable))]
public class Blade : MonoBehaviour
{
    public XRGrabInteractable m_grabInteractable;
    public ControllerDataReader m_controllerDataReader;
    XRBaseInteractor m_interactor;

    private void Awake()
    {
        m_grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        if (m_grabInteractable == null)
            return;

        m_grabInteractable.selectEntered.AddListener(OnSelectEnter);
        m_grabInteractable.selectExited.AddListener(ResetControllerDataReader);
    }

    private void ResetControllerDataReader(SelectExitEventArgs arg)
    {
        m_controllerDataReader = null;
    }

    private void OnSelectEnter(SelectEnterEventArgs arg)
    {
        // set the interactor that is grabbing the axe
        m_interactor = arg.interactorObject as XRBaseInteractor;

        // set the controller data reader
        m_controllerDataReader = m_interactor.gameObject.GetComponentInParent<ControllerDataReader>();

        EnablePhysics();
    }

    private void OnDisable()
    {
        if (m_grabInteractable == null)
            return;

        m_grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
        m_grabInteractable.selectExited.RemoveListener(ResetControllerDataReader);
    }

    public void Drop()
    {
        IXRSelectInteractable grabInteractable = m_grabInteractable;
        m_interactor.interactionManager.CancelInteractableSelection(grabInteractable);
    }

    public void DisablePhysics()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void EnablePhysics()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
    }
}
