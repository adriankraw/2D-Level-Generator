using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 5f;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);


        SceneManager.LoadScene(levelIndex);
    }

    public void LoadNextLevel()

    {
       StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));        
    }

    
}
