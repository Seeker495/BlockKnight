using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Vector3 direction;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rigidbody2D);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot()
    {
        rigidbody2D.velocity = direction * speed * Time.deltaTime;
    }

    public void SetTarget(Transform target)
    {
        direction = (transform.position - target.position).normalized;
    }
}
