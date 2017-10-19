using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MvvmApp.Model.Services
{
    public class ModelState
    {
        [JsonProperty("")]
        public IList<string> Data
        {
            get; set;
        }
    }

    public class RegistrationResponse
    {
        public string Message { get; set; }
        public ModelState ModelState { get; set; }
    }


}
