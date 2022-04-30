using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InventoryScreen inventoryScreen; // Fardeen - Inventory

    private bool isMoving;
    private Vector2 input;
    const float offsetY = 0.3f;
    private Character character;
    private InventoryController inventory; // Fardeen - Inventory
    private GameObject screenDisplay;
    public specimen2 spec;
    SpriteRenderer spriteRenderer;


    public void Awake()
    {
        character = GetComponent<Character>();
        inventory = new InventoryController(); // Fardeen - Inventory
        inventoryScreen.SetInventory(inventory);
        screenDisplay = GameObject.Find("InventoryScreen");
    }
    private void Start()
    {
        spec.LoadPlayer();
        screenDisplay.SetActive(false);
        inventory.Load();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // void Update(){
    //     Debug.Log(character.IsMoving);
    // }

    // public void HandleUpdate()
    // {
    //     if (!character.IsMoving)
    //     {
    //         input.x = Input.GetAxisRaw("Horizontal");
    //         input.y = Input.GetAxisRaw("Vertical");

    //         if (input.x != 0)
    //         {
    //             input.y = 0;
    //         }

    //         if (input != Vector2.zero)
    //         {
    //             StartCoroutine(character.Move(input, OnMoveOver));
    //         }
    //     }

    //     if (Input.GetKeyDown("i")) // Fardeen - Inventory button
    //     {
    //         screenDisplay.SetActive(!screenDisplay.activeSelf);
    //     }

    //     character.HandleUpdate();

    // }

    void Update(){
        Vector2 position = transform.position;
        position.x += 5 * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        position.y += 5 * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        transform.position = position;
        if (Input.GetKeyDown("i")) // Fardeen - Inventory button
        {
            screenDisplay.SetActive(!screenDisplay.activeSelf);
        }
        /*if(spec.getLevel() == 2)
        {
            transform.localScale = new Vector3(2.0f, 2.0f, 0.0f);
        }
        else if(spec.getLevel() == 3)
        {
            transform.localScale = new Vector3(3.0f, 3.0f, 0.0f);
        }*/
        if (spec.getLevel() == 2)
        {
            spriteRenderer.color = Color.red;
        }
        else if (spec.getLevel() == 3)
        {
            spriteRenderer.color = Color.yellow;
        }
    }

    private void OnMoveOver()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, offsetY), 0.2f, GameLayers.i.TriggerableLayers);

        foreach (var collider in colliders)
        {
            var triggerable = collider.GetComponent<IPlayerTriggerable>();
            if (triggerable != null)
            {
                triggerable.OnPlayerTriggered(this);
                break;
            }
        }
    }
}
