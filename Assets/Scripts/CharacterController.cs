using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public int Hp;
    public Slider slider;
    private float x;
    private float y;
    public float speed;
    public float rotspeed;
    public GameObject booster;
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
        if (y != 0 || x != 0)
        {
            Vector3 lookTarget = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y);
            transform.LookAt(lookTarget);
            rigidbody.AddForce(transform.forward * speed, ForceMode.Force);
            if (booster.activeSelf == false)
            {
                booster.SetActive(true);
            }
        }
        else if (rigidbody.velocity.magnitude > 0)
        {
            if (booster.activeSelf == true)
            {
                booster.SetActive(false);
            }
            rigidbody.velocity -= rigidbody.velocity * 0.2f;
        }
        else
        {
            if (booster.activeSelf == true)
            {
                booster.SetActive(false);
            }
        }
        // if (x != 0 && y != 0)
        // {
        //     Vector3 lookTarget = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y);
        //     transform.LookAt(lookTarget);
        //     // Quaternion rot = Quaternion.AngleAxis(x * rotspeed, Vector3.up);
        //     // Quaternion q = this.transform.rotation;
        //     // // 合成して、自身に設定
        //     // this.transform.rotation = q * rot;
        // }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Hp -= 10;
            if (Hp <= 0)
            {
                slider.value = 0;
            }
            else
            {
                slider.value = Hp;
            }
        }
    }
}
