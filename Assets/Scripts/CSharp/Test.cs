using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CSharp
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class Test : MonoBehaviour
    {
        private MeshFilter m_MeshFilter;
        private MeshRenderer m_MeshRenderer;

        void Start()
        {
            m_MeshFilter = GetComponent<MeshFilter>();
            m_MeshRenderer = GetComponent<MeshRenderer>();

            m_MeshFilter.mesh = CreateMesh2();
            m_MeshRenderer.material = CreateMaterial();
        }

        private Material CreateMaterial()
        {
            Material material = new Material(Shader.Find("Transparent/Diffuse"));
            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/5.png");
            material.mainTexture = texture;
            return material;
        }

        private Mesh CreateMesh2()
        {
            var mesh = new Mesh();
            var vertices = new Vector3[10];
            const float angle36 = Mathf.Deg2Rad * 36;
            const float angle72 = Mathf.Deg2Rad * 72;
            var cos36 = Mathf.Cos(angle36);
            var sin36 = Mathf.Sin(angle36);
            var sin72 = Mathf.Sin(angle72);
            var cos72 = Mathf.Cos(angle72);

            //设置顶点
            vertices[0] = new Vector3(0, 0, 0);
            vertices[1] = new Vector3(1, 0, 0);
            vertices[2] = new Vector3(1 + cos72, sin72, 0);
            vertices[3] = new Vector3(1 + 2 * cos72, 0, 0);
            vertices[4] = new Vector3(2 + 2 * cos72, 0, 0);
            vertices[5] = new Vector3(cos36, -sin36, 0);
            vertices[6] = new Vector3(2 + 2 * cos72 - cos36, -sin36, 0);
            vertices[7] = new Vector3(cos72 * 2 * cos36, -sin72 * 2 * cos36, 0);
            vertices[8] = new Vector3(1 + cos72, -sin36 * (1 + 2 * cos72), 0);
            vertices[9] = new Vector3(cos36 * (2 + 2 * cos72), -sin36 * (2 + 2 * cos72), 0);
            mesh.vertices = vertices;

            // foreach (var item in vertices)
            // {
            //     Debug.Log(item);
            // }


            var triangles = new int[15];
            //顺时针绘制正面,逆时针绘制反面
            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 5;
            
            triangles[3] = 1;
            triangles[4] = 2;
            triangles[5] = 3;
            
            triangles[6] = 3;
            triangles[7] = 4;
            triangles[8] = 6;
            
            triangles[9] = 5;
            triangles[10] = 8;
            triangles[11] = 7;
            
            triangles[12] = 8;
            triangles[13] = 6;
            triangles[14] = 9;            

            mesh.triangles = triangles;

            // //uv是uv纹理坐标的简称
            // //UV就是将图像上每一个点精确对应到模型物体的表面, 在点与点之间的间隙位置由软件进行图像光滑插值处理. 这就是所谓的UV贴图
            // //uv坐标系是以左下角为（0，0），右上角为（1，1）的坐标系
            // Vector2[] uvs = new Vector2[vertices.Length];
            // uvs[0] = Vector2.zero;
            // uvs[1] = Vector2.right;
            // uvs[2] = Vector2.up;
            // uvs[3] = Vector2.one;
            // mesh.uv = uvs;
            //
            // //设置法线
            // Vector3[] normals = new Vector3[vertices.Length];
            // for (var i = 0; i < vertices.Length; i++)
            // {
            //     normals[i] = Vector3.forward;
            // }
            //
            // mesh.normals = normals;
            
            //重新设置UV，法线
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            mesh.name = "triangle";
            return mesh;
        }
        
        /// <summary>
        /// 生成自定义多边形方法
        /// </summary>
        /// <param name="s_Vertives">自定义的顶点数组</param>
        public  void DoCreatPloygonMesh(Vector3 []s_Vertives)
        {
            //新建一个空物体进行进行绘制自定义多边形
            GameObject tPolygon = new GameObject("tPolygon");

            //绘制所必须的两个组件
            tPolygon.AddComponent<MeshFilter>();
            tPolygon.AddComponent<MeshRenderer>();

            //新申请一个Mesh网格
            Mesh tMesh = new Mesh();

            //存储所有的顶点
            Vector3[] tVertices = s_Vertives;

            //存储画所有三角形的点排序
            List<int> tTriangles = new List<int>();

            //根据所有顶点填充点排序
            for (int i = 0; i < tVertices .Length -1; i++)
            {
                tTriangles.Add(i);
                tTriangles.Add(i+1);
                tTriangles.Add(tVertices .Length -i-1);
            }

            //赋值多边形顶点
            tMesh.vertices = tVertices;

            //赋值三角形点排序
            tMesh.triangles = tTriangles.ToArray();

            //重新设置UV，法线
            tMesh.RecalculateBounds();
            tMesh.RecalculateNormals();

            //将绘制好的Mesh赋值
            tPolygon.GetComponent<MeshFilter>().mesh = tMesh;

        }

        private void test()
        {
            
        }
    }
}