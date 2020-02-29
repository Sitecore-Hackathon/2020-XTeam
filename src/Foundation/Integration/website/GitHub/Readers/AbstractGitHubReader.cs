﻿using Octokit;
using Sitecore.DataExchange.DataAccess;
using System;

namespace xTeam.Foundation.Integration.GitHub.Readers
{
    public abstract class AbstractGitHubReader : IValueReader
    {
        public virtual ReadResult Read(object source, DataAccessContext context)
        {
            var repoModel = source as RepoModel;
            if (repoModel == null)
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }
            return ReadResult.PositiveResult(repoModel[RepoModel.Name], DateTime.Now);
        }
    }
}