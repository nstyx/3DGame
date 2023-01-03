using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    [SerializeField] private CanvasGroup image;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
        image.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthManager.playerDied) deathMethod();
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

     public void deathMethod()
    {
        StartCoroutine(DeathAnimDelay());
        StartCoroutine(FadeIn());
    }

    private IEnumerator DeathAnimDelay()
    {
        yield return new WaitForSeconds(1.9f); // 1.833 = animation length + X time to show Death Screen?
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
    }

    IEnumerator FadeIn()
    {
        // Fade in over 2 seconds
        float elapsedTime = 0f;
        float fadeTime = 1.9f;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            image.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeTime);
            yield return null;
        }
    }
}
