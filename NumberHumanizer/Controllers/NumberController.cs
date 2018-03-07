using System;
using System.Web.Http;
using NumberHumanizer.BusinessLogic;
using NumberHumanizer.Models;

namespace NumberHumanizer.Controllers
{
    public class NumberController : ApiController
    {
        private readonly INumberHumanizer _humanizer;

        public NumberController()
        {
            _humanizer = new DecimalNumberHumanizer();
        }

        public ApiResult<NumberTransformResponse> Transform(NumberTransformRequest request)
        {
            try
            {
                return new ApiResult<NumberTransformResponse>()
                {
                    IsSuccess = true,
                    Result = new NumberTransformResponse()
                    {
                        Text = _humanizer.Transform(request.Number),
                        Number = request.Number,
                        Name = request.Name
                    }
                };
            }
            catch (Exception e)
            {
                return new ApiResult<NumberTransformResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = e.Message,
                    Result = null
                };
            }
        }
    }
}