using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    [Range(1, 6)][SerializeField] float frequency = 0.5f;
    [Range(1, 6)][SerializeField] float speed = 2;
    [Range(1, 1000)][SerializeField] float amplificateur = 2;
    [Range(-1000, 1000)][SerializeField] float basedX = 201.3671f;
    [Range(-1000, 1000)][SerializeField] float basedY = 239;
    [Range(-1000, 1000)][SerializeField] float basedZ = 428.0844f;

    void Update()
    {
        Vector3 position = transform.localPosition;

        position.y = basedX + Mathf.Sin(Time.time * speed) * amplificateur;
        position.x = basedY + Mathf.Cos(Time.time * frequency * speed) * amplificateur;
        position.z = basedZ;

        transform.localPosition = position;

        // transform.Rotate(new Vector3(0, 0, 60f * Time.deltaTime));
    }

}
