using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField] string characterName;
    public bool hasActed = true;
    bool hasMoved = false;
    bool hasAttacked = false;
    public bool isFriendly;
    ClickToMove clickToMove;
    Shooting shooting;

    private void Awake()
    {
        clickToMove = GetComponent<ClickToMove>();
        clickToMove.enabled = false;
        shooting = GetComponent<Shooting>();
        shooting.enabled = false;
    }
    public void Run()
    {
        if (hasActed || hasMoved)
        {
            return;
        }


        if (isFriendly)
        {
            clickToMove.enabled = true;  
        }
        else
        {
            Debug.Log("Unidad enemiga corriendo");
        }
        Debug.Log(characterName + " usa la acción Correr ");
    }

    public void Attack()
    {
        if (hasActed || hasAttacked)
        {
            return;
        }
        
        if (!isFriendly)
        {
            shooting.enabled = true;
        }
        else
        {
            Debug.Log("Unidad enemiga atacando");
        }
        
        
        Debug.Log(characterName + " usa la acción atacar ");
        FinishAttack();
    }

    public void PassTurn()
    {
        if (hasActed)
        { 
            return;
        }
        Debug.Log(characterName + " no usa ninguna acción y pasa el turno ");
        FinishAction();

    }
    public void StartTurnForThisUnit()
    {
        hasActed = false;
        hasAttacked = false;
        hasMoved = false;
    }

    public void FinishMovement()
    {
        clickToMove.enabled = false;
        hasActed = true;
    }
    
    public void FinishAttack()
    {
        hasActed = true;
    }
    public void FinishAction()
    {
        hasActed = true;
        TurnManager.Instance.CheckEndTurn();
    }
}
