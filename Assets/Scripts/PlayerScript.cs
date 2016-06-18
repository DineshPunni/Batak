using UnityEngine;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

    public List<GameObject> PlayerHand = new List<GameObject>();
    Vector3 PlayerPos;
    public bool isHorizontal;
    public bool hasTurn;

    void Start()
    {
        PlayerPos = transform.position;
        GameManager.instance.GiveCards(PlayerHand);
        ShowHand();
    } 

    private void ShowHand()
    {
        SortHand();
        for (int i = 0; i < 13; i++)
        {
            PlayerHand[i].gameObject.transform.SetParent(transform);
            if (isHorizontal)
                PlayerHand[i].gameObject.transform.position = new Vector3(PlayerPos.x + i, PlayerPos.y, 0);
            else {
                PlayerHand[i].gameObject.transform.position = new Vector3(PlayerPos.x, PlayerPos.y + i, 0);
                PlayerHand[i].gameObject.transform.Rotate(0, 0, 90);
            }
        }
    }

    private void SortHand()
    {
        PlayerHand.Sort(delegate (GameObject a, GameObject b) { return a.GetComponent<CardScript>().index.CompareTo(b.GetComponent<CardScript>().index); });
    }
}
