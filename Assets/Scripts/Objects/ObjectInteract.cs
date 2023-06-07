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
    public string blackTextVal;
    public string asianTextVal;
    public string indianTextVal;
    public string nativeTextVal;
    public string latinoTextVal;
    public string middleTextVal;
    public GameObject blackObject;
    public GameObject asianObject;
    public GameObject indianObject;
    public GameObject nativeObject;
    public GameObject latinoObject;
    public GameObject middleObject;
    public TextMeshProUGUI textComponent;
    bool textOpen = false;
    bool totalRange = false;
    int curText = 7;
    List<GameObject> objects = new List<GameObject>();
    List<string> texts = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
      mask = LayerMask.GetMask("Object");
        objects.Add(blackObject);
        objects.Add(asianObject);
        objects.Add(indianObject);
        objects.Add(nativeObject);
        objects.Add(latinoObject);
        objects.Add(middleObject);

        texts.Add(blackTextVal);
        texts.Add(asianTextVal);
        texts.Add(indianTextVal);
        texts.Add(nativeTextVal);
        texts.Add(latinoTextVal);
        texts.Add(middleTextVal);
        texts.Add("Press E to open");
        texts.Add("Find sculptures and learn about them");

    }

    // Update is called once per frame
    void Update()
    {
        totalRange = false;
        for (int i = 0; i < objects.Count; i++)
        {
            Debug.DrawRay(player.transform.position, (objects[i].transform.position - player.transform.position).normalized * 3f, Color.blue);
            if (Physics.Raycast(player.transform.position, (objects[i].transform.position - player.transform.position).normalized, 3f, mask))
            {
                Debug.Log(i);
                withinRange = true;
                totalRange = true;
            }
            else
            {
                withinRange = false;
            }
            if (withinRange && Input.GetKeyDown(KeyCode.E))
            {
                textOpen = !textOpen;
            }
            if (withinRange && !textOpen)
            {
                curText = 6;
            }
            else if (withinRange && textOpen)
            {
                curText = i;
            }

        }
        if (totalRange)
        {
            textComponent.text = texts[curText];
        }
        else
        {
            textComponent.text = texts[7];
        }
                
    }
}
