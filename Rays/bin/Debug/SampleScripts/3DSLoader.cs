using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public struct Vector
{
    public double X;
    public double Y;
    public double Z;

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector CrossProduct(Vector v)
    {
        return new Vector(Y * v.Z - Z * v.Y,
                Z * v.X - X * v.Z,
                X * v.Y - Y * v.X);
    }

    public double DotProduct(Vector v)
    {
        return X * v.X + Y * v.Y + Z * v.Z;
    }

    public Vector Normalize()
    {
        double d = Math.Sqrt(X * X + Y * Y + Z * Z);

        if (d == 0) d = 1;

        return this / d;
    }

    public override string ToString()
    {
        return String.Format("X: {0} Y: {1} Z: {2}", X, Y, Z);
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        Vector vr;

        vr.X = v1.X + v2.X;
        vr.Y = v1.Y + v2.Y;
        vr.Z = v1.Z + v2.Z;

        return vr;
    }

    public static Vector operator /(Vector v1, double s)
    {
        Vector vr;

        vr.X = v1.X / s;
        vr.Y = v1.Y / s;
        vr.Z = v1.Z / s;

        return vr;
    }

    public static Vector operator -(Vector v1, Vector v2)
    {
        Vector vr;

        vr.X = v1.X - v2.X;
        vr.Y = v1.Y - v2.Y;
        vr.Z = v1.Z - v2.Z;

        return vr;
    }
}

public struct Triangle
{
    public int vertex1;
    public int vertex2;
    public int vertex3;

    public Triangle(int v1, int v2, int v3)
    {
        vertex1 = v1;
        vertex2 = v2;
        vertex3 = v3;
    }

    public override string ToString()
    {
        return String.Format("v1: {0} v2: {1} v3: {2}", vertex1, vertex2, vertex3);
    }
}

public struct TexCoord
{
    public float U;
    public float V;

    public TexCoord(float u, float v)
    {
        U = u;
        V = v;
    }
}

public class Material
{
    // Set Default values
    public float[] Ambient = new float[] { 0.5f, 0.5f, 0.5f };
    public float[] Diffuse = new float[] { 0.5f, 0.5f, 0.5f };
    public float[] Specular = new float[] { 0.5f, 0.5f, 0.5f };
    public int Shininess = 50;

    int textureid = -1;
    public int TextureId
    {
        get
        {
            return textureid;
        }
    }

    //public void BindTexture ( int width, int height, byte [,,] data )
    public void BindTexture(int width, int height, IntPtr data)
    {

    }
}

public class Entity
{
    // TODO: OO this
    // fields should be private
    // constructor with verts and faces
    // normalize in ctor

    public Material material = new Material();

    // The stored vertices 
    public Vector[] vertices;

    // The calculated normals
    public Vector[] normals;

    // The indices of the triangles which point to vertices
    public Triangle[] indices;

    // The coordinates which map the texture onto the entity
    public TexCoord[] texcoords;

    bool normalized = false;

    public void CalculateNormals()
    {
        if (indices == null) return;

        normals = new Vector[vertices.Length];

        Vector[] temps = new Vector[indices.Length];

        for (int ii = 0; ii < indices.Length; ii++)
        {
            Triangle tr = indices[ii];

            Vector v1 = vertices[tr.vertex1] - vertices[tr.vertex2];
            Vector v2 = vertices[tr.vertex2] - vertices[tr.vertex3];

            temps[ii] = v1.CrossProduct(v2);
            //Console.Write ("I");
        }

        for (int ii = 0; ii < vertices.Length; ii++)
        {
            Vector v = new Vector();
            int shared = 0;

            for (int jj = 0; jj < indices.Length; jj++)
            {
                Triangle tr = indices[jj];
                if (tr.vertex1 == ii || tr.vertex2 == ii || tr.vertex3 == ii)
                {
                    v += temps[jj];
                    shared++;
                }
            }

            normals[ii] = (v / shared).Normalize();
        }
        //Console.WriteLine ( "Normals Calculated!" );
        normalized = true;
    }

    public void Render()
    {
        if (indices == null) return;


    }
}

public class Matrix
{
    const double ATR = .01745;

