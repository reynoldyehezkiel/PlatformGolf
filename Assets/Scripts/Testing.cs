using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private Golf golf;

    private float holdDownStartTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse Down, start holding
            holdDownStartTime = Time.time;
        }

        if (Input.GetMouseButton(0))
        {
            // Mouse still down, show force
            float holdDownTime = Time.time - holdDownStartTime;
            golf.ShowForce(CalculateHoldDownForce(holdDownTime));
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Mouse Up, Launch!
            float holdDownTime = Time.time - holdDownStartTime;
            golf.Launch(CalculateHoldDownForce(holdDownTime));
        }
    }

    private float CalculateHoldDownForce(float holdTime)
    {
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        float force = holdTimeNormalized * Golf.MAX_FORCE;
        return force;
    }
}
