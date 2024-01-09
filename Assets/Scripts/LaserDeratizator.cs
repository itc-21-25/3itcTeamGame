using UnityEngine;

public class LaserDeratizator : MonoBehaviour
{
    
    GameManager _GameManager;
    public float speed = 20f;
    [SerializeField] Vector3 startPos;
    [SerializeField] private GameObject Laser;

    public bool hitPlayer = false;
    public bool startLaser = false;
    
    public void StartLaser()
    { 
        Debug.Log("Ano už jedu.....");

        startLaser = true;
        Debug.Log("Ano už jeduddd....."+ startLaser);
    }

    private void Awake()
    {
        startPos = transform.position;
    }


    void Update()
    {
        if (!hitPlayer && startLaser)
        {
            Laser.transform.position += Vector3.right * speed * Time.deltaTime;

           
        }
    }

    public void ResetLaser()
    {
        Debug.Log("Laser jsem dal na zacatek");
        Laser.transform.position = startPos;
        hitPlayer = false;
        startLaser = false;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(!hitPlayer && other.tag == "Player")
        {
            hitPlayer = true;
           
            Debug.Log("Jsi kunda a chcípl si.");
            
            
           

        }
    }

    

}
