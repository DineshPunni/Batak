using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour  {

    public int index;
    public int value;
    public enum Symbol {Heart,Diamond,Club,Spade};
    public Symbol CardSymbol;


    void Start()
    {
        gameObject.name = CardSymbol + " " + value;
    }

   void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponentInParent<PlayerScript>().hasTurn)
        {
            GameRules.instance.PlayCard(this.gameObject);
        }
    }
}
