using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder; 
    Weapon weapon; 

    void Awake(){
        weapon = Instantiate(weaponHolder, transform.position, transform.rotation); 
    }

    void Start(){
        if (weapon != null) TurnVisual(false, weapon);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(!other.CompareTag("Player") || weapon == null) return;
        Debug.Log("Weapon has ben picked up");

        Weapon PickUpWeapon = other.GetComponentInChildren<Weapon>();
        if (PickUpWeapon != null) PickUpWeapon.gameObject.SetActive(false);

        Weapon newWeapon = Instantiate(weapon, other.transform.position, Quaternion.identity);
        newWeapon.transform.SetParent(other.transform);
        newWeapon.transform.localPosition = new Vector3(0, 0, 1);
        newWeapon.gameObject.SetActive(true);
    }

    
    void TurnVisual(bool on){
        weapon.gameObject.SetActive(on);
    }

    void TurnVisual(bool on, Weapon weapon){
        weapon.gameObject.SetActive(on);
    }
}