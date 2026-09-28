using Unity.Burst.CompilerServices;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject[] Suits;
    public GameObject[] Cards;
    public int[] SuitsObtained;
   
    //Checks if a card has been spent
    public int[] SpentSuits;
    //Checks what suit were spent
    [SerializeField] private int[] CardAxis;
    private float loopCounter = 1.0f;
    private float SuitCounter = 4.0f;
    private int RandomSuit = 0;

    void Start()
    {
        SpawnSuits();
        SpawnCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SuitMaker(float i, int suit)
    {
        if (i % 2 == 0)
            {
                Instantiate(Suits[suit], new Vector3((i * 1.5f) - 3.0f, 2, 0), Quaternion.identity);
            }   
            else
            {
                Instantiate(Suits[suit], new Vector3((i * 1.5f) - 3.0f, 4, 0), Quaternion.identity);
            }
    }
    public void SpawnSuits()
    {
        while(loopCounter <= 4)
        {
            RandomSuit = Random.Range(0, 3);
            SuitMaker(loopCounter, RandomSuit);
            loopCounter = loopCounter + 1;
        }
        loopCounter = 0;
    }
    public void SpawnCards()
    {
        while(loopCounter <= 2)
        {
            Instantiate(Cards[Random.Range(0, 5)], new Vector3(CardAxis[(int)loopCounter], -2, 0), Quaternion.identity);
            loopCounter = loopCounter + 1;
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
                    if (suit.SuitID == SpentSuits[i] && suit.isClicked)
                    {
                        SuitsObtained = IAmTheIntRemoverAndIAmEVIL(SuitsObtained, SpentSuits[i]);
                        Destroy(suit.gameObject);
                        break;
                        Debug.Log("Something thing gone very wrong its the end of days RUN!!!");
                    }
                }
                
            }
        }
    public void GainSuit(int Suit)
    {
        SuitsObtained = AddIntToList(SuitsObtained, Suit);
    }
    public void SpendSuit(int Locate)
    {
        SpentSuits = AddIntToList(SpentSuits, SuitsObtained[Locate]);
        Debug.Log(string.Join(", ", SpentSuits));
        IAmTheIntRemoverAndIAmEVIL(SuitsObtained, SuitsObtained[Locate]);
    }
    public void AddSuit(int SuitID)
    {
        SuitCounter++;
        if(SuitID == 3)
        {
            RandomSuit = Random.Range(0, 3);
            SuitMaker(SuitCounter, RandomSuit);
        }
        else
        {
            SuitMaker(SuitCounter, SuitID);
        }
    }
}
