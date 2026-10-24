using UnityEngine;

public class Crow : MonoBehaviour, IClickable
{
    public int CrowPosition;
    public bool Plotted = false;
    private GameManager GM;
    private Animator Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeclarePosition(int Position)
    {
        CrowPosition = Position;
        Debug.Log(Position);
    }
    public void Clicked()
    {
        if(!Plotted)
        {
            GM.GainSuit(GM.SuitCoordinates[CrowPosition]);
            Anim.SetTrigger("Plotting");
            Debug.Log("Plotted");
            Plotted = true;
        }
    }
}
