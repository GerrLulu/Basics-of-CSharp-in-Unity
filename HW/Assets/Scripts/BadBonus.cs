using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation, ICloneable, IComparable<BadBonus>
    {
        private float _lengthFly;
        private float _speedRotation;

        public delegate void CaughtPlayerChange(int value);
        public event CaughtPlayerChange CaughtPlayer;

        private void Awake()
        {
            _lengthFly = Random.Range(1.0f, 2.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            CaughtPlayer?.Invoke(5);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }

        public object Clone()
        {
            return Instantiate(gameObject, new Vector3(6.84f, 0.6f, 0.44f),
                transform.rotation, transform.parent);
        }

        public int CompareTo(BadBonus other)
        {
            return name.CompareTo(other.name);
        }
    }
}