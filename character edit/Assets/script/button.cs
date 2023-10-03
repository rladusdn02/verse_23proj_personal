using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject[] hairs;
    public bool[] hasHairs;
    

    bool sDown1;
    bool sDown2;
    bool sDown3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swap();
    }

    void GetInput(){
        sDown1=Input.GetButtonDown("Swap1");
        sDown2=Input.GetButtonDown("Swap2");
        sDown3=Input.GetButtonDown("Swap3");
    }
    void Swap(){
        int hairIndex=-1;
        if (sDown1) hairIndex = 0;
        if (sDown2) hairIndex = 1;
        if (sDown3) hairIndex = 2;

        if((sDown1 || sDown2 || sDown3)){
            hairIndex[hairIndex].setActive(true);
        }
    }
}
