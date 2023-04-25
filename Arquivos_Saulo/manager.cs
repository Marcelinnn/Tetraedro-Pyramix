using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
     Vector3 m_Center;
	// Use this for initialization
	void Start () {
		for(int i=0; i < 24; i++)
        {
            if(i == 0)
            {
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
            }
            else
                vetGameObj[i]= Instantiate(tetrahedron, new Vector3(vetGameObj[i-1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
            //i-1 posicao anterior
        }

        //pegar tetra da posicao 3 e transladar
        vetGameObj[3].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        //vetGameObj[3].transform.Rotate(110f,0f,0); // 90f
       // vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);

        pai = new GameObject();
        //pai.transform.position = new Vector3(0,1,0); //pivo
        pai.transform.position = new Vector3(0, 1, 0); //pivo
        vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds
    }

	
	// Update is called once per frame
	void Update () {
		//vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);
        //cria um gameobject: Pai. Tem eixo de rotacao
        //por o objeto como filho deste gameobject
        //rotaciona o gameObjet(pai): consequencia o filho rotaciona
        //Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //pai.transform.Rotate(Vector3.right * 5);
        vetGameObj[4].transform.Rotate((Vector3.right + Vector3.up) * 5);
	}
}
