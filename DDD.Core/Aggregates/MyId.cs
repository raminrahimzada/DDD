//using System;
//using EventFlow.Core;
//using EventFlow.ValueObjects;
//using Newtonsoft.Json;

//namespace DDD.Core.Aggregates
//{
    
//    public class Guid:Identity<Guid>
//    {
//        public Guid(string value) : base(value)
//        {
//        }
//        public static implicit operator Guid(Guid value)
//        {
//            return new Guid(value.ToString("N"));
//        }
//        public static implicit operator Guid(string value)
//        {
//            return new Guid(value);

//        }
//    }
//}
