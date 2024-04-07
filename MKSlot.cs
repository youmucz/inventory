using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minikit.Inventory
{
    /// <summary> Represents a single slot within an inventory, and can hold an item </summary>
    [System.Serializable]
    public class MKSlot
    {
        public static MKSlot Invalid = new MKSlot();

        /// <summary> Tags that define this slot (Slot.Backpack, Slot.Equipment.Helmet, etc) </summary>
        public List<MKTag> slotTags = new();

        /// <summary> The tag query that determines what items are allowed to be placed in this slot </summary>
        public MKTagQuery itemTagQuery = new MKTagQuery(MKTagQueryCondition.All, null);

        /// <summary> The item currently in this slot </summary>
        public MKItem item { get; private set; } = null;


        /// <summary> Whether or not this slot is allowed to hold a given item according to rules defined by the slot. Does not 
        /// consider whether an item held in the slot at the time or not </summary>
        public bool AllowedToHoldItem(MKItem _item)
        {
            if (itemTagQuery != null)
            {
                return itemTagQuery.Test(_item.tags);
            }

            return true;
        }

        public bool CanHoldItem(MKItem _item)
        {
            if (item != null)
            {
                return false;
            }

            if (!AllowedToHoldItem(_item))
            {
                return false;
            }

            return true;
        }

        public void SetItem(MKItem _item)
        {
            item = _item;
        }
    }
} // Minikit.Inventory namespace
