using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMover : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Vector3 force;
    [SerializeField] ForceMode forceMode;
    [SerializeField] Vector3 torque;
    [SerializeField] ForceMode torqueMode;
    [SerializeField] KeyCode jumpKey;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(force, forceMode);
            rb.AddTorque(torque, forceMode);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }


}