    public static float[] GetIdentity()
    {
        return new float[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
    }

    public static float[] Inverse(float[] m)
    {
        int swap;
        float t;
        float[,] temp = new float[4, 4];
        float[] inv = GetIdentity();

        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                temp[i, j] = m[(i * 4) + j];

        for (int i = 0; i < 4; i++)
        {
            // Look for largest element in column
            swap = i;
            for (int j = i + 1; j < 4; j++)
                if (Math.Abs(temp[j, i]) > Math.Abs(temp[i, i]))
                    swap = j;

            if (swap != i)
            {
                // Swap rows.
                for (int k = 0; k < 4; k++)
                {
                    t = temp[i, k];
                    temp[i, k] = temp[swap, k];
                    temp[swap, k] = t;

                    t = inv[(i * 4) + k];
                    inv[(i * 4) + k] = inv[(swap * 4) + k];
                    inv[(swap * 4) + k] = t;
                }
            }

            if (temp[i, i] == 0)
                throw new Exception("Matrix is Math.Singular");

            t = temp[i, i];
            for (int k = 0; k < 4; k++)
            {
                temp[i, k] /= t;
                inv[(i * 4) + k] /= t;
            }
            for (int j = 0; j < 4; j++)
            {
                if (j != i)
                {
                    t = temp[j, i];
                    for (int k = 0; k < 4; k++)
                    {
                        temp[j, k] -= temp[i, k] * t;
                        inv[(j * 4) + k] -= inv[(i * 4) + k] * t;
                    }
                }
            }
        }
        return inv;
    }

    public static float[] Transform(float rotX, float rotY, float rotZ, float transX, float transY, float transZ)
    {
        float[] myMatrix = new float[16];

        float A, B, C, D, E, F, AD, BD;
        A = (float)Math.Cos(rotX * ATR);
        B = (float)Math.Sin(rotX * ATR);
        C = (float)Math.Cos(rotY * ATR);
        D = (float)Math.Sin(rotY * ATR);
        E = (float)Math.Cos(rotZ * ATR);
        F = (float)Math.Sin(rotZ * ATR);

        AD = A * D;
        BD = B * D;

        myMatrix[0] = C * E;
        myMatrix[1] = -C * F;
        myMatrix[2] = -D;
        myMatrix[4] = -BD * E + A * F;
        myMatrix[5] = BD * F + A * E;
        myMatrix[6] = -B * C;
        myMatrix[8] = AD * E + B * F;
        myMatrix[9] = -AD * F + B * E;
        myMatrix[10] = A * C;
        myMatrix[3] = myMatrix[7] = myMatrix[11] = 0;
        myMatrix[12] = transX;
        myMatrix[13] = transY;
        myMatrix[14] = transZ;
        myMatrix[15] = 1;

        return myMatrix;
    }
}


public class Model
{
    public List<Entity> Entities = new List<Entity>();

    public void Render()
    {
        foreach (Entity e in Entities)
            e.Render();
    }
}


public class ThreeDSFile
{
    enum Groups
    {
        C_PRIMARY = 0x4D4D,
        C_OBJECTINFO = 0x3D3D,
        C_VERSION = 0x0002,
        C_EDITKEYFRAME = 0xB000,
        C_MATERIAL = 0xAFFF,
        C_MATNAME = 0xA000,
        C_MATAMBIENT = 0xA010,
        C_MATDIFFUSE = 0xA020,
        C_MATSPECULAR = 0xA030,
        C_MATSHININESS = 0xA040,
        C_MATMAP = 0xA200,
        C_MATMAPFILE = 0xA300,
        C_OBJECT = 0x4000,
        C_OBJECT_MESH = 0x4100,
        C_OBJECT_VERTICES = 0x4110,
        C_OBJECT_FACES = 0x4120,
        C_OBJECT_MATERIAL = 0x4130,
        C_OBJECT_UV = 0x4140
    }

    class ThreeDSChunk
    {
        public ushort ID;
        public uint Length;
        public int BytesRead;

        public ThreeDSChunk(BinaryReader reader)
        {
            // 2 byte ID
            ID = reader.ReadUInt16();
            //Console.WriteLine ("ID: {0}", ID.ToString("x"));

            // 4 byte length
            Length = reader.ReadUInt32();
            //Console.WriteLine ("Length: {0}", Length);

            // = 6
            BytesRead = 6;
        }
    }

    BinaryReader reader;

    Model model = new Model();
    public Model ThreeDSModel
    {
        get
        {
            return model;
        }
    }

    Dictionary<string, Material> materials = new Dictionary<string, Material>();

    string base_dir;

