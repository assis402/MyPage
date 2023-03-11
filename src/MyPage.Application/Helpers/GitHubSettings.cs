﻿using Flurl.Http;

namespace MyPage.Application.Helpers;

public class GitHubSettings
{
    internal IFlurlRequest _requestClient;

    public string LoginUrl { get; set; }
    public string ReposUrl { get; set; }
    public string Token { get; set; }
    public string CustomPropertiesPath { get; set; }
    public string RawBaseUrl { get; set; }
    public string TopicName { get; set; }
}
