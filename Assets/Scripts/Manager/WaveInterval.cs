using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveInterval : MonoBehaviour
{
    string status = " ";
    int point = 0;
    int health = 0;
    int wave = 1;

    private Label nextWaveLabel;
    private Label pointLabel;

    void OnEnable(){
        var root = GetComponent<UIDocument>().rootVisualElement;
        nextWaveLabel = root.Q<Label>("Interval");
    }

    void Update(){
        CombatManager enemy = FindObjectOfType<CombatManager>();
        GameObject player = GameObject.Find("Player");
        health = player.GetComponent<HealthComponent>().Health;
        point = enemy.point;
        if(enemy.intervalWave && enemy.waveNumber < 1) IntervalWave("Start in ");
        else if(enemy.intervalWave && enemy.waveNumber > 0) IntervalWave("Next Wave in ");
        else nextWaveLabel.text = " ";
    }

    void IntervalWave(string text){
        nextWaveLabel.text = text + (int)(5 - FindObjectOfType<CombatManager>().timer) + " seconds";
    }
}