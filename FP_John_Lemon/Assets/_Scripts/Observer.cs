using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Observer : MonoBehaviour
{
   public Transform player;
   private bool isPlayerInRange;

   public GameEnding gameEnding;

  private void OnTriggerEnter(Collider other)
   {
      if (other.transform == player)
      {
         isPlayerInRange = true;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.transform == player)
      {
         isPlayerInRange = false;
      }
   }

   private void Update()
   {
      if (isPlayerInRange)
      {
         Vector3 direction = player.position - this.transform.position + Vector3.up;
         Ray ray = new Ray(this.transform.position, direction);
         
         Debug.DrawRay(this.transform.position, direction, Color.green, Time.deltaTime, true);
         RaycastHit raycastHit;
         if (Physics.Raycast(ray, out raycastHit))
         {
            if (raycastHit.collider.transform == player)
            {
               gameEnding.CatchPlayer();
            }
         }
      }
   }

   private void OnDrawGizmos()
   {
      //Gizmos.color = Color.red;
      //Gizmos.DrawSphere(transform.position, 1f);
      Gizmos.color = Color.yellow;
      Gizmos.DrawLine(transform.position, player.position + Vector3.up);
      
   }
}
