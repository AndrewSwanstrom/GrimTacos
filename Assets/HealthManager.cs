using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    Transform obj;
    TapReader tapScript = new TapReader();

    public int health;


    void OnCollisionStay(Collision collider) {
        if (collider.gameObject.tag == "Ground") {
        tapScript.isGrounded = 0;
        }
        else if (collider.gameObject.tag == "Obstacle") {
            health --;
            Debug.Log($"Health: {health}");
            if (health == 0) {
                transform.DetachChildren();
                Destroy(this.gameObject);
            }
            obj = GetComponent<Transform>();
            obj.position = Vector3.zero;
        }
    }
}
