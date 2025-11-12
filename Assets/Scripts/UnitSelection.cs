using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public static UnitSelection Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (TurnManager.Instance.isPlayerTurn)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Units units = hit.collider.GetComponent<Units>();
                if (units != null && units.isFriendly && !units.hasActed)
                {
                    SelectUnit();
                    Debug.Log("soy una unidad");
                }
                else Debug.Log("no soy una unidad");
            }
        }
    }
    
    private void SelectUnit()
    {
        throw new System.NotImplementedException();
        // Implement unit selection logic here
    }
}
