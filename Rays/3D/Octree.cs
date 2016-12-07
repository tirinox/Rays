using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tao.OpenGl;

namespace Rays._3D
{
    public class AABB
    {
        public Vector3 Max = new Vector3(-1e7, -1e7, -1e7);
        public Vector3 Min = new Vector3(1e7, 1e7, 1e7);

        public AABB()
        { }

        public AABB(Vector3 V)
        {
            Min = new Vector3(V);
            Max = new Vector3(V);
        }

        public void Validate()
        {
            if (Min.X > Max.X) { double tmp = Min.X; Min.X = Max.X; Max.X = tmp; }
            if (Min.Y > Max.Y) { double tmp = Min.Y; Min.Y = Max.Y; Max.Y = tmp; }
            if (Min.Z > Max.Z) { double tmp = Min.Z; Min.Z = Max.Z; Max.Z = tmp; }
        }

        public AABB(Vector3 vMin, Vector3 vMax)
        {
            Min = new Vector3(vMin);
            Max = new Vector3(vMax);
            Validate();
        }

        public AABB(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Min = new Vector3(x1, y1, z1);
            Max = new Vector3(x2, y2, z2);
            Validate();
        }

        public void Extend(Vector3 V)
        {
            if (V.X < Min.X) Min.X = V.X;
            if (V.X > Max.X) Max.X = V.X;
            if (V.Y < Min.Y) Min.Y = V.Y;
            if (V.Y > Max.Y) Max.Y = V.Y;
            if (V.Z < Min.Z) Min.Z = V.Z;
            if (V.Z > Max.Z) Max.Z = V.Z;
        }

        public AABB[] OctreeSplit()
        {
            AABB[] SubNodes = new AABB[8];

            Vector3 Size = Max - Min;
            Vector3 Half = Size * 0.5;

            SubNodes[0] = new AABB(Min, Min + Half);
            SubNodes[1] = new AABB(Min + Half, Max);
            SubNodes[2] = new AABB(Min.X + Half.X, Min.Y, Min.Z, Max.X, Min.Y + Half.Y, Min.Z + Half.Z);
            SubNodes[3] = new AABB(Min.X, Min.Y + Half.Y, Min.Z, Min.X + Half.X, Max.Y, Min.Z + Half.Z);
            SubNodes[4] = new AABB(Min.X, Min.Y, Min.Z + Half.Z, Min.X + Half.X, Min.Y + Half.Y, Max.Z);

            SubNodes[5] = new AABB(Min.X + Half.X, Min.Y + Half.Y, Min.Z, Max.X, Max.Y, Min.Z + Half.Z);
            SubNodes[6] = new AABB(Min.X + Half.X, Min.Y, Min.Z + Half.Z, Max.X, Min.Y + Half.Y, Max.Z);
            SubNodes[7] = new AABB(Min.X, Min.Y + Half.Y, Min.Z + Half.Z, Min.X + Half.X, Max.Y, Max.Z);

            return SubNodes;
        }

        public bool IntersectLine(Vector3 O, Vector3 End)
        {
            Vector3 D = End - O;
            Vector3 C = (Min + Max) * 0.5;
            Vector3 e = (Max - Min) * 0.5;
            double[] t = new double[2];
            int parallel = 0;
            bool found = false;
            Vector3 d = C - O;
            for (int i = 0; i < 3; ++i)
            {
                if (Math.Abs(D[i]) < Tracer3D.GeometryEpsilon)
                    parallel |= 1 << i;
                else
                {
                    double es = (D[i] > 0.0) ? e[i] : -e[i];
                    double invDi = 1.0 / D[i];

                    if (!found)
                    {
                        t[0] = (d[i] - es) * invDi;
                        t[1] = (d[i] + es) * invDi;
                        found = true;
                    }
                    else
                    {
                        double s = (d[i] - es) * invDi;
                        if (s > t[0])
                            t[0] = s;
                        s = (d[i] + es) * invDi;
                        if (s < t[1])
                            t[1] = s;
                        if (t[0] > t[1])
                            return false;
                    }
                }
            }

            if (parallel != 0)
                for (int i = 0; i < 3; ++i)
                    if ((parallel & (1 << i)) != 0)
                        if (Math.Abs(d[i] - t[0] * D[i]) > e[i] || Math.Abs(d[i] - t[1] * D[i]) > e[i])
                            return false;

            return true;
        }

        public bool IntersectTriangle(Plane3D Plane)
        {

            Vector3 boxcenter = 0.5 * (Max + Min);
            Vector3 boxhalfsize = 0.5 * (Max - Min);

            return Utils3D.triBoxOverlap(boxcenter.Array, boxhalfsize.Array, Plane.Vertex) > 0;

        }

        public bool IntersectPoint(Vector3 Pt)
        {
            if (
                Pt.X < Min.X || Pt.Y < Min.Y || Pt.Z < Min.Z ||
                Pt.X > Max.X || Pt.Y > Max.Y || Pt.Z > Max.Z)
                return false;
            return true;
        }

