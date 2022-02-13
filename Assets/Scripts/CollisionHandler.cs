using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] float loadLevelDelay = 2f;
  [SerializeField] AudioClip crashSound;
  [SerializeField] AudioClip finishSound;

  AudioSource audioSource;

  bool detectedHit = false;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  void OnCollisionEnter(Collision other)
  {
    if (detectedHit) { return; }

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
    detectedHit = true;
    audioSource.Stop();
    audioSource.PlayOneShot(crashSound);
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", loadLevelDelay);
  }

  void FinishLevel()
  {
    detectedHit = true;
    audioSource.Stop();
    audioSource.PlayOneShot(finishSound);
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
