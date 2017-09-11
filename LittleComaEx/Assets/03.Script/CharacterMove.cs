using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    CharacterControl characterControl;

    public string direction;

    // Use this for initialization
    void Start()
    {
        characterControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        characterControl.SendMessage("moveCharacter", direction);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        characterControl.SendMessage("stopCharacter");
    }

    /*
    public void SendMessage(string direction)
    {
        print("SendMessage");
        characterControl.SendMessage("moveCharacter", direction);
    }
    */
}
