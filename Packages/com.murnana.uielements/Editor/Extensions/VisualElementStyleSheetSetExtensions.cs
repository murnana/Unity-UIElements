// Copyright (c) 2021 murnana.
// 
// This software is released under the MIT License.
// http://opensource.org/licenses/mit-license.php

namespace Murnana.UIElements.Editor
{
    /// <summary>
    /// Extension methods of <see cref="UnityEngine.UIElements.VisualElementStyleSheetSet" />
    /// </summary>
    public static class VisualElementStyleSheetSetExtensions
    {
        /// <summary>
        /// Get <see cref="UnityEngine.UIElements.StyleSheet" /> IEnumerable
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static System.Collections.Generic.IEnumerable<
            UnityEngine.UIElements.StyleSheet> GetEnumerable(
            this UnityEngine.UIElements.VisualElementStyleSheetSet self
        )
        {
            var count = self.count;
            for (var i = 0; i < count; i++)
            {
                yield return self[i];
            }
        }
    }
}
