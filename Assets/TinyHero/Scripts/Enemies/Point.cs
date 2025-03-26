using UnityEngine;

namespace Enemies
{
    public class Point : MonoBehaviour
    {
        public bool IsBusy { get; private set; }

        public void ProhibitUse()
        {
            IsBusy = false;
        }

        public void AllowUse()
        {
            IsBusy = true;
        }
    }
}