using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  Rigidbody rb;
  [SerializeField] float thrusterForce = 1f;
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
    if (Input.GetKey(KeyCode.Space))
    {
        rb.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
    }
  }
  void ProcessRotation()
  {
    if (Input.GetKey(KeyCode.A))
    {
      Debug.Log("Pressed A - ROTATE LEFT");
    }
    else if (Input.GetKey(KeyCode.D))
    {
      Debug.Log("Pressed D - ROTATE RIGHT");
    }
  }
}
