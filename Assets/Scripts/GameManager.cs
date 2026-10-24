using Unity.Burst.CompilerServices;
using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;


public class GameManager : MonoBehaviour
{
    public GameObject[] Suits;
    public GameObject Crow;
    public GameObject[] Cards;
    public GameObject[] CraftedCards;
    public GameObject[] CraftedItems;
    public int[] SuitsObtained;
   
    //Checks if a card has been spent
    public int[] SpentSuits;
    //Checks what suit were spent
    [SerializeField] private int[] CardAxis;
    private int loopCounter = 0;
    private int SuitCounter = 4;
    private int RandomSuit = 0;
    [SerializeField] private float[] SuitCoordinatesX;
    [SerializeField] private float[] SuitCoordinatesY;
    [SerializeField] private float[] CrowCoordinatesX;
    [SerializeField] private float[] CrowCoordinatesY;
    public int[] SuitCoordinates;
    public int[] CrowTracker;
    private bool NoCrow = false;
    private int FoxAmount = 0;
    private int RabbitAmount = 0;
    private int MouseAmount = 0;


    void Start()
    {
        SpawnSuits();
        SpawnCards();
        CrowSpawner(new int[]{UnityEngine.Random.Range(0, 12), UnityEngine.Random.Range(0, 12), UnityEngine.Random.Range(0, 12)});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void restart()
    {
        Suits[] suits = FindObjectsByType<Suits>();
        foreach (Suits suit in suits)
        {
            Destroy(suit.gameObject);
        }
        Cards[] cards = FindObjectsByType<Cards>();
        foreach (Cards card in cards)
        {
            Destroy(card.gameObject);
        }
        Crow[] crows = FindObjectsByType<Crow>();
        foreach (Crow crow in crows)
        {
            Destroy(crow.gameObject);
        }
        SpawnSuits();
        SpawnCards();
        CrowTracker = new int[0];
        CrowSpawner(new int[]{UnityEngine.Random.Range(0, 12), UnityEngine.Random.Range(0, 12), UnityEngine.Random.Range(0, 12)});
    }
    public void CrowSpawner (int[] Coordinates)
    {
        NoCrow = false;
        for (int i = 0; i < Coordinates.Length; i++)
        {
            for (int j = 0; j < CrowTracker.Length; j++)
            {
                if(Coordinates[i] == CrowTracker[j])
                {
                    NoCrow = true;
                    break;
                }
            }
            CrowTracker = AddIntToList(CrowTracker, Coordinates[i]);
            Debug.Log("Something thing gone very RIGHT its the START of days LIVE!!!");
            if(NoCrow == false)
            {
                Debug.Log(string.Join("", CrowCoordinatesX[Coordinates[i]], ", ",CrowCoordinatesY[Coordinates[i]], ", ", Coordinates[i]));
                GameObject NewCrow = Instantiate(Crow, new Vector3(CrowCoordinatesX[Coordinates[i]], CrowCoordinatesY[Coordinates[i]], 0), Quaternion.identity);
                Crow Corvid = NewCrow.GetComponent<Crow>();
                Corvid.DeclarePosition(Coordinates[i]);
            }
        }
    }
    private void SuitMaker(int i, int suit)
    {
        //if (i % 2 == 0)
            
            //{
                Instantiate(Suits[suit], new Vector3(SuitCoordinatesX[i], SuitCoordinatesY[i], 0), Quaternion.identity);
                SuitCoordinates = AddIntToList(SuitCoordinates, suit);
                Debug.Log(string.Join(", ", SuitCoordinates));
            //}   
            //else
            //{
                //Instantiate(Suits[suit], new Vector3((i * 1.5f) - 3.0f, 4, 0), Quaternion.identity);
            //}
    }
    public void CraftCard(int CardID, float X)
    {
        Instantiate(CraftedCards[CardID], new Vector3(X, 4, 0), Quaternion.identity);
    }
    public void CraftItem(int CardID, float X)
    {
        Instantiate(CraftedItems[CardID], new Vector3(X, 2, 0), Quaternion.identity);
    }
    public void SpawnSuits()
    {
        SuitCoordinates = new int[0];
        FoxAmount = 0;
        MouseAmount = 0;
        RabbitAmount = 0;
        loopCounter = 0;
        while(loopCounter <= 11)
        {
            Debug.Log("Suit iteration: " + loopCounter);
            RandomSuit = UnityEngine.Random.Range(0, 3);
            if(RandomSuit == 0)
            {
                if(FoxAmount == 4)
                {
                    RandomSuit = UnityEngine.Random.Range(1, 3);
                }
                else
                {
                    FoxAmount ++;
                }
            }
            else if(RandomSuit == 1)
            {
                if(MouseAmount == 4)
                {
                    while(true)
                    {
                        RandomSuit = UnityEngine.Random.Range(0, 3);
                        if(RandomSuit != 1)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    MouseAmount ++;
                }
            }
            if(RandomSuit == 2)
            {
                if(RabbitAmount == 4)
                {
                    RandomSuit = UnityEngine.Random.Range(0, 2);
                }
                else
                {
                    RabbitAmount ++;
                }
            }
            SuitMaker(loopCounter, RandomSuit);
            loopCounter ++;
        }
        loopCounter = 0;
        Debug.Log(string.Join(", ", SuitCoordinates));
    }
    public void SpawnCards()
    {
        while(loopCounter <= 2)
        {
            Instantiate(Cards[UnityEngine.Random.Range(0, 5)], new Vector3(CardAxis[loopCounter], -2, 0), Quaternion.identity);
            loopCounter ++;
        }
        loopCounter = 1;
    }
    //This is a function I have saved in my C# notes and it comes handy in certain projects so I just copy and paste it into them
    //The function adds an int "NewValue" to an array of ints "list"
    static int[] AddIntToList(int[] list, int NewValue)
    {
        int[] NewList = new int[list.Length + 1];

        for (int i = 0; i < list.Length; i++)
        {
            NewList[i] = list[i];
        }

        NewList[list.Length] = NewValue;

        return NewList;
    }
    static int[] IAmTheIntRemoverAndIAmEVIL(int[] list, int DIE)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] == DIE)
            {
                int[] NewList = new int[list.Length - 1];

                for (int j = 0; j < i; j++)
                {
                    NewList[j] = list[j];
                }

                for (int j = i; j < NewList.Length; j++)
                {
                    NewList[j] = list[j + 1];
                }
                Debug.Log(string.Join(", ", NewList));
                return NewList;
            }
        }

        return list;
    }
    public void SuitSpent()
        {
            for(int i = 0; i < SpentSuits.Length; i++)
            {
                Suits[] suits = FindObjectsByType<Suits>();

                foreach (Suits suit in suits)
                {
                    if (suit.SuitID == SpentSuits[i])
                    {
                        SuitsObtained = IAmTheIntRemoverAndIAmEVIL(SuitsObtained, SpentSuits[i]);
                        //Destroy(suit.gameObject);
                        break;
                        Debug.Log("Something thing gone very wrong its the end of days RUN!!!");
                    }
                }
                
            }
        }
    public void GainSuit(int Suit)
    {
        SuitsObtained = AddIntToList(SuitsObtained, Suit);
        Debug.Log(string.Join(", ", SuitsObtained));
    }
    public void SpendSuit(int Locate)
    {
        SpentSuits = AddIntToList(SpentSuits, SuitsObtained[Locate]);
        Debug.Log(string.Join(", ", SpentSuits));
        IAmTheIntRemoverAndIAmEVIL(SuitsObtained, SuitsObtained[Locate]);
        Debug.Log(string.Join(", ", SuitsObtained));
    }
    public void AddSuit(int SuitID)
    {
        SuitCounter++;
        if(SuitID == 3)
        {
            RandomSuit = UnityEngine.Random.Range(0, 3);
            SuitMaker(SuitCounter, RandomSuit);
        }
        else
        {
            SuitMaker(SuitCounter, SuitID);
        }
    }
    public static int[] SuitFinder(int suit, int[] suitList)
    {
        int[] Positions = new int[0];

        for (int i = 0; i < suitList.Length; i++)
        {
            if (suitList[i] == suit)
            {
                // Record the position where the integer was found
                Positions = AddIntToList(Positions, i);

                // Get the float at the same position
            }
        }

        return Positions;
    }
}
