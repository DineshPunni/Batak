using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour  {

    public int index;
    public int value;
    public enum Symbol {Heart,Diamond,Club,Spade};
    public Symbol CardSymbol;
    private AudioSource cardPlace;
    

    void Start()
    {
        gameObject.name = CardSymbol + " " + value;
        cardPlace = GetComponent<AudioSource>();
    }

   void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponentInParent<PlayerScript>().hasTurn)
        {
            GameRules.instance.PlayCard(this.gameObject);
            cardPlace.Play();
            
        }
    }
}
