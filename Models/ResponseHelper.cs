using System.ComponentModel.DataAnnotations;

namespace Biblioteca82.Models
{
    public class ResponseHelper
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
