using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    TMP_Text tmpText;
    private void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        HideMessage();
    }

    public void SetText(GameObject go)
    {
        tmpText.SetText("You picked up an item");
        tmpText.enabled = true;
        Invoke("HideMessage", 2.5f);
    }

    private void HideMessage()
    {
 
        tmpText.enabled = false;
    }

}
