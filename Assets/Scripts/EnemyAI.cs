using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Units))]
[RequireComponent(typeof(Shooting))]

public class EnemyAI : MonoBehaviour
{
    private Units units;
    private Shooting shooting;
    [SerializeField]  float visionRange = 10f;
    private float attackRange;
    void Awake()
    {
        units = GetComponent<Units>();
        shooting = GetComponent<Shooting>();
    }

    void Update()
    {
        if(units.isFriendly)
        {
            return;
        }
        if(TurnManager.instance.isPlayerTurn)
        {
            //unit.hasActed = true;
            return;
        }
        if(!units.hasActed)
        {
            // Lógica simple de IA: buscar la unidad enemiga más cercana y disparar si está en línea de visión
            StartCoroutine(DoEnemyTurn());
        }
    }


    private IEnumerator DoEnemyTurn()
    {
        Units target = FindClosestPlayerUnit();
        if (target == null)
        {
            Debug.Log(units.characterName + ": No player units found, skipping turn.");
            units.FinishAction();
            yield break;
        }

        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToTarget <= attackRange && hasLineOfSight(target))
        {
           yield return AttackTarget(target);  
        }

    }


    private bool hasLineOfSight(Units target)
    {
        return shooting.isOnLoS(target.transform.position, attackRange);
    }


    private IEnumerator AttackTarget(Units target)
    {
        shooting.Shoot(target.transform.position, attackRange);
        units.hasActed = true;
        yield return new WaitForSeconds(1f); // Espera 1 segundo para simular el tiempo de ataque
    }


    
    private Units FindClosestPlayerUnit()
    {
      Units closest= null;
      float closestDistance = Mathf.Infinity;
      foreach(Units playerUnit in TurnManager.instance.playerUnits)
      {
        float distance = Vector3.Distance(transform.position, playerUnit.transform.position);
        if(distance < closestDistance && distance <= visionRange)
        {
            closestDistance = distance;
            closest = playerUnit;
        }
      }       
      return closest;
    }
}