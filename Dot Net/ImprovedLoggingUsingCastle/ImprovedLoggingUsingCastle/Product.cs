// Created at: 2013-03-06 4:36 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-06 4:36 PM
namespace ImprovedLoggingUsingCastle
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return string.Format("{{Id = {0}, Name = {1}, IsAvailable = {2}}}", Id, Name, IsAvailable);
        }
    }
}