using UnityEngine;
using UnityEngine.Assertions;


public class EnemyClickSpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyVariants;
    [SerializeField] private int selectedVariant = 0;


    // Start is called before the first frame update
    void Start()
    {
       Assert.IsTrue(enemyVariants.Length > 0, "Tambahkan setidaknya 1 Prefab Enemy terlebih dahulu!");
    }


    private void Update(){
        for (int i = 1; i <= enemyVariants.Length; i++){
            if (Input.GetKeyDown(i.ToString())){
                selectedVariant = i - 1;
            }
        }


        if(Input.GetMouseButtonDown(1))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy(){
        if (selectedVariant < enemyVariants.Length){
            Instantiate(enemyVariants[selectedVariant]);
            //set position random
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            enemyVariants[selectedVariant].transform.position = new Vector2(Random.Range(min.x + (max.x - min.x) / 2, max.x), Random.Range(min.y + (max.y - min.y) / 2, max.y));
        }
    }


}
