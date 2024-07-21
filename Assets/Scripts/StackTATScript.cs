using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StackTATScript : MonoBehaviour
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
    public TMP_Text secondaryText;
    int i;
    bool flag;

    // Start is called before the first frame update
    void Start()
    {
        slideNumber = 1;
        onFieldText.gameObject.SetActive(false);
        numberOfElements = 0;
        i = 0;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (slideNumber == 6)
        {
            onFieldText.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(false);
            queue[0] = Instantiate(elementCube, new Vector3(0, 13, 0), elementCube.transform.rotation);
            elements[0] = Instantiate(elementText, new Vector3(0, 13, -2), elementText.transform.rotation);
            numberOfElements++;
            i++;
            elements[0].text = "" + numberOfElements;
            slideNumber++;
        }
        if (slideNumber == 7)
        {
            queue[0].transform.position = Vector3.MoveTowards(queue[0].transform.position, new Vector3(0, 1.1f, 0), Time.deltaTime * 20.0f);
            elements[0].transform.position = Vector3.MoveTowards(elements[0].transform.position, new Vector3(0, 1.1f, -2), Time.deltaTime * 20.0f);
            if (queue[0].transform.position.y == 1.1f)
            {
                onFieldText.text = "You have successfully pushed the first element in stack.";
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
            mainText.text = "Stack data structure follows LIFO data structure. LIFO means Last In, First Out. The element that is pushed last will be popped first.";
            slideNumber++;
        }
        else if (slideNumber == 2)
        {
            mainText.text = "Let's start by pushing our first element.";
            slideNumber++;
        }
        else if (slideNumber == 3)
        {
            back.color = new Color(back.color.r, back.color.g, back.color.b, 0);
            mainText.gameObject.SetActive(false);
            onFieldText.gameObject.SetActive(true);
            secondaryText.gameObject.SetActive(true);
            slideNumber++;
        }
        else if (slideNumber == 4)
        {
            next.text = "Push";
            onFieldText.text = "Click on push: ";
            slideNumber++;
        }
        else if (slideNumber == 5)
        {
            slideNumber++;
        }
        else if (slideNumber == 8)
        {
            onFieldText.text = "As you can see the added element went into the stack through top side, aka top end of the stack.";
            slideNumber++;
        }
        else if (slideNumber == 9)
        {
            onFieldText.text = "You can only add elements through top end of a stack.";
            slideNumber++;
        }
        else if (slideNumber == 10)
        {
            next.text = "Push";
            onFieldText.text = "Try pushing more elements.";
            slideNumber++;
        }
        else if (slideNumber == 11)
        {
            Push();
            if (numberOfElements == 10)
            {
                onFieldText.text = "Oh! It seems that the stack is full.";
                next.text = "Next";
                slideNumber++;
            }
        }
        else if (slideNumber == 12)
        {
            onFieldText.text = "Let's try to pop some elements from the stack.";
            next.text = "Pop";
            slideNumber++;
        }
        else if (slideNumber == 13)
        {
            Destroy(queue[i-1]);
            Destroy(elements[i-1]);
            i--;
            onFieldText.text = "You have popped an element. As you can see the element was removed from top end of the stack.";
            next.text = "Next";
            slideNumber++;
        }
        else if (slideNumber == 14)
        {
            onFieldText.text = "Try popping some more elements.";
            next.text = "Pop";
            slideNumber++;
        }
        else if (slideNumber == 15)
        {
            Pop();
            if (i == 0)
            {
                onFieldText.text = "The stack has been emptied and you cannot pop anymore.";
                next.text = "Next";
                slideNumber++;
            }
        }
        else if (slideNumber == 16)
        {
            secondaryText.gameObject.SetActive(false);
            mainText.text = "You can only insert or take out elements from top of a stack.";
            back.color = new Color(back.color.r, back.color.g, back.color.b, 1);
            mainText.gameObject.SetActive(true);
            onFieldText.gameObject.SetActive(false);
            slideNumber++;
        }
        else if (slideNumber == 17)
        {
            mainText.text = "You can play around with the Stack data structure using Sandbox feature.";
            nextButton.gameObject.SetActive(false);
        }
    }

    public void Push()
    {
            numberOfElements++;
            Vector3 pos = new Vector3(0, numberOfElements * 1.1f, 0);
            queue[i] = Instantiate(elementCube, pos, elementCube.transform.rotation);

            Vector3 pos1 = new Vector3(0, numberOfElements * 1.1f, -0.51f);
            elements[i] = Instantiate(elementText, pos1, elementText.transform.rotation);

            flag = true;
            i++;
    }

    public void Pop()
    {
            Destroy(queue[i - 1]);
            queue[i - 1] = null;
            Destroy(elements[i - 1]);
            elements[i - 1] = null;
            i--;
            numberOfElements--;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
