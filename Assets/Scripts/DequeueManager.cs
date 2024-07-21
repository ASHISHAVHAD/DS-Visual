using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DequeueManager : MonoBehaviour
{
    public GameObject[] dequeue;
    public int frontInsert, backInsert, frontDelete, backDelete;
    public GameObject dequeueElement;

    // Start is called before the first frame update
    void Start()
    {
        frontInsert = 0;
        backInsert = 10;
        frontDelete = 0;
        backDelete = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void insertFromFront()
    {
        if (frontInsert <= backInsert)
        {
            Vector3 pos = new Vector3(-5.4f + frontInsert * 1.1f, 0, 0);
            dequeue[frontInsert] = Instantiate(dequeueElement, pos, dequeueElement.transform.rotation);

            frontInsert++;
        }
    }

    public void deleteFromFront()
    {
        if(frontDelete < frontInsert)
        {
            Destroy(dequeue[frontDelete]);
            frontDelete++;
        }
    }
}
