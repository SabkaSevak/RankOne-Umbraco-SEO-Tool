﻿using RankOne.Interfaces;
using System;

namespace RankOne.Helpers
{
    public class UrlHelper : IUrlHelper
    {

        public string GetFullPath(string path, Uri url)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            if (url == null) throw new ArgumentNullException(nameof(url));

            if (IsLocalLink(path))
            {
                var portSegment = "";
                if (url.Port > 0 && url.Port != 80)
                {
                    portSegment = $":{url.Port}";
                }

                path = $"{url.Scheme}://{url.Host}{portSegment}{path}";
            }

            return path;
        }

        public bool IsLocalLink(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            return path.StartsWith("/") || path.StartsWith("./");
        }
    }
}