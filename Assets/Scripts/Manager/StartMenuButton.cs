using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuButton : MonoBehaviour
{
    void Start(){
        
    }

    // Update is called once per frame
    public void Update(){
        StartGame();
    }

    public void StartGame(){
        if(Input.anyKeyDown) gameObject.SetActive(false);
    }




}
