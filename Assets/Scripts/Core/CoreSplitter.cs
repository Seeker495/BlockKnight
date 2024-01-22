using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSplitter : MonoBehaviour
{
    [SerializeField]
    private GameObject cloneCorePrefab;
    [SerializeField]
    private float cloneInitialSpeed;

    Rigidbody2D rigidBody;

    public void Split()
    {
        var cloneCore = Instantiate(cloneCorePrefab, transform.position, Quaternion.identity);
        rigidBody = cloneCore.GetComponent<Rigidbody2D>();
        Vector2 randomVector = Random.insideUnitCircle;
        rigidBody.velocity = randomVector * cloneInitialSpeed;
    }
}
