using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        Player hp2 = hit.GetComponent<Player>();
        if (hp2 != null)
        {
            Player.Hp=0;
        }
    }
}
