using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyManager : MonoBehaviour
{
    [SerializeField] GameObject body;

   [SerializeField] List<GameObject> bodyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
        bodyList.Add(gameObject);
        add();
        add();
        add();
        
    }

    // Update is called once per frame
   public void move()
    {
        
            for (int i = bodyList.Count -1; i > 0; i--)
            {
            bodyList[i].transform.position = bodyList[i - 1].transform.position;

            }

        

        
    }
    public void add()
    {
        GameObject nextBody = Instantiate(body,transform.position,Quaternion.identity);
        bodyList.Add(nextBody);

        
    }
}
