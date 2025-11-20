using UnityEngine;

public class Shooting : MonoBehaviour
{

    public void Shoot(Vector3 enemyPosition, float weaponRange) // Method to shoot at an enemy
    {
        if (isOnLoS(enemyPosition, weaponRange)) // Check line of sight
        {
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
