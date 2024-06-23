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
        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            loadingBar.value = progress;
            if (progress >= 0.9f)
            {
                loadingBar.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
