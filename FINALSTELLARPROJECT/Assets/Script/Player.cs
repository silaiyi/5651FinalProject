using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float MaxHp = 3000;
    public static float InGameMaxHp, Hp,TotalDef,def=100,TotalDamege;
    public float seeHp;
    public Animator anim;
    public int speed = 10;
    public static int walkspeed = 10;
    public static bool atktype1 = true, atktype2 = false, atktype3 = false, atktype4 = false, atktype5 = false, atktype6 = false;
    public bool cango = false;
    public int attackNum = 2;//
    public float restTime = 0.3f;//
    public static float pistolTime=0.5f,bolterTime=1f;
    public float timer;//
    public float currentTime;
    public int currentAttack = 0;
    List<string> attackAnimList = new List<string>(new string[] { "ESwordAtk1"});
    public float BloterCD=5f,RocketCD=10f,jumpCD=3f;
    public GameObject PistolFrontSight,BolterFrontSight,Drone1,Drone2,energyS;

    // Start is called before the first frame update
    void Start()
    {
        InGameMaxHp = MaxHp + BankShop.ShopExHp + InGameUpdate.InGameExHp;
        Hp = InGameMaxHp;
        atktype1=true;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        anim.SetBool("PlayerToESword",true);
    }
    // Update is called once per frame
    void Update()
    {
        TypeContro();
        InGameMaxHp = MaxHp + BankShop.ShopExHp + InGameUpdate.InGameExHp;
        TotalDef=def+BankShop.ShopDef+InGameUpdate.InGameDef;
        seeHp = Hp;
        BloterCD += Time.deltaTime;
        RocketCD += Time.deltaTime;
        DroneOn();
        if(InGameUpdate.LegJumpOn==true){
            //walkspeed=25;
            if(Input.GetKeyDown(KeyCode.Space)&&jumpCD-3f>=0){
                transform.Translate(0, walkspeed * Time.deltaTime, 0);
                jumpCD=0f;
            }
        }else if(InGameUpdate.LegSpeedOn==true){
            walkspeed=25;
        }else if(InGameUpdate.LegEnergyOn==true){
            energyS.SetActive(true);
        }
    }
    void DroneOn(){
        if(InGameUpdate.DroneON==true){
            Drone1.SetActive(true);
            Drone2.SetActive(true);
        }else{
            Drone1.SetActive(false);
            Drone2.SetActive(false);
        }
    }
    void TypeContro(){
        ChangeToType1();
        ChangeToType2();
        ChangeToType3();
        //ChangeToType4();
        //ChangeToType5();
        //ChangeToType6();
        if(BankShop.UnlockLaser==1){
            ChangeToType4();
        }
        if(BankShop.UnlockHeavy==1){
            ChangeToType5();
        }
        if(BankShop.UnlockRocket==1){
            ChangeToType6();
        }
        if (atktype1 == true)
        {
            ESwordMoveMent();
            PistolFrontSight.SetActive(false);
            BolterFrontSight.SetActive(false);
        }
        else if (atktype2 == true)
        {
            PistolMoveMent();
            PistolFrontSight.SetActive(true);
            BolterFrontSight.SetActive(false);
        }
        else if (atktype3 == true) { 
            BolterMoveMent();
            PistolFrontSight.SetActive(false);
            BolterFrontSight.SetActive(true);
        }else if(atktype4 == true){
            EGunMoveMent();
            PistolFrontSight.SetActive(true);
            BolterFrontSight.SetActive(false);
        }else if(atktype5 == true){
            HeavyMoveMent();
            PistolFrontSight.SetActive(true);
            BolterFrontSight.SetActive(false);
        }else if(atktype6 == true){
            RocketMoveMent();
            PistolFrontSight.SetActive(true);
            BolterFrontSight.SetActive(false);
        }
    }

    void ESwordMoveMent()
    {
        if(Input.GetMouseButton(0)){
            anim.Play(attackAnimList[0]);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
            anim.Play("ESwordWalk");
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
                anim.Play("ESwordWalk");
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
                anim.Play("ESwordWalk");
            }else if(Input.GetMouseButton(0)){
            anim.Play(attackAnimList[0]);
        }
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            anim.Play("ESwordWalk");
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            anim.Play("ESwordWalk");
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkspeed * Time.deltaTime);
            anim.Play("ESwordWalk");
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
                anim.Play("ESwordWalk");
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
                anim.Play("ESwordWalk");
            }
        }
    }
    void PistolMoveMent()
    {
        if(Input.GetMouseButtonDown(0)){
            anim.Play("PistolAtk");
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
            //anim.Play("PistolWalk");
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
                //anim.Play("PistolWalk");
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
                //anim.Play("PistolWalk");
            }else if(Input.GetMouseButtonDown(0)){
            anim.Play("PistolAtk");
            }
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            //anim.Play("PistolWalk");
            if(Input.GetMouseButtonDown(0)){
            anim.Play("PistolAtk");
            }
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            //anim.Play("PistolWalk");
            if(Input.GetMouseButtonDown(0)){
            anim.Play("PistolAtk");
            }
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkspeed * Time.deltaTime);
            //anim.Play("PistolWalk");
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
                //anim.Play("PistolWalk");
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
                //anim.Play("PistolWalk");
            }else
            if(Input.GetMouseButtonDown(0)){
            anim.Play("PistolAtk");
            }
        }
    }
    void BolterMoveMent()
    {
        if(Input.GetMouseButtonDown(0)){
            //anim.Play("BolterAtk");
            //anim.SetTrigger("BolterAttack");
            if(BloterCD - 5f >= 0)
            {
                //anim.Play("BolterAtk");
                anim.SetTrigger("BolterAttack");
                Debug.Log("BolterAttack");
                BloterCD=0;
            }
        }else
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(walkspeed * Time.deltaTime, 0, 0);
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }
        }
    }
    void EGunMoveMent(){
        if(Input.GetMouseButtonDown(0)){
            anim.Play("EgunAtk");
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }else if(Input.GetMouseButtonDown(0)){
            anim.Play("EgunAtk");
            }
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            if(Input.GetMouseButtonDown(0)){
            anim.Play("EgunAtk");
            }
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            if(Input.GetMouseButtonDown(0)){
            anim.Play("EgunAtk");
            }
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }else
            if(Input.GetMouseButtonDown(0)){
            anim.Play("EgunAtk");
            }
        }
    }
    void HeavyMoveMent(){
        if(Input.GetMouseButtonDown(0)){
            anim.Play("HeavyAtk");            
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }else if(Input.GetMouseButtonDown(0)){
            anim.Play("HeavyAtk");
            }
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            if(Input.GetMouseButtonDown(0)){
            anim.Play("HeavyAtk");
            }
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            if(Input.GetMouseButtonDown(0)){
            anim.Play("HeavyAtk");
            }
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }else
            if(Input.GetMouseButtonDown(0)){
            anim.Play("HeavyAtk");
            }
        }
    }
    void RocketMoveMent(){
        if(Input.GetMouseButtonDown(0)){
            //anim.Play("RocketAtk");
            if(RocketCD - 10f >= 0)
            {
                anim.Play("RocketAtk");
                RocketCD=0;
            }
        }else
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(walkspeed * Time.deltaTime, 0, 0);
        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -walkspeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-walkspeed * Time.deltaTime, 0, 0);
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(walkspeed * Time.deltaTime, 0, 0);
            }
        }
    }
    public void TakeDamege(float GetDamage){
        TotalDamege = GetDamage - TotalDef;
        if(TotalDamege<0){
            TotalDamege=10;
        }
        if(Hp>0){
            if(TotalDamege>0){
                Hp-=TotalDamege;
            }
        }else{
            
        }
    }

    void ChangeToType1(){//能量劍
        if (Input.GetKeyDown(KeyCode.Alpha1)&&atktype1==false&&atktype2==true&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToESword",true);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("BolterToESword",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            //anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=true;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)&&atktype1==false&&atktype2==false&&atktype3==true&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",true);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=true;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==true&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",true);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=true;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==true&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",true);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=true;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==true)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",true);            
            atktype1=true;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
    }
    void ChangeToType2(){//手槍
        if (Input.GetKeyDown(KeyCode.Alpha2)&&atktype1==true&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("PistolToESword",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("BolterToESword",false);
            anim.SetBool("ESwordToPistol",true);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            //anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=true;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&atktype1==false&&atktype2==false&&atktype3==true&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",true);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            //anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=true;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==true&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",true);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=true;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==true&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",true);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=true;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==true)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",true);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=true;atktype3=false;atktype4=false;atktype5=false;atktype6=false;
        }        
    }
    void ChangeToType3(){//爆彈槍
        if (Input.GetKeyDown(KeyCode.Alpha3)&&atktype1==true&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("PistolToESword",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("BolterToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",true);
            anim.SetBool("PistolToBolter",false);//
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=true;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&atktype1==false&&atktype2==true&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",true);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=true;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==true&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",true);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=true;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==true&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",true);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=true;atktype4=false;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==true)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",true);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=true;atktype4=false;atktype5=false;atktype6=false;
        }  
    }
    void ChangeToType4(){//能量槍
        if (Input.GetKeyDown(KeyCode.Alpha4)&&atktype1==true&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("PistolToESword",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("BolterToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);//
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",true);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=true;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&&atktype1==false&&atktype2==true&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",true);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=true;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&&atktype1==false&&atktype2==false&&atktype3==true&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",true);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=true;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==true&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",true);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=false;atktype4=true;atktype5=false;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==true)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",true);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=false;atktype4=true;atktype5=false;atktype6=false;
        }          
    }
    void ChangeToType5(){//機關槍
        if (Input.GetKeyDown(KeyCode.Alpha5)&&atktype1==false&&atktype2==true&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("PistolToESword",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("BolterToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);//
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",true);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=true;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)&&atktype1==false&&atktype2==false&&atktype3==true&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",true);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=true;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==true&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",true);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=true;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)&&atktype1==true&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",true);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=true;atktype6=false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==true)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",true);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=true;atktype6=false;
        }        
    }
    void ChangeToType6(){//火箭炮
        if (Input.GetKeyDown(KeyCode.Alpha6)&&atktype1==false&&atktype2==true&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("PistolToESword",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("BolterToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);//
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",true);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)&&atktype1==false&&atktype2==false&&atktype3==true&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",true);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==true&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",true);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)&&atktype1==false&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==true&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",true);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",false);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)&&atktype1==true&&atktype2==false&&atktype3==false&&atktype4==false&&atktype5==false&&atktype6==false)
        {
            anim.SetBool("BolterToESword",false);
            anim.SetBool("PistolToESword",false);
            anim.SetBool("ESwordToPistol",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("ESwordToBolter",false);
            anim.SetBool("PistolToBolter",false);
            anim.SetBool("PlayerToESword",false);
            anim.SetBool("RocketToEgun",false);
            anim.SetBool("RocketToHeavy",false);
            anim.SetBool("EgunToRocket",false);
            anim.SetBool("BolterToPistol",false);
            anim.SetBool("EgunToHeavy",false);
            anim.SetBool("HeavyToEgun",false);
            anim.SetBool("HeavyToRocket",false);
            anim.SetBool("EgunToESword",false);
            anim.SetBool("EgunToPistol",false);
            anim.SetBool("EgunToBolter",false);
            anim.SetBool("ESwordToEgun",false);
            anim.SetBool("PistolToEgun",false);
            anim.SetBool("BolterToEgun",false);
            anim.SetBool("PistolToHeavy",false);
            anim.SetBool("PistolToRocket",false);
            anim.SetBool("BolterToRocket",false);
            anim.SetBool("BolterToHeavy",false);
            anim.SetBool("ESwordToRocket",true);
            anim.SetBool("ESwordToHeavy",false);
            anim.SetBool("HeavyToESword",false);
            anim.SetBool("HeavyToBolter",false);
            anim.SetBool("HeavyToPistol",false);
            anim.SetBool("RocketToPistol",false);
            anim.SetBool("RocketToBolter",false);
            anim.SetBool("RocketToESword",false);            
            atktype1=false;atktype2=false;atktype3=false;atktype4=false;atktype5=false;atktype6=true;
        }
    }
}
