using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructions : MonoBehaviour
{
    [SerializeField] string message;
    [SerializeField] Text title;
    [SerializeField] KeyCode button;
   // [SerializeField]  title;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool entered;
    // Update is called once per frame
    void Update()
    {
        if (entered)
        {
            if(Input.GetKeyDown(button))
            {
                Time.timeScale = 1.0f;
                title.text = null;
            }
        }


        
    }
 
    public void invo()
    {
        Debug.Log("entered");
        entered = true;
            if (message != null)
            {
                title.text = message;
            }
            Time.timeScale = 0.0f;
            
            
        
    }
}
