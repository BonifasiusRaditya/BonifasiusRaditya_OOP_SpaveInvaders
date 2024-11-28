using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Finish : MonoBehaviour
{
    string status = " ";
    int point = 0;
    int health = 0;
    int wave = 1;

    private Label statusLabel;
    private Label pointLabel;

    void OnEnable(){
        var root = GetComponent<UIDocument>().rootVisualElement;
        statusLabel = root.Q<Label>("Status");
        pointLabel = root.Q<Label>("Point");
    }

    void Update(){
        CombatManager enemy = FindObjectOfType<CombatManager>();
        GameObject player = GameObject.Find("Player");
        health = player.GetComponent<HealthComponent>().Health;
        point = enemy.point;
        if(health <= 0) GameOver();
        if(wave > 3) GameFinish();
    }

    void GameOver(){
        Debug.Log("Game Over");
        Time.timeScale = 0;
        statusLabel.text = "Game Over";
        pointLabel.text = point + " points";
    }

    void GameFinish(){
        Debug.Log("Game Finished");
        Time.timeScale = 0;
        statusLabel.text = "Finish!!";
        pointLabel.text = point + " points";
    }
}