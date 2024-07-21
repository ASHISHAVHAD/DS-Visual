using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QueueTATScript : MonoBehaviour
{
    public TMP_Text next;
    public RawImage back;
    public TextMeshProUGUI mainText;
    public int slideNumber;
    public Button nextButton;
    public TMP_Text onFieldText;
    public GameObject elementCube;
    public GameObject[] queue;
    public TMP_Text[] elements;
    public TMP_Text elementText;
    public int numberOfElements;
    public TMP_Text secondaryText, secondaryText2;
    int i, j;
    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        slideNumber = 1;
        onFieldText.gameObject.SetActive(false);
        numberOfElements = 0;
        i = 0;
        j = 0;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (slideNumber == 6)
        {
            onFieldText.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            queue[0] = Instantiate(elementCube, new Vector3(7, 0, 0), elementCube.transform.rotation);
            elements[0] = Instantiate(elementText, new Vector3(7, 0, -2), elementText.transform.rotation);
            numberOfElements++;
            i++;
            elements[0].text = "" + numberOfElements;
            slideNumber++;
        }
        if(slideNumber == 7)
        {
            queue[0].transform.position = Vector3.MoveTowards(queue[0].transform.position, new Vector3(-5.4f, 0, 0), Time.deltaTime * 20.0f);
            elements[0].transform.position = Vector3.MoveTowards(elements[0].transform.position, new Vector3(-5.4f, 0, -2), Time.deltaTime * 20.0f);
            if (queue[0].transform.position.x == -5.4f)
            {
                onFieldText.text = "You have successfully inserted the first element in queue.";
                next.text = "Next";
                onFieldText.gameObject.SetActive(true);
                nextButton.gameObject.SetActive(true);
                slideNumber++;
            }
        }
        if (flag == true)
        {
            elements[i - 1].text = "" + numberOfElements;
            flag = false;
        }
    }

    public void letsGo()
    {
        if (slideNumber == 1)
        {
            next.text = "Next";
            //back.color = new Color(back.color.r, back.color.g, back.color.b, backPanel);//opacity of backpanel
            mainText.text = "Queue data structure follows FIFO data structure. FIFO means First In, First Out. The element that is inserted first will be deleted first.";
            slideNumber++;
        }
        else if(slideNumber == 2)
        {
            mainText.text = "Let's start by inserting our first element.";
            slideNumber++;
        }
        else if(slideNumber == 3)
        {
            back.color = new Color(back.color.r, back.color.g, back.color.b, 0);
            mainText.gameObject.SetActive(false);
            onFieldText.gameObject.SetActive(true);
            secondaryText.gameObject.SetActive(true);
            secondaryText2.gameObject.SetActive(true);
            slideNumber++;
        }
        else if(slideNumber == 4)
        {
            next.text = "Insert";
            onFieldText.text = "Click on insert: ";
            slideNumber++;
        }
        else if(slideNumber == 5)
        {
            slideNumber++;
        }
        else if(slideNumber == 8)
        {
            onFieldText.text = "As you can see the added element went into the queue through right side, aka rear end of the queue.";
            slideNumber++;
        }
        else if(slideNumber == 9)
        {
            onFieldText.text = "You can only add elements through rear end of a queue.";
            slideNumber++;
        }
        else if(slideNumber == 10)
        {
            next.text = "Insert";
            onFieldText.text = "Try inserting more elements.";
            slideNumber++;
        }
        else if(slideNumber == 11)
        {
            insert();
            if (numberOfElements == 11)
            {
                onFieldText.text = "Oh! It seems that the queue is full.";
                next.text = "Next";
                slideNumber++;
            }
        }
        else if(slideNumber == 12)
        {
            onFieldText.text = "Let's try removing some elements from the queue.";
            next.text = "Delete";
            slideNumber++;
        }
        else if(slideNumber == 13)
        {
            Destroy(queue[j]);
            Destroy(elements[j]);
            j++;
            onFieldText.text = "You have deleted an element. As you can see the element was deleted from left side aka front end of the queue.";
            next.text = "Next";
            slideNumber++;
        }
        else if(slideNumber == 14)
        {
            onFieldText.text = "Try deleting some more elements.";
            next.text = "Delete";
            slideNumber++;
        }
        else if(slideNumber == 15)
        {
            dlete();
            if(j == 11)
            {
                onFieldText.text = "The queue has been emptied and you cannot delete anymore.";
                next.text = "Next";
                slideNumber++;
            }
        }
        else if(slideNumber == 16)
        {
            secondaryText.gameObject.SetActive(false);
            secondaryText2.gameObject.SetActive(false);
            mainText.text = "This was a singly ended queue. You can only insert from rear & delete from front.";
            back.color = new Color(back.color.r, back.color.g, back.color.b, 1);
            mainText.gameObject.SetActive(true);
            onFieldText.gameObject.SetActive(false);
            slideNumber++;
        }
        else if(slideNumber == 17)
        {
            mainText.text = "You can play around with the Queue data structure using Sandbox feature.";
            nextButton.gameObject.SetActive(false);
        }
    }

    public void insert()
    {
        Vector3 pos = new Vector3(-5.4f + i * 1.1f, 0, 0);
        queue[i] = Instantiate(elementCube, pos, elementCube.transform.rotation);

        Vector3 pos1 = new Vector3(-5.4f + i * 1.1f, 0, -1.25f);
        elements[i] = Instantiate(elementText, pos1, elementText.transform.rotation);

        flag = true;
        i++;
        numberOfElements++;
    }

    public void dlete()
    {
         Destroy(queue[j]);
         Destroy(elements[j]);
         j++;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
