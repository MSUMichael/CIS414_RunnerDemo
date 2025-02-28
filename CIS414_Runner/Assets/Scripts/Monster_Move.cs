//Michael Anglemier 2/4/2025
//FOllowing John Burk's Lecture


using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_Move : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private float chaseRadius = 10.0f;
    [SerializeField]
    private Transform player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRadius)
        {
            ChasePlayer();
        } 

    }

    private void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
