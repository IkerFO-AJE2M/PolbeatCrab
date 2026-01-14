using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 0.8f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Asegura que empieza transparente
        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    IEnumerator FadeOutAndLoad(string sceneName)
    {
        // Fade OUT (a negro)
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.unscaledDeltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Carga escena
        SceneManager.LoadScene(sceneName);

        // Espera un frame para que la escena esté lista
        yield return null;

        // Fade IN (desde negro)
        while (alpha > 0f)
        {
            alpha -= Time.unscaledDeltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}



