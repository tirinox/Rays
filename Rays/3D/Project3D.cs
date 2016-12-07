using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;
using Tao.OpenGl;

namespace Rays._3D
{
    [Serializable]
    public class Project3D
    {
        [XmlIgnore]
        public bool ChangesUnsaved = false;

        public string Name = "Новый проект Rays";
        public string Description = "";
        public string FileName = "";

        public Scene3D Scene = new Scene3D();
        public Camera3D Camera = new Camera3D();

        public Vector4 BgColor = new Vector4(1, 1, 1, 1);
        public Vector4 LightColor = new Vector4(1, 1, 1, 1);
        public Vector3 LightPosition = new Vector3(50, 200, 200);

        [XmlElement]
        public int TracerDeepness = 5;
        [XmlElement]
        public int PercentVisibleRays = 100;
        [XmlElement]
        public int InitialRaysCount = 200;

        [XmlElement]
        public Tube3D.RenderStyle TubeRenderStyle = Tube3D.RenderStyle.FullPolyhedron;
        [XmlElement]
        public bool RayAlphaPower = false;
        [XmlElement]
        public Vector4 RayColor = new Vector4(1, 0, 0, 1);
        [XmlElement]
        public bool RayFixedColor = true;
        [XmlElement]
        public double LineWidth = 1.0;

        public Project3D()
        {
       //     BgColor = new Vector4(0.6, 0.6, 0.6, 1);
            Scene.Parrent = this;
            
        }

        public void SetupLight()
        {
            Gl.glEnable(Gl.GL_LIGHTING);
            float[] pos = { (float)LightPosition.X, (float)LightPosition.Y, (float)LightPosition.Z, 0 };
            float[] clr = { (float)LightColor.X, (float)LightColor.Y, (float)LightColor.Z, (float)LightColor.A };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, clr);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, pos);
            Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE);
            Gl.glEnable(Gl.GL_LIGHT0);
        }

        #region SaveAndLoad
        public void Save(string FileName)
        {
            var Tpy = this.GetType();
            XmlSerializer s = new XmlSerializer(Tpy);
            TextWriter w = new StreamWriter(FileName);
            s.Serialize(w, this);
            w.Flush();
            w.Close();
        }

        public static Project3D Load(string FileName)
        {
            XmlReader reader = new XmlTextReader(FileName);
            XmlSerializer serializer = new XmlSerializer(typeof(Project3D));
            Project3D sd = (Project3D)serializer.Deserialize(reader);
            reader.Close();

            if (!Rays.Properties.Settings.Default.LoadAllRays)
                sd.Scene.AllRays = new List<Tube3D>();
            sd.Scene.Parrent = sd;
            sd.ChangesUnsaved = false;
            sd.Scene.Selected = null;
            sd.Scene.RaysVisible = false;

            sd.Scene.BuildVBO(true);
            sd.Scene.TransformFiguresAndMergeFaces();

            return sd;
        }
        #endregion
            
    }
}
