using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewScore : MonoBehaviour
{
    public KigouList kigoulist = new KigouList();
    public BulletList bulletList = new BulletList();
    public Dictionary<string, GameObject> right_left = new Dictionary<string, GameObject>() { { "Right", null }, { "Left", null } };
    public GameObject item;
    public GameObject bulletl;
    private Score.Kigou _kigou;
    public GameObject Canvas;
    public List<GameObject> one_two;
    public List<Image> images;
    public Sprite sprite;
    // Update is called once per frame
    public void ItemGet(GameObject weapon, GameObject bullet, Score.Kigou kigou, Sprite ItemSprite)
    {
        Canvas.SetActive(true);
        sprite = ItemSprite;
        _kigou = kigou;
        if (weapon != null)
        {
            item = weapon;
            bulletl = null;
        }
        else
        {
            item = null;
            bulletl = bullet;
        }
        Time.timeScale = 0;
    }
    public void ItemR()
    {
        Time.timeScale = 1;
        if (item != null)
        {
            if (right_left != null)
            {
                Destroy(right_left["Right"]);
                right_left.Remove("Right");
                images[0].sprite = sprite;
            }
            GameObject weapon = Instantiate(item, one_two[0].gameObject.transform);
            GameObject test = bulletList.bullet_R;
            if (test == null)
            {
                test = firstbullet;
            }
            weapon.GetComponent<GunScript>().bullet = test;
            weapon.transform.localPosition = Vector3.zero;
            right_left["Right"] = weapon;
            kigoulist = new KigouList();
            kigoulist.weapon_Right = item;
            kigoulist.kigo_R = _kigou.ToString();
        }
        if (bulletl != null)
        {
            images[1].sprite = sprite;
            right_left["Right"].GetComponent<GunScript>().bullet = bulletl;
            bulletList = new BulletList();
            bulletList.bullet_R = bulletl;
            bulletList.Kigou_R = _kigou.ToString();
        }
    }
    public void ItemL()
    {
        Time.timeScale = 1;
        if (item != null)
        {
            images[2].sprite = sprite;
            if (right_left != null)
            {
                Destroy(right_left["Left"]);
                right_left.Remove("Left");
            }
            GameObject weapon = Instantiate(item, one_two[1].gameObject.transform);
            GameObject test = bulletList.bullet_L;
            if (test == null)
            {
                test = firstbullet;
            }
            weapon.GetComponent<GunScript>().bullet = test;
            weapon.transform.localPosition = Vector3.zero;
            right_left["Left"] = weapon;
            kigoulist = new KigouList();
            kigoulist.weapn_Left = item;
            kigoulist.kigo_L = _kigou.ToString();
        }

        if (bulletl != null)
        {
            images[3].sprite = sprite;
            right_left["Left"].GetComponent<GunScript>().bullet = bulletl;
            Debug.Log(right_left["Left"].name);
            bulletList = new BulletList();
            bulletList.bullet_L = bulletl;
            bulletList.Kigou_L = _kigou.ToString();
        }
    }
    public GameObject firstbullet;

}
public class KigouList
{
    public string kigo_R;
    public GameObject weapon_Right;
    public string kigo_L;
    public GameObject weapn_Left;

}
public class BulletList
{
    public string Kigou_L;
    public GameObject bullet_R;
    public string Kigou_R;
    public GameObject bullet_L;

}