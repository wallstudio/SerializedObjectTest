using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;
using System.Linq;

public class SerializedObjectTraversaer
{
    [MenuItem("Assets/" + nameof(SerializedObjectTraversaer) + "/" + nameof(SerializedObjectTraversaer.Dump))]
    public static void Dump()
    {
        var log = new StringBuilder();

        var target = Selection.activeObject;
        var serialized = new SerializedObject(target);
        var iterator = serialized.GetIterator();
        while(iterator.Next(true))
        {
            log.AppendLine($"{iterator.name}:");
            var props = iterator.GetType().GetProperties();
            foreach (var prop in props)
            {
                var value = prop.GetValue(iterator);
                log.AppendLine($"  {prop.Name:30}: {value}");
            }
        }

        GUIUtility.systemCopyBuffer = log.ToString();
        Debug.Log(log);
    }
}
