using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBallMovement : MonoBehaviour
{
    private Rigidbody rdbody;
    public float speed;
    public float damage;
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
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Crystal"))
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            damagable?.TakeDamage(damage);
        }


        Destroy(this.gameObject);
    }

}
