﻿namespace WebApi.DTO
{
    public class BeverageDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? ImagePath { get; set; }
    }
}