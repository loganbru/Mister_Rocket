using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  Rigidbody rb;
  AudioSource audioSource;
  [SerializeField] float thrusterForce = 1000f;
  [SerializeField] float rotationForce = 100f;
  [SerializeField] AudioClip ThrusterSound;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    audioSource = GetComponent<AudioSource>();
  }

  void Update()
  {
    ProcessThrust();
    ProcessRotation();
  }

  void ProcessThrust()
  {
    if (Input.GetKey(KeyCode.W))
    {
      rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
      if (!audioSource.isPlaying)
      {
        audioSource.PlayOneShot(ThrusterSound);
      }
    }
    else
    {
      audioSource.Stop();
    }

  }
  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      RotateRocket(rotationForce);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      RotateRocket(-rotationForce);
    }
  }

  void RotateRocket(float rotationDirection)
  {
    rb.freezeRotation = true; // freezing rotation so we can manually rotate
    transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
    rb.freezeRotation = false; // unfreeze physics rotation
  }
}
