using UnityEngine;
public class Pyramix_Manager : MonoBehaviour
{
    // Quantidade de triangulos a serem criados
    public int numeroDeTriangulos = 0;
    // Qual o triangulo base que vai ser clonado
    public GameObject triangulo;
    // Array de triangulos
    public GameObject[] trianguloArray;
    // Array de pivores
    public GameObject[] pivoArray;
    public GameObject pivoBaseVermelho;
    public GameObject pivoBaseAmarelo;
    public GameObject pivoBaseVerde;
    public GameObject pivoBaseAzul;
    public GameObject pivoMeioVermelho;
    public GameObject pivoMeioVerde;
    public GameObject pivoMeioAzul;
    public GameObject pivoMeioAmarelo;
    public GameObject pivoTopoVermelho;
    public GameObject pivoTopoVerde;
    public GameObject pivoTopoAzul;
    public GameObject pivoTopoAmarelo;
    
    GameObject pai;
    // Use this for initialization
    void Start()
    {
        trianguloArray = new GameObject[numeroDeTriangulos];
        pivoArray = new GameObject[numeroDeTriangulos];
        // Cria os triangulos e os pivores
        for (int i = 0; i < numeroDeTriangulos; i++)
        {
            // Cria um pivo
            pivoArray[i] = new GameObject();
            // Define a posição inicial de cada pivo
            pivoArray[i].transform.position = new Vector3(0, 0, 0);
            // Da um nome para cada pivo
            pivoArray[i].name = "Pivo " + i;
            // Cria um triangulo
            GameObject trianguloClone = Instantiate(triangulo, new Vector3(-0.5f, -0.28f, -0.28f), Quaternion.identity);
            // Define a escala do triangulo criado
            trianguloClone.transform.localScale = Vector3.one;
            // Enfia o triangulo no array
            trianguloArray[i] = trianguloClone;
            // Da um nome pro triangulo
            trianguloArray[i].name = "Triangulo " + i;
            // Envia o triangulo no pivo            
            trianguloArray[i].transform.parent = pivoArray[i].transform;
        }
        /*
        *   Define as posições dos triangulos
        */
        // Amarelo (Frente)
        pivoArray[1].transform.position = new Vector3(1, 0, 0);
        pivoArray[2].transform.position = new Vector3(2, 0, 0);
        pivoArray[3].transform.position = new Vector3(0.5f, 0.194f, 0.07f);
        pivoArray[3].transform.Rotate(36.1f, 0.0f, 180.0f);
        pivoArray[4].transform.position = new Vector3(1.5f, 0.194f, 0.07f);
        pivoArray[4].transform.Rotate(36.1f, 0.0f, 180.0f);
        pivoArray[5].transform.position = new Vector3(0.5f, 0.856f, 0.289f);
        pivoArray[6].transform.position = new Vector3(1.5f, 0.856f, 0.289f);
        pivoArray[7].transform.position = new Vector3(1f, 1.05f, 0.35f);
        pivoArray[7].transform.Rotate(37.2f, 0.0f, 180.0f);
        pivoArray[8].transform.position = new Vector3(1, 1.72f, 0.577f);
        // Vermelho (Baixo)
        pivoArray[9].transform.position = new Vector3(0.5f, 0, 0.3f);
        pivoArray[9].transform.Rotate(0.0f, 180.0f, 0f);
        pivoArray[10].transform.position = new Vector3(1.5f, 0, 0.3f);
        pivoArray[10].transform.Rotate(0.0f, 180.0f, 0f);
        pivoArray[11].transform.position = new Vector3(0.5f, 0, 0.86f);
        pivoArray[12].transform.position = new Vector3(1.5f, 0, 0.86f);
        pivoArray[13].transform.position = new Vector3(1.0f, 0, 1.165f);
        pivoArray[13].transform.Rotate(0.0f, 180.0f, 0f);
        pivoArray[14].transform.position = new Vector3(1.0f, 0, 1.72f);
        // Azul
        pivoArray[15].transform.position = new Vector3(0.3046848f, 0.2528399f, 0.366502f);
        pivoArray[15].transform.Rotate(-53.237f, 3.649f, 32.34f);
        pivoArray[16].transform.position = new Vector3(pivoArray[15].transform.position.x+0.5f,pivoArray[15].transform.position.y,pivoArray[15].transform.position.z+0.86f);
        pivoArray[16].transform.Rotate(-53.237f, 3.649f, 32.34f);
        pivoArray[17].transform.position = new Vector3(1.0f, 0.856f, 1.1f);
        pivoArray[18].transform.position = new Vector3(0.8f, 1.1f, 0.66f);
        pivoArray[18].transform.Rotate(-54.71f, 7.715f, 26.595f);
        // Verde
        pivoArray[19].transform.position = new Vector3(1.11f, 1.101006f, 0.700864f);
        pivoArray[19].transform.Rotate(38.804f, 34.142f, 47.602f);
        pivoArray[20].transform.position = new Vector3(1.129233f, 0.231463f, 1.29255f);
        pivoArray[20].transform.Rotate(38.68f, 36.725f, 45.643f);
        pivoArray[21].transform.position = new Vector3(1.657f, 0.29f, 0.426f);
        pivoArray[21].transform.Rotate(38.68f, 36.725f, 45.643f);

        // pivo base Vermelha
        pivoBaseVermelho.transform.position = new Vector3((pivoArray[0].transform.position.x + pivoArray[2].transform.position.x + pivoArray[14].transform.position.x) / 3.0f,
        (pivoArray[0].transform.position.y + pivoArray[2].transform.position.y + pivoArray[14].transform.position.y) / 3.0f,
        (pivoArray[0].transform.position.z + pivoArray[2].transform.position.z + pivoArray[14].transform.position.z) / 3.0f);
        
        //pivo base Amarela
        pivoBaseAmarelo.transform.position = new Vector3((pivoArray[0].transform.position.x + pivoArray[2].transform.position.x + pivoArray[8].transform.position.x) / 3.0f,
        (pivoArray[0].transform.position.y + pivoArray[2].transform.position.y + pivoArray[8].transform.position.y) / 3.0f,
        (pivoArray[0].transform.position.z + pivoArray[2].transform.position.z + pivoArray[8].transform.position.z) / 3.0f);
        
        //pivo base Verde
        pivoBaseVerde.transform.position = new Vector3((pivoArray[14].transform.position.x + pivoArray[2].transform.position.x + pivoArray[8].transform.position.x) / 3.0f,
        (pivoArray[14].transform.position.y + pivoArray[2].transform.position.y + pivoArray[8].transform.position.y) / 3.0f,
        (pivoArray[14].transform.position.z + pivoArray[2].transform.position.z + pivoArray[8].transform.position.z) / 3.0f);
        
        //pivo base Azul
        pivoBaseAzul.transform.position = new Vector3((pivoArray[0].transform.position.x + pivoArray[14].transform.position.x + pivoArray[8].transform.position.x) / 3.0f,
        (pivoArray[0].transform.position.y + pivoArray[14].transform.position.y + pivoArray[8].transform.position.y) / 3.0f,
        (pivoArray[0].transform.position.z + pivoArray[14].transform.position.z + pivoArray[8].transform.position.z) / 3.0f);

        //pivo base superior 1
        pivoMeioVermelho.transform.position = new Vector3((pivoArray[5].transform.position.x + pivoArray[6].transform.position.x + pivoArray[17].transform.position.x) / 3.0f,
        (pivoArray[5].transform.position.y + pivoArray[6].transform.position.y + pivoArray[17].transform.position.y) / 3.0f,
        (pivoArray[5].transform.position.z + pivoArray[6].transform.position.z + pivoArray[17].transform.position.z) / 3.0f);
        
        //pivo base superior 2
        pivoMeioVerde.transform.position = new Vector3((pivoArray[5].transform.position.x + pivoArray[11].transform.position.x + pivoArray[1].transform.position.x) / 3.0f,
        (pivoArray[5].transform.position.y + pivoArray[11].transform.position.y + pivoArray[1].transform.position.y) / 3.0f,
        (pivoArray[5].transform.position.z + pivoArray[11].transform.position.z + pivoArray[1].transform.position.z) / 3.0f);
        
        //pivo base superior 3
        pivoMeioAzul.transform.position = new Vector3((pivoArray[1].transform.position.x + pivoArray[6].transform.position.x + pivoArray[12].transform.position.x) / 3.0f,
        (pivoArray[1].transform.position.y + pivoArray[6].transform.position.y + pivoArray[12].transform.position.y) / 3.0f,
        (pivoArray[1].transform.position.z + pivoArray[6].transform.position.z + pivoArray[12].transform.position.z) / 3.0f);
        
        //pivo base superior 4
        pivoMeioAmarelo.transform.position = new Vector3((pivoArray[12].transform.position.x + pivoArray[11].transform.position.x + pivoArray[17].transform.position.x) / 3.0f,
        (pivoArray[12].transform.position.y + pivoArray[11].transform.position.y + pivoArray[17].transform.position.y) / 3.0f,
        (pivoArray[12].transform.position.z + pivoArray[11].transform.position.z + pivoArray[17].transform.position.z) / 3.0f);

        //pivoPontas
        pivoTopoVermelho.transform.position=pivoArray[8].transform.position;
        pivoTopoVerde.transform.position=pivoArray[0].transform.position;
        pivoTopoAzul.transform.position=pivoArray[2].transform.position;
        pivoTopoAmarelo.transform.position=pivoArray[14].transform.position;
    }
    public void GirarBaseVermelha(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.y>=-0.100f && pivoArray[i].transform.position.y<=0.3000f)
                pivoArray[i].transform.parent = pivoBaseVermelho.transform;
        }
        pivoBaseVermelho.transform.Rotate(0.0f,40.0f,0.0f); // FOI
    }
    public void GirarBaseAcima1(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.y>=0.85f && pivoArray[i].transform.position.y<1.2f)
                pivoArray[i].transform.parent = pivoMeioVermelho.transform;
        }
        pivoMeioVermelho.transform.Rotate(0.0f,40.0f,0.0f); // FOI
    }    
    public void GirarBaseAmarela(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.z>=-0.50f && pivoArray[i].transform.position.z<0.80f)
                pivoArray[i].transform.parent = pivoBaseAmarelo.transform;
        }
        pivoBaseAmarelo.transform.Rotate(0.0f,40.0f,0.0f); // FOI
    }
    public void GirarBaseAcima4(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.z>=0.82f && pivoArray[i].transform.position.z<1.8f)
                pivoArray[i].transform.parent = pivoMeioAmarelo.transform;
        }
        pivoMeioAmarelo.transform.Rotate(0.0f,40.0f,0.0f); // FOI
    }
        
    public void GirarBaseAzul(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.z>=-0.01f && pivoArray[i].transform.position.z<1.82f && pivoArray[i].transform.position.x>-0.0001f && pivoArray[i].transform.position.x<1.20f 
            && !(pivoArray[i].transform.position.z>=-0.01f && pivoArray[i].transform.position.z<0.05f && pivoArray[i].transform.position.x>=0.98f && pivoArray[i].transform.position.x<1.02f)){
                pivoArray[i].transform.parent = pivoBaseAzul.transform;
            }
        }
        pivoBaseAzul.transform.Rotate(0.0f,40.0f,0.0f);
        // pivoBaseAzul.transform.Rotate(0.0f,30.0f,0.0f);
    }

    public void GirarBaseAcima3(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.x>0.98f && pivoArray[i].transform.position.x<2.1f && pivoArray[i].transform.position.z>-0.02f && pivoArray[i].transform.position.z<0.92f && pivoArray[i].transform.position.y<0.90f)
                pivoArray[i].transform.parent = pivoMeioAzul.transform;
        }
        pivoMeioAzul.transform.Rotate(0.0f,40.0f,0.0f);
    }   

    public void GirarBaseVerde(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.x>0.79f && pivoArray[i].transform.position.x<2.04f && pivoArray[i].transform.position.z>=-0.01f && pivoArray[i].transform.position.z<1.75f 
            && !(pivoArray[i].transform.position.z>=-0.01f && pivoArray[i].transform.position.z<0.05f && (pivoArray[i].transform.position.x>-0.02f && pivoArray[i].transform.position.x<0.03f ||
            pivoArray[i].transform.position.x>0.98f && pivoArray[i].transform.position.x<1.02f))){
                pivoArray[i].transform.parent = pivoBaseVerde.transform;
            }
        }
        pivoBaseVerde.transform.Rotate(0.0f,40.0f,0.0f);
    }

    public void GirarBaseAcima2(){
        for(int i = 0; i < numeroDeTriangulos; i++) {
            if(pivoArray[i].transform.position.x>-0.02f && pivoArray[i].transform.position.x<1.02f && pivoArray[i].transform.position.z>-0.02f && pivoArray[i].transform.position.z<0.89f && pivoArray[i].transform.position.y<0.90f)
                pivoArray[i].transform.parent = pivoMeioVerde.transform;
        }
        pivoMeioVerde.transform.Rotate(0.0f,40.0f,0.0f);
    }
    public void GirarpivoTopoVermelho(){
        for(int i = 0; i < 15; i++){
            if(pivoArray[i].transform.position.x>=0.97f&&pivoArray[i].transform.position.z>=0.54f&&pivoArray[i].transform.position.y>=1.69f&&
                pivoArray[i].transform.position.x<=1.03f&&pivoArray[i].transform.position.z<=0.60f&&pivoArray[i].transform.position.y<=1.75f 
                && (i==0 || i==2 || i==8 || i==14))
                pivoArray[i].transform.parent = pivoTopoVermelho.transform;
        }
        pivoTopoVermelho.transform.Rotate(0.0f,40.0f,0.0f);
        // pivoTopoVermelho.transform.Rotate(0.0f,10.0f,0.0f);
    }

    public void GirarpivoTopoVerde(){
        for(int i = 0; i < 15; i++){
            if(pivoArray[i].transform.position.x>=-0.02f&&pivoArray[i].transform.position.z>=-0.02f&&pivoArray[i].transform.position.y>=-0.01f&&
                pivoArray[i].transform.position.x<=0.02f&&pivoArray[i].transform.position.z<=0.02f&&pivoArray[i].transform.position.y<=0.02f 
                && (i==0 || i==2 || i==8 || i==14))
                pivoArray[i].transform.parent = pivoTopoVerde.transform;
        }
        pivoTopoVerde.transform.Rotate(0.0f,40.0f,0.0f);
    }

    public void GirarpivoTopoAzul(){
        for(int i = 0; i < 15; i++){
            if(pivoArray[i].transform.position.x>=1.98f&&pivoArray[i].transform.position.z>=-0.02f&&pivoArray[i].transform.position.y>=-0.01f&&
                pivoArray[i].transform.position.x<=2.02f&&pivoArray[i].transform.position.z<=0.02f&&pivoArray[i].transform.position.y<=0.02f 
                && (i==0 || i==2 || i==8 || i==14))
                pivoArray[i].transform.parent = pivoTopoAzul.transform;
        }
        pivoTopoAzul.transform.Rotate(0.0f,40.0f,0.0f);
    }

    public void GirarpivoTopoAmarelo(){
        for(int i = 0; i < 15; i++){
            if(pivoArray[i].transform.position.x>=0.98f&&pivoArray[i].transform.position.z>=1.69f&&pivoArray[i].transform.position.y>=-0.01f&&
                pivoArray[i].transform.position.x<=1.02f&&pivoArray[i].transform.position.z<=1.75f&&pivoArray[i].transform.position.y<=0.02f 
                && (i==0 || i==2 || i==8 || i==14))
                pivoArray[i].transform.parent = pivoTopoAmarelo.transform;
        }
        pivoTopoAmarelo.transform.Rotate(0.0f,40.0f,0.0f);
    }    
}