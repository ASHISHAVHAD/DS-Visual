using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QueueManager : MonoBehaviour
{
    public GameObject queueElement;
    public int numberOfElements;
    public GameObject[] queue;
    public int i, j;
    public TMP_Text[] elements;
    public TMP_Text elementText;
    public bool flag;
    public TMP_Text frontPointer;
    public TMP_Text rearPointer;
    private TMP_Text frontInstance;
    private TMP_Text rearInstance;
    public TextMeshProUGUI queueEmpty;
    public TextMeshProUGUI queueFull;


    // Start is called before the first frame update
    void Start()
    {
        numberOfElements = 0;
        i = 0;
        j = 0;
        flag = false;
        frontInstance = Instantiate(frontPointer, new Vector3(-5.4f, -2.5f, 0), frontPointer.transform.rotation);
        queueFull.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            elements[i - 1].text = "" + numberOfElements;
            flag = false;
        }
    }

    public void insert()
    {
        queueFull.alpha = 0;
        queueEmpty.alpha = 0;
        if (i < 11)
        {
            Vector3 pos = new Vector3(-5.4f + i * 1.1f, 0, 0);
            queue[i] = Instantiate(queueElement, pos, queueElement.transform.rotation);

            Vector3 pos1 = new Vector3(-5.4f + i * 1.1f, 0, -1.25f);
            elements[i] = Instantiate(elementText, pos1, elementText.transform.rotation);

            flag = true;

            if (i == 0)
            {
                rearInstance = Instantiate(rearPointer, new Vector3(-5.4f, -5.2f, 0), rearPointer.transform.rotation);
            }
            i++;
            numberOfElements++;

            if (i == 11)
            {
                frontInstance.text = "Full";
            }
            else
            {
                frontInstance.transform.position = frontInstance.transform.position + new Vector3(1.1f, 0, 0);
            }   
        }
        else
        {
            queueFull.alpha = 1;
        }
    }

    public void dlete()
    {
        queueFull.alpha = 0;
        queueEmpty.alpha = 0;
        if (i > j)
        {
            Destroy(queue[j]);
            Destroy(elements[j]);
            j++;
            //numberOfElements--;

            if (j == 11)
            {
                rearInstance.text = "Empty";
            }
            else
            {
                rearInstance.transform.position = rearInstance.transform.position + new Vector3(1.1f, 0, 0);
            }
        }
        else
        {
            queueEmpty.alpha = 1;
        }
        
    }

    public void reset()
    {
        SceneManager.LoadScene("Queue");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
