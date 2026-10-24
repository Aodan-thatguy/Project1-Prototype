using UnityEngine;

public class Bomb : MonoBehaviour, IClickable
{
    private GameManager GM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicked ()
    {
        GM.restart();
    }
}
