using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    [SerializeField] public string weaponName;
    [SerializeField] public float weaponDamage;
    [SerializeField] public float weaponRange;
    [SerializeField] public float armorPenetration;
    [SerializeField] public int magazine; // Current ammo in magazine
    [SerializeField] public int magazineSize; // Max ammo in magazine


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
