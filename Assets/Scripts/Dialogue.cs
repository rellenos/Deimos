using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [TextArea(6, 8)] public string[] lines;
    public float textSpeed;

    public GameObject dialogue1;
    public GameObject dialogue2;

    private int index;

    public bool movement;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();

                if(dialogue1.activeInHierarchy == true)
                {
                    dialogue2.SetActive(true);
                    dialogue1.SetActive(false);
                }
                else
                {
                    dialogue2.SetActive(false);
                    dialogue1.SetActive(true);
                }
            }
            else
            {
                movement = true;
                Global.moving = true;
                
                StopAllCoroutines();
                textComponent.text = lines[index];

                
                
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
