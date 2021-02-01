using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sorting;
using Array = System.Array;

public class RadixSorter : BaseSorter
{
    protected override IEnumerator Sort()
    {
        int nodeCount = nodes.Length;
        int i, j;
        Node[] temp = new Node[nodes.Length];

        for(int shift = 31; shift > -1; --shift)
        {
            // Reset j to zero
            j = 0;

            // Loop through the whole array
            for (i = 0; i < nodeCount; ++i)
            {
                // Determine if the bit shifted variable is above 0
                bool move = (nodes[i].Index << shift) >= 0;
                if (shift == 0 ? !move : move)
                    nodes[i - j] = nodes[i];
                else
                    temp[j++] = nodes[i];
            }

            // Copy the data to the temp array
            Array.Copy(temp, 0, nodes, nodes.Length - j, j);

            // Stupid visualisation
            StartFrame(0, 1);
            yield return null;
            EndFrame(0, 1);

        }
    }
}
