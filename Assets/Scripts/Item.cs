using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    List<Material> allMaterials;

    public static List<Item> allItems = new List<Item>();


    // Start is called before the first frame update
    void Awake()
    {
        
        GetComponent<MeshRenderer>().material = allMaterials[(int)Random.Range(0,allMaterials.Count)];
        transform.position = new Vector3(Random.Range(-4, 4), 0.4f, Random.Range(-4, 4));
        transform.Rotate(Vector3.forward * Random.Range(0,180));
        foreach(Item item in allItems) {
            if(transform.position == item.transform.position) {
                transform.position = new Vector3(Random.Range(-4, 4), 0.4f, Random.Range(-4, 4));
            }
        }
        allItems.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.left + Vector3.up) * rotationSpeed * Time.deltaTime);
    }

    public void DestroyItem() {
        allItems.Remove(this);
        Destroy(gameObject);
    }
}
