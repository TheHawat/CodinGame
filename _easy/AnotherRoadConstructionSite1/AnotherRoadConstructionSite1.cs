//https://www.codingame.com/ide/puzzle/another-road-construction-site---1
using System;
using System.Collections.Generic;
class Solution
{
    static void Main() {
        float RoadLength = float.Parse(Console.ReadLine());
        int ZoneQuantity = int.Parse(Console.ReadLine());
        float CurrentSpeed = 130f / 60f;
        float MaxTime = RoadLength / CurrentSpeed;
        float PreviousChange = 0;
        float RealTime = 0;
        for (int i = 0; i < ZoneQuantity; i++) {
            string[] inputs = Console.ReadLine().Split(' ');
            float zoneKm = float.Parse(inputs[0]);
            float zoneSpeed = float.Parse(inputs[1]);
            RealTime += (zoneKm - PreviousChange) / CurrentSpeed;
            PreviousChange = zoneKm;
            CurrentSpeed = zoneSpeed / 60;
        }
        RealTime += (RoadLength - PreviousChange) / CurrentSpeed;
        Console.WriteLine(Math.Round(RealTime - MaxTime));
    }
}