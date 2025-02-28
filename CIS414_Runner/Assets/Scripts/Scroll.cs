using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.position += GenerateWorld.dummyTraveller.transform.forward * -0.1f;
    }
}
