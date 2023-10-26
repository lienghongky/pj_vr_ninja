using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string playerTag = "Player"; // The tag of the player GameObject
    public float jumpForce = 10.0f;
    public float jumpCooldown = 2.0f;
    public float jumpRange = 5.0f; // The maximum distance to the player for a jump

    private Rigidbody rb;
    private float lastJumpTime;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        lastJumpTime = -jumpCooldown;
    }

    void Update()
    {
        if (Time.time - lastJumpTime >= jumpCooldown)
        {
            JumpTowardsPlayerLogic();
        }
    }

  

    void JumpTowardsPlayerLogic()
    {
        // Find the player GameObject by its tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player == null)
        {
            return; // Player object not found, so don't jump.
        }

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= jumpRange)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

            lastJumpTime = Time.time;
        }
    }
}
