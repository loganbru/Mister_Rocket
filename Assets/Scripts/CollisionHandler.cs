using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] float loadLevelDelay = 2f;
  void OnCollisionEnter(Collision other)
  {
    switch (other.gameObject.tag)
    {
      case "Friendly":
        Debug.Log("This thing is friendly");
        break;

      case "Finish":
        FinishLevel();
        break;

      case "Fuel":
        Debug.Log("Picked up fuel");
        break;

      default:
        Crash();
        break;
    }
  }

  void Crash()
  {
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", loadLevelDelay);
  }

  void FinishLevel()
  {
    GetComponent<Movement>().enabled = false;
    Invoke("NextLevel", loadLevelDelay);
  }

  void ReloadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }
  void NextLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;
    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
      nextSceneIndex = 0;
    }
    SceneManager.LoadScene(nextSceneIndex);
  }
}
