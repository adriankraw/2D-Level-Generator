using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 5f;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += (Scene, LoadSceneMode) => { if (Scene.buildIndex != 0) transition.SetTrigger("End"); };
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return null;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }


}
