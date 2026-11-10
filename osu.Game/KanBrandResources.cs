// Copyright (c) kan-rhythm contributors. Licensed under the MIT Licence.
// kan! rebrand (ADR-0011): new kan! code; no upstream code adapted in this file.

using System;
using System.IO;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;

namespace osu.Game
{
    /// <summary>
    /// kan!'s own art and sounds (fork F-21): files in the <c>brand</c> folder next
    /// to the executable, named as in osu!'s resources (<c>Textures/Menu/logo.png</c>,
    /// <c>Tracks/circles.osz</c>…), are used instead of osu!'s. A file not there
    /// falls back to osu!'s, so the identity can be replaced one file at a time.
    /// The folder's source is <c>game/brand/</c> in the kan-rhythm repository.
    /// </summary>
    public static class KanBrandResources
    {
        public static IResourceStore<byte[]>? Create()
        {
            string path = Path.Combine(AppContext.BaseDirectory, @"brand");
            return Directory.Exists(path) ? new StorageBackedResourceStore(new NativeStorage(path)) : null;
        }
    }
}
