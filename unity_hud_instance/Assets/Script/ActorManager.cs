
//=======================================================
// 作者：hannibal
// 描述：模拟actor的移动和hp改变
//=======================================================
using System.Collections.Generic;
using UnityEngine;

namespace YX
{
    public class ActorManager : MonoBehaviour
    {
        public bool m_isUseRandomPos = true;
        public int Count = 500;
        public float m_timeClip = 1;
        float m_curTimeClip = 0;
        public List<Actor> AllActors { get; private set; } = new List<Actor>();

        public static ActorManager Instance;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            AllActors.Capacity = Count;
            for (int i = 0; i < Count; i++)
            {
                Actor actor = new Actor();
                //actor.Matrix = Matrix4x4.TRS(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0), Quaternion.identity, Vector3.one);
                actor.CreateObj(i);
                actor.NameIndex = i;
                actor.Progress = Random.Range(0.0f, 1.0f);
                AllActors.Add(actor);
            }
        }
        private void Update()
        {
            foreach (var actor in AllActors)
            {
                actor.Update();
            }

            //m_curTimeClip += Time.deltaTime;
            //if (m_curTimeClip >= m_timeClip)
            //{
            //    foreach (var actor in AllActors)
            //    {
            //        actor.Update();
            //    }
            //    m_curTimeClip -= m_timeClip;
            //}
        }
    }
    public class Actor
	{
		public Matrix4x4 Matrix;
		public int NameIndex = 0;
		public float Progress = 1.0f;

        public GameObject m_obj;

        public void CreateObj(int idx)
        {
            m_obj =  GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (ActorManager.Instance.m_isUseRandomPos == true)
            {
                float x = Random.Range(-100, 100);
                float y = Random.Range(-100, 100);
                float z = Random.Range(-100, 100);
                m_obj.transform.position = new Vector3(x, y, z);
            }
        }
        public void Update()
        {
            Vector3 pos = m_obj.transform.position;
            Quaternion que = m_obj.transform.rotation;
            Vector3 scale = m_obj.transform.localScale;
            Matrix = Matrix4x4.TRS(pos, que, scale);
            //Progress = Random.Range(0.0f, 1.0f);
        }
    }
}
