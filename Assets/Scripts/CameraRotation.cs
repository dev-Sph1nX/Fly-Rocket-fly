using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float tumble = 0.01f;

    // Update is called once per frame
    void Update()
    {
        float rotation = transform.localRotation.y + tumble;
        transform.Rotate(new Vector3(0, rotation * Time.deltaTime, 0), Space.Self);
    }
}
