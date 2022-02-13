using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  Rigidbody rb;
  [SerializeField] float thrusterForce = 1000f;
  [SerializeField] float rotationForce = 100f;
  void Start()
  {
    rb = GetComponent<Rigidbody>();
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
    transform.Rotate(Vector3.forward * rotationDirection * Time.deltaTime);
  }
}
