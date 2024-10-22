﻿using System;
namespace Sn0wballEngine
{
    public class SNVector2f
    {
        public float x { get; set; }
        public float y { get; set; }

        public SNVector2f() {
        
        }
        public SNVector2f(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static SNVector2f Zero()
        {
            return new SNVector2f(0, 0);
        }
        public static SNVector2f operator + (SNVector2f A, SNVector2f B)
        {
            return new SNVector2f(A.x + B.x, A.y + B.y);
        }
        public static SNVector2f operator - (SNVector2f A, SNVector2f B)
        {
            return new SNVector2f(A.x - B.x, A.y - B.y);
        }
        public static SNVector2f operator * (SNVector2f A, SNVector2f B)
        {
            return new SNVector2f(A.x * B.x, A.y * B.y);
        }
        public static SNVector2f operator / (SNVector2f A, SNVector2f B)
        {
            return new SNVector2f(A.x / B.x, A.y / B.y);
        }


        public static SNVector2f operator + (SNVector2f A, float B)
        {
            return new SNVector2f(A.x + B, A.y + B);
        }
        public static SNVector2f operator - (SNVector2f A, float B)
        {
            return new SNVector2f(A.x -B , A.y - B);
        }
        public static SNVector2f operator * (SNVector2f A, float B)
        {
            return new SNVector2f(A.x * B, A.y * B);
        }
        public static SNVector2f operator / (SNVector2f A, float B)
        {
            return new SNVector2f(A.x / B, A.y / B);
        }
    }
}
