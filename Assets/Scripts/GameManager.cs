using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Symbol { Heart, Diamond, Club, Spade };

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public Sprite[] cardImages = new Sprite[52];
    public List<GameObject> Deck = new List<GameObject>();
    public List<GameObject> Players = new List<GameObject>();
    public GameObject Card;
    

    void Awake()
    {
        InitializeDeck();

        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

   
 
    public void GiveCards(List<GameObject> PlayerHand)
    {
        int i = 0;

        while (i < 13){
            int randNum = UnityEngine.Random.Range(0,Deck.Count);
            GameObject tempCard = (GameObject)Deck[randNum];
            if (!PlayerHand.Contains(tempCard))
            {
                PlayerHand.Add(tempCard);
                Deck.RemoveAt(randNum);
                i++;
            }            
        }
    }

    private void InitializeDeck()
    {
        for(int i=0; i<52; i++)
        {   
            GameObject tempCard = Instantiate(Card, new Vector3(i,10,0), Quaternion.identity) as GameObject;
            tempCard.GetComponent<SpriteRenderer>().sprite = cardImages[i];
            SetSymbol(i,tempCard);
            tempCard.GetComponent<CardScript>().value = (i % 13)+2;
            tempCard.GetComponent<CardScript>().index = i;
            Deck.Add(tempCard);
        }
    }

    private void SetSymbol(int i, GameObject tempCard)
    {
        if(i <= 12)
            tempCard.GetComponent<CardScript>().CardSymbol = Symbol.Heart;
        else if (i <= 25)
            tempCard.GetComponent<CardScript>().CardSymbol = Symbol.Diamond;
        else if (i <= 38)
            tempCard.GetComponent<CardScript>().CardSymbol = Symbol.Club;
        else
            tempCard.GetComponent<CardScript>().CardSymbol = Symbol.Spade;
    }

    public void SwitchTurns()
    {
    }
}
