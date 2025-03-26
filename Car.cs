﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarType Type { get; set; }
        public Car(string make, string model, int year, CarType type)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
        }

        public override string ToString()
        {
            return $"Maker: {Make}, Model: {Model}, Year: {Year}, Type: {Type}";
        }
    }
}
