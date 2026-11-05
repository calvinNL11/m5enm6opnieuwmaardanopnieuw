using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class items : MonoBehaviour
{
    [SerializeField] private Image itemDisplay;

    private Movement playerMovement;
    private Shoot playerShoot;
    private Messages playerMessages;

    private List<Color> inventory = new List<Color>();
    private int selectedItem = -1;

    void Start()
    {
        playerMovement = GetComponent<Movement>();
        playerShoot = GetComponent<Shoot>();
        playerMessages = GetComponent<Messages>();

        itemDisplay.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SwitchItem();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateItem();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Item"))
            return;

        AddToInventory(collision.gameObject);
    }

    private void AddToInventory(GameObject pickup)
    {
        Renderer itemRenderer = pickup.GetComponent<Renderer>();
        Color pickedColor = itemRenderer.material.color;

        inventory.Add(pickedColor);
        selectedItem = inventory.Count - 1;

        Destroy(pickup);

        RefreshDisplay();
    }

    private void SwitchItem()
    {
        if (inventory.Count == 0)
        {
            selectedItem = -1;
            RefreshDisplay();
            return;
        }

        selectedItem++;

        if (selectedItem >= inventory.Count)
        {
            selectedItem = 0;
        }

        RefreshDisplay();
    }

    private void ActivateItem()
    {
        if (inventory.Count == 0 || selectedItem < 0)
            return;

        Color currentColor = inventory[selectedItem];

        if (currentColor == Color.blue)
        {
            playerMovement.moveSpeed += 5;
            StartCoroutine(playerMessages.ShowMessage(" + Move Speed"));
        }
        else if (currentColor == Color.red)
        {
            playerShoot.cooldownTime -= 0.1f;
            StartCoroutine(playerMessages.ShowMessage(" + Fire Rate"));
        }
        else if (currentColor == Color.green)
        {
            playerMovement.rotationSpeed += 20;
            StartCoroutine(playerMessages.ShowMessage(" + Rotation Speed"));
        }

        inventory.RemoveAt(selectedItem);

        if (inventory.Count == 0)
        {
            selectedItem = -1;
        }
        else
        {
            selectedItem = Mathf.Max(0, selectedItem - 1);
        }

        RefreshDisplay();
    }

    private void RefreshDisplay()
    {
        if (selectedItem == -1 || inventory.Count == 0)
        {
            itemDisplay.color = Color.white;
            itemDisplay.enabled = false;
            return;
        }

        itemDisplay.enabled = true;
        itemDisplay.color = inventory[selectedItem];
    }
}