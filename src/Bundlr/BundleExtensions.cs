﻿using System.IO;
using System.Web.Optimization;

namespace Bundlr
{
    public static class BundleExtensions
    {
        public static TBundle IncludePath<TBundle>(this TBundle bundle, string root, params string[] files)
            where TBundle : Bundle
        {
            foreach (string file in files)
            {
                string path = Path.Combine(root, file);
                bundle.Include(path);
            }

            return bundle;
        }
    }
}