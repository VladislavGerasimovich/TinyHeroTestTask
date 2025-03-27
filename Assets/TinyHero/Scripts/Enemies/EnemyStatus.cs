using UnityEngine;

namespace Enemies
{
    public class EnemyStatus : MonoBehaviour
    {
        public Point Point { get; private set; }

        public void Init(Point point)
        {
            Point = point;
        }

        public void ResetPoint()
        {
            Point.AllowUse();
        }
    }
}