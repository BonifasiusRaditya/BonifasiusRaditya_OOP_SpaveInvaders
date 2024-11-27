using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DisplayStatus : MonoBehaviour
{
    public int point = 0;
    public int health = 0;
    public int wave = 1;
    public int enemiesLeft = 0;

    private Label pointLabel;
    private Label healthLabel;
    private Label waveLabel;
    private Label enemiesLeftLabel;

    void OnEnable()
    {
        // Get the root VisualElement from the UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Query each Label by its name
        pointLabel = root.Q<Label>("Points");
        healthLabel = root.Q<Label>("Health");
        waveLabel = root.Q<Label>("Wave");
        enemiesLeftLabel = root.Q<Label>("TotalEnemies");
    }

    void Update()
    {
        CombatManager enemy = FindObjectOfType<CombatManager>();
        if (enemy != null)
        {
            GameObject player = GameObject.Find("Player");
            point = enemy.point;
            health = player.GetComponent<HealthComponent>().Health;
            wave = enemy.waveNumber;
            enemiesLeft = enemy.totalEnemies;

            // Update the UI Labels dynamically
            pointLabel.text = "Points: " + point;
            healthLabel.text = "Health: " + health;
            waveLabel.text = "Wave: " + wave;
            enemiesLeftLabel.text = "Enemies Left: " + enemiesLeft;
        }
    }
}