    public ThreeDSFile(string file_name)
    {
        base_dir = new FileInfo(file_name).DirectoryName + "/";

        FileStream file;
        file = new FileStream(file_name, FileMode.Open, FileAccess.Read);

        reader = new BinaryReader(file);
        reader.BaseStream.Seek(0, SeekOrigin.Begin);

        ThreeDSChunk chunk = new ThreeDSChunk(reader);
        if (chunk.ID != (short)Groups.C_PRIMARY)
            throw new ApplicationException("Not a proper 3DS file.");

        ProcessChunk(chunk);

        reader.Close();
        file.Close();
    }

    void ProcessChunk(ThreeDSChunk chunk)
    {
        while (chunk.BytesRead < chunk.Length)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);

            switch ((Groups)child.ID)
            {
                case Groups.C_VERSION:

                    int version = reader.ReadInt32();
                    child.BytesRead += 4;

                    Console.WriteLine("3DS File Version: {0}", version);
                    break;

                case Groups.C_OBJECTINFO:

                    ThreeDSChunk obj_chunk = new ThreeDSChunk(reader);

                    // not sure whats up with this chunk
                    SkipChunk(obj_chunk);
                    child.BytesRead += obj_chunk.BytesRead;

                    ProcessChunk(child);

                    break;

                case Groups.C_MATERIAL:

                    ProcessMaterialChunk(child);
                    //SkipChunk ( child );
                    break;

                case Groups.C_OBJECT:

                    //SkipChunk ( child );
                    string name = ProcessString(child);
                    Console.WriteLine("OBJECT NAME: {0}", name);

                    Entity e = ProcessObjectChunk(child);
                    e.CalculateNormals();
                    model.Entities.Add(e);

                    break;

                default:

                    SkipChunk(child);
                    break;

            }

