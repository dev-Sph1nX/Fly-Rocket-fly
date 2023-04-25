using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelToLoad = "Game";
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float fadeDuration = 0.01f;

    // public void Awake()
    // {
    //     // animator = GetComponent<Animator>();
    //     Debug.Log(animator);
    // }
    public void StartGame()
    {
        animator.SetTrigger("FadeOut");
        float newVolume = Mathf.Lerp(audioSource.volume, 0, fadeDuration);
        audioSource.volume = newVolume;
        Invoke("LoadLevel", 3f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
