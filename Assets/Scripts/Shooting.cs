using UnityEngine;

public class Shooting : MonoBehaviour
{

    public void Shoot()
    {
        isOnLoS();
    }

    bool isOnLoS(Vector3 enemyPosition, float weaponRange)
    {
        bool isLos;

        if (Physics.Raycast(transform.position, enemyTransform.position, out hit, 1000f))
        {
            Character character = hit.collider.GetComponent<Character>();

                if (character != null)
                {
                    return true;
                }
                else
                {
                   
                }
        }
        return false;
    }


}
