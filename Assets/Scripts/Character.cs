using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character main")]
    [SerializeField] string characterName;
    protected int level; //protected funciona como private pero permite acceso a clases derivadas
    [Header("Character Stats")]
    float currtentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] float baseAttackDamage;
    [SerializeField] protected float armorValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        name = gameObject.name;
        currtentHealth = maxHealth;
        baseAttackDamage = 10f;
        armorValue = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void TakeDamage(float damageAmount)
    {
        float finalDamage = damageAmount - armorValue;
        currtentHealth -= damageAmount;
        IsAlive();
    }

    

    void IsAlive()
    {
        if(currtentHealth <= 0)
        {
            Debug.Log(characterName + " has died.");
            Destroy(gameObject);
        }
    }
}
