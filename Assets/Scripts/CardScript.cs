using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour  {

    public int index;
    public int value;
    public enum Symbol {Heart,Diamond,Club,Spade};
    public Symbol CardSymbol;


   void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponentInParent<PlayerScript>().hasTurn)
        {
            Debug.Log(value + " " + CardSymbol);
            gameObject.transform.position = Vector3.zero;
            GameManager.instance.SwitchTurns(GetComponentInParent<GameObject>());
        }
    }
    
}
