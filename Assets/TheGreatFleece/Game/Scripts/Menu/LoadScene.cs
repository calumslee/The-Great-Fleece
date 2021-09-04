using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private Image _loadingBar;
    [SerializeField]
    private Image _continueText;

    private void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        yield return null;

        AsyncOperation async = SceneManager.LoadSceneAsync("Main");
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            _loadingBar.fillAmount = async.progress;

            if (async.progress >= 0.9f)
            {
                _loadingBar.fillAmount = 1f;
                _continueText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    async.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}