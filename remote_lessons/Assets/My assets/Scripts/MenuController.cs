using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public bool IsAsyncLoad = false;
    public GameObject LoadingScreen;
    public Animator LoadingAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPlayButtonPressed() 
    {
        LoadingScreen.SetActive(true);
        LoadingAnimator.SetTrigger("Spinning");
        if (IsAsyncLoad)
        {
            StartCoroutine(StartLoading());
        }
        else 
        {
            SceneManager.LoadScene(1);
        }
    }

    public IEnumerator StartLoading() 
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadSceneAsync(1);
    }

    public void OnExitButtonPressed() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
