using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minikit.Inventory
{
    /// <summary> Represents a single object that can be held within a bag </summary>
    public class MKItem
    {
        public List<MKTag> tags = new();

        protected List<MKShard> dynamicShards = new();
        protected MKItemDefinitionScriptableObject itemDefinition { get; private set; }


        public MKItem(MKItemDefinitionScriptableObject _itemDefinition, List<MKShard> _additionalDynamicShards = null)
        {
            itemDefinition = _itemDefinition;

            dynamicShards.AddRange(itemDefinition.GetAllDynamicShards());
            if (_additionalDynamicShards != null)
            {
                dynamicShards.AddRange(_additionalDynamicShards);
            }
        }


        public MKShard GetFirstShard(MKTagQuery _tagQuery = null)
        {
            return GetAllShards(_tagQuery, true).FirstOrDefault();
        }

        public T GetFirstShard<T>(MKTagQuery _tagQuery = null) where T : MKShard
        {
            return GetAllShards<T>(_tagQuery, true).FirstOrDefault();
        }

        public List<MKShard> GetAllShards(MKTagQuery _tagQuery = null, bool _returnFirst = false)
        {
            return GetAllShards<MKShard>(_tagQuery);
        }

        public List<T> GetAllShards<T>(MKTagQuery _tagQuery = null, bool _returnFirst = false) where T : MKShard
        {
            List<T> foundShards = new();
            foreach (MKShard dynamicShard in dynamicShards)
            {
                if (dynamicShard.GetType().IsAssignableFrom(typeof(T)))
                {
                    if (_tagQuery?.Test(dynamicShard.tags) ?? true) // If no query is supplied, pass every shard
                    {
                        foundShards.Add(dynamicShard as T);

                        if (_returnFirst)
                        {
                            return foundShards;
                        }
                    }
                }
            }

            // Search for static shards on the item definition directly
            foundShards.AddRange(itemDefinition.GetAllStaticShards<T>(_tagQuery, _returnFirst));

            return foundShards;
        }
    }
} // Minikit.Inventory namespace
