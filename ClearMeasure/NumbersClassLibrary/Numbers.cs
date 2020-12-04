using System;
using System.Collections.Generic;

namespace NumbersClassLibrary
{
    public class Numbers
    {
        // up and running handling memory
        // developer make rules
        // unit test for #15


        public List<string> PrintNumbers(int lower, int upper, Dictionary<int, string> rules)
        {
            if (upper < lower) throw new ArgumentException("Upper less then Lower");
            if (upper >= int.MaxValue) throw new ArgumentException("Upper value is too large");

            var maxUpperLimit = 134217728; // 32 bit process
            if (Environment.Is64BitProcess)
            {
                maxUpperLimit = 0X7FEFFFFF; // 64 bit process
            }

            if(upper - lower > maxUpperLimit) throw new ArgumentException($"Maximum upper limit is: {maxUpperLimit - lower}");


            var resultList = new List<string>(upper-lower);
            for (int i = lower; i <= upper; i++)
            {
                var printed = false;
                var result = "";

                foreach (var rule in rules)
                {
                    if (i % rule.Key == 0)
                    {
                        if (string.IsNullOrWhiteSpace(result))
                            result = rule.Value;
                        else
                            result += rule.Value;
                        printed = true;
                    }
                }

                if (!string.IsNullOrWhiteSpace(result))
                {
                    resultList.Add(result);
                }

                if (!printed)
                {
                    resultList.Add(i.ToString());
                }

            }


            return resultList;
        }
    }
}
