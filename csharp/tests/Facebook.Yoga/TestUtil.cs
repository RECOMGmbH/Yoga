/**
 * Copyright (c) Facebook, Inc. and its affiliates.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */

using System.Runtime.InteropServices;

namespace Facebook.Yoga
{
    internal static class TestUtil
    {
#if (UNITY_IOS && !UNITY_EDITOR) || __IOS__
        private const string DllName = "__Internal";
#else
        private const string DllName = "yoga";
#endif

        [DllImport(DllName, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void YGTestStartCountingNodes();

        [DllImport(DllName, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern int YGTestGetNodeCount();

        [DllImport(DllName, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern void YGTestStopCountingNodes();

    }
}
