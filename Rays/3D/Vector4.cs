using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;
using MatrixLibrary;

namespace Rays._3D
{
    [Serializable()]
    public struct Vector4
    {
      /*  public static implicit operator Vector4(Color c)
        {
            return new Vector4(c.R, c.G, c.B, c.A);
        }*/


        #region Class Variables

        /// <summary>
        /// The X component of the vector
        /// </summary>
        private double x;

        /// <summary>
        /// The Y component of the vector
        /// </summary>
        private double y;

        /// <summary>
        /// The Z component of the vector
        /// </summary>
        private double z;

        /// <summary>
        /// The A component of the vector
        /// </summary>
        private double a;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for the Vector3 class accepting three doubles
        /// </summary>
        /// <param name="x">The new x value for the Vector3</param>
        /// <param name="y">The new y value for the Vector3</param>
        /// <param name="z">The new z value for the Vector3</param>
        /// <implementation>
        /// Uses the mutator properties for the Vector3 components to allow verification of input (if implemented)
        /// This results in the need for pre-initialisation initialisation of the Vector3 components to 0 
        /// Due to the necessity for struct's variables to be set in the constructor before moving control
        /// </implementation>
        public Vector4(double x, double y, double z, double a)
        {
            // Pre-initialisation initialisation
            // Implemented because a struct's variables always have to be set in the constructor before moving control
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.a = 0;

            // Initialisation
            X = x;
            Y = y;
            Z = z;
            A = a;
        }

        public Vector4(Vector3 v, double w)
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.a = 0;

            X = v.X;
            Y = v.Y;
            Z = v.Z;
            A = w;
        }

        /// <summary>
        /// Constructor for the Vector3 class from an array
        /// </summary>
        /// <param name="xyz">Array representing the new values for the Vector3</param>
        /// <implementation>
        /// Uses the VectorArray property to avoid validation code duplication 
        /// </implementation>
        public Vector4(double[] xyza)
        {
            // Pre-initialisation initialisation
            // Implemented because a struct's variables always have to be set in the constructor before moving control
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.a = 0;

            // Initialisation
            Array = xyza;
        }

        /// <summary>
        /// Constructor for the Vector3 class from another Vector3 object
        /// </summary>
        /// <param name="v1">Vector3 representing the new values for the Vector3</param>
        /// <implementation>
        /// Copies values from Vector4 v1 to this vector, does not hold a reference to object v1 
        /// </implementation>
        public Vector4(Vector4 v1)
        {
            // Pre-initialisation initialisation
            // Implemented because a struct's variables always have to be set in the constructor before moving control
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.a = 0;

            // Initialisation
            X = v1.X;
            Y = v1.Y;
            Z = v1.Z;
            A = v1.A;
        }

        #endregion

        #region Accessors & Mutators

        /// <summary>
        /// Property for the x component of the Vector4
        /// </summary>
        [XmlAttribute]
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Property for the y component of the Vector4
        /// </summary>
        [XmlAttribute]
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Property for the z component of the Vector4
        /// </summary>
        [XmlAttribute]
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        /// <summary>
        /// Property for the a component of the Vector4
        /// </summary>
        [XmlAttribute]
        public double A
        {
            get { return a; }
            set { a = value; }
        }


        /// <summary>
        /// Property for the Vector4 as an array
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the array argument does not contain exactly three components 
        /// </exception> 
        [XmlIgnore]
        public double[] Array
        {
            get { return new double[] { x, y, z, a }; }
            set
            {
                if (value.Length == 3)
                {
                    x = value[0];
                    y = value[1];
                    z = value[2];
                    a = value[3];
                }
                else
                {
                    throw new ArgumentException("Need 4 components for Vector4");
                }
            }
        }

