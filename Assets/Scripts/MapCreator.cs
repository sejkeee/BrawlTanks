using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MapCreator
    {
        private static int Length = 200, Width = 200;
        
        public List<Vector3> Ground;

        private static MapCreator _mapInstance;
    
        private MapCreator() {}

        public static MapCreator GetMap()
        {
            if (_mapInstance == null)
            {
                _mapInstance = new MapCreator();
                _mapInstance.Ground = new List<Vector3>();
            }

            CreateMap();

            return _mapInstance;
        }

        private static void CreateMap()
        {
            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (i < 15 || i > Length - 15 || j < 15 || j > Width - 15)
                    {
                        _mapInstance.Ground.Add(new Vector3(i,Random.Range(4f,10f)/10f,j));
                        continue;
                    }
                    _mapInstance.Ground.Add(new Vector3(i,0,j));
                }
            }
        }
    }
}

