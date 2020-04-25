using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Helpers
{
    public class TwoDimensionalListsComparator
    {
        public static bool Compare(List<List<int>> list1, List<List<int>> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Count != list2[i].Count)
                {
                    return false;
                }

                for (int j = 0; j < list2.Count; j++)
                {
                    if (list1[i][j] != list2[i][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
