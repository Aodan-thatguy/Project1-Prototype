using UnityEngine;
using UnityEngine.UIElements;

public class Suits : MonoBehaviour, IClickable
{
    public int SuitID = 4;
    //0 Fox, 1 Mouse, 2 Rabbit, 3 Bird
    public bool isClicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator Anim;
    private GameManager GM;
    void Awake()
    {
        Anim = GetComponent<Animator>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Animation()
    {
        Anim.SetTrigger("Clicked");
        //I was planing on doing more with this to excuse a full function but never ending up doing it
    }
    public void Clicked()
    {
        if(!isClicked)
        {
            GM.GainSuit(SuitID);
            Anim.SetTrigger("Clicked");
            Debug.Log("Suit Clicked");
            isClicked = true;
        }
    }
}

