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
        if (clickToMove != null)
            clickToMove.enabled = false;
        else
            Debug.LogWarning("ClickToMove no encontrado en " + gameObject.name);

        playerCharacter = GetComponent<PlayerCharacter>();
        if (playerCharacter == null)
            Debug.LogWarning("PlayerCharacter no encontrado en " + gameObject.name);

        shooting = GetComponent<Shooting>();
        if (shooting != null)
            shooting.enabled = false;
        else
            Debug.LogWarning("Shooting no encontrado en " + gameObject.name);
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
            //shooting.Shoot(targetSelection.transform.position, 10f);
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
        TurnManager.Instance.CheckEndTurn();
    }
    
    public void FinishAttack()
    {
        hasActed = true;
        TurnManager.Instance.CheckEndTurn();
    }
    public void FinishAction()
    {
        hasActed = true;
        TurnManager.Instance.CheckEndTurn();
        
    }

}
