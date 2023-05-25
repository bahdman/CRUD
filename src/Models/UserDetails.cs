using System;
using System.ComponentModel.DataAnnotations;

namespace src.Models{
    public class UserDetails{
        public Guid Id{get; set;}
        public string Name{get; set;}
        [Range(1,250)]
        public int Age{get; set;}
        public string Email{get; set;}
        public DateTimeOffset DateCreated{get; set;}  
    }

    public class CreateUser{
        public Guid Id{get; set;}
         public string Name{get; set;}
        [Range(1,250)]
        public int Age{get; set;}
        public string Email{get; set;}
        public DateTimeOffset DateCreated{get; set;}  
    }

    public class Updatedetails{
        public string Name{get; set;}
        [Range(1,250)]
        public int Age{get; set;}
        public string Email{get; set;}
        public DateTimeOffset DateUpadated{get; set;}
    }
}