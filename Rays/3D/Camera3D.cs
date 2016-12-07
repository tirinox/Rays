using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace Rays._3D
{
    public enum Camera3DMovements
    {
        Forward,
        Back,
        StrafeLeft,
        StrafeRight,
        Up,
        Down
    }

    [Serializable]
    public class Camera3D
    {
        private Vector3 position = new Vector3(-100, -50, -100);

        private Vector3 up = new Vector3(0, -1, 0);
        private double yaw = -44.0f;
        private double pitch = 21.0f;

        public double Speed = 5.0;

        public double IsoZoom = 50;

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector3 Up
        {
            get { return up; }
            set { up = value; }
        }

        public double Yaw
        {
            get { return yaw; }
            set { yaw = value; }
        }

        public double Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }

        public void AddYaw(double amount)
        {
            yaw += amount;
        }

        public void AddPitch(double amount)
        {
            pitch += amount;
        }

        public void ProcessKey(Camera3DMovements Move)
        {

            switch (Move)
            {
                case Camera3DMovements.Forward:
                    if (Rays.Properties.Settings.Default.GLPerspective)
                        walkForward(Speed);
                    else
                        IsoZoom *= 0.9;
                    break;
                case Camera3DMovements.Back:
                    if (Rays.Properties.Settings.Default.GLPerspective)
                        walkBackwards(Speed);
                    else
                        IsoZoom *= 1.1;
                    break;
                case Camera3DMovements.StrafeLeft:
                    strafeLeft(Speed);
                    break;
                case Camera3DMovements.StrafeRight:
                    strafeRight(Speed);
                    break;
                case Camera3DMovements.Up:
                    position += Speed * up;
                    break;
                case Camera3DMovements.Down:
                    position -= Speed * up;
                    break;
            }


        }

        public void Rotation(double aX, double aY)
        {
            AddPitch(aX);
            AddYaw(aY);
        }

        public static double MathtoRadians(double a)
        {
            return a / 180.0 * Math.PI;
        }

        public Vector3 CameraDirection()
        {
            return new Vector3(
                (double)Math.Sin(MathtoRadians(yaw)),
                0,
                (double)Math.Cos(MathtoRadians(yaw)));

        }

        public void walkForward(double distance)
        {
            position.X -= distance * (double)Math.Sin(MathtoRadians(yaw));
            position.Z += distance * (double)Math.Cos(MathtoRadians(yaw));
        }

        public void walkBackwards(double distance)
        {
            position.X += distance * (double)Math.Sin(MathtoRadians(yaw));
            position.Z -= distance * (double)Math.Cos(MathtoRadians(yaw));
        }

        public void strafeLeft(double distance)
        {
            position.X -= distance * (double)Math.Sin(MathtoRadians(yaw - 90));
            position.Z += distance * (double)Math.Cos(MathtoRadians(yaw - 90));
        }

        public void strafeRight(double distance)
        {
            position.X -= distance * (double)Math.Sin(MathtoRadians(yaw + 90));
            position.Z += distance * (double)Math.Cos(MathtoRadians(yaw + 90));
        }

        public void See(double aspectRatio, bool UpdateProject = true)
        {
            if (UpdateProject)
            {
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                // 2D
                if (!Rays.Properties.Settings.Default.GLPerspective)
                    Gl.glOrtho(-IsoZoom * aspectRatio, IsoZoom * aspectRatio, -IsoZoom, IsoZoom, -100000, 500);
                else
                    Glu.gluPerspective(Rays.Properties.Settings.Default.GLPerspectiveFoV, aspectRatio, 0.1, 1000);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Gl.glRotated(pitch, 1.0f, 0.0f, 0.0f);
            Gl.glRotated(yaw, 0.0f, 1.0f, 0.0f);
         //   if (!Rays.Properties.Settings.Default.GLPerspective)
                Gl.glTranslated(position.X, position.Y, position.Z);
         /*   else
                Gl.glTranslated(-100, -50, -100);*/

        }
    }
}
