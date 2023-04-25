using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleIn : MonoBehaviour
{
    // [SerializeField] float fadeDuration = 1.0f;
    // [SerializeField] float maxScale = 1.3f;

    // void Start()
    // {
    //     transform.localScale = new Vector3(0, 0, 0);
    // }

    // void Update()
    // {
    //     float newScaleX = Mathf.Lerp(transform.localScale.x, maxScale, fadeDuration);
    //     float newScaleY = Mathf.Lerp(transform.localScale.y, maxScale, fadeDuration);
    //     float newScaleZ = Mathf.Lerp(transform.localScale.z, maxScale, fadeDuration);
    //     transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
    // }

    public float duration = 1.0f;  // Durée de l'animation en secondes
    public float scaleFactor = 1.3f;  // Échelle finale de l'objet

    private float timeElapsed = 0.0f;  // Temps écoulé depuis le début de l'animation
    private Vector3 initialScale;  // Échelle initiale de l'objet

    void Start()
    {
        // Sauvegarder l'échelle initiale de l'objet
        initialScale = transform.localScale;
        // Mettre l'échelle de l'objet à zéro
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        // Mettre à jour le temps écoulé depuis le début de l'animation
        timeElapsed += Time.deltaTime;

        // Calculer le ratio de progression de l'animation (entre 0 et 1)
        float t = Mathf.Clamp01(timeElapsed / duration);

        // Appliquer l'échelle correspondante en fonction du ratio
        transform.localScale = Vector3.Lerp(Vector3.zero, initialScale * scaleFactor, t);

        // Si l'animation est terminée, arrêter le script
        if (t >= 1.0f)
        {
            enabled = false;
        }
    }
}
