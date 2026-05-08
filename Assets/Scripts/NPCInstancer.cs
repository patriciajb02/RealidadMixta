using UnityEngine;

public class NPCInstancer : MonoBehaviour
{
    public GameObject player;
    public GameObject Mascota;
    public GameObject MascotaPosicion;
    
    void Start()
    {
        player = GameObject.Find("OVRCameraRig");
        
    }


    void Update()
    {
        Vector3 v = player.transform.position - transform.position;

            //Magnitud en la que es interactuable
        if (v.magnitude <= 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                    //Instanciar al NPC / bicho / lo que sea
                Instantiate(Mascota, MascotaPosicion.transform.position, Quaternion.identity);

            }
            
        }
        
    }
    
}
