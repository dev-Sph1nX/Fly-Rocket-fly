using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollAnimation : MonoBehaviour
{
    [SerializeField] float timeBetweenAnimation = 10.0f;
    [SerializeField] float timeToAnimate = 2f;

    void Update()
    {
        if (Time.time >= timeToAnimate)
        {
            if (Time.time % timeBetweenAnimation < 0.1f)
            {
                GetComponent<Animator>().SetTrigger("Roll");
            }
        }
    }
}
