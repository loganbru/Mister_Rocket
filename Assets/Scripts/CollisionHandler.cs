using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] float loadLevelDelay = 2f;
  [SerializeField] AudioClip crashSound;
  [SerializeField] AudioClip finishSound;
  [SerializeField] ParticleSystem crashParticles;
  [SerializeField] ParticleSystem finishParticles;

  AudioSource audioSource;

  bool detectedHit = false;
  bool collisionDisabled = false;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  void Update()
  {
    CheckDebugKeys();
  }

  void CheckDebugKeys()
  {
    if (Input.GetKeyDown(KeyCode.L))
    {
      NextLevel();
    }
    else if (Input.GetKeyDown(KeyCode.C))
    {
      collisionDisabled = !collisionDisabled; // toggle collision
    }
  }

  void OnCollisionEnter(Collision other)
  {
    if (detectedHit || collisionDisabled) { return; }

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
    crashParticles.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", loadLevelDelay);
  }

  void FinishLevel()
  {
    detectedHit = true;
    audioSource.Stop();
    audioSource.PlayOneShot(finishSound);
    finishParticles.Play();
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
