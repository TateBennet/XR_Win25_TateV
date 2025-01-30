using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// The log script purpose is...
/// </summary>

[RequireComponent (typeof(Collider))]

public class Log : MonoBehaviour
{

    [SerializeField] GameObject logOne;
    [SerializeField] GameObject logTwo;


    Collider m_collider = null;
    [SerializeField] float m_splitThreshold = 6f;
    [SerializeField] float m_stickThreshold = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        m_collider = GetComponent<Collider>();
        m_collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Blade blade = null;
        if (other.CompareTag("Blade"))
        {
            blade = other.GetComponentInParent<Blade>();
        }

        if (blade == null) 
            return;

        if (blade.m_controllerDataReader == null) 
            return;

        Split(blade);
    }

    private void Split(Blade blade)
    {
        //split log
        float bladeHitSpeed = blade.m_controllerDataReader.Velocity.magnitude;
        if (bladeHitSpeed > m_splitThreshold)
        {
            // disable collision to ensure interaction only happens once.
            m_collider.enabled = false;

            EnablePhsysics(logOne);
            EnablePhsysics(logTwo);
        }
        
        // stick axe
        else if (bladeHitSpeed > m_stickThreshold)
        {
            blade.Drop();
            blade.DisablePhysics();
        }
        
    }

    void EnablePhsysics(GameObject log)
    {
        log.transform.parent = null;

        Rigidbody rb = log.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}
