using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMenu : MonoBehaviour
{
    public static int easy=0,normal=1,hard=0,moreCoin,moreExp;
    public static float EnemyHp,EnemyAtk,SpwanChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(easy==1){
            EnemyHp=-100;EnemyAtk=-50;SpwanChange=-20;moreCoin=100;moreExp=50;
        }else if(normal==1){
            EnemyHp=0;EnemyAtk=0;SpwanChange=0;moreCoin=0;moreExp=0;
        }else if(hard==1){
            EnemyHp=200;EnemyAtk=100;SpwanChange=50;moreCoin=-20;moreExp=-5;
        }
    }
    public void chooseEasy(){
        easy=1;normal=0;hard=0;
        PlayerPrefs.SetInt("easy",easy);
        PlayerPrefs.SetInt("normal",normal);
        PlayerPrefs.SetInt("hard",hard);
    }
    public void chooseNormal(){
        easy=0;normal=1;hard=0;
        PlayerPrefs.SetInt("easy",easy);
        PlayerPrefs.SetInt("normal",normal);
        PlayerPrefs.SetInt("hard",hard);
    }
    public void chooseHard(){
        easy=0;normal=0;hard=1;
        PlayerPrefs.SetInt("easy",easy);
        PlayerPrefs.SetInt("normal",normal);
        PlayerPrefs.SetInt("hard",hard);
    }
}