using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public List<Sphere> spheres;

    public Level(List<Sphere> spheres)
    {
        this.spheres = spheres;
    }

    public void spawn(Camera playerCamera, Font font)
    {
        foreach (Sphere sphere in spheres)
        {
            sphere.spawn(playerCamera, font);
        }
    }
}