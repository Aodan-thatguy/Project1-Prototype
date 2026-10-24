using UnityEngine;
using System.Collections.Generic;
using System.Data;
public class Cards : MonoBehaviour, IClickable, IHoldable
{
    
    public int CardID = 0;
    //0 Saboteur, 1 Eyrie Emirge, 2 False Orders, 3 Root Tea, 4 Tunneling
    [SerializeField] private bool ItemCard;
    [SerializeField] private float CraftedPlacement;
    public int SuitID = 0;
    //0 Fox, 1 Mouse, 2 Rabbit, 3 Bird
    public int[] CardCost;
    //First int is suit 0 Fox, 1 Mouse, 2 Rabbit, 3 Bird
    //Second int is amount 
    private GameManager GM;

    private Vector3 originalPosition;
    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Clicked ()
    {
        int paid = 0;
        Debug.Log("Card Clicked");
        int[] SafeKeeping = GM.SuitsObtained;
        for (int i = 0; i < GM.SuitsObtained.Length; i++)
        {
            if(GM.SuitsObtained[i] == CardCost[0] || CardCost[0] == 3)
            {
                GM.SpendSuit(i);
                int[] newArray = new int[GM.SuitsObtained.Length - 1];
                for (int j = 0; j < i; j++)
                {
                    newArray[j] = GM.SuitsObtained[j];
                }

                for (int j = i; j < newArray.Length; j++)
                {
                    newArray[j] = GM.SuitsObtained[j + 1];
                }

                GM.SuitsObtained = newArray;
                Debug.Log(string.Join(", ",GM.SuitsObtained));
                paid++;
            }
            if(paid == CardCost[1])
            {
                if (ItemCard)
                {
                    GM.CraftItem(CardID ,CraftedPlacement);
                }
                else
                {
                    GM.CraftCard(CardID ,CraftedPlacement);
                }
                GM.SuitSpent();
                Destroy(gameObject);
            }
            else
            {
                GM.SuitsObtained = SafeKeeping;
                Debug.Log(string.Join(", ",GM.SuitsObtained));
            }
        }
    }
    public void Hold(Vector2 cursorPosition, float deltaTime)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, -Camera.main.transform.position.z));
        transform.position = Vector3.Lerp(transform.position, worldPosition, 10f * deltaTime);
    }

    public void Release()
    {
        transform.position = originalPosition;
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        Debug.Log("Fuck I hit him!");
        if(Other.CompareTag("Crow"))
        {
            Debug.Log("Turn on the TV they hit the Crow!!");
            int[] spawner = GameManager.SuitFinder(SuitID, GM.SuitCoordinates);
            GM.CrowSpawner(spawner);
            //GM.AddSuit(SuitID);
            Destroy(gameObject);
        }
    }
}

