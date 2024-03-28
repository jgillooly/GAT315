using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    string status;
    Vector3 Contact;
    Vector3 Normal;

    #region Collisions
    private void OnCollisionEnter(Collision collision)
    {
        status = "collision Enter " + collision.gameObject;
        Contact = collision.GetContact(0).point;
        Normal = collision.GetContact(0).normal;
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
    #endregion

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        status = "trigger Enter " + other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
    #endregion

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 20;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Contact, 0.1f);
        Gizmos.DrawLine(Contact, Contact + Normal);
    }
}
