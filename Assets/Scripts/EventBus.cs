using System;
using System.Collections.Generic;
using UnityEngine;


public static class EventBus<T>//singleton bir class static ile olsuturuldugu icin new() kullanilarak baska instance i olusturulamaz
{
        private static readonly List<Action<T>> listeners = new();

        public static void Subscribe(Action<T> listener)
        {
                listeners.Add(listener);//listeners listesine subscribe olarak gelen event i ekle
        }
        public static void Unsubcribe(Action<T> listener) => listeners.Remove(listener);//usttekinin kisa yazilisi

        public static void Invoke(T evt)
        {
                foreach(var listener in listeners)
                        listener.Invoke(evt);// invoke un icine yazilan sey aslinda parametre
                // *** listener diye belirledigimiz sey ise list in bir elemani ve bir fonksiyon aslinda!!!!
        }
        
        
}
