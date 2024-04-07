using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
 
namespace Minikit.Inventory
{
    [Serializable]
    [MKShardHidden]
    public class MKShard
    {
        public List<MKTag> tags;


        public virtual string GetDebugPrintString() { return "";  }

        public void OnAddedToItem(MKItem _item)
        {

        }

        public void OnRemovedFromItem(MKItem _item)
        {

        }
    }

    public class MKShard_Text : MKShard
    {
        public string text;


        public override string GetDebugPrintString()
        {
            return text;
        }
    }

    public class MKShard_NumberFloat : MKShard
    {
        public float number;


        public override string GetDebugPrintString()
        {
            return number.ToString();
        }
    }

    public class MKShard_NumberInt : MKShard
    {
        public int number;


        public override string GetDebugPrintString()
        {
            return number.ToString();
        }
    }

    public class MKShard_NumberDouble : MKShard
    {
        public double number;


        public override string GetDebugPrintString()
        {
            return number.ToString();
        }
    }

    public class MKShard_Bool : MKShard
    {
        public bool value;


        public override string GetDebugPrintString()
        {
            return value.ToString();
        }
    }

    public class MKShard_Vector2 : MKShard
    {
        public Vector2 vector2;


        public override string GetDebugPrintString()
        {
            return vector2.ToString();
        }
    }

    public class MKShard_Vector3 : MKShard
    {
        public Vector3 vector3;


        public override string GetDebugPrintString()
        {
            return vector3.ToString();
        }
    }

    public class MKShard_Rect : MKShard
    {
        public Rect rect;


        public override string GetDebugPrintString()
        {
            return rect.ToString();
        }
    }

    public class MKShard_Color : MKShard
    {
        public Color color;


        public override string GetDebugPrintString()
        {
            return color.ToString();
        }
    }
} // Minikit.Inventory namespace
