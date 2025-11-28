using UnityEngine;

public class TargetSelectionAttack : MonoBehaviour
{
    [SerializeField] GameObject target_1;
    [SerializeField] GameObject target_2;
    [SerializeField] GameObject characterShooting;
    Shooting shooting;

    private void Awake()
    {
        shooting = characterShooting.GetComponent<Shooting>();
    }

    public void ShootTarget1()
    {
        Debug.Log("detectando al objetivo 1");
        shooting.Shoot(target_1.transform.position,shooting.weapon.weaponRange);
    }   
    

    public void ShootTarget2()
    {
        Debug.Log("detectando al objetivo 2");
        shooting.Shoot(target_2.transform.position,shooting.weapon.weaponRange);

    }   

}
