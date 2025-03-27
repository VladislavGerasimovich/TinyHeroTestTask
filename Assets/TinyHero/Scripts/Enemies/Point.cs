using System;
using UnityEngine;

namespace Enemies
{
    public class Point : MonoBehaviour
    {
        public event Action Free;

        public bool IsBusy { get; private set; }

        public void AllowUse()
        {
            IsBusy = false;
            Free?.Invoke();
        }

        public void ProhibitUse()
        {
            IsBusy = true;
        }
    }
}