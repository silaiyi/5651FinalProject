using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public const int MaxHp=3000;
    public static int ExHp = 0,InGameExHp=0,InGameMaxHp,Hp;
    public int seeHp;
    public Animator anim;
    public int speed = 10;
    public int walkspeed = 5;
    public int currentAttack = 0;//
    public int attackNum = 3;//
    public float restTime = 0.1f;//
    private float timer;//
    public static bool atktype1 = true, atktype2 = false,Exweapon = false;
    public GameObject testGun,testExWeapon;
    
    void Start()
    {
        InGameMaxHp = MaxHp + ExHp + InGameExHp;
        Hp = InGameMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        seeHp = InGameMaxHp;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            atktype1 = true;
            atktype2 = false;
            //anim.Play("testct1");
            anim.SetBool("type1",true);
            anim.SetBool("type2", false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))    
        {
            atktype1 = false;
            atktype2 = true;
            //anim.Play("testct2");
            anim.SetBool("type2", true);
            anim.SetBool("type1", false);
        }
        if (atktype1 == true)
        {
            //anim.Play("testIdle");
            Attack();
            Walk();
        }
        if (atktype2 == true)
        {
            //anim.Play("testatk2");
            AttackType2();
            Walk();
        }
        if (Exweapon == false) { 
            testExWeapon.SetActive(false);
        }
        else
        {
            testExWeapon.SetActive(true);
        }
    }
    void Attack()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("testatk");
        }*/
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.Play("testatk");
        }
    }
    void AttackType2()
    {
        if (Input.GetKey(KeyCode.J))
        {
            //anim.Play("testatk");
            //Debug.Log("Shooting");
            timer += Time.deltaTime;
            //timer++;
        }
        if (timer >= restTime)
        {
            timer = 0;
            Debug.Log("Shooting");
        }
    }
    void Walk()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
            anim.Play("tesWalk");
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * speed);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walkspeed = 10;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walkspeed = 5;
            }



        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * speed);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * speed);
            }
        }
        else
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * speed);
        }
        else
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }

    }
}
