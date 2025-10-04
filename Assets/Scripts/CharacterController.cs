using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float x;
    private float y;
    public float speed;
    public float rotspeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if (y != 0)
        {
            Debug.Log(rigidbody.velocity);
            rigidbody.AddForce(transform.forward * y * speed, ForceMode.Force);
        }
        else if (rigidbody.velocity.magnitude > 0)
        {
            rigidbody.velocity -= rigidbody.velocity * 0.2f;
        }
        if (x != 0)
        {
            Quaternion rot = Quaternion.AngleAxis(x * rotspeed, Vector3.up);
            Quaternion q = this.transform.rotation;
            // 合成して、自身に設定
            this.transform.rotation = q * rot;
        }
    }
}
