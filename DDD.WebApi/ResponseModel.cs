//using System;
//using DDD.Domain.Exceptions;

//namespace DDD.WebApi
//{
//    public class ResponseModel
//    {
//        public bool Succeed { get; set; }
//        public string ErrorCode { get; set; }
//        public string ErrorMessage { get; set; }

//        public static ResponseModel Success()
//        {
//            return new ResponseModel
//            {
//                Succeed = true
//            };
//        }
//        public static ResponseModel Failure(Exception exception)
//        {
//            ResponseModel model=new ResponseModel();
//            model.Succeed = false;
//            model.ErrorMessage = exception.Message;
//            if (exception is DomainException domainException)
//            {
//                model.ErrorCode = domainException.ErrorCode;
//            }

//            return model;
//        }
//    }

//    public class ResponseModel<TResponse> : ResponseModel
//    {
//        public TResponse Response { get; set; }

//        public static ResponseModel<TResponse> Success(TResponse data)
//        {
//            return new ResponseModel<TResponse>
//            {
//                Succeed = true,
//                Response = data
//            };
//        }
//        public new static ResponseModel<TResponse> Failure(Exception exception)
//        {
//            var model = new ResponseModel<TResponse> {Succeed = false, ErrorMessage = exception.Message};
            
//            if (exception is DomainException domainException)
//            {
//                model.ErrorCode = domainException.ErrorCode;
//            }

//            return model;
//        }
//    }
//}