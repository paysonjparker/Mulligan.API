﻿using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices.RepositoryClients;

namespace Mulligan.API.RepositoryServices
{
    public class ScoreRepoService : IScoreRepoService
    {
        private readonly IScoreRepoClient _scoreRepoClient;

        public ScoreRepoService(IScoreRepoClient scoreRepoClient)
        {
            _scoreRepoClient = scoreRepoClient;
        }

        public ScoreResponse AddScore(AddScoreRequest addScoreRequest)
        {
            return ConvertScore(_scoreRepoClient.AddScore(addScoreRequest));
        }

        public IEnumerable<ScoreResponse> GetAllScores()
        {
            return ConvertScores(_scoreRepoClient.GetAllScores());
        }

        public IEnumerable<ScoreResponse> GetAllScoresByUser(int userId)
        {
            return ConvertScores(_scoreRepoClient.GetAllScoresByUser(userId));
        }

        public IEnumerable<ScoreResponse> GetAllScoresByGolfCourse(int golfCourseId)
        {
            return ConvertScores(_scoreRepoClient.GetAllScoresByGolfCourse(golfCourseId));
        }

        public bool DeleteScore(int scoreId)
        {
            return _scoreRepoClient.DeleteScore(scoreId);
        }

        private ScoreResponse ConvertScore(Score scoreDomain)
        {
            if (scoreDomain == null)
            {
                return null;
            }
            ScoreResponse scoreResponse = new ScoreResponse
            {
                Id = scoreDomain.Id,
                Differential = scoreDomain.Differential,
                Total = scoreDomain.Total,
                CreatedDate = scoreDomain.CreatedDate,
                UserId = scoreDomain.UserId,
                GolfCourseId = scoreDomain.GolfCourseId,
            };

            return scoreResponse;
        }

        private List<ScoreResponse> ConvertScores(IEnumerable<Score> scoreDomains)
        {
            if (scoreDomains == null)
            {
                return null;
            }
            var scoreResponses = new List<ScoreResponse>();
            foreach (var scoreDomain in scoreDomains)
            {
                var scoreResponse = ConvertScore(scoreDomain);
                if (scoreResponse != null)
                {
                    scoreResponses.Add(scoreResponse);
                }
            }
            return scoreResponses;
        }
    }
}
