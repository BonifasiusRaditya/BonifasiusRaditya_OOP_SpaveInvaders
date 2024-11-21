using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(HitboxComponent))]
public class InvincibilityComponent : MonoBehaviour
{
    [SerializeField] private int blinkingCount = 3;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Material blinkMaterial;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public bool isInvincible = false;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void SetBlinkMaterial(Material material){
        blinkMaterial = material;
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(gameObject.tag == "Player"){
            if (collision.gameObject.tag == gameObject.tag || collision.gameObject.tag != "Enemy")
                return;
            isInvincible = true;
            if(isInvincible) StartCoroutine(BlinkingEffect());
        }
        else{
            if (collision.gameObject.tag == gameObject.tag)
                return;
            isInvincible = true;
            if(isInvincible) StartCoroutine(BlinkingEffect());
        }
    }

    private IEnumerator BlinkingEffect(){
        for (int i = 0; i < blinkingCount; i++){
            spriteRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval);
            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(blinkInterval);
        }
        isInvincible = false;
    }
}