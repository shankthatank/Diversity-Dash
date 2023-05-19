using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteract : MonoBehaviour
{
    public GameObject player;
    bool withinRange = false;
    LayerMask mask;
    public string textVal;
    public TextMeshProUGUI textComponent;
    bool textOpen = false;

    // Start is called before the first frame update
    void Start()
    {
      mask = LayerMask.GetMask("Player");
        textVal = "Fortnite Burger 2019";
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * 3f, Color.blue);
        if(Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, 3f, mask))
        {
            withinRange = true;
        }
        else
        {
            withinRange = false;
        }
        if(withinRange && Input.GetKeyDown(KeyCode.E))
        {
            textOpen = !textOpen;
        }
        if(withinRange && !textOpen)
        {
            textComponent.text = "Press E to open";
        } else if(withinRange && textOpen) {
            textComponent.text = textVal;
        }

    }
}
