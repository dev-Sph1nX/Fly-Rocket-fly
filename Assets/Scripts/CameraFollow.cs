using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform viper;
    [SerializeField] Vector3 offset;

    [SerializeField] float smoothFactor = 0.1f;
    Vector3 smoothposition = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.position = viper.position + offset;
        smoothposition = Vector3.Lerp(smoothposition, viper.position, smoothFactor);
        transform.position = smoothposition + offset;

    }
}

