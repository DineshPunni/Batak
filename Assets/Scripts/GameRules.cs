using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameRules : MonoBehaviour {

    public static GameRules instance = null;

    public int layer = 0;
    public int turns = 0;
    public GameObject firstCard;
    public List<GameObject> CardsOut = new List<GameObject>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }


    public void PlayCard(GameObject card)
    {
        if (turns == 0)
        {
            firstCard = card;
            card.transform.position = new Vector3(0, 0, layer--);
        }
        else if(turns < 4)
        {
            card.transform.position = new Vector3(0, 0, layer--);
        }
        else
        {
            for(int i=0; i<CardsOut.Count; i++)
            {
                Destroy(CardsOut[i]);
            }
            turns = 0;
            layer = 0;
            card.transform.position = new Vector3(0, 0, layer--);
        }
        turns++;
        CardsOut.Add(card);
    }
}
