using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyController : MonoBehaviour
{
    [SerializeField] float Speed = 5;
    [SerializeField] Space space = Space.World;
    Rigidbody body;
    Vector3 Force;
    Vector3 Torque;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        float rotation = 0;
        if (space == Space.World) direction.x = Input.GetAxis("Horizontal");
        else
        {
            rotation = Input.GetAxis("Horizontal");
        }
        direction.z = Input.GetAxis("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);

        //transform.rotation *= Quaternion.Euler(0, rotation * Speed, 0);

        //direction = transform.rotation * direction;
        //transform.position += direction * Time.deltaTime * Speed;

        //transform.Translate(direction * Time.deltaTime * Speed, space); //better way of doing above

        Force = direction * Speed;
        Torque = Vector3.up * rotation * Speed;

    }

    private void FixedUpdate()
    {
        body.AddForce(Force);
        body.AddTorque(Torque);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);
    }
}
