using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuButtonEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject image;
    public Image button;

    Vector3 startScale;
    Vector3 imageScale;
    Vector3 imagepos;
    float scaleX;
    float scaleY;
    float scaleZ;

    float vel = 0.5f;

    void Start()
    {
        scaleX = transform.localScale.x + vel;
        scaleY = transform.localScale.y + vel;
        scaleZ = transform.localScale.z + vel;
        startScale = transform.localScale;
        if (image != null)
        {
            imagepos = image.transform.position;
            imageScale = image.transform.localScale;
        }

        return;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.color = new Color32(225,179,0,255);

        transform.localScale = new Vector3(scaleX+0.2f, scaleY+0.5f, scaleZ+0.2f);
        
        return;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = startScale;

        button.color = new Color32(255,255,255,255);

        return;
    }
}
