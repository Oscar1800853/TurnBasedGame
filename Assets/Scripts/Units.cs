using UnityEngine;

public class Units : MonoBehaviour
{
    [SerializeField] public string characterName;
    public bool hasActed = true;
    public bool hasMoved = false;
    bool hasAttacked = false;
    public bool isFriendly;
    ClickToMove clickToMove;
    Shooting shooting;
    GameObject targetSelection;
    PlayerCharacter playerCharacter;

    private void Awake()
    {
        clickToMove = GetComponent<ClickToMove>();
        clickToMove.enabled = false;
        playerCharacter = GetComponent<PlayerCharacter>();

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
            playerCharacter.targetSelectionPanel.SetActive(true);
            shooting.enabled = true;
            shooting.Shoot(targetSelection.transform.position, 10f);
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
        playerCharacter.targetSelectionPanel.SetActive(false);
        hasActed = true;

    }
    public void FinishAction()
    {
        hasActed = true;
        TurnManager.Instance.CheckEndTurn();
        
    }

}
