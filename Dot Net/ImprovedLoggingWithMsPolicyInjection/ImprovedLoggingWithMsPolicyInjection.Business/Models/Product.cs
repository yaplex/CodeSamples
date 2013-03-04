// Created at: 2013-03-04 1:49 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-04 1:49 PM
namespace ImprovedLoggingWithMsPolicyInjection.Business.Models
{
    using System;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return string.Format("{{Id={0}, Name={1}, IsAvailable={2}, CreatedAt={3}}}", Id, Name, IsAvailable, CreatedAt);
        }
    }
}