        public bool IntersectAABB(AABB Other)
        {
            if (Min.X > Other.Max.X) return false;
            if (Min.Y > Other.Max.Y) return false;
            if (Min.Z > Other.Max.Z) return false;
            if (Max.X < Other.Min.X) return false;
            if (Max.Y < Other.Min.Y) return false;
            if (Max.Z < Other.Min.Z) return false;

            return true;
        }

        public void Render()
        {
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex3d(Min.X, Min.Y, Min.Z);
            Gl.glVertex3d(Max.X, Min.Y, Min.Z);
            Gl.glVertex3d(Max.X, Max.Y, Min.Z);
            Gl.glVertex3d(Min.X, Max.Y, Min.Z);
            Gl.glVertex3d(Min.X, Max.Y, Max.Z);

            Gl.glVertex3d(Max.X, Max.Y, Max.Z);
            Gl.glVertex3d(Max.X, Min.Y, Max.Z);
            Gl.glVertex3d(Min.X, Min.Y, Max.Z);
            Gl.glVertex3d(Min.X, Min.Y, Min.Z);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex3d(Min.X, Min.Y, Min.Z);
            Gl.glVertex3d(Min.X, Max.Y, Min.Z);

            Gl.glVertex3d(Min.X, Min.Y, Max.Z);
            Gl.glVertex3d(Min.X, Max.Y, Max.Z);

            Gl.glVertex3d(Max.X, Max.Y, Min.Z);
            Gl.glVertex3d(Max.X, Max.Y, Max.Z);

            Gl.glVertex3d(Max.X, Min.Y, Min.Z);
            Gl.glVertex3d(Max.X, Min.Y, Max.Z);

            Gl.glEnd();
        }

        public void Cubize()
        {
            Validate();
            Vector3 S = Max - Min;
            if (S.X > S.Y && S.X > S.Z)
            {
                double S05 = S.X * 0.5;
                double Yp = 0.5 * (Min.Y + Max.Y);
                double Zp = 0.5 * (Min.Z + Max.Z);
                Max.Y = Yp + S05;
                Max.Z = Zp + S05;
                Min.Y = Yp - S05;
                Min.Z = Zp - S05;
            }
            else if (S.Y > S.X && S.Y > S.Z)
            {
                double S05 = S.Y * 0.5;
                double Xp = 0.5 * (Min.X + Max.X);
                double Zp = 0.5 * (Min.Z + Max.Z);
                Max.X = Xp + S05;
                Max.Z = Zp + S05;
                Min.X = Xp - S05;
                Min.Z = Zp - S05;
            }
            else
            {
                double S05 = S.Z * 0.5;
                double Xp = 0.5 * (Min.X + Max.X);
                double Yp = 0.5 * (Min.Y + Max.Y);
                Max.X = Xp + S05;
                Max.Y = Yp + S05;
                Min.X = Xp - S05;
                Min.Y = Yp - S05;
            }
        }

        public bool IntersectFrustum(Utils3D.Plane[] Planes)
        {

            for (int i = 0; i < 6; ++i)
            {
                Vector4 plane = new Vector4(Planes[i].n.X, Planes[i].n.Y, Planes[i].n.Z, Planes[i].d);
                Vector4 pv = new Vector4(
                    plane.X > 0 ? Max.X : Min.X,
                    plane.Y > 0 ? Max.Y : Min.Y,
                    plane.Z > 0 ? Max.Z : Min.Z,
                    1.0);

                Vector4 nv = new Vector4(
                    plane.X < 0 ? Max.X : Min.X,
                    plane.Y < 0 ? Max.Y : Min.Y,
                    plane.Z < 0 ? Max.Z : Min.Z,
                    1.0);

                double n = Vector4.DotProduct(pv, plane);
                if (n < 0) return false;
                double m = Vector4.DotProduct(nv, plane);
                if (m < 0) return false;
            }

            return true;
        }

    }
    
    public class OctreeNode
    {
        public bool Final = false;
        public OctreeNode[] Childs = new OctreeNode[8];
        public List<Plane3D> Faces = new List<Plane3D>();
        public AABB MyAABB = new AABB();

        public OctreeNode()
        { }

        public OctreeNode(AABB MyNewAABB)
        {
            MyAABB = MyNewAABB;
        }
    }

    public class Octree
    {
        public ushort MaxDeep = 5;
        public uint MinFaceCountInNode = 10;

        public static CW cw = null;

        public static void Log(string s)
        {
            if (cw != null)
                cw("Octree: " + s);
        }


        private OctreeNode Root = new OctreeNode();
        private bool Built = false;
        public Octree()
        { }


