using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDestroyable, IFightable
{
    [SerializeField] private int hp = 100;
    [SerializeField] private int bulletsMainCount = 5;
    [SerializeField] private int bulletsAltCount = 3;

    [SerializeField] private float speed = 3;
    [SerializeField] private GameObject bulletMain = null;
    [SerializeField] private GameObject bulletAlt = null;
    private Transform bulletStartPosition = null;
    private GameObject tower = null;

    private Vector3 direction = Vector3.zero;
    private float rotation = 0;
    private float towerRotation = 0;

    private bool fireMain = false;
    private bool fireAlt = false;

    
    private void Awake()
    {
        //MeshRenderer mesh = GetComponent<MeshRenderer>();
        //Material mat = mesh.material;
        tower = transform.GetChild(0).gameObject;
        bulletStartPosition = tower.transform.GetChild(0);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 400, 100), "WASD to move, QE to rotate, mouse left-right click to fire");
        GUI.Label(new Rect(20, 40, 100, 100), "hp: " + hp.ToString());
        GUI.Label(new Rect(20, 60, 100, 100), "ammo: " + bulletsMainCount.ToString() + "/" + bulletsAltCount.ToString());
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

        rotation = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        towerRotation = 2 * Input.GetAxis("Rotate");
    }

    private void FixedUpdate()
    {
        Vector3 deltaPosition = direction * speed * Time.fixedDeltaTime;
        transform.Translate(deltaPosition);

        transform.Rotate(Vector3.up, rotation);
        tower.transform.Rotate(Vector3.up, towerRotation);

        //Debug.Log("Delta position: " + deltaPosition.x.ToString() + ", tower rotate: " + rotation.ToString());

        if (fireMain)
        {
            if (bulletsMainCount > 0)
            {
                Fire(bulletMain);
                bulletsMainCount--;
            }
        }
        if(fireAlt)
        {
            if (bulletsAltCount > 0)
            {
                Fire(bulletAlt);
                bulletsAltCount--;
            }
        }
    }

    private void Fire(GameObject bullet)
    {
        fireMain = false;
        fireAlt = false;
        GameObject bulletInstance = Instantiate(bullet, bulletStartPosition.position, tower.transform.rotation);
    }

    public void Damage(int value)
    {
        hp -= value;
        if(hp <= 0)
        {
            Death();
        }
    }

    public int GetHP()
    {
        return hp;
    }

    private void Death()
    {
        Destroy(gameObject, 0);
    }

    public void AddAmmo(int addMainAmmoCount, int addAltAmmoCount)
    {
        bulletsMainCount += addMainAmmoCount;
        bulletsAltCount += addAltAmmoCount;
    }
}
