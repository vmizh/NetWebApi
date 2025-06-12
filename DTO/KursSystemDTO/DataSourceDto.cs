using System.ComponentModel.DataAnnotations;

namespace DTO.KursSystemDTO
{
    public record DataSourceDto
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required string ShowName { get; set; }

        public int? Order { get; set; }

        public required string Server { get; set; }

        public required string DBName { get; set; }

        public string? Color { get; set; }

        public bool? IsVisible { get; set; }

        public int? RedisDBId { get; set; }
    }
}
