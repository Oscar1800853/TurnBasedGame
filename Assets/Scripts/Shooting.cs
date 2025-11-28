using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem; // Particle system for shooting effect
    public Weapon weapon; // Weapon used for shooting
    PlayerCharacter playerCharacter;
    Character character;
     // Reference to the character component

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
        if (character == null)
        {
            Debug.LogWarning("Character component not found on " + gameObject.name);
        }
    }
    public void Shoot(Vector3 enemyPosition, float weaponRange) // Method to shoot at an enemy
    {
        Debug.Log("Llego aqui");

        if (isOnLoS(enemyPosition, weaponRange)) // Check line of sight
        {
            //GetComponent<ParticleSystem>().Play(); // Play shooting effect 
            Debug.Log("Enemigo en linea de tiro");
        }
        else
        {
            Debug.Log("Enemigo no está en linea de tiro");
        }
    }

    public bool isOnLoS(Vector3 enemyPosition, float weaponRange) // Check if enemy is in line of sight
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, enemyPosition, out hit, weaponRange))
        {
            Character character = hit.collider.GetComponent<Character>();

                if (character != null)
                {
                    return true;
                }
        }
        return false;
    }


}
