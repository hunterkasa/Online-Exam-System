using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demoFinal_3.Controllers
{
    [RoutePrefix("api/analytics")]
    public class AnalyticalResultController : ApiController
    {
        private readonly StudentExamResultService _resultService;

        public AnalyticalResultController()
        {
            _resultService = new StudentExamResultService();
        }
        
        [HttpGet]
        [Route("student/{studentId:int}/average")]
        public HttpResponseMessage GetStudentAverageScore(int studentId)
        {
            var results = _resultService.GetResultsByStudentId(studentId);
            if (!results.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound, "No results found for this student.");

            var avg = results.Average(r => r.Score);
            return Request.CreateResponse(HttpStatusCode.OK, new { StudentId = studentId, AverageScore = avg });
        }

        [HttpGet]
        [Route("student/{studentId:int}/range")]
        public HttpResponseMessage GetStudentScoreRange(int studentId)
        {
            var results = _resultService.GetResultsByStudentId(studentId);
            if (!results.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound, "No results found for this student.");

            var highest = results.Max(r => r.Score);
            var lowest = results.Min(r => r.Score);
            return Request.CreateResponse(HttpStatusCode.OK, new { StudentId = studentId, Highest = highest, Lowest = lowest });
        }

        [HttpGet]
        [Route("student/{studentId:int}/trend")]
        public HttpResponseMessage GetStudentScoreTrend(int studentId)
        {
            var results = _resultService.GetResultsByStudentId(studentId)
                .OrderByDescending(r => r.ExamTakenTime)
                .Take(5)
                .OrderBy(r => r.ExamTakenTime)
                .ToList();

            if (!results.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound, "No results found for this student.");

            var trend = results.Select(r => new { r.ExamTakenTime, r.Score }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, new { StudentId = studentId, Trend = trend });
        }

        [HttpGet]
        [Route("student/{studentId:int}/distribution")]
        public HttpResponseMessage GetStudentScoreDistribution(int studentId)
        {
            var results = _resultService.GetResultsByStudentId(studentId).Select(r => r.Score).ToList();
            if (!results.Any())
                return Request.CreateResponse(HttpStatusCode.NotFound, "No results found for this student.");

            var distribution = new Dictionary<string, int>
            {
                { "0-59", results.Count(s => s < 60) },
                { "60-69", results.Count(s => s >= 60 && s < 70) },
                { "70-79", results.Count(s => s >= 70 && s < 80) },
                { "80-89", results.Count(s => s >= 80 && s < 90) },
                { "90-100", results.Count(s => s >= 90 && s <= 100) }
            };
            return Request.CreateResponse(HttpStatusCode.OK, new { StudentId = studentId, Distribution = distribution });
        }

        [HttpGet]
        [Route("student/{studentId:int}/predict")]
        public HttpResponseMessage PredictNextScore(int studentId)
        {
            var results = _resultService.GetResultsByStudentId(studentId)
                .OrderByDescending(r => r.ExamTakenTime)
                .Take(5)
                .OrderBy(r => r.ExamTakenTime)
                .ToList();

            if (results.Count < 2)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not enough data to predict future score.");

            // Simple linear regression (least squares) for prediction
            var scores = results.Select(r => (double)r.Score).ToArray();
            var xs = Enumerable.Range(1, scores.Length).ToArray();
            double avgX = xs.Average();
            double avgY = scores.Average();
            double numerator = xs.Zip(scores, (x, y) => (x - avgX) * (y - avgY)).Sum();
            double denominator = xs.Sum(x => Math.Pow(x - avgX, 2));
            double slope = denominator == 0 ? 0 : numerator / denominator;
            double intercept = avgY - slope * avgX;
            double nextX = xs.Length + 1;
            double predicted = intercept + slope * nextX;

            // Clamp prediction to [0, 100]
            predicted = Math.Max(0, Math.Min(100, predicted));

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                StudentId = studentId,
                PredictedNextScore = Math.Round(predicted, 2),
                BasedOnLastScores = scores
            });
        }
    }
}
