//Written by Michael Anglemier
//Following John Burke's Lecture

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{

    [SerializeField] 
    private GameObject[] platforms;

    private GameObject dummyTraveller;

    void Awake()
    {
        //Vector3 position = new Vector3(0, 0, 0);

        dummyTraveller = new GameObject("dummy");

        int randomNumber = 0;

        for (int i = 0; i < 30; i++)
        {
            randomNumber = Random.Range(0, platforms.Length);

            if (platforms[randomNumber].tag == "StairsDown")
            {
                //position.y = position.y - 5;
                dummyTraveller.transform.Translate(0, -5, 0);

            }

            GameObject p = Instantiate(platforms[randomNumber], dummyTraveller.transform.position, dummyTraveller.transform.rotation);
            //position.z = position.z + 10;

            if (platforms[randomNumber].tag == "StairsUp")
            {
                //position.y = position.y + 5;
                dummyTraveller.transform.Translate(0, 5, 0);
            }

            if (platforms[randomNumber].tag == "TurnLeft")
            {
                dummyTraveller.transform.Rotate(new Vector3(0, -90, 0));
            }

            if (platforms[randomNumber].tag == "TurnRight")
            {
                dummyTraveller.transform.Rotate(new Vector3(0, 90, 0));
            }


            dummyTraveller.transform.Translate(Vector3.forward *10);

        }
    }

    
}
