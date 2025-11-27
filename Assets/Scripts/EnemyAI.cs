using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Units))]
[RequireComponent(typeof(Shooting))]

public class EnemyAI : MonoBehaviour
{
    private Units units;
    private Shooting shooting;
    [SerializeField]  float visionRange = 10f;
    [SerializeField] float attackRange = 5f;
    UnityEngine.AI.NavMeshAgent agent;
    
    void Awake()
    {
        units = GetComponent<Units>();
        shooting = GetComponent<Shooting>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(units.isFriendly)
        {
            return;
        }
        if(TurnManager.Instance.isPlayerTurn)
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

        //1. Si no detecta ningun jugador cerca, termina el turno

        if (target == null)
        {
            Debug.Log(units.characterName + ": No player units found, skipping turn.");
            units.FinishAction();
            yield break;
        }

        //2. Esta en la linea de vision y en rango de ataque

        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        
        if (distanceToTarget <= attackRange && hasLineOfSight(target))
        {
           yield return AttackTarget(target);  
        }
        else //3. Muevo al personaje para que este cerca para atacar o dentro de la linea de vision
        {
            yield return MoveTowardsTarget(target.transform.position);

            //4.Vuelvo  a disparar al personaje

            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        
            if (distanceToTarget <= attackRange && hasLineOfSight(target))
            {
                yield return AttackTarget(target);  
            }
        }

    }


    private bool hasLineOfSight(Units target)
    {
        return shooting.isOnLoS(target.transform.position, attackRange);
    }


    private IEnumerator AttackTarget(Units target)
    {
        Debug.Log(units.characterName + " is attacking " + target.characterName);

        Vector3 lookDirection = target.transform.position - transform.position;
        lookDirection.y = 0;
        if(lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        shooting.Shoot(target.transform.position, attackRange);
        units.hasActed = true;

        yield return new WaitForSeconds(1f); // Espera 1 segundo para simular el tiempo de ataque
        
    }

    private IEnumerator MoveTowardsTarget(Vector3 targetPosition)
    {
        Debug.Log(units.characterName + " is moving towards target.");

        agent.destination = targetPosition;
        yield return new WaitForSeconds(5); // Espera 5 segundos para simular el tiempo de movimiento
        units.FinishMovement();

    }


    
    private Units FindClosestPlayerUnit()
    {
      Units closest= null;
      float closestDistance = Mathf.Infinity;
      foreach(Units playerUnit in TurnManager.Instance.playerUnits)
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
