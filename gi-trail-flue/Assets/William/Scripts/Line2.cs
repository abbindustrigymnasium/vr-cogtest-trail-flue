using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line2 : MonoBehaviour
{
    public Camera cam;
    public Material myMat;
    public int sphereTime = -1;

    public GameObject spherePrefab;
    public string lightColorHEX;
    public string darkColorHEX;
    public string lineColorHEX;
    Color LightColor;
    Color DarkColor;
    Color lineColor;

    public enum ColorType
      {
        Light,
        Dark
        }

        public List<SphereValues[,]> ActiveSphereList = new List<SphereValues[,]>
    {
        new SphereValues[,]
        {
            {
                new SphereValues(8,72,65,ColorType.Light,"1"),
                new SphereValues(8,120,75,ColorType.Light,"2"), 
                new SphereValues(8,210,70,ColorType.Light,"3"), 
                new SphereValues(8,164,95,ColorType.Light,"4"), 
                new SphereValues(8,280,70,ColorType.Light,"5"),
                new SphereValues(8,340,42,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,100,90,ColorType.Light,"1"),
                new SphereValues(8,72,55,ColorType.Light,"2"), 
                new SphereValues(8,248,75,ColorType.Light,"3"), 
                new SphereValues(8,216,95,ColorType.Light,"4"), 
                new SphereValues(8,2,70,ColorType.Light,"5"),
                new SphereValues(8,154,42,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,263,80,ColorType.Light,"1"),
                new SphereValues(8,156,60,ColorType.Light,"2"), 
                new SphereValues(8,6,63,ColorType.Light,"3"), 
                new SphereValues(8,200,115,ColorType.Light,"4"), 
                new SphereValues(8,45,55,ColorType.Light,"5"),
                new SphereValues(8,169,54,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,200,92,ColorType.Light,"1"),
                new SphereValues(8,15,69,ColorType.Light,"2"), 
                new SphereValues(8,80,95,ColorType.Light,"3"), 
                new SphereValues(8,281,85,ColorType.Light,"4"), 
                new SphereValues(8,165,87,ColorType.Light,"5"),
                new SphereValues(8,122,50,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,314,75,ColorType.Light,"1"),
                new SphereValues(8,106,85,ColorType.Light,"2"), 
                new SphereValues(8,194,73,ColorType.Light,"3"), 
                new SphereValues(8,297,78,ColorType.Light,"4"), 
                new SphereValues(8,126,88,ColorType.Light,"5"),
                new SphereValues(8,236,64,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,162,86,ColorType.Light,"1"),
                new SphereValues(8,106,71,ColorType.Light,"2"), 
                new SphereValues(8,203,74,ColorType.Light,"3"), 
                new SphereValues(8,50,90,ColorType.Light,"4"), 
                new SphereValues(8,293,120,ColorType.Light,"5"),
                new SphereValues(8,327,88,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,297,67,ColorType.Light,"1"),
                new SphereValues(8,157,100,ColorType.Light,"2"), 
                new SphereValues(8,27,89,ColorType.Light,"3"), 
                new SphereValues(8,243,112,ColorType.Light,"4"), 
                new SphereValues(8,128,45,ColorType.Light,"5"),
                new SphereValues(8,211,110,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,304,54,ColorType.Light,"1"),
                new SphereValues(8,60,71,ColorType.Light,"2"), 
                new SphereValues(8,335,92,ColorType.Light,"3"), 
                new SphereValues(8,97,96,ColorType.Light,"4"), 
                new SphereValues(8,173,86,ColorType.Light,"5"),
                new SphereValues(8,117,83,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,92,66,ColorType.Light,"1"),
                new SphereValues(8,248,97,ColorType.Light,"2"), 
                new SphereValues(8,83,53,ColorType.Light,"3"), 
                new SphereValues(8,121,81,ColorType.Light,"4"), 
                new SphereValues(8,200,77,ColorType.Light,"5"),
                new SphereValues(8,290,96,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,123,70,ColorType.Light,"1"),
                new SphereValues(8,110,66,ColorType.Light,"2"), 
                new SphereValues(8,357,79,ColorType.Light,"3"), 
                new SphereValues(8,315,50,ColorType.Light,"4"), 
                new SphereValues(8,224,104,ColorType.Light,"5"),
                new SphereValues(8,99,101,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,314,91,ColorType.Light,"1"),
                new SphereValues(8,221,87,ColorType.Light,"2"), 
                new SphereValues(8,113,87,ColorType.Light,"3"), 
                new SphereValues(8,337,110,ColorType.Light,"4"), 
                new SphereValues(8,190,120,ColorType.Light,"5"),
                new SphereValues(8,53,54,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,12,79,ColorType.Light,"1"),
                new SphereValues(8,76,68,ColorType.Light,"2"), 
                new SphereValues(8,296,114,ColorType.Light,"3"), 
                new SphereValues(8,188,67,ColorType.Light,"4"), 
                new SphereValues(8,335,99,ColorType.Light,"5"),
                new SphereValues(8,226,67,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,163,48,ColorType.Light,"1"),
                new SphereValues(8,74,57,ColorType.Light,"2"), 
                new SphereValues(8,114,68,ColorType.Light,"3"), 
                new SphereValues(8,247,100,ColorType.Light,"4"), 
                new SphereValues(8,307,108,ColorType.Light,"5"),
                new SphereValues(8,252,89,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,294,69,ColorType.Light,"1"),
                new SphereValues(8,203,55,ColorType.Light,"2"), 
                new SphereValues(8,125,47,ColorType.Light,"3"), 
                new SphereValues(8,10,91,ColorType.Light,"4"), 
                new SphereValues(8,352,60,ColorType.Light,"5"),
                new SphereValues(8,176,76,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,174,110,ColorType.Light,"1"),
                new SphereValues(8,49,69,ColorType.Light,"2"), 
                new SphereValues(8,267,106,ColorType.Light,"3"), 
                new SphereValues(8,335,98,ColorType.Light,"4"), 
                new SphereValues(8,90,95,ColorType.Light,"5"),
                new SphereValues(8,220,85,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,300,96,ColorType.Light,"1"),
                new SphereValues(8,253,83,ColorType.Light,"2"), 
                new SphereValues(8,185,63,ColorType.Light,"3"), 
                new SphereValues(8,133,70,ColorType.Light,"4"), 
                new SphereValues(8,93,58,ColorType.Light,"5"),
                new SphereValues(8,291,86,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,168,80,ColorType.Light,"1"),
                new SphereValues(8,38,84,ColorType.Light,"2"), 
                new SphereValues(8,244,52,ColorType.Light,"3"), 
                new SphereValues(8,280,117,ColorType.Light,"4"), 
                new SphereValues(8,76,56,ColorType.Light,"5"),
                new SphereValues(8,125,83,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,345,78,ColorType.Light,"1"),
                new SphereValues(8,256,99,ColorType.Light,"2"), 
                new SphereValues(8,12,79,ColorType.Light,"3"), 
                new SphereValues(8,137,52,ColorType.Light,"4"), 
                new SphereValues(8,180,87,ColorType.Light,"5"),
                new SphereValues(8,285,85,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,149,118,ColorType.Light,"1"),
                new SphereValues(8,203,79,ColorType.Light,"2"), 
                new SphereValues(8,9,71,ColorType.Light,"3"), 
                new SphereValues(8,327,92,ColorType.Light,"4"), 
                new SphereValues(8,256,118,ColorType.Light,"5"),
                new SphereValues(8,65,112,ColorType.Light,"6"), 
            },
            {
                new SphereValues(8,104,42,ColorType.Light,"1"),
                new SphereValues(8,284,64,ColorType.Light,"2"), 
                new SphereValues(8,122,104,ColorType.Light,"3"), 
                new SphereValues(8,177,118,ColorType.Light,"4"), 
                new SphereValues(8,244,70,ColorType.Light,"5"),
                new SphereValues(8,65,57,ColorType.Light,"6"), 
            },
        },
        new SphereValues[,]
        {
            {
                new SphereValues(8,72,65,ColorType.Light,"1"),
                new SphereValues(8,120,75,ColorType.Dark,"2"), 
                new SphereValues(8,210,70,ColorType.Light,"3"), 
                new SphereValues(8,164,95,ColorType.Dark,"4"), 
                new SphereValues(8,280,70,ColorType.Light,"5"),
                new SphereValues(8,340,42,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,100,90,ColorType.Light,"1"),
                new SphereValues(8,72,55,ColorType.Dark,"2"), 
                new SphereValues(8,248,75,ColorType.Light,"3"), 
                new SphereValues(8,216,95,ColorType.Dark,"4"), 
                new SphereValues(8,2,70,ColorType.Light,"5"),
                new SphereValues(8,154,42,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,263,80,ColorType.Light,"1"),
                new SphereValues(8,156,60,ColorType.Dark,"2"), 
                new SphereValues(8,6,63,ColorType.Light,"3"), 
                new SphereValues(8,200,115,ColorType.Dark,"4"), 
                new SphereValues(8,45,55,ColorType.Light,"5"),
                new SphereValues(8,169,54,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,200,92,ColorType.Light,"1"),
                new SphereValues(8,15,69,ColorType.Dark,"2"), 
                new SphereValues(8,80,95,ColorType.Light,"3"), 
                new SphereValues(8,281,85,ColorType.Dark,"4"), 
                new SphereValues(8,165,87,ColorType.Light,"5"),
                new SphereValues(8,122,50,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,314,75,ColorType.Light,"1"),
                new SphereValues(8,106,85,ColorType.Dark,"2"), 
                new SphereValues(8,194,73,ColorType.Light,"3"), 
                new SphereValues(8,297,78,ColorType.Dark,"4"), 
                new SphereValues(8,126,88,ColorType.Light,"5"),
                new SphereValues(8,236,64,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,162,86,ColorType.Light,"1"),
                new SphereValues(8,106,71,ColorType.Dark,"2"), 
                new SphereValues(8,203,74,ColorType.Light,"3"), 
                new SphereValues(8,50,90,ColorType.Dark,"4"), 
                new SphereValues(8,293,120,ColorType.Light,"5"),
                new SphereValues(8,327,88,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,297,67,ColorType.Light,"1"),
                new SphereValues(8,157,100,ColorType.Dark,"2"), 
                new SphereValues(8,27,89,ColorType.Light,"3"), 
                new SphereValues(8,243,112,ColorType.Dark,"4"), 
                new SphereValues(8,128,45,ColorType.Light,"5"),
                new SphereValues(8,211,110,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,304,54,ColorType.Light,"1"),
                new SphereValues(8,60,71,ColorType.Dark,"2"), 
                new SphereValues(8,335,92,ColorType.Light,"3"), 
                new SphereValues(8,97,96,ColorType.Dark,"4"), 
                new SphereValues(8,173,86,ColorType.Light,"5"),
                new SphereValues(8,117,83,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,92,66,ColorType.Light,"1"),
                new SphereValues(8,248,97,ColorType.Dark,"2"), 
                new SphereValues(8,83,53,ColorType.Light,"3"), 
                new SphereValues(8,121,81,ColorType.Dark,"4"), 
                new SphereValues(8,200,77,ColorType.Light,"5"),
                new SphereValues(8,290,96,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,123,70,ColorType.Light,"1"),
                new SphereValues(8,110,66,ColorType.Dark,"2"), 
                new SphereValues(8,357,79,ColorType.Light,"3"), 
                new SphereValues(8,315,50,ColorType.Dark,"4"), 
                new SphereValues(8,224,104,ColorType.Light,"5"),
                new SphereValues(8,99,101,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,314,91,ColorType.Light,"1"),
                new SphereValues(8,221,87,ColorType.Dark,"2"), 
                new SphereValues(8,113,87,ColorType.Light,"3"), 
                new SphereValues(8,337,110,ColorType.Dark,"4"), 
                new SphereValues(8,190,120,ColorType.Light,"5"),
                new SphereValues(8,53,54,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,12,79,ColorType.Light,"1"),
                new SphereValues(8,76,68,ColorType.Dark,"2"), 
                new SphereValues(8,296,114,ColorType.Light,"3"), 
                new SphereValues(8,188,67,ColorType.Dark,"4"), 
                new SphereValues(8,335,99,ColorType.Light,"5"),
                new SphereValues(8,226,67,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,163,48,ColorType.Light,"1"),
                new SphereValues(8,74,57,ColorType.Dark,"2"), 
                new SphereValues(8,114,68,ColorType.Light,"3"), 
                new SphereValues(8,247,100,ColorType.Dark,"4"), 
                new SphereValues(8,307,108,ColorType.Light,"5"),
                new SphereValues(8,252,89,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,294,69,ColorType.Light,"1"),
                new SphereValues(8,203,55,ColorType.Dark,"2"), 
                new SphereValues(8,125,47,ColorType.Light,"3"), 
                new SphereValues(8,10,91,ColorType.Dark,"4"), 
                new SphereValues(8,352,60,ColorType.Light,"5"),
                new SphereValues(8,176,76,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,174,110,ColorType.Light,"1"),
                new SphereValues(8,49,69,ColorType.Dark,"2"), 
                new SphereValues(8,267,106,ColorType.Light,"3"), 
                new SphereValues(8,335,98,ColorType.Dark,"4"), 
                new SphereValues(8,90,95,ColorType.Light,"5"),
                new SphereValues(8,220,85,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,300,96,ColorType.Light,"1"),
                new SphereValues(8,253,83,ColorType.Dark,"2"), 
                new SphereValues(8,185,63,ColorType.Light,"3"), 
                new SphereValues(8,133,70,ColorType.Dark,"4"), 
                new SphereValues(8,93,58,ColorType.Light,"5"),
                new SphereValues(8,291,86,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,168,80,ColorType.Light,"1"),
                new SphereValues(8,38,84,ColorType.Dark,"2"), 
                new SphereValues(8,244,52,ColorType.Light,"3"), 
                new SphereValues(8,280,117,ColorType.Dark,"4"), 
                new SphereValues(8,76,56,ColorType.Light,"5"),
                new SphereValues(8,125,83,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,345,78,ColorType.Light,"1"),
                new SphereValues(8,256,99,ColorType.Dark,"2"), 
                new SphereValues(8,12,79,ColorType.Light,"3"), 
                new SphereValues(8,137,52,ColorType.Dark,"4"), 
                new SphereValues(8,180,87,ColorType.Light,"5"),
                new SphereValues(8,285,85,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,149,118,ColorType.Light,"1"),
                new SphereValues(8,203,79,ColorType.Dark,"2"), 
                new SphereValues(8,9,71,ColorType.Light,"3"), 
                new SphereValues(8,327,92,ColorType.Dark,"4"), 
                new SphereValues(8,256,118,ColorType.Light,"5"),
                new SphereValues(8,65,112,ColorType.Dark,"6"), 
            },
            {
                new SphereValues(8,104,42,ColorType.Light,"1"),
                new SphereValues(8,284,64,ColorType.Dark,"2"), 
                new SphereValues(8,122,104,ColorType.Light,"3"), 
                new SphereValues(8,177,118,ColorType.Dark,"4"), 
                new SphereValues(8,244,70,ColorType.Light,"5"),
                new SphereValues(8,65,57,ColorType.Dark,"6"), 
            },
        },
        new SphereValues[,]
        {
            {
                new SphereValues(8,72,65,ColorType.Light ,"1"),
                new SphereValues(8,120,75,ColorType.Light,"A"), 
                new SphereValues(8,210,70,ColorType.Light,"2"), 
                new SphereValues(8,164,95,ColorType.Light,"B"), 
                new SphereValues(8,280,70,ColorType.Light,"3"),
                new SphereValues(8,340,42,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,100,90,ColorType.Light,"1"),
                new SphereValues(8,72,55,ColorType.Light ,"A"), 
                new SphereValues(8,248,75,ColorType.Light,"2"), 
                new SphereValues(8,216,95,ColorType.Light,"B"), 
                new SphereValues(8,2,70,ColorType.Light  ,"3"),
                new SphereValues(8,154,42,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,263,80,ColorType.Light ,"1"),
                new SphereValues(8,156,60,ColorType.Light ,"A"), 
                new SphereValues(8,6,63,ColorType.Light   ,"2"), 
                new SphereValues(8,200,115,ColorType.Light,"B"), 
                new SphereValues(8,45,55,ColorType.Light  ,"3"),
                new SphereValues(8,169,54,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,200,92,ColorType.Light,"1"),
                new SphereValues(8,15,69,ColorType.Light ,"A"), 
                new SphereValues(8,80,95,ColorType.Light ,"2"), 
                new SphereValues(8,281,85,ColorType.Light,"B"), 
                new SphereValues(8,165,87,ColorType.Light,"3"),
                new SphereValues(8,122,50,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,314,75,ColorType.Light,"1"),
                new SphereValues(8,106,85,ColorType.Light,"A"), 
                new SphereValues(8,194,73,ColorType.Light,"2"), 
                new SphereValues(8,297,78,ColorType.Light,"B"), 
                new SphereValues(8,126,88,ColorType.Light,"3"),
                new SphereValues(8,236,64,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,162,86,ColorType.Light ,"1"),
                new SphereValues(8,106,71,ColorType.Light ,"A"), 
                new SphereValues(8,203,74,ColorType.Light ,"2"), 
                new SphereValues(8,50,90,ColorType.Light  ,"B"), 
                new SphereValues(8,293,120,ColorType.Light,"3"),
                new SphereValues(8,327,88,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,297,67,ColorType.Light ,"1"),
                new SphereValues(8,157,100,ColorType.Light,"A"), 
                new SphereValues(8,27,89,ColorType.Light  ,"2"), 
                new SphereValues(8,243,112,ColorType.Light,"B"), 
                new SphereValues(8,128,45,ColorType.Light ,"3"),
                new SphereValues(8,211,110,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,304,54,ColorType.Light,"1"),
                new SphereValues(8,60,71,ColorType.Light ,"A"), 
                new SphereValues(8,335,92,ColorType.Light,"2"), 
                new SphereValues(8,97,96,ColorType.Light ,"B"), 
                new SphereValues(8,173,86,ColorType.Light,"3"),
                new SphereValues(8,117,83,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,92,66,ColorType.Light ,"1"),
                new SphereValues(8,248,97,ColorType.Light,"A"), 
                new SphereValues(8,83,53,ColorType.Light ,"2"), 
                new SphereValues(8,121,81,ColorType.Light,"B"), 
                new SphereValues(8,200,77,ColorType.Light,"3"),
                new SphereValues(8,290,96,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,123,70,ColorType.Light ,"1"),
                new SphereValues(8,110,66,ColorType.Light ,"A"), 
                new SphereValues(8,357,79,ColorType.Light ,"2"), 
                new SphereValues(8,315,50,ColorType.Light ,"B"), 
                new SphereValues(8,224,104,ColorType.Light,"3"),
                new SphereValues(8,99,101,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,314,91,ColorType.Light ,"1"),
                new SphereValues(8,221,87,ColorType.Light ,"A"), 
                new SphereValues(8,113,87,ColorType.Light ,"2"), 
                new SphereValues(8,337,110,ColorType.Light,"B"), 
                new SphereValues(8,190,120,ColorType.Light,"3"),
                new SphereValues(8,53,54,ColorType.Light  ,"C"), 
            },
            {
                new SphereValues(8,12,79,ColorType.Light  ,"1"),
                new SphereValues(8,76,68,ColorType.Light  ,"A"), 
                new SphereValues(8,296,114,ColorType.Light,"2"), 
                new SphereValues(8,188,67,ColorType.Light ,"B"), 
                new SphereValues(8,335,99,ColorType.Light ,"3"),
                new SphereValues(8,226,67,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,163,48,ColorType.Light ,"1"),
                new SphereValues(8,74,57,ColorType.Light  ,"A"), 
                new SphereValues(8,114,68,ColorType.Light ,"2"), 
                new SphereValues(8,247,100,ColorType.Light,"B"), 
                new SphereValues(8,307,108,ColorType.Light,"3"),
                new SphereValues(8,252,89,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,294,69,ColorType.Light,"1"),
                new SphereValues(8,203,55,ColorType.Light,"A"), 
                new SphereValues(8,125,47,ColorType.Light,"2"), 
                new SphereValues(8,10,91,ColorType.Light ,"B"), 
                new SphereValues(8,352,60,ColorType.Light,"3"),
                new SphereValues(8,176,76,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,174,110,ColorType.Light,"1"),
                new SphereValues(8,49,69,ColorType.Light  ,"A"), 
                new SphereValues(8,267,106,ColorType.Light,"2"), 
                new SphereValues(8,335,98,ColorType.Light ,"B"), 
                new SphereValues(8,90,95,ColorType.Light  ,"3"),
                new SphereValues(8,220,85,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,300,96,ColorType.Light,"1"),
                new SphereValues(8,253,83,ColorType.Light,"A"), 
                new SphereValues(8,185,63,ColorType.Light,"2"), 
                new SphereValues(8,133,70,ColorType.Light,"B"), 
                new SphereValues(8,93,58,ColorType.Light ,"3"),
                new SphereValues(8,291,86,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,168,80,ColorType.Light ,"1"),
                new SphereValues(8,38,84,ColorType.Light  ,"A"), 
                new SphereValues(8,244,52,ColorType.Light ,"2"), 
                new SphereValues(8,280,117,ColorType.Light,"B"), 
                new SphereValues(8,76,56,ColorType.Light  ,"3"),
                new SphereValues(8,125,83,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,345,78,ColorType.Light,"1"),
                new SphereValues(8,256,99,ColorType.Light,"A"), 
                new SphereValues(8,12,79,ColorType.Light ,"2"), 
                new SphereValues(8,137,52,ColorType.Light,"B"), 
                new SphereValues(8,180,87,ColorType.Light,"3"),
                new SphereValues(8,285,85,ColorType.Light,"C"), 
            },
            {
                new SphereValues(8,149,118,ColorType.Light,"1"),
                new SphereValues(8,203,79,ColorType.Light ,"A"), 
                new SphereValues(8,9,71,ColorType.Light   ,"2"), 
                new SphereValues(8,327,92,ColorType.Light ,"B"), 
                new SphereValues(8,256,118,ColorType.Light,"3"),
                new SphereValues(8,65,112,ColorType.Light ,"C"), 
            },
            {
                new SphereValues(8,104,42,ColorType.Light ,"1"),
                new SphereValues(8,284,64,ColorType.Light ,"A"), 
                new SphereValues(8,122,104,ColorType.Light,"2"), 
                new SphereValues(8,177,118,ColorType.Light,"B"), 
                new SphereValues(8,244,70,ColorType.Light ,"3"),
                new SphereValues(8,65,57,ColorType.Light  ,"C"), 
            },
        },
    };

    private List<string> path = new List<string>();
    private List<string> pairs = new List<string>();

    private string s1;
    private string s2 = "";
    private bool cont = true;
    private bool done = false;

    void Start()
    {
        ColorUtility.TryParseHtmlString(lightColorHEX, out LightColor);
        ColorUtility.TryParseHtmlString(darkColorHEX, out DarkColor);
        ColorUtility.TryParseHtmlString(lineColorHEX, out lineColor);
        sphereTime = -1;
        GameEvents2.current.onNewGame += OnNewGame;
        GameEvents2.current.onNewMode += OnNewMode;
        GameEvents2.current.onInstructionDone += OnInstructionDone;
    }

    void Update()
    {
        handleMouse();
    }

    float mod(float x, float m) {
        float r = x % m;
        return r < 0 ? r + m : r;
    }

    private void drawLine(string s1, string s2)
    {
        Vector3 start = GameObject.Find(s1).transform.position;
        Vector3 end = GameObject.Find(s2).transform.position;

        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        go.name = "Line";
        go.tag = "line";

        lr.material = myMat;
        lr.material.SetColor("_Color", lineColor);

    //Central angle between current start and end points
        float deltaSigma = Mathf.Acos(Vector3.Dot(start.normalized, end.normalized));

        //Angle between each point on the line
        float angleToNextPoint = Mathf.Deg2Rad;

        lr.positionCount = Mathf.RoundToInt(deltaSigma / angleToNextPoint); 

        //Sets start point so that the line is always drawn counterclockwise along the horizontal circle
       if (mod(Mathf.Atan2(end.z,end.x) - Mathf.Atan2(start.z,start.x), 2 * Mathf.PI) > Mathf.PI)
            {
                (start, end) = (end, start);
            }

        //Radial distance for start and end point
        float rhoStart = Mathf.Sqrt(Mathf.Pow(start.x,2f) + Mathf.Pow(start.y,2f) + Mathf.Pow(start.z,2f));
        float rhoEnd = Mathf.Sqrt(Mathf.Pow(end.x,2f) + Mathf.Pow(end.y,2f) + Mathf.Pow(end.z,2f));
        float totalPosition = (float)lr.positionCount;

        lr.SetPosition(0, start);
        lr.SetPosition((lr.positionCount - 1), end);
        for (int i = 1; i < (lr.positionCount - 1); i++) 
        {
            
            //Azimuthal angle for current start point
            float thetaStart = Mathf.Atan2(start.z,start.x);

            //Polar angle for current start point and end point
            float phiStart = Mathf.Atan2(Mathf.Sqrt(Mathf.Pow(start.x, 2f) + Mathf.Pow(start.z, 2f)), start.y);
            float phiEnd = Mathf.Atan2(Mathf.Sqrt(Mathf.Pow(end.x, 2f) + Mathf.Pow(end.z, 2f)),end.y);
            
            //Central angle between current start and end points
            float deltaSigmaNew = Mathf.Acos(Vector3.Dot(start.normalized, end.normalized));

            //Angle between north pole, start point and next point (atan2(y,x))
            float x_Start = Mathf.Cos(phiEnd) - Mathf.Cos(deltaSigmaNew)  * Mathf.Cos(phiStart);
            float y_Start = Mathf.Sqrt(Mathf.Max(0, Mathf.Pow(Mathf.Sin(deltaSigmaNew) * Mathf.Sin(phiStart), 2f) - Mathf.Pow(x_Start, 2f)));
            float triangularAngleStart = Mathf.Atan2(y_Start, x_Start);

            //Polar angle for new point 
            float phiNewPoint = Mathf.Acos(Mathf.Cos(angleToNextPoint) * Mathf.Cos(phiStart) + Mathf.Sin(angleToNextPoint) * Mathf.Sin(phiStart) * Mathf.Cos(triangularAngleStart));
            
            //Angle between start point, north pole and next point (atan2(y,x))
            float x_NewPoint = Mathf.Cos(angleToNextPoint) - Mathf.Cos(phiNewPoint)  * Mathf.Cos(phiStart);
            float y_NewPoint = Mathf.Sqrt(Mathf.Max(0, Mathf.Pow(Mathf.Sin(phiNewPoint) * Mathf.Sin(phiStart), 2f) - Mathf.Pow(x_NewPoint, 2f)));
            float poleAngleNew = Mathf.Atan2(y_NewPoint, x_NewPoint);

            //Azimuthal angle for next point
            float thetaNewPoint = thetaStart + poleAngleNew;

            //Radial distance for next point 
            float currentPosition = (float)i;
            float rhoNew = (((totalPosition - currentPosition)/totalPosition) * rhoStart + (currentPosition/totalPosition) * rhoEnd);
            

            Vector3 nextPoint = new Vector3(rhoNew * Mathf.Sin(phiNewPoint) * Mathf.Cos(thetaNewPoint), rhoNew * Mathf.Cos(phiNewPoint), rhoNew * Mathf.Sin(phiNewPoint) * Mathf.Sin(thetaNewPoint));
            
           
            lr.SetPosition(i, nextPoint);
            start = nextPoint;
        } 
        
        //Alpha gradient
        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[] { },
            new GradientAlphaKey[] { new GradientAlphaKey(0.5f, 0.0f), new GradientAlphaKey(1f, 0.3f), new GradientAlphaKey(1f, 0.7f), new GradientAlphaKey(0.5f, 1.0f) }
        );

        lr.colorGradient = gradient;

        //Width curve
        AnimationCurve curve = new AnimationCurve();

        curve.AddKey(0.0f, 0.04f);
        curve.AddKey(0.5f, 0.08f);
        curve.AddKey(1.0f, 0.04f);

        lr.widthCurve = curve;
    }


    private void handleMouse()
    {
        
        if (!Input.GetMouseButtonDown(0)) return;

        // UnityEngine.XR.InputDevice handR = InputDevices.GetDeviceAtXRNode(XRNode.RightHand); //InputDeviceRole.RightHanded

        // if (!handr.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue) return;
        // handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion rotR);
        // handR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Vector3 posR);
        // Vector3 direction = rotR * Vector3.forward;

        // Ray ray = new Ray(posR, direction);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) return;

        string name = hit.collider.gameObject.name;
        string tag = hit.collider.gameObject.tag;

        if (!(tag=="sphere")) return;

        if (s2 == name) return;

        string pair1 = s2 + name;
        string pair2 = name + s2;

        if (pairs.Contains(pair1) || pairs.Contains(pair2)) return;

        s1 = s2;
        s2 = name;

        path.Add(s2);

        if (string.IsNullOrEmpty(s1)) return;

        pairs.Add(pair1);

        GameEvents2.current.NewLine(path, sphereTime);

        drawLine(s1, s2);
    }

    IEnumerator Spawn()
    {
        for(var x = 0; x < ActiveSphereList[sphereTime].GetLength(0); x ++){
            cont = true;
            for(var y = 0; y < ActiveSphereList[sphereTime].GetLength(1); y ++){
                spawnSphere(ActiveSphereList[sphereTime][x,y].rho, ActiveSphereList[sphereTime][x,y].theta, ActiveSphereList[sphereTime][x,y].phi, ActiveSphereList[sphereTime][x,y].color, ActiveSphereList[sphereTime][x,y].label, y == (ActiveSphereList[sphereTime].GetLength(1) - 1), y);  
                
            }
            do 
            {
                yield return null;
            } while (cont);

            noMoreSpheres();

        }
    }

    void spawnSphere(float rho, float theta, float phi, ColorType color, string label, bool end, int y)
    {
        Vector3 spherePosition = new Vector3(rho * Mathf.Sin(phi) * Mathf.Cos(theta), rho * Mathf.Cos(phi), rho * Mathf.Sin(phi) * Mathf.Sin(theta));
        GameObject sphere = Instantiate(spherePrefab, spherePosition, Quaternion.identity) as GameObject;
        
        
        sphere.name = "Sphere" + y.ToString();
        if (end)
        {
            sphere.tag = "end";
        }
        var sphereScript = sphere.GetComponent<TextOnObject>();
        sphereScript.label = label;
        sphereScript.playerCamera = cam;

        var sphereRenderer = sphere.GetComponent<Renderer>();
        Color colorValue = color == ColorType.Light ? LightColor: DarkColor;
        sphereRenderer.material.SetColor("_Color", colorValue);

        sphere.SetActive(true);
    }

    public class SphereValues
    {
        public float rho; 
        public float theta; 
        public float phi; 
         public ColorType color;
        public string label;

        public SphereValues(float rhoI, float thetaI, float phiI, ColorType colorI, string labelI)
        {
            rho = rhoI;
            theta = thetaI * Mathf.Deg2Rad;
            phi =  phiI * Mathf.Deg2Rad;
            color = colorI;
            label = labelI;
        }

    }

    // SphereValues[,] ListOfSphereValuesDefault = new SphereValues[,]


    // SphereValues[,] ListOfSphereValuesColoreds = new SphereValues[,]

    void OnNewGame(List<string> path1, int sphereTime)
    {
        s1 = "";
        s2 = "";
        path = new List<string>();
        pairs = new List<string>();
        
        cont = false;

    }

    void OnInstructionDone()
    {
        s1 = "";
        s2 = "";
        path = new List<string>();
        pairs = new List<string>();
        
        cont = false;
        sphereTime += 1;
        noMoreSpheres();
        if (sphereTime == 3)
        {
            StopCoroutine("Spawn");
            noMoreSpheres();
            done = true;
            GameEvents2.current.GameDone();
        }
        else
        {
            StartCoroutine("Spawn");
        }
    }

    void OnNewMode()
    {
        noMoreSpheres();
        StopCoroutine("Spawn");
    }

    void noMoreSpheres()
    {
        GameObject[] spheres = GameObject.FindGameObjectsWithTag("sphere");

        for (int i=0; i < spheres.Length; i++){
            Destroy(spheres[i]);
        }
        GameObject[] lines = GameObject.FindGameObjectsWithTag("line");

        for (int i=0; i < lines.Length; i++){
            Destroy(lines[i]);
        }

        GameObject[] ends = GameObject.FindGameObjectsWithTag("end");

        for (int i=0; i < ends.Length; i++){
            Destroy(ends[i]);
        }
    }


    void OnDestroy()
    {
        GameEvents2.current.onNewGame -= OnNewGame;
        GameEvents2.current.onNewMode -= OnNewMode;
        GameEvents2.current.onInstructionDone -= OnInstructionDone;
    }
}
