using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class AttackPoints : MonoBehaviour
    {
        [SerializeField] private List<Point> _positions;

        public int Count => _positions.Count;

        public Point GetPointByIndex(int index)
        {
            return _positions[index];
        }
    }
}