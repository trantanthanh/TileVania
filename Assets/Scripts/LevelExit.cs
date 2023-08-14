using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float timeWaitForLoadNextLevel = 1.0f;
    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(LoatNextLevel());
    }

    IEnumerator LoatNextLevel()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
