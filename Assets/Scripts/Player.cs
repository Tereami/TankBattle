using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private GameObject bulletMain = null;
    [SerializeField] private GameObject bulletAlt = null;
    [SerializeField] private Transform bulletStartPosition = null;
    private GameObject tower = null;

    private Vector3 direction = Vector3.zero;
    private Quaternion rotation = Quaternion.identity;
    private Vector3 towerRotation = Vector3.zero;

    private bool fireMain = false;
    private bool fireAlt = false;

    
    private void Awake()
    {
        //MeshRenderer mesh = GetComponent<MeshRenderer>();
        //Material mat = mesh.material;
        tower = transform.GetChild(0).gameObject;
    }
    


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            fireMain = true;
        }
        else if(Input.GetMouseButtonDown(1))
        {
            fireAlt = true;
        }

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        rotation.y = Input.GetAxis("Rotate");

    }

    private void FixedUpdate()
    {
        Vector3 deltaPosition = direction * speed * Time.fixedDeltaTime;
        transform.Translate(deltaPosition);

        //tower.transform.ro

        Debug.Log("Delta position: " + deltaPosition.x.ToString() + ", tower rotate: " + rotation.ToString());

        if (fireMain)
        {
            Fire(bulletMain);
        }
        else if(fireAlt)
        {
            Fire(bulletAlt);
        }
    }

    private void Fire(GameObject bullet)
    {
        fireMain = false;
        fireAlt = false;
        GameObject bulletInstance = Instantiate(bullet, bulletStartPosition.position, Quaternion.identity);
        bulletInstance.transform.Rotate(1, 0, 0);
    }
}
