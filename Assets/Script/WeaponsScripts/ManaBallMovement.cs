using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBallMovement : MonoBehaviour
{
    private Rigidbody rdbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rdbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rdbody.velocity = this.transform.forward * speed ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
