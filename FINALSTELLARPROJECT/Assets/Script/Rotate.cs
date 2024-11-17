using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public int roz = 2000;
    public int roy = 0;
    public int rox = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rox * Time.deltaTime, roy * Time.deltaTime, roz * Time.deltaTime);
    }
}
