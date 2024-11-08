using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Awake(){
        animator.enabled = false;
    }

    public void LoadScene(string sceneName){
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName){
        animator.enabled = true;
        animator.SetTrigger("EndTransition");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
        animator.SetTrigger("StartTransition");
        Player.Instance.transform.position = new Vector3(0, -4.5f, 0);
    }
}