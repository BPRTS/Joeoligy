using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Chasing Object")]
    public Transform whiteHouse; // Reference to the White House GameObject or its position

    [Header("Enemy Specs")]
    public float moveSpeed = 5f; // Speed at which the character moves
    public int health = 50;
    public int damage = 10;

    private void Update()
    {
        // Calculate the direction from the character to the White House (ignoring Y-axis)
        Vector3 targetDirection = whiteHouse.position - transform.position;
        targetDirection.y = 0f; // Set Y-component to zero

        // Move towards the White House (only in X and Z axes)
        Vector3 newPosition = transform.position + targetDirection.normalized * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);

        // Rotate to face the movement direction
        if (targetDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WhiteHouse")
        {
            collision.gameObject.GetComponent<WhiteHouse>().health -= damage;
        }
    }
}
