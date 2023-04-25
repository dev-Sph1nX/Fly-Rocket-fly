using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start at -408
    // End at -373
    [SerializeField] GameObject indicator;

    // in seconds
    public int globalGameTime = 120;
    [SerializeField] GameObject surchargeViper;
    [SerializeField] GameObject viper;
    [SerializeField] string nextScene = "EndCinematic";
    [SerializeField] Animator animator;
    [SerializeField] int intialX = -31;
    [SerializeField] int finalX = 31;
    public float completion = 0, secondCount = 0;
    int deltaX;

    void Start()
    {
        Vector3 localPosition = indicator.transform.localPosition;
        localPosition.x = intialX;
        indicator.transform.localPosition = localPosition;

        deltaX = finalX - intialX;
        InvokeRepeating("IncrementIndicator", 1f, 1f);
    }

    void FixedUpdate()
    {
        if (secondCount < globalGameTime)
        {
            completion = Time.timeSinceLevelLoad / globalGameTime;
            Vector3 localPosition = indicator.transform.localPosition;
            localPosition.x = intialX + (deltaX * completion);
            indicator.transform.localPosition = localPosition;
        }
    }

    void IncrementIndicator()
    {
        secondCount++;
        if (secondCount >= globalGameTime)
        {
            CancelInvoke("IncrementIndicator");
            animator.SetTrigger("FadeOut");
            Invoke("EndGame", 3f);
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void OnCollision()
    {
        viper.GetComponent<Rigidbody>().useGravity = true;
        surchargeViper.GetComponent<RocketFreeMovement>().enabled = false;
        animator.SetTrigger("FadeOut");
        Invoke("ReturnToMenu", 3f);

    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
