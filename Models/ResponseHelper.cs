using System.ComponentModel.DataAnnotations;

namespace Biblioteca82.Models
{
    public class ResponseHelper
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
