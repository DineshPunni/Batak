using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour  {

    public int index;
    public int value;
    public Symbol CardSymbol;
    private AudioSource cardPlace;
    public GameObject owner;
    

    void Start()
    {
        gameObject.name = CardSymbol + " " + value;
        cardPlace = GetComponent<AudioSource>();
        Invoke("SetOwner", 1);
    }


    void SetOwner(){
        owner = transform.parent.gameObject;
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
