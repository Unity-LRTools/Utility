using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LRT.Utility
{
	[Serializable]
	public class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField] private List<KeyValue> items = new List<KeyValue>();

		// Unity serialization callback before serialization
		public void OnBeforeSerialize()
		{
			items.Clear();

			foreach (KeyValuePair<TKey, TValue> kvp in this)
			{
				KeyValue kv = new KeyValue()
				{
					key = kvp.Key,
					value = kvp.Value,
				};

				items.Add(kv);
			}
		}

		// Unity serialization callback after deserialization
		public void OnAfterDeserialize()
		{
			this.Clear();

			for (int i = 0; i < items.Count; i++)
			{
				if (!ContainsKey(items[i].key))
					Add(items[i].key, items[i].value);
			}
		}

		[Serializable]
		public class KeyValue
		{
			public TKey key;
			public TValue value;
		}
	}
}
