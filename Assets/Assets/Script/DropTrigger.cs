using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrigger : MonoBehaviour
{
    private Rigidbody rb;

    public Transform spawnPoint;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("collision");

        if ((collisionInfo.collider.tag == "Ground") && rb.isKinematic == false)
        {
            Debug.Log(collisionInfo.collider.name);
            transform.SetParent(spawnPoint, false);
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
            transform.localScale = spawnPoint.localScale;
            rb.isKinematic = true;
        }
    }
}
    