        private void BuildTreeRecursive(OctreeNode Node, uint Call = 0)
        {
            if (Node.Faces.Count < MinFaceCountInNode || Call == MaxDeep)
            {
                Node.Final = true;
                return;
            }

            ++Call;

            AABB[] SplitNodeAABBs = Node.MyAABB.OctreeSplit();

            for (int i = 0; i < 8; ++i)
                Node.Childs[i] = new OctreeNode(SplitNodeAABBs[i]);

            foreach (Plane3D Face in Node.Faces)
            {
                //AABB TriangleAABB = Face.GetAABB();
                for (int i = 0; i < 8; ++i)
                    if (Node.Childs[i].MyAABB.IntersectTriangle(Face))
                        /*  Node.Childs[i].MyAABB.HasPoint(Face.Vertex[0]) ||
                          Node.Childs[i].MyAABB.HasPoint(Face.Vertex[1]) ||
                          Node.Childs[i].MyAABB.HasPoint(Face.Vertex[2]))*/
                        Node.Childs[i].Faces.Add(Face);
            }

            for (int i = 0; i < 8; ++i)
                BuildTreeRecursive(Node.Childs[i], Call);
        }

        public void BuildTree(List<Plane3D> Faces)
        {
            if (Faces == null)
                throw new ArgumentException("Faces array is not initialized!");

            Root = new OctreeNode();
            Root.Faces = Faces;
            foreach (Plane3D Face in Faces)
            {
                Root.MyAABB.Extend(Face.Vertex[0]);
                Root.MyAABB.Extend(Face.Vertex[1]);
                Root.MyAABB.Extend(Face.Vertex[2]);
            }
            Root.MyAABB.Cubize();

            BuildTreeRecursive(Root);
            Built = true;
        }

        public void BuildTree(Scene3D Scene)
        {

            Root = new OctreeNode();
            foreach (Figure3D F in Scene.Figs)
            {
                Root.Faces.AddRange(F.Faces);
                foreach (Plane3D Face in F.Faces)
                {
                    Root.MyAABB.Extend(Face.Vertex[0]);
                    Root.MyAABB.Extend(Face.Vertex[1]);
                    Root.MyAABB.Extend(Face.Vertex[2]);
                }
            }
            Root.MyAABB.Cubize();

            BuildTreeRecursive(Root);
            Built = true;
        }

        public void RenderRecursive(OctreeNode Node)
        {
            Node.MyAABB.Render();
            if (!Node.Final)
                for (int i = 0; i < 8; ++i)
                    RenderRecursive(Node.Childs[i]);

        }

        public void Render()
        {
            RenderRecursive(Root);
        }

        public List<Plane3D> WalkTreeRecursive(Tube3D Tube, OctreeNode Node)
        {
            List<Plane3D> Suspects = new List<Plane3D>();

            bool IntersectsWithMe =
                Node.MyAABB.IntersectLine(Tube.Rays[0].Begin, Tube.Rays[0].End) ||
                Node.MyAABB.IntersectLine(Tube.Rays[1].Begin, Tube.Rays[1].End) ||
                Node.MyAABB.IntersectLine(Tube.Rays[2].Begin, Tube.Rays[2].End);

            if (IntersectsWithMe && Node.Final)
                return Node.Faces;

            if (!IntersectsWithMe && Node.Final)
                return Suspects;

            for (int i = 0; i < 8; ++i)
                Suspects.AddRange(WalkTreeRecursive(Tube, Node.Childs[i]));

            return Suspects;
        }

        public List<Plane3D> WalkTree(Tube3D Tube)
        {
            if (!Built) return new List<Plane3D>();
            return WalkTreeRecursive(Tube, Root);
        }

        public List<Plane3D> WalkTreeRecursive(Utils3D.Plane[] Frustum, OctreeNode Node)
        {
            

            bool IntersectsWithMe = Node.MyAABB.IntersectFrustum(Frustum);
               

            if (IntersectsWithMe && Node.Final)
                return Node.Faces;

            if (!IntersectsWithMe && Node.Final)
                return null;

            List<Plane3D> Suspects = new List<Plane3D>();

            for (int i = 0; i < 8; ++i)
            {
                List<Plane3D> SubArray = WalkTreeRecursive(Frustum, Node.Childs[i]);
                if(SubArray != null)
                    SubArray.ForEach(delegate(Plane3D f) { if(!f.Added) { f.Added = true; Suspects.Add(f); } } );
            }

            

            return Suspects;
        }

        public List<Plane3D> WalkTree(Utils3D.Plane [] Frustum)
        {
            if (!Built) return new List<Plane3D>();
            return WalkTreeRecursive(Frustum, Root);
        }

        private bool SearchPlaneRecursive(OctreeNode Node, Plane3D Plane)
        {
            if (Node.Final)
                return Node.Faces.Contains(Plane);
            bool Res = false;
            for (int i = 0; i < 8; ++i)
                Res |= SearchPlaneRecursive(Node.Childs[i], Plane);
            return Res;
        }

        public void Analyze(List<Plane3D> AllPlanes)
        {
            int cnt = 0;
            foreach (Plane3D F in AllPlanes)
            {
                if (SearchPlaneRecursive(Root, F)) cnt++;
            }
            Log("All faces = " + AllPlanes.Count);
            Log("Found faces = " + cnt);
        }
    }
}
