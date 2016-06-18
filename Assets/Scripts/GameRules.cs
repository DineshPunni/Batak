using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameRules : MonoBehaviour {

    public static GameRules instance = null;

    public Symbol smallCoz;
    private int layer = 0;
    private int turns = 0;
    
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
            smallCoz = card.GetComponent<CardScript>().CardSymbol;
            card.transform.position = new Vector3(0, 0, layer--);
        }
        else if(turns < 3)
        {
            card.transform.position = new Vector3(0, 0, layer--);
        }
        else if(turns == 3)
        {
            ChooseWinner();
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
            firstCard = card;
        }
        turns++;
        CardsOut.Add(card);
    }

    private void ChooseWinner()
    {

    }
}
