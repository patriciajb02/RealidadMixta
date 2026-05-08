using System;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using NUnit.Framework;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    public MRUKRoom CurrRoom;
    public MRUKAnchor.SceneLabels Etiquetas;

    public NavMeshSurface Surface;
    
    public GameObject NPC;
    public GameObject NPCInstanciado;

    public bool bSetRoom;

    public Volume V;
    public Vignette Vignette;
    
    private void Start()
    {
        V.profile.TryGet(out Vignette);

    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.J))
        // {
        //         //Reconstruye la maya de navegación, mejor hacerlo lo mínimo posible
        //         // ya que coge todos los objetos que están en ese momento
        //     Surface.BuildNavMesh();
        //     
        // }
        
        if (!MRUK.Instance && !MRUK.Instance.IsInitialized) return;

        
        CurrRoom = MRUK.Instance.GetCurrentRoom();
        if (CurrRoom != null)
        {
            // Ray r = new Ray(RaycastOrigin.transform.position, 
            //                 RaycastOrigin.transform.forward);
            //
            // Debug.DrawRay(RaycastOrigin.transform.position, 
            //               RaycastOrigin.transform.forward * 100, 
            //               Color.red, 0);
            // RaycastHit RH;
            //
            // if (CurrRoom.Raycast(r, 100, new LabelFilter(Etiquetas), out RH, out MRUKAnchor A))
            // {
            //     InfoText.text = "CHOCANDO CON: " + A.Label;
            //
            // }
            
            if (bSetRoom == false)
            {
                bSetRoom = true;
                Surface.BuildNavMesh();

            }
            
            if (!NPCInstanciado)
            {
                //Vector3 v = (Vector3)CurrRoom.GenerateRandomPositionInRoom(0, true);
                //NPCInstanciado = Instantiate(NPC, v, Quaternion.identity);
                Vector3 pos;
                Vector3 normal;
                CurrRoom.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP, 
                                        0, new LabelFilter(MRUKAnchor.SceneLabels.TABLE), 
                                                out pos, out normal);
                NPCInstanciado = Instantiate(NPC, pos, Quaternion.Euler(normal));
                
            }
            
        }


    }
}
