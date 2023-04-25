using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFreeMovement : MonoBehaviour
{
    [SerializeField] GameObject go;
    [Header("General")]

    [SerializeField] float strafSpeed = 7.5f;
    [SerializeField] float hoverSpeed = 7.5f;

    [Header("Roll")]
    [SerializeField] float maxRollAngle = .15f;

    [SerializeField] float rollSpeed = 90f;
    [SerializeField] float rollAcceleration = 3.5f;
    // [Header("Balance")]
    // [SerializeField] float maxBalanceAngle = .15f;
    // [SerializeField] float balanceSpeed = 90f;
    // [SerializeField] float balanceAcceleration = 3.5f;

    float activeStrafSpeed, activeHoverSpeed;
    float strafAcceleration = 2f, hoverAcceleration = 2f;
    float rollInput; // balanceInput


    // A chaque update de la physique
    void FixedUpdate()
    {

        rollInput = Mathf.Lerp(rollInput, -Input.GetAxisRaw("Horizontal") * .3f, rollAcceleration * Time.deltaTime);

        if (go.transform.rotation.z > maxRollAngle && rollInput > 0)
        {
            rollInput = 0;
        }
        if (go.transform.rotation.z < -maxRollAngle && rollInput < 0)
        {
            rollInput = 0;
        }

        // balanceInput = Mathf.Lerp(balanceInput, -Input.GetAxisRaw("Vertical") * .3f, balanceAcceleration * Time.deltaTime);

        // if (go.transform.rotation.x > maxBalanceAngle && balanceInput > 0)
        // {
        //     balanceInput = 0;
        // }
        // if (go.transform.rotation.x < -maxBalanceAngle && balanceInput < 0)
        // {
        //     balanceInput = 0;
        // }

        //balanceInput * balanceSpeed * Time.deltaTime
        go.transform.Rotate(new Vector3(0, 0, rollInput * rollSpeed * Time.deltaTime), Space.Self);

        activeStrafSpeed = Mathf.Lerp(activeStrafSpeed, Input.GetAxisRaw("Horizontal") * strafSpeed, strafAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Vertical") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        transform.position += (transform.right * activeStrafSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

    }


}
