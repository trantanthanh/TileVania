using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float timeWaitForLoadNextLevel = 1.0f;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            StartCoroutine(LoatNextLevel());
        }
    }

    IEnumerator LoatNextLevel()
    {
        yield return new WaitForSecondsRealtime(timeWaitForLoadNextLevel);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        FindObjectOfType<ScenePersist>().ResetScenePersist();

        SceneManager.LoadScene(nextSceneIndex);
    }
}
