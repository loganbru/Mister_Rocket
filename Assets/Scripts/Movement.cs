using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  [SerializeField] float thrusterForce = 1000f;
  [SerializeField] float rotationForce = 100f;
  [SerializeField] AudioClip ThrusterSound;
  [SerializeField] ParticleSystem mainThrusterParticles;
  [SerializeField] ParticleSystem leftThrusterParticles;
  [SerializeField] ParticleSystem rightThrusterParticles;

  Rigidbody rb;
  AudioSource audioSource;

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
      StartMainThruster();
    }
    else
    {
      StopMainThrusting();
    }

  }

  void StopMainThrusting()
  {
    audioSource.Stop();
    mainThrusterParticles.Stop();
  }

  void StartMainThruster()
  {
    rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
    if (!audioSource.isPlaying)
    {
      audioSource.PlayOneShot(ThrusterSound);
    }
    if (!mainThrusterParticles.isPlaying)
    {
      mainThrusterParticles.Play();
    }
  }

  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      ThrustLeft();
    }
    else if (Input.GetKey(KeyCode.D))
    {
      ThrustRight();
    }
    else
    {
      rightThrusterParticles.Stop();
      leftThrusterParticles.Stop();
    }
  }

  private void ThrustRight()
  {
    RotateRocket(-rotationForce);
    if (!rightThrusterParticles.isPlaying)
    {
      rightThrusterParticles.Play();
    }
  }

  private void ThrustLeft()
  {
    RotateRocket(rotationForce);
    if (!leftThrusterParticles.isPlaying)
    {
      leftThrusterParticles.Play();
    }
  }

  void RotateRocket(float rotationDirection)
  {
    rb.freezeRotation = true; // freezing rotation so we can manually rotate
    transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
    rb.freezeRotation = false; // unfreeze physics rotation
  }
}
