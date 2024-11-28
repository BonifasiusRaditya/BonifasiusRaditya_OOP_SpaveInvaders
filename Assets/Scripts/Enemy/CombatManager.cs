using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float interval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;
    public int point = 0;
    public bool intervalWave = false;

    private void Update(){
        if(totalEnemies <= 0 || waveNumber == 0){
            timer += Time.deltaTime;
            intervalWave = true;
            if(timer >= interval){
                NewWave();
                intervalWave = false;
            }
        }
    }

    private void NewWave(){
        timer = 0;
        waveNumber++;
        totalEnemies = 0;
        foreach(EnemySpawner spawner in enemySpawners){
            spawner.Begin();
        }
    }

    public void getKilled(){
        totalEnemies--;
    }
}