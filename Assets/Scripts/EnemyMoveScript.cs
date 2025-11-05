using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 direct;
    private Rigidbody rigidbody;
    public float speed = 2f;
    public Slider slider;
    private float Hp = 100;
    public GameObject effect;
    private bool isground;
    private float rotSpan;
    private Vector3 lastPoj;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        direct = player.transform.position - transform.position;
        rigidbody = GetComponent<Rigidbody>();
        Serch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Hp > 0)
        {
            if (rotSpan <= 1)
            {
                rotSpan += Time.deltaTime / 3;
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                // 現在の回転情報と、ターゲット方向の回転情報を補完する
                transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, rotSpan);
            }
            rigidbody.AddForce(new Vector3(transform.forward.x * speed, 0, transform.forward.z * speed), ForceMode.Impulse);
        }
    }
    public GameObject sliderObj;
    public void GetDamage(float damage)
    {
        if (sliderObj.activeSelf == false)
        {
            sliderObj.SetActive(true);
        }
        Hp -= damage;
        if (Hp <= 0)
        {
            lastPoj = transform.position;
            slider.value = 0;
            rigidbody.constraints = RigidbodyConstraints.None;
            GameObject _effct = Instantiate(effect, transform.position, Quaternion.identity);
            _effct.transform.parent = transform;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce((transform.position.normalized * 5f + new Vector3(0, 2, 0)) * 2f, ForceMode.Impulse);
            Destroy(gameObject, 1f);
        }
        else
        {
            slider.value = Hp;
        }
        if (rigidbody.velocity.magnitude <= 0.1)
        {
            rigidbody.AddForce(new Vector3(-1*transform.forward.x * speed, 0, -1*transform.forward.z * speed), ForceMode.Impulse);
        }
    }
    private Vector3 relativePos;
    private void Serch()
    {
        rigidbody.velocity = Vector3.zero;
        direct = player.transform.position - transform.position;
        relativePos = player.transform.position - this.transform.position;
        rotSpan = 0;
        // 方向を、回転情報に変換
    }
    public List<GameObject> weapon;
    void OnDestroy()
    {
        int R = Random.Range(0, weapon.Count);
        Instantiate(weapon[R], lastPoj, Quaternion.identity);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "SerachRange")
        {
            Serch();
        }
    }
     void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Blade")
        {
            GetDamage(1f);
        }      
    }
}
