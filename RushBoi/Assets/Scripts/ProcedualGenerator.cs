using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedualGenerator : MonoBehaviour
{
    public GameObject chunk1;
    public GameObject chunk2;
    public GameObject chunk3;
    public GameObject chunkPos;
    public GameObject oldChunk;

    
    

    ArrayList chunks = new ArrayList();


    // Start is called before the first frame update
    void Start()
    {
        chunks.Add(chunk1);
        chunks.Add(chunk2);
        chunks.Add(chunk3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        int rand = Random.Range(0, chunks.Count);
        GameObject objectToPlace = (GameObject) chunks[rand];
        print(rand);

        //chunkPos = objectToPlace;


        if (collision.transform.tag == "SpawnCollider")
        {

            print(oldChunk);
            Destroy(oldChunk);
            oldChunk = collision.gameObject.transform.parent.gameObject;
            
            GameObject newChunk = Instantiate(objectToPlace, new Vector2(chunkPos.transform.position.x + 23.5f, chunkPos.transform.position.y), Quaternion.identity);

            chunkPos = newChunk;
        }

    }


}
