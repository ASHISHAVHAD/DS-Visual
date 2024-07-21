using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StackManager : MonoBehaviour
{
    public GameObject stackElement;
    public int numberOfElements;
    public GameObject[] stack;
    public TMP_Text[] elements;
    public int i;
    public Material top;
    public Material element;
    bool flag = false;
    public TMP_Text elementText;
    public TextMeshProUGUI stackEmpty;
    public TextMeshProUGUI stackFull;
    private TMP_Text topInstance;
    public TMP_Text topPointer;

    // Start is called before the first frame update
    void Start()
    {
        numberOfElements = 0;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == true)
        {
            elements[i-1].text = "" + numberOfElements;
            flag = false;
        }
    }

    public void Push()
    {
        if (numberOfElements < 10)
        {
            stackEmpty.alpha = 0;
            numberOfElements++;
            Vector3 pos = new Vector3(0, numberOfElements * 1.1f, 0);
            stack[i] = Instantiate(stackElement, pos, stackElement.transform.rotation);

            Vector3 pos1 = new Vector3(0, numberOfElements * 1.1f, -0.51f);
            elements[i] = Instantiate(elementText, pos1, elementText.transform.rotation);

            flag = true;

            if (i == 0)
            {
                topInstance = Instantiate(topPointer, new Vector3(2.0f, 1.1f, -2.0f), topPointer.transform.rotation);
            }
            else
            {
                topInstance.transform.position = topInstance.transform.position + new Vector3(0.0f, 1.1f, 0.0f);
            }

            for (int k = 0; k < i; k++)
            {
                stack[k].GetComponent<MeshRenderer>().material = element;
            }
            stack[i].GetComponent<MeshRenderer>().material = top;
            i++;
        }
        else
        {
            stackFull.alpha = 1;
        }
    }

    public void Pop()
    {
        stackFull.alpha = 0;
        if (i != 0)
        {
            Destroy(stack[i - 1]);
            stack[i - 1] = null;
            Destroy(elements[i - 1]);
            elements[i - 1] = null;
            i--;
            numberOfElements--;
            topInstance.transform.position = topInstance.transform.position - new Vector3(0.0f, 1.1f, 0.0f);
            if (i != 0)
            {
                for (int k = 0; k < i - 1; k++)
                {
                    stack[k].GetComponent<MeshRenderer>().material = element;
                }
                stack[i - 1].GetComponent<MeshRenderer>().material = top;
            }
            if(i==0)
            {
                Destroy(topInstance);
                topInstance = null;
            }
        }
        else
        {
            stackEmpty.alpha = 1;
        }
    }

    public void reset()
    {
        SceneManager.LoadScene("Stack");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
