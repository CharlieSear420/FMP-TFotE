using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TriggerSound : MonoBehaviour, ISelectHandler , IPointerEnterHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("entered");
        //AudioManager.instance.Play("beep1");
    }

    public void OnSelect( BaseEventData eventData )
    {
        //print("selected");
        AudioManager.instance.Play("beep");
    }
}
