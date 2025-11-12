using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance; //singleton para acceder al TurnManager desde otras clases
    public bool isPlayerTurn = true; //empieza el turno del jugador al comienzo del juego
    public List<Units> enemyUnits = new List<Units>(); //lista de unidades enemigas
    public List<Units> playerUnits = new List<Units>(); //lista de unidades del jugador

    private void Awake()
    {
        Instance = this;
        // Aquí podrías inicializar las listas de unidades si no lo has hecho en el editor
        // Por ejemplo, encontrando todas las unidades en la escena y clasificándolas
    }

    void Start()
    {
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        isPlayerTurn = true;
        ResetUnits(playerUnits);
        Debug.Log("Player's Turn Started");
    }

    private void StartEnemyTurn()
    {
        isPlayerTurn = false;
        ResetUnits(enemyUnits);
        Debug.Log("Enemy's Turn Started");
    }
    private void ResetUnits(List<Units> units)
    {
        foreach (Units unit in units)
        {
            unit.hasActed = false;
            // Aquí puedes resetear el estado de cada unidad para el nuevo turno
            // Por ejemplo, restablecer puntos de acción, mover estado, etc.
        }

    }

    bool AllUnitsActed(List<Units> units)
    {
        foreach (var u in units) //var u representa cada unidad en la lista units //también se puede usar Units u
        {
            if (!u.hasActed)
            {
                
                return false;
            }
        }
        return true;
    }

    public void CheckEndTurn()
    {
        if (isPlayerTurn)
        {
            if (AllUnitsActed(playerUnits)) //si todas las unidades del jugador han actuado
                StartEnemyTurn();
        }
        else
        {
            if (AllUnitsActed(enemyUnits)) //si todas las unidades enemigas han actuado
                StartPlayerTurn();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
