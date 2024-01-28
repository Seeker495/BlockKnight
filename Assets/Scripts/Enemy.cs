using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float timeInterval;
    [SerializeField] GameObject attackObject;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rigidbody2D);    
    }

    // Update is called once per frame
    void Update()
    {
        if((time += Time.deltaTime) > timeInterval)
        {
            GameObject attack = Instantiate(attackObject, transform.parent);
            attack.TryGetComponent(out Fire fire);
            fire.SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
            fire.Shot();
        }
    }
}
