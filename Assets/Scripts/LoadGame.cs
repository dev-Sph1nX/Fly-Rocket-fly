using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] string levelToLoad = "Game";
    [SerializeField] Animator animator;

    public void StartGame()
    {
        Debug.Log("StartGame");
        animator.SetTrigger("FadeOut");
        Invoke("LoadLevel", 3f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
