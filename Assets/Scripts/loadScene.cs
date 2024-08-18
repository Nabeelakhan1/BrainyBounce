using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider loadingBar;

    public void LoadSceneByIndex(int index)  // Renamed method to avoid conflict
    {
        StartCoroutine(LoadScene_Coroutine(index));
    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        loadingBar.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;

        float duration = 5.0f;  // Duration to complete loading in seconds
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            loadingBar.value = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        // Ensure loading bar is full after the duration
        loadingBar.value = 1;

        // Activate the scene once the loading bar is full
        asyncOperation.allowSceneActivation = true;

        // Wait until the scene is fully loaded
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Hide loader UI after the scene is loaded
        loaderUI.SetActive(false);
    }
}
