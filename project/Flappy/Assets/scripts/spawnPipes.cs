using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPipes : MonoBehaviour
{
    //dificulte set
    public int dificulte; // (5.5 -5.5 <> 8 -8 alt) -1 <> -8 baixo 3 <> 10 alto
    public int aux;
    public float[] posX = { 3, 3.5F, 4, 4.5F, 5, 5.5f, 6, 6.5F, 7, 7.5F, 8, 8.5F, 9, 9.5F, 10 };
    public float[] posY = { -1, -1.5F, -2, -2.5F, -3, -3.5F, -4, -4.5F, -5, -5.5F, -6, -6.5F, -7, -7.5F, -8 };
    public float[,] posResult = new float[15, 15];
    public List<float> resultX = new List<float>();
    public List<float> resultY = new List<float>();
    public float pipeQuant;//++
    float pipeQuantTime;//++
    public float speedPipes; //++
    public float destroyTime; // --
    public int x;
    public int y;

    //prefab set
    public GameObject pipe_x;
    public GameObject pipe_y;
    //color preference
    public Sprite pipe_green;
    public Sprite pipe_orange;
    public int colorSelect;
    public int cont;
    // Start is called before the first frame update
    void Start()
    {
        pipe_x.GetComponent<SpriteRenderer>().sprite = colorSelect > 0 ? pipe_orange : pipe_green;
        pipe_y.GetComponent<SpriteRenderer>().sprite = colorSelect > 0 ? pipe_orange : pipe_green;
        IAUp();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("a"))
        {
            aux = aux / dificulte;
            cont = 0;
            IAUp();
        }


        pipeQuantTime += Time.deltaTime;
        if (pipeQuantTime >= pipeQuant)
        {
            Spawn(resultX[cont], resultY[cont], speedPipes, destroyTime);
            print(resultX[cont] + " " + resultY[cont]);
            if (cont >= aux)
            {
                //IADown();
                cont = 0;
            }
            cont += 1;
            pipeQuantTime = 0;
        }
    }
    void Rand(int ii, int jj)
    {
        ii = Random.Range(0, 14);
        jj = Random.Range(0, 14);
    }
    void Dificulte(int dif)
    {

    }
    void Spawn(float alt_x, float alt_y, float speed, float destroy)
    {
        GameObject pipeX = Instantiate(pipe_y, transform.position, transform.rotation);
        pipeX.transform.parent = transform.parent;
        pipeX.GetComponent<movePipes>().speed = speed;
        pipeX.GetComponent<movePipes>().lifeTime = destroy;
        pipeX.transform.position = new Vector3(transform.position.x, alt_x, transform.position.z);

        GameObject pipeY = Instantiate(pipe_x, transform.position, transform.rotation);
        pipeY.transform.parent = transform.parent;
        pipeY.GetComponent<movePipes>().speed = speed;
        pipeY.GetComponent<movePipes>().lifeTime = destroy;
        pipeY.transform.position = new Vector3(transform.position.x, alt_y, transform.position.z);
    }
    void IAUp()
    {
        resultX.Clear();
        resultY.Clear();
        //UP
        for (int i = 0; i < aux; i++)
        {
            resultX.Add(posX[i + dificulte]);
            resultY.Add(posY[aux - (i + dificulte)]);
        }
        print("UP!");
    }
    void IADown()
    {
        //down
        for (int i = 0; i < posX.Length; i++)
        {
            posResult[i, 0] = posX[14 - i];
            posResult[0, i] = posY[i];
        }
        print("DOWN!");
    }
}