        /// <summary>
        /// An index accessor 
        /// Mapping index [0] -> X, [1] -> Y and [2] -> Z, [3] -> A
        /// </summary>
        /// <param name="index">The array index referring to a component within the vector (i.e. x, y, z)</param>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the array argument does not contain exactly three components 
        /// </exception>
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: { return X; }
                    case 1: { return Y; }
                    case 2: { return Z; }
                    case 3: { return A; }
                    default: throw new ArgumentException("Need 4 components for Vector4", "index");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: { X = value; break; }
                    case 1: { Y = value; break; }
                    case 2: { Z = value; break; }
                    case 3: { A = value; break; }
                    default: throw new ArgumentException("Need 4 components for Vector4", "index");
                }
            }
        }

        #endregion

        #region Operators

        #endregion

        public static double DotProduct(Vector4 v1, Vector4 v2)
        {
            return
            (
                v1.X * v2.X +
                v1.Y * v2.Y +
                v1.Z * v2.Z +
                v1.A * v2.A
            );
        }

        public double DotProduct(Vector4 other)
        {
            return DotProduct(this, other);
        }

        public static Vector4 operator *(Vector4 q1, Vector4 q2)
        {
            return QuatMultiply(q1, q2);
        }

        public static Vector4 QuatMultiply(Vector4 q1, Vector4 q2)
        {
            double nw = q1.A * q2.A - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
            double nx = q1.A * q2.X + q1.X * q2.A + q1.Y * q2.Z - q1.Z * q2.Y;
            double ny = q1.A * q2.Y + q1.Y * q2.A + q1.Z * q2.X - q1.X * q2.Z;
            double nz = q1.A * q2.Z + q1.Z * q2.A + q1.X * q2.Y - q1.Y * q2.X;
            return new Vector4(nw, nx, ny, nz);
        }

        public void QuatNormalize()
        {
            double m = A * A + X * X + Y * Y + Z * Z;
            if (m > 0.001)
            {
                m = Math.Sqrt(m);
                A /= m;
                X /= m;
                Y /= m;
                Z /= m;
            }
            else
            {
                A = 1; X = 0; Y = 0; Z = 0;
            }
        }

        public void QuatConjugate()
        {
            X = -X; Y = -Y; Z = -Z;
        }

        public static Vector4 QuatEuler(Vector3 Euler)
        {
            Vector4 QX = Vector4.QuatFromAxisAngle(Vector3.xAxis, Euler.X);
            Vector4 QY = Vector4.QuatFromAxisAngle(Vector3.yAxis, -Euler.Y);
            Vector4 QZ = Vector4.QuatFromAxisAngle(Vector3.zAxis, Euler.Z);

            return QX * QY * QZ;
        }

        /*   inline void unit_from_axis_angle(const vector3& axis, const float& angle){
        vector3 v(axis);
        v.norm();
        float half_angle = angle*0.5f;
        float sin_a = (float)sin(half_angle);
        set(v.x*sin_a, v.y*sin_a, v.z*sin_a, (float)cos(half_angle));*/

        public static Vector4 QuatFromAxisAngle(Vector3 Axis, double Angle)
        {
            Vector3 axis = new Vector3(Axis);
            axis.Normalize();
            double halfAngle = Angle * 0.5;
            double sinA = Math.Sin(halfAngle);
            return new Vector4(axis.X * sinA, axis.Y * sinA, axis.Z * sinA, Math.Cos(halfAngle));
        }

        public Vector3 QuatRotateVector(Vector3 In)
        {
            Vector4 QuIn = new Vector4(In, 0);
            Vector4 ThisConj = new Vector4(this);
            ThisConj.QuatConjugate();
            Vector4 Res = this * QuIn * ThisConj;
            return new Vector3(Res.X, Res.Y, Res.Z);
        }

        public Matrix QuatToMatrix44()
        {
            Matrix m = new Matrix(4, 4);
            double wx, wy, wz, xx, yy, yz, xy, xz, zz, x2, y2, z2;
            x2 = X + X;
            y2 = Y + Y;
            z2 = Z + Z;
            xx = X * x2; xy = X * y2; xz = X * z2;
            yy = Y * y2; yz = Y * z2; zz = Z * z2;
            wx = A * x2; wy = A * y2; wz = A * z2;

            m[0, 0] = 1.0 - (yy + zz); m[0, 1] = xy - wz; m[0, 2] = xz + wy;
            m[1, 0] = xy + wz; m[1, 1] = 1.0 - (xx + zz); m[1, 2] = yz - wx;
            m[2, 0] = xz - wy; m[2, 1] = yz + wx; m[2, 2] = 1.0 - (xx + yy);

            m[0, 3] = m[1, 3] = m[2, 3] = 0;
            m[3, 0] = m[3, 1] = m[3, 2] = 0;
            m[3, 3] = 1;

            return m;
        }

        public static Vector4 PerComponentProduct(Vector4 One, Vector4 Two)
        {
            return new Vector4(
                One.X * Two.X,
                One.Y * Two.Y,
                One.Z * Two.Z,
                One.A * Two.A);
        }

    }
}
