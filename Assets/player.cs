using Cinemachine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    bodyManager bm;
    [SerializeField] Text score;
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<bodyManager>();
        time = Time.time;
    }
    [SerializeField] float speed;
    float time;
    [SerializeField] int maxScore; 
    [SerializeField] int CurrentScore; 
    bool detect(out RaycastHit hit, int directionIndex)
    {


        if (Physics.Raycast(transform.position, directions[directionIndex], out hit, 1f))
        {
            return true;


        }
        else
            return false;
    }
    bool detectLayers(out RaycastHit hit, int directionIndex, params string[] layerNames)
    {
        LayerMask mask = LayerMask.GetMask(layerNames);
       
        if (Physics.Raycast(transform.position, directions[directionIndex], out hit, 1f, mask))
        {
            return true;


        }
        else
            return false;
    }
    void death()
    {

          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void win()
    {
        SceneManager.LoadScene(1);


    }

    void moveInDiretion(int dirIndex)
    {
     
        if (detect(out RaycastHit hit, dirIndex))
        {
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("ground"))
            {

                 Debug.Log("Death");
                score.text = "u died, better luck nex time,restarting the level";

               
                main.m_Priority = 12;
                Invoke("death", 1);

            }
            else if (hit.collider.CompareTag("food"))
            {
                Debug.Log("eated");
                Destroy(hit.transform.gameObject);
                bm.add();
                CurrentScore++;
            }
            else if(hit.collider.CompareTag("to"))
            {
                hit.transform.gameObject.GetComponent<instructions>().invo();
            }
        }

        transform.position += directions[dirIndex];

    }


    [SerializeField] Vector3Int[] directions = new Vector3Int[] { Vector3Int.left, Vector3Int.forward, Vector3Int.right, Vector3Int.back, Vector3Int.down, Vector3Int.up };
    [SerializeField] Vector3Int[] directionsCopy = new Vector3Int[] { Vector3Int.left, Vector3Int.forward, Vector3Int.right, Vector3Int.back, Vector3Int.down, Vector3Int.up };
    [SerializeField] int dirINd = 1;
    void FixedUpdate()
    {
        if (Time.time - time >= speed)
        {
            time = Time.time;
            moveInDiretion(directionIndex);
            bm.move();
            resetDirection();
            rotation();
            directionIndex = 1;
        }


    }
    int findDirection(Vector3Int dir)
    {

        return directions.ToList().IndexOf(dir);

    }
    private void rotation()
    {
        // 1, 3: forward , back 
        // 0 , 2 : left, right
        // 4,5 : down , up
        
        //float x = Vector3.Angle(Vector3.forward, directions[1]);
        //    float y = Vector3.Angle(Vector3.right, directions[2]);
        //    float z= Vector3.Angle(Vector3.up, directions[5]);

        if(Vector3.up == directions[1] && Vector3.right == directions[2])
        transform.rotation = Quaternion.Euler(-90f,0,0);
       else if (Vector3.up == directions[1] && Vector3.left == directions[2])
            transform.rotation = Quaternion.Euler(-90f, -180f, 0f);
       else if (Vector3.up == directions[1] && Vector3.forward == directions[2])
            transform.rotation = Quaternion.Euler(-90, -180f, 90f);
       else if (Vector3.up == directions[1] && Vector3.back == directions[2])
            transform.rotation = Quaternion.Euler(-90, -180, -90);




        if (Vector3.down == directions[1] && Vector3.right == directions[2])
            transform.rotation = Quaternion.Euler(90, -180, 180);
       else if (Vector3.down == directions[1] && Vector3.left == directions[2])
            transform.rotation = Quaternion.Euler(90, -180, 0);
       else if (Vector3.down == directions[1] && Vector3.forward == directions[2])
            transform.rotation = Quaternion.Euler(90, -180, -90);
       else if (Vector3.down == directions[1] && Vector3.back == directions[2])
            transform.rotation = Quaternion.Euler(90, -180, -270);



        if (Vector3.right == directions[1] && Vector3.back == directions[2])
            transform.rotation = Quaternion.Euler(0, 90, 0);
       else if (Vector3.right == directions[1] && Vector3.forward == directions[2])
            transform.rotation = Quaternion.Euler(0, 90, 180);
      else  if (Vector3.right == directions[1] && Vector3.up == directions[2])
            transform.rotation = Quaternion.Euler(0, 90, 90);
      else  if (Vector3.right == directions[1] && Vector3.down == directions[2])
            transform.rotation = Quaternion.Euler(0, 90, 270);










        if (Vector3.left == directions[1] && Vector3.forward == directions[2])
            transform.rotation = Quaternion.Euler(0, 270,0);
       else if (Vector3.left == directions[1] && Vector3.up == directions[2])
            transform.rotation = Quaternion.Euler(0, 270, 90);
       else if (Vector3.left == directions[1] && Vector3.back == directions[2])
            transform.rotation = Quaternion.Euler(0, 270, 180);
       else if (Vector3.left == directions[1] && Vector3.down == directions[2])
            transform.rotation = Quaternion.Euler(0, 270, 270);














        if (Vector3.forward == directions[1] && Vector3.right == directions[2])
            transform.rotation = Quaternion.Euler(0, 0, 0);
       else if (Vector3.forward == directions[1] && Vector3.up == directions[2])
            transform.rotation = Quaternion.Euler(0, 0, 90);
       else if (Vector3.forward == directions[1] && Vector3.left == directions[2])
            transform.rotation = Quaternion.Euler(0, 0, 180);
       else if (Vector3.forward == directions[1] && Vector3.down == directions[2])
            transform.rotation = Quaternion.Euler(0, 0, 270);









        if (Vector3.back == directions[1] && Vector3.left == directions[2])
            transform.rotation = Quaternion.Euler(0, 180, 0);
       else if (Vector3.back == directions[1] && Vector3.up == directions[2])
            transform.rotation = Quaternion.Euler(0, 180, 90);
       else if (Vector3.back == directions[1] && Vector3.right == directions[2])
            transform.rotation = Quaternion.Euler(0, 180, 180);
       else if (Vector3.back == directions[1] && Vector3.down == directions[2])
            transform.rotation = Quaternion.Euler(0, 180, 270);




    }
    //void updateRotation()
    //{
    //    Vector3 axis = Vector3.Cross( directions[1], directions[directionIndex]);
    //    float angle = Vector3.Angle(directions[1],directions[directionIndex]);
    //    Debug.Log(angle);
    //    Debug.Log(axis);
    //    if (!Mathf.Approximately(angle, 0f))
    //    {

    //        transform.RotateAround(transform.position,axis , angle);
    //    }



    //}
    //void updateRotationFromInput(int next)
    //{

    //    float angle = Vector3.Angle(directions[1], directions[next]);
    //    if (!Mathf.Approximately(angle, 0f))
    //    {

    //        transform.RotateAround(transform.position, Vector3.Cross(directions[1], directions[next]), angle);
    //    }




    //}
    bool firsttime;
    private void Update()
    {
        score.text = $"{CurrentScore}/{maxScore}";
        if(CurrentScore == maxScore)
        {
            score.text = "u won";
            Invoke("win", 1);
        
        }


        if (Input.GetKeyDown(KeyCode.P))
            rotation();
        detectNewDirs();
        takeInput();

        //  detectDirectoion();
        //   detectNewDirs();
        if (inAir)
        {
            directionIndex = 4;

            main.m_Priority = 11;

            //updateRotation();

            if (firsttime)
            {
            //updateRotation();
                firsttime = false;
               
            }
            //dirINd = findDirection(direction);
        }
        else
        {
            //directions = directionsCopy;
            //dirINd = 1;
            //if (pressedW)
            //{
            //    directions = directionsCopy;
            //    dirINd = 1;
            //    pressedW = false;
            //}
            firsttime = true;

            //// updatarray();
            //takeInput();
        }




    }
    bool pressedW = false;



    int directionIndex = 1;
    void resetDirection()
    {
        Vector3 temp = Vector3.Cross(directions[1], directions[4]);
        Vector3Int tempint = new Vector3Int { x = Mathf.RoundToInt(temp.x), y = Mathf.RoundToInt(temp.y), z = Mathf.RoundToInt(temp.z) };

        switch (directionIndex)
        {
            case 0:
                directions[2] = directions[1];
                directions[0] = -directions[1];
                directions[1] = -tempint;
                directions[3] = tempint;
                break;


            case 2:
                directions[2] = -directions[1];
                directions[0] = directions[1];
                directions[1] = tempint;
                directions[3] = -tempint;
                break;

            case 4:
                (directions[4], directions[5], directions[1], directions[3]) = (-directions[1], directions[1], -directions[5], directions[5]);

                break;

            case 5:
                (directions[4], directions[5], directions[1], directions[3]) = (directions[1], -directions[1], directions[5], -directions[5]);

                break;



        }








    }


  //  [SerializeField] CinemachineVirtualCamera fp;
    void takeInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if(fp.m_Priority == 10)
            fp.m_Priority = 12;
            else
                fp.m_Priority = 10;
        }
       



        if (Input.GetKeyDown(KeyCode.E))
        {

            if (detect(out RaycastHit hit, 2))
            {
                if (hit.collider.CompareTag("ground"))
                {


                    setDirectionRotation(0);

                }
            }
            //else
            //{
            //    directionIndex = 2;
               
            //}


        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (detect(out RaycastHit hit, 0))
            {
                if (hit.collider.CompareTag("ground"))
                {
                    setDirectionRotation(2);



                }
            }
            //else
            //{
            //    moveInDiretion(0);
            //    moveInDiretion(2);
            //}




        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (detect(out RaycastHit hit, 5))
            {
                if (hit.collider.CompareTag("ground"))
                {
                    setDirectionRotation(1);



                }
            }




        }
        //if (Input.GetKeyDown(KeyCode.A))
        //{


        //    bool end;
        //    if (dirINd - 1 <= -1)
        //        end = true;
        //    else
        //        end = false;

        //    if (end)
        //    {

        //        if (directions[3] != direction && directions[3] != -direction)
        //        {
        //            updateRotationFromInput(3);

        //            dirINd = 3;
        //        }

        //    }
        //    else
        //    {
        //        updateRotationFromInput(dirINd -1);
        //        dirINd--;
        //    }
        //}



        if (Input.GetKeyDown(KeyCode.A))
        {
            //updateRotationFromInput(0);
            directionIndex = 0;



        }
        //if (Input.GetKeyDown(KeyCode.D))
        //{

        //    bool end;
        //    if (dirINd + 1 >= 4)
        //        end = true;
        //    else
        //        end = false;

        //    if (end)
        //    {

        //        if (directions[0] != direction && directions[0] != -direction)
        //        {
        //            updateRotationFromInput(0);

        //            dirINd = 0;
        //        }

        //    }
        //    else
        //    {
        //        updateRotationFromInput(dirINd + 1);
        //        dirINd++;
        //    }
        //}


        if (Input.GetKeyDown(KeyCode.D))
        {
           // updateRotationFromInput(2);

            directionIndex = 2;


        }



        //if (Input.GetKey(KeyCode.W))
        //{

        //    if (detect(out RaycastHit hit, dirINd))
        //    {
        //        if (hit.collider.CompareTag("ground"))//u can add the power up to build around urself
        //        {
        //            main.m_Priority = 9;

        //            pressedW = true;

        //            updateRotationFromInput(5);

        //            dirINd = 5;

        //        }
        //    }

        //}


        if (Input.GetKey(KeyCode.W))
        {

            if (detect(out RaycastHit hit, directionIndex))
            {
                if (hit.collider.CompareTag("ground"))//u can add the power up to build around urself
                {
                   

                    main.m_Priority = 9;
                    directionIndex = 5;
                    //updateRotationFromInput(5);

                }
            }

        }
        //if (Input.GetKeyDown(KeyCode.S)) // for te hardCore

        //{
        //    if (directions[4] != direction)
        //    {
        //        updateRotationFromInput(4);

        //        dirINd = 4;
        //    }
        //}

        updatarrayInput();
    }

    private void updatarray()
    {

        // Debug.Log(directions[dirINd]);
        // (directions[1], directions[3]) = (directions[dirINd], -directions[dirINd]);
        Vector3 temp = Vector3.Cross(directions[dirINd], direction);
        Vector3Int tempint = new Vector3Int { x = Mathf.RoundToInt(temp.x), y = Mathf.RoundToInt(temp.y), z = Mathf.RoundToInt(temp.z) };

        directions[4] = -directions[dirINd];
        directions[5] = directions[dirINd];


        (directions[1], directions[3]) = (direction, -direction);



        directions[0] = -tempint;
        directions[2] = tempint;


        //  new_dirs = new_dirs.OrderByDescending(item => item == directions[4]).ToArray();
    }
    private void updatarrayInput()
    {

        //Debug.Log(directions[dirINd]);
        //(directions[1], directions[3]) = (directions[dirINd], -directions[dirINd]);



        (directionsCopy[1], directionsCopy[3]) = (directions[dirINd], -directions[dirINd]);

        Vector3 temp = Vector3.Cross(directionsCopy[dirINd], direction);
        Vector3Int tempint = new Vector3Int { x = Mathf.RoundToInt(temp.x), y = Mathf.RoundToInt(temp.y), z = Mathf.RoundToInt(temp.z) };




        directionsCopy[0] = -tempint;
        directionsCopy[2] = tempint;

        new_dirs = new_dirs.OrderByDescending(item => item == directions[4]).ToArray();


    }
    // RaycastHit hit;
    [SerializeField] Vector3Int direction;
    Vector3 temp;
  [SerializeField] bool inAir = false;
    [SerializeField] Vector3[] new_dirs = new Vector3[] { Vector3.down, Vector3.forward, Vector3.right, Vector3.left, Vector3.up, Vector3.back };
    Vector3[] new_dirs2 = new Vector3[] { Vector3.down, Vector3.right, Vector3.up, Vector3.left };
    bool ndown, nback, nleft, nright, nup;
    private void setDirectionRotation(int Dirindex)//dir index is the desired rotation to be ground direction
    {

        switch (Dirindex)
        {
            case 0:
                (directions[5], directions[4], directions[2], directions[0]) = (directions[0], -directions[0], directions[5], -directions[5]);
        transform.RotateAround(transform.position, directions[1], 90f);
                break;
            case 1:
                (directions[5], directions[4], directions[2], directions[0]) = (-directions[5], directions[5], directions[0], directions[2]);
        transform.RotateAround(transform.position, directions[1], 180f);
                break;
            case 2:
                (directions[5], directions[4], directions[2], directions[0]) = (-directions[0], directions[0],- directions[5], directions[5]);
        transform.RotateAround(transform.position, directions[1],-90f);
                break;

        }



    }
    List<int> idk = new List<int>();
    int flipIndex;
 
        [SerializeField] List<Vector3Int> allCurrentDirections = new List<Vector3Int>();
    bool detectNewDirs()
    {
        RaycastHit hit = new RaycastHit();
        bool thereIsGround = false;
        inAir = true;
        allCurrentDirections = new List<Vector3Int>();
        for (int i = 0; i < 6; i++)
        {
            if (detectLayers(out hit, i, "ground"))
            {
                if (i == 4)
                {
                    thereIsGround = true;
                    inAir = false;

                }
                else
                    allCurrentDirections.Add(directions[i]);
            }

        }
        if (allCurrentDirections.Count > 0)
        {
            idk.Clear();
            //add here the concept toreturn the array of int of the index for these directions, so that u can when press e,q it moves the direction for the next index
            foreach (Vector3Int vector in allCurrentDirections)
            {
                idk.Add(findDirection(vector));

            }
            return true;

        }
        else if (thereIsGround)
        {
            //temp = hit.transform.position - transform.position;
            direction = directions[4];
            return false;
        }
        //else
        //{
        //    inAir = true;
        //    return false;
        //}
        return false;
    }
    [SerializeField] CinemachineVirtualCamera main;
    [SerializeField] CinemachineVirtualCamera fp;
    [SerializeField] CinemachineVirtualCamera second;
    [SerializeField] bool breaked = false;
    void detectDirectoion()
    {
        //breaked = false;
        //LayerMask groundMask = LayerMask.GetMask("ground");
        //inAir = false;
        //for(int i = 0; i < 6; i++)
        //{
        //    if (Physics.Raycast(transform.position, new_dirs[i], out hit, 1, groundMask))
        //    {
        //        temp = hit.transform.position - transform.position;
        //        breaked = true;
        //        break;
        //    }

        //}
        //if (!breaked)
        //{
        //   inAir = true;
        //}
        //if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1, groundMask))
        //{
        //    temp = hit.transform.position - transform.position;
        //}
        //else if (Physics.Raycast(transform.position, Vector3.up, out hit, 1, groundMask))
        //{
        //    temp = hit.transform.position - transform.position;
        //}
        //else if (Physics.Raycast(transform.position, Vector3.right, out hit, 1, groundMask))
        //{
        //    temp = hit.transform.position - transform.position;
        //}
        //else if (Physics.Raycast(transform.position, Vector3.left, out hit, 1, groundMask))
        //{
        //    temp = hit.transform.position - transform.position;
        //}
        //else if (Physics.Raycast(transform.position, Vector3.down, out hit, 1, groundMask))
        //{
        //    temp = hit.transform.position - transform.position;
        //}
        //else if (Physics.Raycast(transform.position, Vector3.back, out hit, 1, groundMask))
        //{
        //    temp = hit.transform.position - transform.position;
        //}
        //else
        //{
        //    inAir = true;

        //}
        direction = new Vector3Int { x = Mathf.RoundToInt(temp.x), y = Mathf.RoundToInt(temp.y), z = Mathf.RoundToInt(temp.z) };

        //  direction = directionsCopy[4];



    }

}
