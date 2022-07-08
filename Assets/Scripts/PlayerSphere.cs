using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSphere : MonoBehaviour
{
    [SerializeField] 
    float speed = 5;
    Vector3 force;
    Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        force = new Vector3(0,0,0);
        ChangeColor();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Bouge la boule 
        force.x = Input.GetAxisRaw("Horizontal") * speed; 
        force.z = Input.GetAxisRaw("Vertical") * speed;
        rb.AddForce(force);
    }

    // Quand le joueur rentre en collision avec un objet, il regarde s'ils ont la même couleur et si c'est le cas, il détruit l'objet
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Item")) {
            if(other.GetComponent<MeshRenderer>().sharedMaterial == GetComponent<MeshRenderer>().sharedMaterial) {
                other.GetComponent<Item>().DestroyItem();
                if(Item.allItems.Count > 0) 
                    ChangeColor();
                else
                    GameMaster.Win();
            } else 
                GameMaster.RemoveLife();
        }
    }

    void ChangeColor() {
        GetComponent<MeshRenderer>().sharedMaterial = Item.allItems[Random.Range(0,Item.allItems.Count -1)].GetComponent<MeshRenderer>().sharedMaterial;
    }
}