            chunk.BytesRead += child.BytesRead;
            //Console.WriteLine ( "ID: {0} Length: {1} Read: {2}", chunk.ID.ToString("x"), chunk.Length , chunk.BytesRead );
        }
    }

    void ProcessMaterialChunk(ThreeDSChunk chunk)
    {
        string name = string.Empty;
        Material m = new Material();

        while (chunk.BytesRead < chunk.Length)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);

            switch ((Groups)child.ID)
            {
                case Groups.C_MATNAME:

                    name = ProcessString(child);
                    Console.WriteLine("Material: {0}", name);
                    break;

                case Groups.C_MATAMBIENT:

                    m.Ambient = ProcessColorChunk(child);
                    break;

                case Groups.C_MATDIFFUSE:

                    m.Diffuse = ProcessColorChunk(child);
                    break;

                case Groups.C_MATSPECULAR:

                    m.Specular = ProcessColorChunk(child);
                    break;

                case Groups.C_MATSHININESS:

                    m.Shininess = ProcessPercentageChunk(child);
                    //Console.WriteLine ( "SHININESS: {0}", m.Shininess );
                    break;

                case Groups.C_MATMAP:

                    ProcessPercentageChunk(child);

                    //SkipChunk ( child );
                    ProcessTexMapChunk(child, m);

                    break;

                default:

                    SkipChunk(child);
                    break;
            }
            chunk.BytesRead += child.BytesRead;
        }
        materials.Add(name, m);
    }

    void ProcessTexMapChunk(ThreeDSChunk chunk, Material m)
    {
        while (chunk.BytesRead < chunk.Length)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);
            switch ((Groups)child.ID)
            {
                case Groups.C_MATMAPFILE:

                    string name = ProcessString(child);
                    Console.WriteLine("	Texture File: {0}", name);


                    break;

                default:

                    SkipChunk(child);
                    break;

            }
            chunk.BytesRead += child.BytesRead;
        }
    }

    float[] ProcessColorChunk(ThreeDSChunk chunk)
    {
        ThreeDSChunk child = new ThreeDSChunk(reader);
        float[] c = new float[] { (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256, (float)reader.ReadByte() / 256 };
        //Console.WriteLine ( "R {0} G {1} B {2}", c.R, c.B, c.G );
        chunk.BytesRead += (int)child.Length;
        return c;
    }

    int ProcessPercentageChunk(ThreeDSChunk chunk)
    {
        ThreeDSChunk child = new ThreeDSChunk(reader);
        int per = reader.ReadUInt16();
        child.BytesRead += 2;
        chunk.BytesRead += child.BytesRead;
        return per;
    }

    Entity ProcessObjectChunk(ThreeDSChunk chunk)
    {
        return ProcessObjectChunk(chunk, new Entity());
    }

    Entity ProcessObjectChunk(ThreeDSChunk chunk, Entity e)
    {
        while (chunk.BytesRead < chunk.Length)
        {
            ThreeDSChunk child = new ThreeDSChunk(reader);

            switch ((Groups)child.ID)
            {
                case Groups.C_OBJECT_MESH:

                    ProcessObjectChunk(child, e);
                    break;

                case Groups.C_OBJECT_VERTICES:

                    e.vertices = ReadVertices(child);
                    break;

                case Groups.C_OBJECT_FACES:

                    e.indices = ReadIndices(child);

                    if (child.BytesRead < child.Length)
                        ProcessObjectChunk(child, e);
                    break;

                case Groups.C_OBJECT_MATERIAL:

                    string name2 = ProcessString(child);
                    Console.WriteLine("	Uses Material: {0}", name2);

                    Material mat;
                    if (materials.TryGetValue(name2, out mat))
                        e.material = mat;
                    else
                        Console.WriteLine(" Warning: Material '{0}' not found. ", name2);
                    //throw new Exception ( "Material not found!" );

                    /*
                       int nfaces = reader.ReadUInt16 ();
                       child.BytesRead += 2;
                       Console.WriteLine ( nfaces );

                       for ( int ii=0; ii< nfaces+2; ii++)
                       {
                       Console.Write ( reader.ReadUInt16 () + " " );
                       child.BytesRead += 2;

                       }
                       */
                    SkipChunk(child);
                    break;

                case Groups.C_OBJECT_UV:

                    int cnt = reader.ReadUInt16();
                    child.BytesRead += 2;

                    Console.WriteLine("	TexCoords: {0}", cnt);
                    e.texcoords = new TexCoord[cnt];
                    for (int ii = 0; ii < cnt; ii++)
                        e.texcoords[ii] = new TexCoord(reader.ReadSingle(), reader.ReadSingle());

                    child.BytesRead += (cnt * (4 * 2));

                    break;

                default:

                    SkipChunk(child);
                    break;

            }
            chunk.BytesRead += child.BytesRead;
            //Console.WriteLine ( "	ID: {0} Length: {1} Read: {2}", chunk.ID.ToString("x"), chunk.Length , chunk.BytesRead );
        }
        return e;
    }

    void SkipChunk(ThreeDSChunk chunk)
    {
        int length = (int)chunk.Length - chunk.BytesRead;
        reader.ReadBytes(length);
        chunk.BytesRead += length;
    }

    string ProcessString(ThreeDSChunk chunk)
    {
        StringBuilder sb = new StringBuilder();

        byte b = reader.ReadByte();
        int idx = 0;
        while (b != 0)
        {
            sb.Append((char)b);
            b = reader.ReadByte();
            idx++;
        }
        chunk.BytesRead += idx + 1;

        return sb.ToString();
    }

    Vector[] ReadVertices(ThreeDSChunk chunk)
    {
        ushort numVerts = reader.ReadUInt16();
        chunk.BytesRead += 2;
        Console.WriteLine("	Vertices: {0}", numVerts);
        Vector[] verts = new Vector[numVerts];

        for (int ii = 0; ii < verts.Length; ii++)
        {
            float f1 = reader.ReadSingle();
            float f2 = reader.ReadSingle();
            float f3 = reader.ReadSingle();

            verts[ii] = new Vector(f1, f3, -f2);
            //Console.WriteLine ( verts [ii] );
        }

        //Console.WriteLine ( "{0}   {1}", verts.Length * ( 3 * 4 ), chunk.Length - chunk.BytesRead );

        chunk.BytesRead += verts.Length * (3 * 4);
        //chunk.BytesRead = (int) chunk.Length;
        //SkipChunk ( chunk );

        return verts;
    }

    Triangle[] ReadIndices(ThreeDSChunk chunk)
    {
        ushort numIdcs = reader.ReadUInt16();
        chunk.BytesRead += 2;
        Console.WriteLine("	Indices: {0}", numIdcs);
        Triangle[] idcs = new Triangle[numIdcs];

        for (int ii = 0; ii < idcs.Length; ii++)
        {
            idcs[ii] = new Triangle(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());
            //Console.WriteLine ( idcs [ii] );

            // flags
            reader.ReadUInt16();
        }
        chunk.BytesRead += (2 * 4) * idcs.Length;
        //Console.WriteLine ( "b {0} l {1}", chunk.BytesRead, chunk.Length);

        //chunk.BytesRead = (int) chunk.Length;
        //SkipChunk ( chunk );

        return idcs;
    }

    /*
       public static void Main (string[] argv)
       {
       if (argv.Length <= 0) return;
       new ThreeDSFile ( argv[0] );
       }
       */
}
