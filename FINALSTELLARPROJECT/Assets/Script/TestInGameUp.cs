using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInGameUp : MonoBehaviour
{
    // Start is called before the first frame update
    public float Exp;
    public GameObject UpMenu,ExWeapinBtn1;
    public int timer = 0;
    public bool ExWeapon1 = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Exp+=Time.deltaTime;
        if (Exp >= 10f)
        {
            UpMenu.SetActive(true);
            Time.timeScale = 0f;
            Exp = 0;
        }
        if (ExWeapon1 == false) { 
            ExWeapinBtn1.SetActive(true);
        }
        else
        {
            ExWeapinBtn1.SetActive(false);
        }
    }
    public void ExtraHp()
    {
        TestPlayer.InGameExHp += 100;
        TestPlayer.InGameMaxHp = TestPlayer.MaxHp + TestPlayer.ExHp + TestPlayer.InGameExHp;
        TestPlayer.Hp = TestPlayer.InGameMaxHp;
        UpMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void AddExWeapon1()
    {
        ExWeapinBtn1.SetActive(false);
        ExWeapon1 = true;
        TestPlayer.Exweapon = true;
        UpMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
