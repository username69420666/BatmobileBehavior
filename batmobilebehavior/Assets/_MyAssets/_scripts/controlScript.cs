using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    public characterMovement cr;
    [SerializeField] GameObject[] objects;
    System.Random rand = new System.Random();
    [SerializeField] Sprite[] targetSprites;
    [SerializeField] AudioClip batTransition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioSource.PlayClipAtPoint(batTransition, transform.position);
            objects[0].SetActive(true);
            objects[1].SetActive(true);
            objects[1].GetComponent<SpriteRenderer>().sprite = targetSprites[0];
            objects[2].SetActive(false);
            objects[0].GetComponent<Rigidbody2D>().velocity *= 0;
            cr.soundPlayed = false;
            objects[0].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[0].transform.position.z);
            objects[1].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[1].transform.position.z);
            Vector3 difference = objects[1].transform.position - objects[0].transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
            objects[0].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            cr.behaviour = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioSource.PlayClipAtPoint(batTransition, transform.position);
            objects[0].SetActive(true);
            objects[1].SetActive(true);
            objects[1].GetComponent<SpriteRenderer>().sprite = targetSprites[1];
            objects[2].SetActive(false);
            objects[0].GetComponent<Rigidbody2D>().velocity *= 0;
            cr.soundPlayed = false;
            objects[0].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[0].transform.position.z);
            objects[1].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[1].transform.position.z);
            Vector3 difference = objects[1].transform.position - objects[0].transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 90f;
            objects[0].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            cr.behaviour = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AudioSource.PlayClipAtPoint(batTransition, transform.position);
            objects[0].SetActive(true);
            objects[1].SetActive(true);
            objects[1].GetComponent<SpriteRenderer>().sprite = targetSprites[0];
            objects[2].SetActive(false);
            objects[0].GetComponent<Rigidbody2D>().velocity *= 0;
            cr.soundPlayed = false;
            objects[0].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[0].transform.position.z);
            objects[1].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[1].transform.position.z);
            Vector3 difference = objects[1].transform.position - objects[0].transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 90f;
            objects[0].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            cr.behaviour = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AudioSource.PlayClipAtPoint(batTransition, transform.position);
            objects[0].SetActive(true);
            objects[1].SetActive(true);
            objects[1].GetComponent<SpriteRenderer>().sprite = targetSprites[0];
            objects[2].SetActive(true);
            objects[0].GetComponent<Rigidbody2D>().velocity *= 0;
            cr.soundPlayed = false;
            objects[0].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[0].transform.position.z);
            objects[1].transform.position = new Vector3 (rand.Next(-8, 9), rand.Next(-4, 5), objects[1].transform.position.z);
            objects[2].transform.position = new Vector3 ((objects[0].transform.position.x + objects[1].transform.position.x)/2, (objects[0].transform.position.y + objects[1].transform.position.y)/2, objects[2].transform.position.z);
            Vector3 difference = objects[1].transform.position - objects[0].transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 85f;
            objects[0].transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            cr.behaviour = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cr.behaviour = 0;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }
        }
    }
}
