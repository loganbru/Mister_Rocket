using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
  void OnCollisionEnter(Collision other)
  {
    switch (other.gameObject.tag)
    {
      case "Friendly":
        Debug.Log("This thing is friendly");
        break;

      case "Finish":
        Debug.Log("Congrats you finished!");
        break;

      case "Fuel":
        Debug.Log("Picked up fuel");
        break;

      default:
        Debug.Log("you blew up");
        break;
    }
  }
}
