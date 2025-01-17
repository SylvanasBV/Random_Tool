
using UnityEngine;

public class ÏnventoryController : MonoBehaviour
{
    [SerializeField]
    private UIInventoryPage inventoryUI;
    public int inventorySize = 9;

    private void Start()
    {
        inventoryUI.InitilizeInventoryUI(inventorySize);
    }



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }


}
