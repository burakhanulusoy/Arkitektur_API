using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Arkitektur.Business.Base
{
    public class BaseResult<T>
    {

        public T? Data { get; set; }
        public IEnumerable<object> Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccessful => Errors == null || !Errors.Any();//any deger varsa demek

        [JsonIgnore]
        public bool IsFailure =>Errors !=null;



        public static BaseResult<T> Success()
        {
            return new BaseResult<T> { Errors=null };
        }

        public static BaseResult<T> Success(T data)
        {
            return new BaseResult<T> { Data = data };
        }

        public static BaseResult<T> Fail(string errorMessage)
        {
            return new BaseResult<T> { Errors = new[] { new { ErrorMessage = errorMessage } } };
        }


        public static BaseResult<T> Fail(List<ValidationFailure> errorMessages)
        {

            IEnumerable<object> errors = (from error in errorMessages
                                          select new
                                          {
                                              PropertyName = error.PropertyName,
                                              ErrorMessage = error.ErrorMessage

                                          }).ToList();



            return new BaseResult<T>
            {
                Errors = errors
            };


        }
           


    }
}
