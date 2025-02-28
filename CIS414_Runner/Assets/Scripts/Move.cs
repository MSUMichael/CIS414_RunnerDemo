//Written by Michael Anglemier
//2/4/2025

//Following John Burke's lecture, and Issac

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private IMovementStrategy movementStrategy;

    /*
    [SerializeField]
    private float moveSpeed;
    */

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    static GameObject player;

    //on enable
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Start is called before the first frame update
    private void Start()
    { 
        // start with the 
        movementStrategy = new GreenStrategy();

        player = this.gameObject;
        GenerateWorld.RunDummy();
    }

    void OnTriggerEnter (Collider other)
    {
        GenerateWorld.RunDummy();
        //Debug.Log("Not Working");
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float speed = movementStrategy.GetSpeed();

        //create movement vector

        Vector3 move = new Vector3(moveX, 0.0f, moveZ) * speed * Time.deltaTime;

        transform.Translate(move, Space.World);

    }

    public void ChangeMovementStrategy(IMovementStrategy newStrategy)
    {
        this.movementStrategy = newStrategy;
    }

    
    private void OnCollisionEnter(Collision other)
    {

        IMovementStrategy newStrategy = MovementStrategyFactory.GetStrategy(other.gameObject.tag);
        ChangeMovementStrategy(newStrategy);

        
        /* Legacy Code
        if (other.gameObject.CompareTag("RedStrategy"))
        { 
            ChangeMovementStrategy(new RedStrategy());
        }
        else if (other.gameObject.CompareTag("YellowStrategy"))
        {
            ChangeMovementStrategy(new YellowStrategy());
        }
        else if (other.gameObject.CompareTag("GreenStrategy"))
        {
            ChangeMovementStrategy(new GreenStrategy());
        }
        else if (other.gameObject.CompareTag("PurpleStrategy"))
        {
            ChangeMovementStrategy(new PurpleStrategy());
        }
        */
        
    }



}
