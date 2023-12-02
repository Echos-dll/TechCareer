using System;
using UnityEngine;

namespace Inheritance
{
    public abstract class Vehicle : MonoBehaviour
    {
        protected int topSpeed = 300000;
        protected int acceleration;
        protected string brandName;

        protected virtual void Awake()
        {
            Debug.Log($"Top speed of {brandName} is {topSpeed} km/h");
        }

        protected abstract void Brake();
    }
    
    public class Car : Vehicle
    {
        protected override void Awake()
        {
            base.Awake();
            topSpeed = 200;
            acceleration = 10;
            brandName = "BMW";
        }

        protected override void Brake()
        {
            
        }
    }
    
    public class Truck : Vehicle
    {
        protected override void Awake()
        {
            base.Awake();
            topSpeed = 100;
            acceleration = 5;
            brandName = "BMC";
        }

        protected override void Brake()
        {
            
        }
    }

    public class Bicycle : Vehicle
    {
        protected override void Awake()
        {
            base.Awake();
            topSpeed = 5;
        }

        protected override void Brake()
        {
            
        }
    }
}