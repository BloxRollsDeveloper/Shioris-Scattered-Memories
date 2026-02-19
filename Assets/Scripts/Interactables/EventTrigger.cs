using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
   public UnityEvent unityEvent;
   public GameObject BookOne;

   public void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject == BookOne)
         unityEvent.Invoke();
   }
}
