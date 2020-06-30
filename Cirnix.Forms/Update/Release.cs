﻿using System;
using System.Collections.Generic;

namespace Cirnix.Forms.Update
{
    public sealed class Release
    {
        public string url { get; set; }
        public string html_url { get; set; }
        public string assets_url { get; set; }
        public string upload_url { get; set; }
        public string tarball_url { get; set; }
        public string zipball_url { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
        public string name { get; set; }
        public string body { get; set; }
        public bool draft { get; set; }
        public bool prerelease { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public Author author { get; set; }
        public sealed class Author
        {
            public string login { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string avatar_url { get; set; }
            public string gravatar_id { get; set; }
            public string url { get; set; }
            public string html_url { get; set; }
            public string followers_url { get; set; }
            public string following_url { get; set; }
            public string gists_url { get; set; }
            public string starred_url { get; set; }
            public string subscriptions_url { get; set; }
            public string organizations_url { get; set; }
            public string repos_url { get; set; }
            public string events_url { get; set; }
            public string received_events_url { get; set; }
            public string type { get; set; }
            public bool site_admin { get; set; }
        }
        public List<Asset> assets { get; set; }
        public sealed class Asset
        {
            public string url { get; set; }
            public string browser_download_url { get; set; }
            public int id { get; set; }
            public string node_id { get; set; }
            public string name { get; set; }
            public string label { get; set; }
            public string state { get; set; }
            public string content_type { get; set; }
            public int size { get; set; }
            public int download_count { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
            public Uploader uploader { get; set; }
            public sealed class Uploader
            {
                public string login { get; set; }
                public int id { get; set; }
                public string node_id { get; set; }
                public string avatar_url { get; set; }
                public string gravatar_id { get; set; }
                public string url { get; set; }
                public string html_url { get; set; }
                public string followers_url { get; set; }
                public string following_url { get; set; }
                public string gists_url { get; set; }
                public string starred_url { get; set; }
                public string subscriptions_url { get; set; }
                public string organizations_url { get; set; }
                public string repos_url { get; set; }
                public string events_url { get; set; }
                public string received_events_url { get; set; }
                public string type { get; set; }
                public bool site_admin { get; set; }
            }
        }
    }

}
